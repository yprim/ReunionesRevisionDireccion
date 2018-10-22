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
    ///19/09/2018
    ///Clase para administrar las consultas sql para los estados de Hallazgo
    /// </summary>
    public class EstadoDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

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

            List<Estado> listaEstados = new List<Estado>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select e.* from  estado e;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Estado estado = new Estado();

                estado.idEstado = Convert.ToInt32(reader["idEstado"].ToString());
                estado.descripcionEstado = reader["descripcion"].ToString();

                listaEstados.Add(estado);
            }

            sqlConnection.Close();

            return listaEstados;
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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into estado(descripcion)
                                                    values(@descripcion);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@descripcion", estado.descripcionEstado);


            sqlConnection.Open();
            int idEstado = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idEstado;
        }

        /// <summary>
        /// Priscilla Mena
        /// 12/septiembnre/2018
        /// Efecto: actualiza un estado
        /// Requiere: estado a modificar
        /// Modifica: estado
        /// Devuelve: -
        /// </summary>
        /// <param name="Estado"></param>
        public void actualizarEstado(Estado estado)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Update estado " +
                                                    "set descripcion = @descripcion " +
                                                    "where idEstado = @idEstado;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idEstado", estado.idEstado);
            sqlCommand.Parameters.AddWithValue("@descripcion", estado.descripcionEstado);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete estado " +
                                               "where idEstado = @idEstado;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idEstado", estado.idEstado);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

    }
}
