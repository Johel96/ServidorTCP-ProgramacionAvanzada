using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
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
    public class ClienteAD
    {
        private string CadenaConexion = string.Empty; // Cadena de conexión a la base de datos, si se requiere

        public ClienteAD() // Constructor de la clase ClienteAD
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString; // Obtiene la cadena de conexión desde el archivo de configuración
        } // fin constructor    

        #region Metodos
        /// <summary>
        /// Metodo que almacena un cliente el una lista de clientes
        /// </summary>
        /// <param name="pCliente">Recibe los datos del cliente</param>
        /// <returns>true/false</returns>        
        public bool GuardarCliente(Cliente pCliente)
        {
            bool clienteGuardado = false; // Variable para indicar si el cliente fue guardado correctamente

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                string sentencia = "INSERT INTO Cliente (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo)" +
                    "VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Activo)"; // Sentencia SQL para insertar un nuevo cliente
                using (SqlCommand comando = new SqlCommand(sentencia, conexion)) // Crea un comando SQL con la sentencia y la conexión
                {
                    comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                    comando.Parameters.AddWithValue("@Identificacion", pCliente.Identificacion); // Agrega el parámetro Id al comando
                    comando.Parameters.AddWithValue("@Nombre", pCliente.Nombre); // Agrega el parámetro Nombre al comando
                    comando.Parameters.AddWithValue("@PrimerApellido", pCliente.PrimerApellido); // Agrega el parámetro Apellido al comando
                    comando.Parameters.AddWithValue("@SegundoApellido", pCliente.SegundoApellido); // Agrega el parámetro SegundoApellido al comando
                    comando.Parameters.AddWithValue("@FechaNacimiento", pCliente.FechaNacimiento); // Agrega el parámetro FechaNacimiento al comando
                    comando.Parameters.AddWithValue("@Activo", SqlDbType.Bit) // Agrega el parámetro Estado al comando
                        .Value = pCliente.Estado; // Asigna el valor del estado al parámetro
                    conexion.Open(); // Abre la conexión a la base de datos
                    int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta el comando y obtiene el número de filas afectadas
                    clienteGuardado = filasAfectadas > 0; // Si se afectaron filas, se considera que el cliente fue guardado correctamente
                } // fin using SqlCommand
            } // fin using SqlConnection
            return clienteGuardado;
        } // fin GuardarCliente

        /// <summary>
        /// Metodo que permite consultar un cliente
        /// </summary>
        /// <returns>Retorna un arreglo de clientes</returns>        
        public List<Cliente> ConsultarClientes()
        {
            List<Cliente> listaCliente = new List<Cliente>(); // Lista para almacenar los clientes consultados
            SqlConnection conexion; // Crea una conexión a la base de datos
            SqlCommand comando = new SqlCommand(); // Crea un comando SQL
            SqlDataReader reader; // Crea un adaptador de datos para ejecutar el comando

            using (conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString)) // Abre la conexión a la base de datos
            {
                comando.Connection = conexion; // Asigna la conexión al comando
                comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                comando.CommandText = "SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo FROM Cliente"; // Sentencia SQL para consultar los clientes
                conexion.Open(); // Abre la conexión a la base de datos
                reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos
                while (reader.Read()) // Recorre los resultados obtenidos
                {   
                    bool estado = reader.GetBoolean(5); // Obtiene el estado del cliente (Activo/Inactivo)

                    Cliente cliente = new Cliente() // Crea un nuevo objeto Cliente
                    {
                        Identificacion = Convert.ToInt32(reader[0]), // Obtiene el Id del cliente
                        Nombre = reader.GetString(1), // Obtiene el Nombre del cliente
                        PrimerApellido = reader.GetString(2), // Obtiene el PrimerApellido del cliente
                        SegundoApellido = reader.GetString(3), // Obtiene el SegundoApellido del cliente
                        FechaNacimiento = reader.GetDateTime(4), // Obtiene la FechaNacimiento del cliente
                        Estado = estado // Obtiene el Estado del cliente
                    };
                    listaCliente.Add(cliente); // Agrega el cliente a la lista de clientes
                } // fin while
            } // fin using SqlConnection
            return listaCliente;
        } // fin ConsultarClientes    

        #endregion
    }
}
