using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class RepartidorLN
    {
        #region Metodos
        ///<summary>
        ///Metodo que valida el repartidor y lo guarda en la base de datos
        ///</summary>
        ///<param name="pRepartidor">Recibe los datos del repartidor</param>
        ///<returns>true/false</returns>"
        public bool GuardarRepartidor(Repartidor pRepartidor)
        {
            RepartidorAD repartidorAD = new RepartidorAD(); // Crea una instancia de la clase RepartidorAD para acceder a los métodos de acceso a datos
            return repartidorAD.GuardarRepartidor(pRepartidor); // Llama al método GuardarRepartidor de la clase RepartidorAD para guardar el repartidor
        }// fin GuardarRepartidor

        ///<summary>
        ///Metodo que permite consultar los repartidores
        ///</summary>
        ///<return>Un arreglo repartidores</return>
        public List<Repartidor> ConsultarRepartidores()// Método que consulta los repartidores
        {
            RepartidorAD repartidorAD = new RepartidorAD(); // Crea una instancia de la clase RepartidorAD para acceder a los métodos de acceso a datos
            List<Repartidor> listaRepartidores = new List<Repartidor>(); // Crea una lista para almacenar los repartidores
            return repartidorAD.ConsultarRepartidores(); // Llama al método ConsultarRepartidores de la clase RepartidorAD para obtener el arreglo de repartidores
        }// fin ConsultarRepartidores
        #endregion
    }
}
