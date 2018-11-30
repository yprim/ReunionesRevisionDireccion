using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /*
* Priscilla Mena Monge
* 21/11/2018
* Clase para administrar las consultas sql para los hallazgos de reuniones
*/
    public class HallazgoDatos
    {
         private ConexionDatos conexion = new ConexionDatos();


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

            List<Hallazgo> listaHallazgos = new List<Hallazgo>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"SELECT h.idHallazgo, u.idUsuario, u.nombre,h.fechaMaximaImplementacion,h.codigoAccion,e.idEstado, e.descripcion,h.observaciones
             FROM Hallazgo h, Usuario u, Estado e where h.idUsuario = u.idUsuario and h.idEstado = e.idEstado order by h.fechaMaximaImplementacion desc, h.observaciones", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Hallazgo hallazgo = new Hallazgo();

                hallazgo.idHallazgo = Convert.ToInt32(reader["idHallazgo"].ToString());
                hallazgo.fechaMaximaImplementacion = Convert.ToDateTime(reader["fechaMaximaImplementacion"].ToString());
                hallazgo.codigoAccion = reader["codigoAccion"].ToString();
                hallazgo.observaciones = reader["observaciones"].ToString();

                Estado estado = new Estado();
                estado.idEstado= Convert.ToInt32(reader["idEstado"].ToString());
                estado.descripcionEstado = reader["descripcionEstado"].ToString();

                Usuario usuario = new Usuario();
                usuario.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.nombre = reader["nombre"].ToString();

                hallazgo.estado = estado;
                hallazgo.usuario = usuario;
                listaHallazgos.Add(hallazgo);
            }

            sqlConnection.Close();

            return listaHallazgos;
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
            SqlConnection sqlConnection = conexion.conexionRRD();

            string consulta = @"INSERT INTO Hallazgo (idUsuario,fechaMaximaImplementacion,codigoAccion,idEstado,observaciones)
                                                     values(@idUsuario,@fechaMaximaImplementacion,@codigoAccion,@idEstado,@observaciones);
                                                        SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idUsuario", hallazgo.usuario.idUsuario);
            sqlCommand.Parameters.AddWithValue("@fechaMaximaImplementacion", hallazgo.fechaMaximaImplementacion);
            sqlCommand.Parameters.AddWithValue("@codigoAccion", hallazgo.codigoAccion);
            sqlCommand.Parameters.AddWithValue("@idEstado", hallazgo.estado.idEstado);
            sqlCommand.Parameters.AddWithValue("@observaciones", hallazgo.observaciones);
            sqlConnection.Open();
            int idHallazgo = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();
            return idHallazgo;
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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Update Hallazgo " +
                                                    "set codigoAccion = @codigoAccion " +
                                                    ",fechaMaximaImplementacion = @fechaMaximaImplementacion " +
                                                    ",idEstado = @idEstado " +
                                                    ",observaciones = @observaciones " +
                                                    ",idUsuario = @idUsuario " +
                                                    "where idHallazgo = @idHallazgo;", sqlConnection);


            sqlCommand.Parameters.AddWithValue("@idUsuario", hallazgo.usuario.idUsuario);
            sqlCommand.Parameters.AddWithValue("@fechaMaximaImplementacion", hallazgo.fechaMaximaImplementacion);
            sqlCommand.Parameters.AddWithValue("@codigoAccion", hallazgo.codigoAccion);
            sqlCommand.Parameters.AddWithValue("@idEstado", hallazgo.estado.idEstado);
            sqlCommand.Parameters.AddWithValue("@observaciones", hallazgo.observaciones);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();


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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete Hallazgo " +
                                                    "where idHallazgo = @idHallazgo;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idHallazgo", hallazgo.idHallazgo);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();


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

            List<Hallazgo> listaHallazgos = new List<Hallazgo>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"SELECT h.idHallazgo,u.idUsuario,
              u.nombre,h.fechaMaximaImplementacion,
              h.codigoAccion, e.idEstado, e.descripcion, h.observaciones
              FROM Hallazgo h, Estado e, Usuario u, Reunion_ElementoRevisar_Hallazgo reh
              WHERE h.idEstado = e.idEstado and h.idUsuario = u.idUsuario and
              h.idHallazgo = reh.idHallazgo and reh.idReunion = @idReunion", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Hallazgo hallazgo = new Hallazgo();

                hallazgo.idHallazgo = Convert.ToInt32(reader["idHallazgo"].ToString());
                hallazgo.fechaMaximaImplementacion = Convert.ToDateTime(reader["fechaMaximaImplementacion"].ToString());
                hallazgo.codigoAccion = reader["codigoAccion"].ToString();
                hallazgo.observaciones = reader["observaciones"].ToString();

                Estado estado = new Estado();
                estado.idEstado = Convert.ToInt32(reader["idEstado"].ToString());
                estado.descripcionEstado = reader["descripcion"].ToString();

                Usuario usuario = new Usuario();
                usuario.idUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.nombre = reader["nombre"].ToString();

                hallazgo.estado = estado;
                hallazgo.usuario = usuario;
                listaHallazgos.Add(hallazgo);
            }
            sqlConnection.Close();
            return listaHallazgos;
        }



        /// <summary>
        /// Priscilla Mena
        /// 21/11/2018
        /// Efecto: elimina una Hallazgo en la base de datos
        /// Requiere: Hallazgo 
        /// Modifica: Hallazgoes
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public void eliminarHallazgo(Reunion reunion)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete Hallazgo " +
                                                    "where idHallazgo = @idHallazgo;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idHallazgo", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();


        }


    }
}
