using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
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
    public class DetallePedidoAD
    {
        #region Constructor
        private string CadenaConexion = string.Empty; // Cadena de conexión a la base de datos, si se requiere

        public DetallePedidoAD()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString; // Obtiene la cadena de conexión desde el archivo de configuración
        } // fin constructor
        #endregion

        #region Metodos
        /// <summary>
        /// Registra un nuevo detalle de pedido en el sistema.
        ///</summary>
        /// <param name="pPedido">Objeto DetallePedido que contiene los datos del detalle a registrar.</param>
        /// <returns>true/false</returns>               
        public bool GuardarDetallePedido(DetallePedido pPedido)
        {
            bool detalleGuardado = false;

            string insertSql = @"
                INSERT INTO DetallePedido (Idpedido, Idarticulo, Cantidad, Monto)
                VALUES (@Idpedido, @Idarticulo, @Cantidad, @Monto);
            ";

            string updateStockSql = @"
                UPDATE Articulo
                SET Inventario    = Inventario - @Cantidad,
                    Activo        = CASE WHEN Inventario - @Cantidad <= 0 THEN 0 ELSE Activo END
                WHERE Id = @Idarticulo;
            ";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();

                // Iniciar transacción para garantizar atomicidad
                using (SqlTransaction trx = conexion.BeginTransaction())
                {
                    try
                    {
                        //Insertar el detalle de pedido
                        using (SqlCommand cmdInsert = new SqlCommand(insertSql, conexion, trx))
                        {
                            cmdInsert.Parameters.Add("@Idpedido", SqlDbType.Int).Value = pPedido.NumeroPedido;
                            cmdInsert.Parameters.Add("@Idarticulo", SqlDbType.Int).Value = pPedido.Articulo.ID;
                            cmdInsert.Parameters.Add("@Cantidad", SqlDbType.Int).Value = pPedido.Cantidad;
                            cmdInsert.Parameters.Add("@Monto", SqlDbType.Decimal).Value = pPedido.Monto;

                            int filasInsert = cmdInsert.ExecuteNonQuery();
                            if (filasInsert <= 0)
                                throw new Exception("No se insertó el detalle de pedido.");
                        }

                        //Actualizar inventario
                        using (SqlCommand cmdUpdate = new SqlCommand(updateStockSql, conexion, trx))
                        {
                            cmdUpdate.Parameters.Add("@Cantidad", SqlDbType.Int).Value = pPedido.Cantidad;
                            cmdUpdate.Parameters.Add("@Idarticulo", SqlDbType.Int).Value = pPedido.Articulo.ID;

                            int filasUpdate = cmdUpdate.ExecuteNonQuery();
                            if (filasUpdate <= 0)
                                throw new Exception("No se actualizó el inventario del artículo.");
                        }

                        //Si todo fue bien, confirmar transacción
                        trx.Commit();
                        detalleGuardado = true;
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, revertir cambios
                        try
                        {
                            trx.Rollback();
                        }
                        catch {  }

                        
                        detalleGuardado = false;
                    }
                } // fin transacción
            } // fin conexión

            return detalleGuardado;
        }

        /// <summary>
        /// Guarda el detalle del pedido y actualiza las existencias del artículo.
        /// </summary>
        /// <param name="detalle">Detalle del pedido a guardar</param>
        /// <returns>true si se guarda correctamente y se actualiza el inventario</returns>
        public bool GuardarDetallePedidoPorCliente(DetallePedido detalle)
        {
            bool guardado = false;

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction(); // Inicia una transacción

                try
                {
                    // 1. Insertar en DetallePedido
                    string sentenciaInsertar = "INSERT INTO DetallePedido (Idpedido, Idarticulo, Cantidad, Monto) " +
                                               "VALUES (@Idpedido, @Idarticulo, @Cantidad, @Monto);";

                    using (SqlCommand cmdInsertar = new SqlCommand(sentenciaInsertar, conexion, transaccion))
                    {
                        cmdInsertar.CommandType = CommandType.Text;
                        cmdInsertar.Parameters.AddWithValue("@Idpedido", detalle.NumeroPedido);
                        cmdInsertar.Parameters.AddWithValue("@Idarticulo", detalle.Articulo.ID);
                        cmdInsertar.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        cmdInsertar.Parameters.AddWithValue("@Monto", detalle.Monto);
                        cmdInsertar.ExecuteNonQuery();
                    }

                    // 2. Actualizar existencias del artículo
                    string sentenciaActualizar = "UPDATE Articulo SET Existencias = Existencias - @Cantidad " +
                                                 "WHERE ID = @Idarticulo AND Existencias >= @Cantidad;";

                    using (SqlCommand cmdActualizar = new SqlCommand(sentenciaActualizar, conexion, transaccion))
                    {
                        cmdActualizar.CommandType = CommandType.Text;
                        cmdActualizar.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        cmdActualizar.Parameters.AddWithValue("@Idarticulo", detalle.Articulo.ID);

                        int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            // Si no se actualizó nada, puede que no haya suficientes existencias
                            throw new Exception("No hay existencias suficientes del artículo.");
                        }
                    }

                    transaccion.Commit(); // Si todo fue bien, confirmar transacción
                    guardado = true;
                }
                catch
                {
                    transaccion.Rollback(); // En caso de error, revertir cambios
                    throw; // Lanza la excepción para que la maneje el servidor
                }
            }

            return guardado;
        }


        /// <summary>
        /// Consulta todos los detalles de pedidos registrados en el sistema.
        /// </summary>
        /// <returns>Un arreglo de detalles de pedido</returns>
        public List<DetallePedido> ConsultarDetallesPedidos()
        {
            PedidoAD pedidoAD = new PedidoAD(); // Crea una instancia de PedidoAD para acceder a los pedidos
            List<Pedido> pedidos = pedidoAD.ConsultarPedidos(); // Obtiene la lista de pedidos desde PedidoAD
            ArticuloAD articuloAD = new ArticuloAD(); // Crea una instancia de ArticuloAD para acceder a los artículos
            List<Articulo> articulos = articuloAD.ConsultarArticulos(); // Obtiene la lista de artículos desde ArticuloAD

            List<DetallePedido> listaDetallePedido = new List<DetallePedido>(); // Crea una lista para almacenar los detalles de pedidos
            SqlConnection conexion = new SqlConnection(CadenaConexion); // Crea una conexión a la base de datos
            SqlCommand comando = new SqlCommand(); // Crea un comando SQL para seleccionar todos los detalles de pedidos
            SqlDataReader reader; // Crea un lector para leer los datos de la consulta

            using (conexion = new SqlConnection(CadenaConexion))
            {
                string sentencia = "SELECT Idpedido, Idarticulo, Cantidad, Monto FROM DetallePedido"; // Sentencia SQL para consultar los detalles de pedidos
                comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                comando.CommandText = sentencia; // Asigna la sentencia al comando
                comando.Connection = conexion; // Asocia el comando con la conexión
                comando.Connection.Open(); // Abre la conexión a la base de datos
                reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos
                while (reader.Read()) // Recorre los resultados de la consulta
                {
                    int numeroPedido = Convert.ToInt32(reader.GetDecimal(0)); // Obtiene el número de pedido del lector
                    int idArticulo = Convert.ToInt32(reader.GetDecimal(1)); // Obtiene el ID del artículo del lector
                    int Cantidad = Convert.ToInt32(reader.GetDecimal(2)); // Obtiene la cantidad del detalle de pedido
                    double monto = Convert.ToDouble(reader.GetDecimal(3)); // Obtiene el monto del detalle de pedido


                    Pedido pedido = pedidos.FirstOrDefault(p => p.NumeroPedido == numeroPedido); // Busca el pedido correspondiente al número de pedido obtenido
                    Articulo articulo = articulos.FirstOrDefault(a => a.ID == idArticulo); // Busca el artículo correspondiente al ID obtenido

                    DetallePedido detallePedido = new DetallePedido() // Crea un nuevo objeto DetallePedido
                    {
                        NumeroPedido = numeroPedido, // Asigna el número de pedido                        
                        Articulo = articulo, // Asigna el artículo
                        Cantidad = Cantidad, // Asigna la cantidad del detalle de pedido
                        Monto = monto, // Asigna el monto del detalle de pedido
                    };
                    listaDetallePedido.Add(detallePedido); // Agrega el detalle de pedido a la lista
                }
            } // fin using SqlConnection
            return listaDetallePedido; // Retorna un arreglo de detalles de pedidos
            #endregion
        } // fin ConsultarDetallesPedidos        



    }
}
