using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
  public  class ArchivoReunionServicios
    {
        ArchivoReunionDatos archivoReunionDatos = new ArchivoReunionDatos();


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: recupera todos los archivos de reuniones de la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de archivos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<ArchivoReunion> getArchivosReunion()
        {
            return archivoReunionDatos.getArchivosReunion();
        }


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: recupera todos los archivos de Reuniones de la base de datos que estan asociados a una Reunion en especifico
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de archivos
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public List<ArchivoReunion> getArchivosReunionPorIdReunion(Reunion reunion)
        {

            return archivoReunionDatos.getArchivosReunionPorIdReunion(reunion);
        }


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: inserta un archivo Reunion en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve:  devuelve el id del archivo ingresado
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int insertarArchivoReunion(ArchivoReunion archivoReunion)
        {

            return archivoReunionDatos.insertarArchivoReunion(archivoReunion);
        }


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: metodo que elimina un archivo Reunion en la base de datos
        /// Requiere: -
        /// Modifica: elimina el registro del archivo de la base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="archivoReunion"></param>
        /// <returns></returns>
        public void eliminarArchivoReunion(ArchivoReunion archivoReunion)
        {
            archivoReunionDatos.eliminarArchivoReunion(archivoReunion);
        }
    }
}
