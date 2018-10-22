using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    /// <summary>
    /// Priscilla Mena
    /// 09/10/2018
    //////Clase para administrar los servicios de Elementos a Revisar asignados a reuniones
    /// </summary>
    public class ReunionElementoRevisarServicios
    {
        ReunionElementoRevisarDatos reunionElementoRevisarDatos = new ReunionElementoRevisarDatos();

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: guarda en la base de datos una asociación entre la reunion con el elemento a revisar
        /// Requiere: Reunión, ElementoRevisar
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarReunionElemento(Reunion reunion, ElementoRevisar elementoRevisar)
        {
            reunionElementoRevisarDatos.insertarReunionElemento(reunion, elementoRevisar);
        }

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: método que elimina la asociacion entre la reunion con el elemento a revisar
        /// Requiere: Reunión, ElementoRevisar
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElemento(Reunion reunion, ElementoRevisar elementoRevisar)
        {
            reunionElementoRevisarDatos.eliminarReunionElemento(reunion, elementoRevisar);
        }

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: metodo que devuelve true si existe un elemento a revisar asociado con una reunión.
        /// Requiere: Reunión, ElementoRevisar
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar
        /// Devuelve: true si el elemento está asociado a una reunión o false si no está asociado
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean elementoAsociadoAReunión(Reunion reunion, ElementoRevisar elementoRevisar)
        {
            return reunionElementoRevisarDatos.elementoAsociadoAReunión(reunion,elementoRevisar);
        }

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: devuelve la lista de elementos a revisar que estan asociados a una reunión en específico
        /// Requiere: Reunion
        /// Modifica: -
        /// Devuelve: lista de elementos a revisar
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public List<ElementoRevisar> getElementosAsociadosAReunion(Reunion reunion)
        {
           return reunionElementoRevisarDatos.getElementosAsociadosAReunion(reunion);
        }
    }
}
