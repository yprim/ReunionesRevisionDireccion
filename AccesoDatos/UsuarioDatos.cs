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

            SqlCommand sqlCommand = new SqlCommand("select u.* from  Usuario u;", sqlConnection);

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
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public int insertarUsuario(Usuario Usuario)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Usuario(nombre)
                                                    values(@nombre);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", Usuario.nombre);


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
        /// <param name="Usuario"></param>
        public void eliminarUsuario(Usuario Usuario)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete Usuario " +
                                               "where idUsuario = @idUsuario;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idUsuario", Usuario.idUsuario);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
    }
}
