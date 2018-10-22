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
    /// 26/septiembre/2018
    /// Clase para administrar los servicios de Reunion
    /// </summary>
    public class ReuniónServicios
    {
        ReunionDatos reunionDatos = new ReunionDatos();
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: devuelve una lista con todas las reuniones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de tipos
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public List<Reunion> getReuniones()
        {
             return reunionDatos.getReuniones();
        }


        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: recupera todas las Reuniones de la base de datos que estan asociadas a un tipo en especifico
        /// Requiere: Tipo 
        /// Modifica: -
        /// Devuelve: lista de Reuniones
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public List<Reunion> getReunionesPorTipo(Tipo tipo)
        {
            return reunionDatos.getReunionesPorTipo(tipo);
        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Inserta una reunion en la base de datos
        /// Requiere: Reunion 
        /// Modifica: Reuniones
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public int insertarReunion(Reunion reunion)
        {
            return reunionDatos.insertarReunion(reunion);
        }


        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: actualiza una Reunion en la base de datos
        /// Requiere: Reunion 
        /// Modifica: Reuniones
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public void actualizarReunion(Reunion reunion)
        {
            reunionDatos.actualizarReunion(reunion);

        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: elimina una Reunion en la base de datos
        /// Requiere: Reunion 
        /// Modifica: Reuniones
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public void eliminarReunion(Reunion reunion)
        {
            reunionDatos.eliminarReunion(reunion);
        }


        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: compara todos los datos para devolver la reunion correspondiente
        /// Requiere: Reunion 
        /// Modifica: -
        /// Devuelve: Reunion
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public Reunion getReunionPorDatos(Reunion reunion)
        {

            
            return reunionDatos.getReunionPorDatos(reunion);
        }

        /// <summary>
        /// Priscilla Mena
        /// 22/10/2018
        /// Efecto: recupera el ultimo numero de las reuniones de la base de datos
        /// Requiere: numero int 
        /// Modifica: -
        /// Devuelve: numero int
        /// </summary>
        /// <param name="anno"></param>
        /// <returns></returns>
        public int getUltimoNumeroPorAnno(int anno)
        {


            return reunionDatos.getUltimoNumeroPorAnno(anno);
        }
    }
}
