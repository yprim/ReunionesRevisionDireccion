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
    /// Clase para administrar los servicios de Usuario
    /// </summary>
    public class UsuarioServicios
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();
        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: devuelve una lista con todos los Usuarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuario> getUsuarios()
        {
            return usuarioDatos.getUsuarios();
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/sptiembre/2018
        /// Efecto: inserta en la base de datos un Usuario
        /// Requiere: Usuario
        /// Modifica: -
        /// Devuelve: id del Usuario insertado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int insertarUsuario(Usuario usuario)
        {
            return usuarioDatos.insertarUsuario(usuario);
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/septiembnre/2018
        /// Efecto: actualiza un Usuario
        /// Requiere: Usuario a modificar
        /// Modifica: Usuario
        /// Devuelve: -
        /// </summary>
        /// <param name="usuario"></param>
        public void actualizarUsuario(Usuario usuario)
        {
            usuarioDatos.actualizarUsuario(usuario);

        }

        /// <summary>
        /// Priscilla Mena
        /// 20/septiembre/2018
        /// Efecto: Elimina un Usuario de forma logica
        /// Requiere: Usuario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="usuario"></param>
        public void eliminarUsuario(Usuario usuario)
        {
            usuarioDatos.eliminarUsuario(usuario);


        }



        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: recupera todos los usuarios que no estan asociados a una reunión
        /// Requiere: reunion
        /// Modifica: -
        /// Devuelve: lista de usuarios
        /// </summary>
        /// <param name="reunion"></param>
        public List<Usuario> getUsuariosNoEstanEnReunion(Reunion reunion)
        {

            return usuarioDatos.getUsuariosNoEstanEnReunion(reunion);

        }

        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: recupera todos los usuarios estan asociados a una reunión en específico
        /// Requiere: reunion
        /// Modifica: -
        /// Devuelve: lista de usuarios
        /// </summary>
        /// <param name="reunion"></param>
        public List<Usuario> getUsuariosEstanEnReunion(Reunion reunion)
        {

            return usuarioDatos.getUsuariosEstanEnReunion(reunion);

        }

        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: Metodo que devuelve una lista de usuarios que se encuentran activos en la base de datos de Login de RevisionesPorLaDireccionDB
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de usuarios
        public List<Usuario> getUsuariosLogin()
        {
            return usuarioDatos.getUsuariosLogin();
        }
    }
}
