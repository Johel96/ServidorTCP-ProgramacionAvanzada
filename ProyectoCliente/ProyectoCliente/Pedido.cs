using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Client;
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
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public Cliente Cliente { get; set; }
        public Repartidor Repartidor { get; set; }
        public string Direccion { get; set; }

        public string NombreCliente
        {
            get
            {
                return Cliente != null
                    ? $"{Cliente.Nombre} {Cliente.PrimerApellido} {Cliente.SegundoApellido}"
                    : string.Empty;
            }
        }

        public string NombreRepartidor
        {
            get
            {
                return Repartidor != null
                    ? $"{Repartidor.Nombre} {Repartidor.PrimerApellido} {Repartidor.SegundoApellido}"
                    : string.Empty;
            }
        }
    }
}
