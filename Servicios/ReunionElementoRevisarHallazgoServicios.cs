using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ReunionElementoRevisarHallazgoServicios
    {
        ReunionElementoRevisarHallazgoDatos reunionElementoRevisarHallazgoDatos = new ReunionElementoRevisarHallazgoDatos();

        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: guarda en la base de datos una asociación entre la reunion con el elemento a revisar y hallazgo
        /// Requiere: Reunión, ElementoRevisar, Hallazgo
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar_Hallazgo
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarReunionElementoHallazgo(Reunion reunion, ElementoRevisar elementoRevisar, Hallazgo hallazgo)
        {
            reunionElementoRevisarHallazgoDatos.insertarReunionElementoHallazgo(reunion, elementoRevisar, hallazgo);
        }

        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: método que elimina la asociacion entre la reunion con el elemento a revisar y hallazgo
        /// Requiere: Reunión, ElementoRevisar, Hallazgo
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar_Hallazgo
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElementoHallazgo(Reunion reunion, ElementoRevisar elementoRevisar, Hallazgo hallazgo)
        {
            reunionElementoRevisarHallazgoDatos.eliminarReunionElementoHallazgo(reunion, elementoRevisar, hallazgo);
        }


        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: método que elimina  todas las relaciones que contengan esa reunión
        /// Requiere: Reunión
        /// Modifica: -
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElementoHallazgo(Reunion reunion)
        {
            reunionElementoRevisarHallazgoDatos.eliminarReunionElementoHallazgo(reunion);


        }

        /// <summary>
        /// Priscilla Mena
        /// 14/12/2018
        /// Efecto: recupera el elemento a revisar asociado a ese hallazgo
        /// Requiere: Hallazgo
        /// Modifica: -
        /// Devuelve: ElemenetoRevisar
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public ElementoRevisar getElementoHallazgo(Reunion reunion, Hallazgo hallazgo)
        {
            
            return reunionElementoRevisarHallazgoDatos.getElementoHallazgo(reunion, hallazgo);





        }


        /// <summary>
        /// Priscilla Mena
        /// 14/12/2018
        /// Efecto: método que elimina todas las asociaciones que poseen ese hallazgo
        /// Requiere: Reunión, ElementoRevisar, Hallazgo
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar_Hallazgo
        /// Devuelve: -
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElementoHallazgo(Hallazgo hallazgo)
        {

            reunionElementoRevisarHallazgoDatos.eliminarReunionElementoHallazgo(hallazgo);
        }



    }
}
