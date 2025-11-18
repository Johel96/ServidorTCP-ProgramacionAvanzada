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
    public class DetallePedidoLN
    {
        #region Metodos
        ///<summary>
        /// Método que valida el detalle de pedido y lo guarda en el arreglo
        /// </summary> 
        ///<param name="pEntidad">Recibe los datos del detalle de pedido</param>
        ///<returns>true/false</returns>
        public bool GuardarDetallePedido(DetallePedido pEntidad)
        {
            DetallePedidoAD detallePedidoAD = new DetallePedidoAD();
            return detallePedidoAD.GuardarDetallePedido(pEntidad); // Llama al método de acceso a datos para guardar el detalle del pedido y retorna el resultado
        }// fin GuardarDetallePedido

        /// <summary>
        /// Método que permite consultar los detalles de pedidos
        /// </summary>
        /// <returns>Un arreglo detalle pedidos</returns>
        public List<DetallePedido> ConsultarDetallesPedidos()// Método para consultar detalles de pedidos por número de pedido
        {
            DetallePedidoAD DetallePedidoAD = new DetallePedidoAD(); // Crea una instancia de la clase DetallePedidoAD para acceder a los métodos de acceso a datos
            return DetallePedidoAD.ConsultarDetallesPedidos(); // Llama al método de acceso a datos para obtener el arreglo de detalles de pedidos
        }
        #endregion
    }
}
