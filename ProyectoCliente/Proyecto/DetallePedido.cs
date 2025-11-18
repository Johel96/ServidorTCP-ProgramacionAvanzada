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


namespace Entidades
{
    public class DetallePedido
    {
        #region Propiedades
        public int NumeroPedido { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }

        // Propiedad para obtener el nombre del artículo asociado al detalle del pedido
        public string NombreArticulo
        {
            get { return Articulo?.Nombre ?? ""; } // Devuelve el nombre del artículo o una cadena vacía si Articulo es nulo
        }
        #endregion                
    }
}
