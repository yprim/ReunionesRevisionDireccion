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
    /// 19/septiembre/2018
    /// Clase para administrar los servicios de Estado
    /// </summary>
    public class EstadoServicios
    {
        EstadoDatos estadoDatos = new EstadoDatos();

        /// <summary>
        /// Priscilla Mena
        /// 19/09/2018
        /// Efecto: devuelve una lista con todos los Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Estados
        /// </summary>
        /// <returns></returns>
        public List<Estado> getEstados()
        {

            return estadoDatos.getEstados();
        }

        /// <summary>
        /// Priscilla Mena
        /// 19/sptiembre/2018
        /// Efecto: inserta en la base de datos un estado
        /// Requiere: estado
        /// Modifica: -
        /// Devuelve: id del estado insertado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int insertarEstado(Estado estado)
        {
            return estadoDatos.insertarEstado(estado);
        }

        /// <summary>
        /// Priscilla Mena
        /// 19/septiembnre/2018
        /// Efecto: actualiza un estado
        /// Requiere: estado a modificar
        /// Modifica: estado
        /// Devuelve: -
        /// </summary>
        /// <param name="estado"></param>
        public void actualizarEstado(Estado estado)
        {
            estadoDatos.actualizarEstado(estado);
        }

        /// <summary>
        /// Priscilla Mena
        /// 19/septiembre/2018
        /// Efecto: Elimina un estado 
        /// Requiere: estado
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="estado"></param>
        public void eliminarEstado(Estado estado)
        {
            estadoDatos.eliminarEstado(estado);
        }
    }
}
