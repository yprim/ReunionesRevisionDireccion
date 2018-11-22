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
    }
}
