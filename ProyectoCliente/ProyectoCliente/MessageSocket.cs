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
namespace ProyectoCliente
{
    public class MessageSocket<T>
    {
        /// <summary>
        /// Propiedad utilizada para indicar el nombre del metodo que debe ejecutarse en el servidor.
        /// </summary>
        public string Metodo { get; set; }

        /// <summary>
        /// Propiedad utilizada para enviar la entidad que se debe procesar en el metodo solicitado por el cliente.
        /// La entidad puede ser de cualquier tipo, por lo que se utiliza un objeto genérico.
        /// Se debe indicar el tipo de entidad al momento de crear una instancia de esta clase.
        /// </summary> 
        public T Entidad { get; set; }
    }
}
