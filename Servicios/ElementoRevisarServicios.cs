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
    /// 20/septiembre/2018
    /// Clase para administrar los servicios de elementoRevisar
    /// </summary>
    public class ElementoRevisarServicios
    {
        ElementoRevisarDatos elementoRevisarDatos = new ElementoRevisarDatos();

        public List<ElementoRevisar> getElementosRevisar()
        {

           

            return elementoRevisarDatos.getElementosRevisar();
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/sptiembre/2018
        /// Efecto: inserta en la base de datos un elementoRevisar
        /// Requiere: elementoRevisar
        /// Modifica: -
        /// Devuelve: id del elementoRevisar insertado
        /// </summary>
        /// <param name="elementoRevisar"></param>
        /// <returns></returns>
        public int insertarElementoRevisar(ElementoRevisar elementoRevisar)
        {
            return elementoRevisarDatos.insertarElementoRevisar(elementoRevisar);
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/septiembnre/2018
        /// Efecto: actualiza un elementoRevisar
        /// Requiere: elementoRevisar a modificar
        /// Modifica: elementoRevisar
        /// Devuelve: -
        /// </summary>
        /// <param name="ElementoRevisar"></param>
        public void actualizarElementoRevisar(ElementoRevisar elementoRevisar)
        {

            elementoRevisarDatos.actualizarElementoRevisar(elementoRevisar);
        }


        /// <summary>
        /// Priscilla Mena
        /// 20/septiembre/2018
        /// Efecto: Elimina un elementoRevisar 
        /// Requiere: elementoRevisar
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="elementoRevisar"></param>
        public void eliminarElementoRevisar(ElementoRevisar elementoRevisar)
        {
            elementoRevisarDatos.eliminarElementoRevisar(elementoRevisar);

        }

        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: recupera todos los elementos a revisar que no estan asociados a una reunión
        /// Requiere: reunion
        /// Modifica: -
        /// Devuelve: lista de elementos a revisar
        /// </summary>
        /// <param name="reunion"></param>
        public List<ElementoRevisar> getElementosNoEstanEnReunion(Reunion reunion)
        {
            return elementoRevisarDatos.getElementosNoEstanEnReunion(reunion);

        }

        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: recupera todos los elementos a revisar que  estan asociados a una reunión en específico
        /// Requiere: reunion
        /// Modifica: -
        /// Devuelve: lista de elementos a revisar
        /// </summary>
        /// <param name="reunion"></param>
        public List<ElementoRevisar> getElementosEstanEnReunion(Reunion reunion)
        {
            return elementoRevisarDatos.getElementosEstanEnReunion(reunion);

        }


    }
}

