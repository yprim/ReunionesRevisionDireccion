using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /// <summary>
    /// Priscilla Mena
    ///20/09/2018
    ///Clase para administrar las consultas sql para los usuarios
    /// </summary>
    public class UsuarioDatos
    {

        private ConexionDatos conexion = new ConexionDatos();

        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: devuelve una lista con todos los Usuarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Usuarios
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<Usuario> getUsuarios()
        {

            List<Usuario> listaUsuarios = new List<Usuario>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select u.* from  Usuario u order by nombre;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Usuario Usuario = new Usuario();

                Usuario.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                Usuario.nombre = reader["nombre"].ToString();

                listaUsuarios.Add(Usuario);
            }

            sqlConnection.Close();

            return listaUsuarios;
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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Usuario(nombre)
                                                    values(@nombre);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", usuario.nombre);


            sqlConnection.Open();
            int idUsuario = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idUsuario;
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/septiembnre/2018
        /// Efecto: actualiza un Usuario
        /// Requiere: Usuario a modificar
        /// Modifica: Usuario
        /// Devuelve: -
        /// </summary>
        /// <param name="Usuario"></param>
        public void actualizarUsuario(Usuario Usuario)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Update Usuario " +
                                                    "set nombre = @nombre " +
                                                    "where idUsuario = @idUsuario;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idUsuario", Usuario.idUsuario);
            sqlCommand.Parameters.AddWithValue("@nombre", Usuario.nombre);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete Usuario " +
                                               "where idUsuario = @idUsuario;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

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
            List<Usuario> listausuario = new List<Usuario>();
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select U.idUsuario,U.nombre
                from Usuario U
                 where  U.idUsuario not in (select UR.idUsuario 
                 from Usuario_Reunion UR 
                 where UR.idReunion = @idReunion ) 
             order by U.nombre;", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                Usuario usuario = new Usuario();

                usuario.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.nombre = reader["nombre"].ToString();
                listausuario.Add(usuario);
            }

            sqlConnection.Close();

            return listausuario;

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
            List<Usuario> listausuario = new List<Usuario>();
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select U.idUsuario,U.nombre
               from Usuario U,Usuario_Reunion UR 
                where UR.idReunion = @idReunion  and U.idUsuario = UR.idUsuario
                 order by U.nombre;", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                Usuario usuario = new Usuario();

                usuario.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.nombre = reader["nombre"].ToString();
                listausuario.Add(usuario);
            }

            sqlConnection.Close();

            return listausuario;

        }

        /*Leonardo Carrion
    12/07/2016
    Metodo que devuelve una lista de usuarios que se encuentran activos en la base de datos de Login*/
        public List<Usuario> getUsuariosLogin()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            SqlConnection sqlConnection = conexion.conexionLogin();

            SqlCommand sqlCommand = new SqlCommand(@"select U.id_usuario, U.nombre_completo
            from Usuario U, Rol R, Aplicacion A, Usuario_Rol_Aplicacion URA
            where A.nombre_aplicacion = 'ReunionesRevisionDireccion' and
            URA.id_aplicacion = A.id_aplicacion and U.id_usuario = URA.id_usuario
            and R.id_rol = URA.id_rol
            order by U.nombre_completo; ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.idUsuario = Convert.ToInt32(reader["id_usuario"].ToString());
                usuario.nombre = reader["nombre_completo"].ToString();



                listaUsuarios.Add(usuario);
            }

            sqlConnection.Close();

            return listaUsuarios;
        }
    }
}
