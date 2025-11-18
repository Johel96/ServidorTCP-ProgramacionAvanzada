using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

#region Descripción
/**
 * UNED 2do Cuatrimestre 2025
 * Proyecto 1: Programa de Entregas
 * Estudiante: Johel Smaiker Granados Elizondo
 * Fecha: 15/06/2025
 * Referencias:
 * 00830 I Sesión Virtual Programación Avanzada- II Cuatrimestre 2025- Tutor Johan Acosta I https://www.youtube.com/watch?v=2IWiBqwDgKM&t=5835s
 * 00830 PROGRAMACION AVANZADA- SEGUNDA Sesión Virtual- II CUATRIMESTRE-TUTOR JOHAN ACOSTA IBAÑEZ https://www.youtube.com/watch?v=pk7YVwlEInM
 * (Deitel, 2007) Deitel, H. M.  (2007). Cómo programar en C#,  2nd Edition. [[VitalSource Bookshelf version]].  Retrieved from vbk://9789702610564
 */
#endregion

namespace AccesoDatos
{
    public class PedidoAD
    {
        #region Constructor
        private string CadenaConexion = string.Empty; // Cadena de conexión a la base de datos, si se requiere

        public PedidoAD()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString; // Obtiene la cadena de conexión desde el archivo de configuración
        } // fin constructor
        #endregion


        #region Metodos
        /// <summary>
        /// Registra un nuevo pedido en la base de datos.
        /// </summary>
        /// <param name="pPedido">Objeto Pedido que contiene los datos del pedido a registrar.</param>
        /// <returns>true/false</returns>
        public bool GuardarPedido(Pedido pPedido)
        {
            bool pedidoGuardado = false; // Variable para indicar si el pedido fue guardado correctamente
            
            using (SqlConnection conexion = new SqlConnection(CadenaConexion)) // Inicia una conexión a la base de datos
            {
                string sentencia = "INSERT INTO Pedido (FechaPedido, IdCliente, IdRepartidor, Direccion) " +
                    "VALUES (@FechaPedido, @IdCliente, @IdRepartidor, @Direccion); " + // Sentencia SQL para insertar un nuevo pedido
                    "SELECT SCOPE_IDENTITY();"; // Obtiene el ID del pedido recién insertado

                using (SqlCommand comando = new SqlCommand(sentencia, conexion)) // Crea un comando SQL con la sentencia y la conexión
                {
                    comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                    // Agrega los parámetros al comando                    
                    comando.Parameters.AddWithValue("@FechaPedido", pPedido.FechaPedido);
                    comando.Parameters.AddWithValue("@IdCliente", pPedido.Cliente.Identificacion); // Convierte el cliente a su ID y lo agrega como parámetro
                    comando.Parameters.AddWithValue("@IdRepartidor", pPedido.Repartidor.Identificacion); // Convierte el repartidor a su ID y lo agrega como parámetro
                    comando.Parameters.AddWithValue("@Direccion", pPedido.Direccion);
                    conexion.Open(); // Abre la conexión a la base de datos

                    object idPedido = comando.ExecuteScalar(); // Ejecuta el comando y obtiene el ID del pedido recién insertado

                    if (idPedido != null && int.TryParse(idPedido.ToString(), out int numeroPedido)) // Verifica si se obtuvo un ID válido y lo convierte a entero
                    {
                        pPedido.NumeroPedido = numeroPedido; // Asigna el ID del pedido al objeto Pedido
                        pedidoGuardado = true; // Indica que el pedido fue guardado correctamente
                    } // fin if
                    

                } // fin using SqlCommand
                return pedidoGuardado; // Retorna el resultado de si el pedido fue guardado o no
            } // fin using SqlConnection
        } // fin GuardarPedido         

