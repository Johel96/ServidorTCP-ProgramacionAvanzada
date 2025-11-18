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
    public class TipoArticuloLN
    {
        #region Metodos
        /// <summary>
        /// Metodo que valida el tipo de artículo y lo guarda en la base de datos
        /// </summary>
        /// <param name="pEntidad"></param>
        /// <returns></returns>

        public bool GuardarTipoArticulo(TipoArticulo pEntidad)
        {                      
            TipoArticuloAD TipoArticuloAD = new TipoArticuloAD(); // Crea una instancia de la clase TipoArticuloAD para acceder a los métodos de acceso a datos      
            return TipoArticuloAD.GuardarTipoArticulo(pEntidad); // Si el tipo de artículo no existe, se guarda en el arreglo
          
        } // fin GuardarTipoArticulo

        /// <summary>
        /// Metodo que permite consultar los tipos de artículo
        /// </summary>
        /// <returns></returns>

        public List<TipoArticulo> ConsultarTiposArticulo() // Método que consulta los tipos de artículos
        {
            TipoArticuloAD TipoArticuloAD = new TipoArticuloAD(); // Crea una instancia de la clase TipoArticuloAD para acceder a los métodos de acceso a datos
            List<TipoArticulo> listaTipos = new List<TipoArticulo>(); // Crea una lista para almacenar los tipos de artículos
            return TipoArticuloAD.ConsultarTiposArticulo(); // Llama al método de acceso a datos para obtener el arreglo de tipos de artículos
        } // fin ConsultarTiposArticulo
        #endregion
    }//termina clase TipoArticuloLN
}
