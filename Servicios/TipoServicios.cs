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
    /// 12/septiembre/2018
    /// Clase para administrar los servicios de Tipo
    /// </summary>
   public class TipoServicios
    {
        TipoDatos tipoDatos = new TipoDatos();


        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: devuelve una lista con todos los tipos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de tipos
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public List<Tipo> getTipos()
        {
            return tipoDatos.getTipos();
        }

        /// <summary>
        /// Priscilla Mena
        /// 12/sptiembre/2018
        /// Efecto: inserta en la base de datos un tipo
        /// Requiere: tipo
        /// Modifica: -
        /// Devuelve: id del tipo insertado
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public int insertarTipo(Tipo tipo)
        {
            return tipoDatos.insertarTipo(tipo);
        }

        /// <summary>
        /// Priscilla Mena
        /// 12/septiembnre/2018
        /// Efecto: actualiza de forma logica un tipo
        /// Requiere: tipo a modificar
        /// Modifica: tipo
        /// Devuelve: -
        /// </summary>
        /// <param name="tipo"></param>
        public void actualizarTipo(Tipo tipo)
        {
            tipoDatos.actualizarTipo(tipo);

        }

        /// <summary>
        /// Priscilla Mena
        /// 12/septiembre/2018
        /// Efecto: Elimina un tipo de forma logica
        /// Requiere: Tipo
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="tipo"></param>
        public void eliminarTipo(Tipo tipo)
        {
            tipoDatos.eliminarTipo(tipo);

        }

    }
}
