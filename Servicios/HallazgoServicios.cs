using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class HallazgoServicios
    {
        HallazgoDatos hallazgoDatos = new HallazgoDatos();


        /// <summary>
        /// Priscilla Mena
        /// 21/11/2018
        /// Efecto: devuelve una lista con todos los Hallazgos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de hallazgos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Hallazgo> getHallazgos()
        {
            return hallazgoDatos.getHallazgos();
        }



        /// <summary>
        /// Priscilla Mena
        /// 21/11/2018
        /// Efecto: Inserta una Hallazgo en la base de datos
        /// Requiere: Hallazgo 
        /// Modifica: Hallazgoes
        /// Devuelve: -
        /// </summary>
        /// <param name="hallazgo"></param>
        /// <returns></returns>
        public int insertarHallazgo(Hallazgo hallazgo)
        {
            return hallazgoDatos.insertarHallazgo(hallazgo);
        }


        /// <summary>
        /// Priscilla Mena
        /// 21/11/2018
        /// Efecto: actualiza una Hallazgo en la base de datos
        /// Requiere: Hallazgo 
        /// Modifica: Hallazgo
        /// Devuelve: -
        /// </summary>
        /// <param name="hallazgo"></param>
        /// <returns></returns>
        public void actualizarHallazgo(Hallazgo hallazgo)
        {
            hallazgoDatos.actualizarHallazgo(hallazgo);
        }

        /// <summary>
        /// Priscilla Mena
        /// 21/11/2018
        /// Efecto: elimina una Hallazgo en la base de datos
        /// Requiere: Hallazgo 
        /// Modifica: Hallazgoes
        /// Devuelve: -
        /// </summary>
        /// <param name="hallazgo"></param>
        /// <returns></returns>
        public void eliminarHallazgo(Hallazgo hallazgo)
        {
            hallazgoDatos.eliminarHallazgo(hallazgo);
        }

        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: recupera todos los hallazgos de la base de datos que estan asociadas a una reunión en específico
        /// Requiere: Reunion 
        /// Modifica: -
        /// Devuelve: lista de Hallazgos
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public List<Hallazgo> getHallazgosPorReunion(Reunion reunion)
        {
            return hallazgoDatos.getHallazgosPorReunion(reunion);
        }
    }
}