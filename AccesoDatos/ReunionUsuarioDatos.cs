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
    /// 02/11/2018
    //////Clase para administrar las consultas sql para los usuarios asignados a reuniones
    /// </summary>
    public class ReunionUsuarioDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("INSERT Usuario_Reunion (idReunion, idUsuario) " +
                "values(@idReunion,@idUsuario);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Usuario_Reunion WHERE idReunion = @idReunion and idUsuario = @idUsuario", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

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
            Boolean existe = false;

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select R.idReunion " +
                "from Usuario_Reunion R " +
                "where R.idUsuario = @idUsuario and R.idReunion = @idReunion;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                existe = true;
            }

            sqlConnection.Close();

            return existe;
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
            List<Usuario> listaUsuarios = new List<Usuario>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select U.*
                from Usuario_Reunion RU, Usuario U
                where RU.idReunion = @idReunion and E.idUsuario = RU.idUsuario ;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.nombre = reader["nombre"].ToString();
                listaUsuarios.Add(usuario);
            }

            sqlConnection.Close();

            return listaUsuarios;
        } 

    }
}
