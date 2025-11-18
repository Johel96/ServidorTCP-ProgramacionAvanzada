using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration; 
using Microsoft.Data.SqlClient; // Asegúrate de tener la referencia a Microsoft.Data.SqlClient para usar SqlConnection y SqlCommand

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
    public class RepartidorAD
    {
        #region constuctores
        private string CadenaConexion = string.Empty; // Cadena de conexión a la base de datos, si se requiere

        public RepartidorAD() // Constructor de la clase RepartidorAD
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString; // Obtiene la cadena de conexión desde el archivo de configuración
        } // fin constructor
        #endregion


        #region Metodos
        /// <summary>
        /// Metodo que almacena un repartidor en el arreglo
        /// </summary>
        /// <param name="pRepartidor">Recibe los datos del repartidor</param>
        /// <returns>true/false</returns>        
        public bool GuardarRepartidor(Repartidor pRepartidor)
        {
            bool repartidorGuardado = false; // Variable para indicar si el repartidor fue guardado correctamente

            using (SqlConnection conexion = new SqlConnection(CadenaConexion)) // Crea una conexión a la base de datos
            {
                string sentencia = "INSERT INTO Repartidor (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, FechaContratacion, Activo)" +
                    "VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @FechaContratacion, @Activo)"; // Sentencia SQL para insertar un nuevo repartidor`
                using (SqlCommand comando = new SqlCommand(sentencia, conexion)) // Crea un comando SQL con la sentencia y la conexión
                {
                    comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                    // Agrega los parámetros al comando
                    comando.Parameters.AddWithValue("@Identificacion", pRepartidor.Identificacion);
                    comando.Parameters.AddWithValue("@Nombre", pRepartidor.Nombre);
                    comando.Parameters.AddWithValue("@PrimerApellido", pRepartidor.PrimerApellido);
                    comando.Parameters.AddWithValue("@SegundoApellido", pRepartidor.SegundoApellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", pRepartidor.FechaNacimiento);
                    comando.Parameters.AddWithValue("@FechaContratacion", pRepartidor.FechaContratacion);
                    comando.Parameters.AddWithValue("@Activo", SqlDbType.Bit)
                        .Value = pRepartidor.Activo;// Agrega el estado activo del repartidor
                    conexion.Open(); // Abre la conexión a la base de datos
                    int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta el comando y obtiene el número de filas afectadas
                    repartidorGuardado = filasAfectadas > 0; // Si se afectaron filas, se considera que el repartidor fue guardado correctamente


                } // fin using SqlConnection
                return repartidorGuardado; // Retorna true si el repartidor fue guardado correctamente, false en caso contrario
            } // fin using SqlCommand            
        }// fin GuardarRepartidor

        /// <summary>
        /// Metodo que permite consultar un repartidor
        /// </summary>
        /// <returns>Retorna un arreglo de repartidores</returns>        
        public List<Repartidor> ConsultarRepartidores()
        {
            List<Repartidor> listaRepartidor = new List<Repartidor>(); // Lista para almacenar los repartidores consultados
            SqlConnection conexion = new SqlConnection(CadenaConexion); // Crea una conexión a la base de datos
            SqlCommand comando = new SqlCommand(); // Crea un comando SQL para seleccionar todos los repartidores
            SqlDataReader reader; // Crea un lector para leer los datos de la consulta

            using (conexion = new SqlConnection(CadenaConexion))
            {
                String sentencia = "SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, FechaContratacion, Activo FROM Repartidor"; // Sentencia SQL para consultar los repartidores

                comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                comando.CommandText = sentencia; // Asigna la sentencia al comando
                comando.Connection = conexion; // Asocia el comando con la conexión
                comando.Connection.Open(); // Abre la conexión a la base de datos
                reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos                
                while (reader.Read())
                {
                    bool estado = reader.GetBoolean(6); // Variable para indicar si el repartidor está activo, por defecto es verdadero
                    Repartidor repartidor = new Repartidor
                    {
                        Identificacion = Convert.ToInt32(reader[0]), // Obtiene la identificación del repartidor
                        Nombre = reader.GetString(1), // Obtiene el nombre del repartidor
                        PrimerApellido = reader.GetString(2), // Obtiene el primer apellido del repartidor
                        SegundoApellido = reader.GetString(3), // Obtiene el segundo apellido del repartidor
                        FechaNacimiento = reader.GetDateTime(4), // Obtiene la fecha de nacimiento del repartidor
                        FechaContratacion = reader.GetDateTime(5), // Obtiene la fecha de contratación del repartidor
                        Activo = estado // Asigna el estado activo del repartidor
                    };
                    listaRepartidor.Add(repartidor); // Agrega el repartidor a la lista
                }                
                return listaRepartidor;

            }
        }// fin ConsultarRepartidores
        #endregion
    }
} // fin namespace AccesoDatos

