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
    /// 02/11/2018
    //////Clase para administrar las consultas sql para los usuarios asignados a reuniones
    /// </summary>
    public class ReunionUsuarioServicios
    {
        private ReunionUsuarioDatos reunionUsuarioDatos = new ReunionUsuarioDatos();

        /// <summary>
        /// Priscilla Mena
        /// 02/11/2018
        /// Efecto: guarda en la base de datos una asociación entre la reunion con el usuaio
        /// Requiere: Reunión, usuario
        /// Modifica: inserta en la base de datos un registro de Usuario_Reunion
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="usuario"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarReunionUsuario(Reunion reunion, Usuario usuario)
        {
            reunionUsuarioDatos.insertarReunionUsuario(reunion, usuario);
        }

        /// <summary>
        /// Priscilla Mena
        /// 02/11/2018
        /// Efecto: método que elimina la asociacion entre la reunion con el usuario 
        /// Requiere: Reunion, Usuario
        /// Modifica: inserta en la base de datos un registro de Usuario_Reunion
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="usuario"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionUsuario(Reunion reunion, Usuario usuario)
        {
            reunionUsuarioDatos.eliminarReunionUsuario(reunion, usuario);

        }

        /// <summary>
        /// Priscilla Mena
        /// 02/11/2018
        /// Efecto: metodo que devuelve true si existe un Usuario asociado con una reunión.
        /// Requiere: Reunion, Usuario
        /// Modifica: inserta en la base de datos un registro de Usuario_Reunion
        /// Devuelve: true si el Usuario está asociado a una reunión o false si no está asociado
        /// <param name="reunion"></param>
        /// <param name="usuario"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean usuarioAsociadoAReunión(Reunion reunion, Usuario usuario)
        {
            
            return reunionUsuarioDatos.usuarioAsociadoAReunión(reunion, usuario);
        }

        /// <summary>
        /// Priscilla Mena
        /// 02/11/2018
        /// Efecto: devuelve la lista de Usuarios a revisar que estan asociados a una reunión en específico
        /// Requiere: Reunion
        /// Modifica: -
        /// Devuelve: lista de Usuarios a revisar
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public List<Usuario> getUsuariosAsociadosAReunion(Reunion reunion)
        {
           

            return getUsuariosAsociadosAReunion(reunion);
        }

    }
}
