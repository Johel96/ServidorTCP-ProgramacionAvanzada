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
    public class ClienteLN
    {
        #region Metodos
        ///<summary>
        ///metodo que valida el cliente y lo guarda en el arreglo
        ///<summary/>
        ///<param name="pEntidad">Recibe los datos del cliente</param>
        ///<returns>true/false</returns>
        public bool GuardarCliente(Cliente pEntidad)
        {
            ClienteAD ClienteAD = new ClienteAD(); // Crea una instancia de la clase ClienteAD para acceder a los métodos de acceso a datos
            return ClienteAD.GuardarCliente(pEntidad); // Llama al método de acceso a datos para guardar el cliente y retorna el resultado

        } // fin GuardarCliente

        /// <summary>
        /// metodo que permite consultar los clientes
        /// </summary>
        /// <returns>un arreglo clientes</returns>
        public List<Cliente> ConsultarClientes() // Método que consulta los clientes
        {
            ClienteAD ClienteAD = new ClienteAD(); // Crea una instancia de la clase ClienteAD para acceder a los métodos de acceso a datos
            List<Cliente> listaClientes = new List<Cliente>(); // Crea una lista para almacenar los clientes
            return ClienteAD.ConsultarClientes(); // Llama al método de acceso a datos para obtener el arreglo de clientes
        } // fin ConsultarClientes
        #endregion
    }// fin de la clase ClienteLN
} 
