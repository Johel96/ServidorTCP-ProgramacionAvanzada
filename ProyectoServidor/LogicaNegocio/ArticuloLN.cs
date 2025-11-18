using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
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

namespace LogicaNegocio
{
    public class ArticuloLN
    {
        #region Metodos
        /// <summary>
        /// Metodo que valida el articulo y lo guarda en la base de datos
        /// </summary> 
        /// <param name="pEntidad">Recibe los datos del articulo</param>"
        ///<returns>true/false</returns>
        public bool GuardarArticulo(Articulo pEntidad)
        {
            
            ArticuloAD ArticuloAD = new ArticuloAD(); // Crea una instancia de la clase ArticuloAD para acceder a los métodos de acceso a datos
            return ArticuloAD.GuardarArticulo(pEntidad); // Llama al método de acceso a datos para guardar el artículo y retorna el resultado


        } // fin GuardarArticulo

        /// <summary>
        /// metodo que permite consultar los articulos de la base de datos
        /// </summary>
        /// <returns>un arreglo clientes</returns>
        public List<Articulo> ConsultarArticulos() // Método que consulta los artículos
        {
            ArticuloAD ArticuloAD = new ArticuloAD(); // Crea una instancia de la clase ArticuloAD para acceder a los métodos de acceso a datos
            return ArticuloAD.ConsultarArticulos(); // Llama al método de acceso a datos para obtener el arreglo de artículos
        } // fin ConsultarArticulos


        
        #endregion
    }
}