        /// <summary>
        /// Consulta todos los pedidos registrados en el sistema.
        ///</summary>
        ///<returns>Un arreglo de pedidos</returns>
        public List<Pedido> ConsultarPedidos()
        {
            ClienteAD clienteAD = new ClienteAD(); // Crea una instancia de la clase ClienteAD para acceder a los métodos de acceso a datos
            List<Cliente> listaClientes = clienteAD.ConsultarClientes(); // Llama al método de acceso a datos para obtener la lista de clientes
            RepartidorAD repartidorAD = new RepartidorAD(); // Crea una instancia de la clase RepartidorAD para acceder a los métodos de acceso a datos
            List<Repartidor> listaRepartidores = repartidorAD.ConsultarRepartidores(); // Llama al método de acceso a datos para obtener la lista de repartidores

            List<Pedido> pedidos = new List<Pedido>(); // Lista para almacenar los pedidos consultados
            SqlConnection conexion = new SqlConnection(CadenaConexion); // Crea una conexión a la base de datos
            SqlCommand comando = new SqlCommand(); // Crea un comando SQL para consultar todos los pedidos
            SqlDataReader reader; // Crea un lector para leer los datos de la consulta

            using (conexion = new SqlConnection(CadenaConexion))
            {
                string sentencia = "SELECT Id, FechaPedido, IdCliente, IdRepartidor, Direccion FROM Pedido"; // Sentencia SQL para seleccionar todos los pedidos
                comando = new SqlCommand(sentencia, conexion); // Asigna la sentencia al comando
                comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                conexion.Open(); // Abre la conexión a la base de datos
                reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector para leer los datos
                while (reader.Read()) // Mientras haya registros que leer
                {
                    int idCliente = Convert.ToInt32(reader.GetDecimal(2)); // Obtiene el ID del cliente del lector
                    int idRepartidor = Convert.ToInt32(reader.GetDecimal(3)); // Obtiene el ID del repartidor del lector

                    Cliente cliente = listaClientes.FirstOrDefault(c => c.Identificacion == idCliente); // Busca el cliente correspondiente al ID obtenido
                    Repartidor repartidor = listaRepartidores.FirstOrDefault(r => r.Identificacion == idRepartidor); // Busca el repartidor correspondiente al ID obtenido


                    Pedido pedido = new Pedido() // Crea un nuevo objeto Pedido
                    {
                        NumeroPedido = Convert.ToInt32(reader.GetDecimal(0)), // Obtiene el número de pedido del lector
                        FechaPedido = reader.GetDateTime(1), // Obtiene la fecha del pedido del lector
                        Cliente = cliente, // Crea un nuevo cliente con su identificación
                        Repartidor = repartidor, // Crea un nuevo repartidor con su identificación
                        Direccion = reader.GetString(4) // Obtiene la dirección del pedido del lector
                    };
                    pedidos.Add(pedido); // Agrega el pedido a la lista de pedidos
                } // fin while
            }
            return pedidos; // Retorna la lista de pedidos consultados
        } // fin ConsultarPedidos
        #endregion

        #region Metodos de consulta por cliente
        public List<Pedido> ConsultarPedidosPorCliente(int idCliente)
        {
            ClienteAD clienteAD = new ClienteAD(); // Instancia para acceder a datos de clientes
            List<Cliente> listaClientes = clienteAD.ConsultarClientes(); // Carga todos los clientes

            RepartidorAD repartidorAD = new RepartidorAD(); // Instancia para acceder a datos de repartidores
            List<Repartidor> listaRepartidores = repartidorAD.ConsultarRepartidores(); // Carga todos los repartidores

            List<Pedido> pedidosPorCliente = new List<Pedido>(); // Lista para almacenar los pedidos del cliente especificado

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                string sentencia = "SELECT Id, FechaPedido, IdCliente, IdRepartidor, Direccion FROM Pedido WHERE IdCliente = @IdCliente";

                using (SqlCommand comando = new SqlCommand(sentencia, conexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        int idRepartidor = Convert.ToInt32(reader.GetDecimal(3));

                        Cliente cliente = listaClientes.FirstOrDefault(c => c.Identificacion == idCliente);
                        Repartidor repartidor = listaRepartidores.FirstOrDefault(r => r.Identificacion == idRepartidor);

                        Pedido pedido = new Pedido
                        {
                            NumeroPedido = Convert.ToInt32(reader.GetDecimal(0)),
                            FechaPedido = reader.GetDateTime(1),
                            Cliente = cliente,
                            Repartidor = repartidor,
                            Direccion = reader.GetString(4)
                        };

                        pedidosPorCliente.Add(pedido);
                    }
                }
            }

            return pedidosPorCliente;
        }                
        #endregion
    } // fin ConsultarPedidos        

}

