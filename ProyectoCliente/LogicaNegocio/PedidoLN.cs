using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

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
    public class PedidoLN
    {
        #region Metodos
        ///<summary>
        ///Metodo que valida el pedido y lo guarda en la base de datos
        ///</summary>
        ///<param name="pEntidad">Recibe los datos del pedido</param>
        ///<returns>true/false</returns>
        public bool GuardarPedido(Pedido pEntidad)
        {
           PedidoAD PedidoAD = new PedidoAD(); // Crea una instancia de la clase PedidoAD para acceder a los métodos de acceso a datos
            return PedidoAD.GuardarPedido(pEntidad); // Llama al método de acceso a datos para guardar el pedido y retorna el resultado
        } // fin GuardarPedido

        /// <summary>
        /// Metodo que permite consultar los pedidos
        /// </summary>
        /// <returns>un arreglo de pedidos</returns>
        public List<Pedido> ConsultarPedidos() // Método que consulta los pedidos
        {
            PedidoAD PedidoAD = new PedidoAD(); // Crea una instancia de la clase PedidoAD para acceder a los métodos de acceso a datos
            return PedidoAD.ConsultarPedidos(); // Llama al método de acceso a datos para obtener el arreglo de pedidos
        } // fin ConsultarPedidos
        #endregion
    }
}
