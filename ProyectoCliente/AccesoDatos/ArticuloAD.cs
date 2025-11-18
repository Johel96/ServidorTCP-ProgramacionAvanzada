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
    public class ArticuloAD
    {
        #region Constructor
        private string CadenaConexion = string.Empty; // Cadena de conexión a la base de datos, si se requiere

        public ArticuloAD()
        {
           CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionEntregas"].ConnectionString; // Obtiene la cadena de conexión desde el archivo de configuración
        } // fin constructor
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que almacena un articulo en la base de datos
        /// </summary>
        /// <param name="pArticulo">Recibe los datos del articulo</param>
        /// <returns>true/false</returns>        
        public bool GuardarArticulo(Articulo pArticulo)
        {
            bool articuloGuardado = false; // Variable para indicar si el artículo fue guardado correctamente

            using (SqlConnection conexion = new SqlConnection(CadenaConexion)) // Inicia una conexión a la base de datos
            {
                string sentencia = "INSERT INTO Articulo (Id, Nombre, IdTipoArticulo, Valor, Inventario, Activo) " +
                    "VALUES (@Id, @Nombre, @IdTipoArticulo, @Valor, @Inventario, @Activo)"; // Sentencia SQL para insertar un nuevo artículo
                using (SqlCommand comando = new SqlCommand(sentencia, conexion)) // Crea un comando SQL con la sentencia y la conexión
                {
                    comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                    // Agrega los parámetros al comando
                    comando.Parameters.AddWithValue("@Id", pArticulo.ID);
                    comando.Parameters.AddWithValue("@Nombre", pArticulo.Nombre);
                    //Agrega el parametro TipoArticulo y lo convierte en el id del tipo de articulo
                    comando.Parameters.AddWithValue("@IdTipoArticulo", pArticulo.tipoArticulo.Id); // Convierte el tipo de artículo a su ID y lo agrega como parámetro                    
                    comando.Parameters.AddWithValue("@Valor", pArticulo.Precio);
                    comando.Parameters.AddWithValue("@Inventario", pArticulo.Stock);
                    comando.Parameters.AddWithValue("@Activo", SqlDbType.Bit) // Agrega el parámetro Estado al comando
                        .Value = pArticulo.Activo; // Asigna el valor del estado al parámetro
                    conexion.Open(); // Abre la conexión a la base de datos
                    int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta el comando y obtiene el número de filas afectadas
                    articuloGuardado = filasAfectadas > 0; // Si se afectaron filas, se considera que el artículo fue guardado correctamente
                }
            }
            return articuloGuardado; // Retorna true si el artículo fue guardado correctamente, false en caso contrario
        } // fin GuardarArticulo
        
        /// <summary>
        /// Metodo que permite consultar un articulo
        /// </summary>
        /// <returns>Retorna una lista de articulos</returns>        
        public List<Articulo> ConsultarArticulos()
        {
            TipoArticuloAD tipoAD = new TipoArticuloAD();
            List<TipoArticulo> listaTipos = tipoAD.ConsultarTiposArticulo();

            List<Articulo> listaArticulo = new List<Articulo>();
            SqlConnection conexion; // Crea una conexión a la base de datos
            SqlCommand comando = new SqlCommand(); // Crea un comando SQL
            SqlDataReader reader;// Crea un adaptador de datos para ejecutar el comando
                        
            using (conexion = new SqlConnection(CadenaConexion)) // Inicia una conexión a la base de datos
            {
                string sentencia = "Select Id, Nombre, IdTipoArticulo, Valor, Inventario, Activo from Articulo"; // Define la sentencia SQL para consultar los artículos
                comando.CommandType = CommandType.Text; // Establece el tipo de comando como texto
                comando.CommandText = sentencia; // Asigna la sentencia SQL al comando
                comando.Connection = conexion; // Asocia el comando a la conexión
                comando.Connection.Open(); // Abre la conexión a la base de datos
                reader = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos
                if (reader.HasRows) // Verifica si hay filas en el resultado
                {
                    while (reader.Read())
                    {
                        int idTipo = Convert.ToInt32(reader.GetDecimal(2));
                        //FirstOrDefault busca el primer elemento que cumpla con la condición especificada o devuelve null si no se encuentra ninguno
                        //t => t.Id == idTipo es una expresión lambda que define la condición de búsqueda
                        TipoArticulo tipo = listaTipos.FirstOrDefault(t => t.Id == idTipo);// Busca el tipo de artículo correspondiente al ID obtenido

                        listaArticulo.Add(new Articulo
                        {
                            ID = Convert.ToInt32(reader.GetDecimal(0)),
                            Nombre = reader.GetString(1),
                            tipoArticulo = tipo,
                            Precio = Convert.ToDouble(reader.GetDecimal(3)),
                            Stock = Convert.ToInt32(reader.GetDecimal(4)),
                            Activo = reader.GetBoolean(5)
                        });
                    }

                }
                return listaArticulo; // Retorna la lista de artículos consultados
            }
        } // fin ConsultarArticulos
                   
               
        #endregion
    }
}
