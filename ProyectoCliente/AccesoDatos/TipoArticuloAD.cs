 using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Entidades;

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
    public class TipoArticuloAD
    {
        private string CadenaConexion = string.Empty; // Cadena de conexión a la base de datos, si se requiere
        
        public TipoArticuloAD()// Constructor de la clase TipoArticuloAD
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString; // Obtiene la cadena de conexión desde el archivo de configuración
        }// fin constructor

        #region Metodos
        /// <summary>
        /// Metodo que almacena un tipo de articulo en la base de datos
        /// </summary>
        /// <param name="tArticulo">Recibe los datos del tipo de articulo</param>
        /// <returns>true/false</returns>      
        public bool GuardarTipoArticulo(TipoArticulo tArticulo)
        {
            bool articuloGuardado = false; // Variable para indicar si el artículo fue guardado correctamente

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                string sentencia = "INSERT INTO TipoArticulo (Id, Nombre, Descripcion)" +
                    "VALUES (@Id, @Nombre, @Descripcion)"; // Sentencia SQL para insertar un nuevo tipo de artículo
               

                using (SqlCommand comando = new SqlCommand(sentencia, conexion)) // Crea un comando SQL con la sentencia y la conexión
                {
                    comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto

                    comando.Parameters.AddWithValue("@Id", tArticulo.Id); // Agrega el parámetro Id al comando
                    comando.Parameters.AddWithValue("@Nombre", tArticulo.Nombre); // Agrega el parámetro Nombre al comando
                    comando.Parameters.AddWithValue("@Descripcion", tArticulo.Descripcion); // Agrega el parámetro Descripción al comando

                    conexion.Open(); // Abre la conexión a la base de datos
                    int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta el comando y obtiene el número de filas afectadas
                    articuloGuardado = filasAfectadas > 0; // Si se afectaron filas, se considera que el artículo fue guardado correctamente
                    
                } // fin using SqlCommand
            }
            return articuloGuardado; // Retorna true si el artículo fue guardado correctamente, false en caso contrario
        } // fin GuardarTipoArticulo

        /// <summary>
        /// Metodo que permite consultar los tipos de articulo
        /// </summary>
        /// <returns>Un arreglo de tipo de articulos</returns>
        public List<TipoArticulo> ConsultarTiposArticulo()
        {
            List<TipoArticulo> listaTipoArticulo = new List<TipoArticulo>();            
            SqlConnection conexion; // Crea una conexión a la base de datos
            SqlCommand comando = new SqlCommand(); // Crea un comando SQL
            SqlDataReader reader; // Crea un adaptador de datos para ejecutar el comando

            using (conexion = new SqlConnection(CadenaConexion)) // Inicia una conexión a la base de datos
            {
                string sentencia = "SELECT Id, Nombre, Descripcion FROM TipoArticulo"; // Define la sentencia SQL para consultar los tipos de artículo

                comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                comando.CommandText = sentencia; // Asigna la sentencia al comando
                comando.Connection = conexion; // Asocia el comando con la conexión
                comando.Connection.Open(); // Abre la conexión a la base de datos
                reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos
                if (reader.HasRows) // Verifica si hay filas en el resultado
                {
                    while (reader.Read()) // Recorre los resultados obtenidos
                        listaTipoArticulo.Add(new TipoArticulo
                        {
                            Id = Convert.ToInt32(reader[0]), // Obtiene el ID del tipo de artículo
                            Nombre = reader.GetString(1), // Obtiene el nombre del tipo de artículo
                            Descripcion = reader.GetString(2) // Obtiene la descripción del tipo de artículo
                        });
                }// fin if
                return listaTipoArticulo; // Retorna la lista de tipos de artículo
            }

        } // fin ConsultarTiposArticulo
        #endregion
    }
}
