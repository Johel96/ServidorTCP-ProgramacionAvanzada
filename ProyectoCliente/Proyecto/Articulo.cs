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
    public class Articulo
    {
        #region Propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public TipoArticulo tipoArticulo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
        #endregion

        //Agrega la propiedad NombreTipoArticulo para obtener el nombre del tipo de artículo
        public string NombreTipoArticulo
        {
            get { return tipoArticulo?.Nombre ?? ""; }
        }
    }
}