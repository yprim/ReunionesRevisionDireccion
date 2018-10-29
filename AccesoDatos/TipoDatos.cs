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
    ///07/09/2018
    ///Clase para administrar las consultas sql para los tipos de reunion
    /// </summary>
    public class TipoDatos
    {

        private ConexionDatos conexion = new ConexionDatos();

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

            List<Tipo> listaTipos = new List<Tipo>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select t.* from  Tipo t order by descripcionTipo;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Tipo tipo = new Tipo();

                tipo.idTipo = Convert.ToInt32(reader["idTipo"].ToString());
                tipo.descripcion = reader["descripcionTipo"].ToString();

                listaTipos.Add(tipo);
            }

            sqlConnection.Close();

            return listaTipos;
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
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into Tipo(descripcionTipo)
                                                    values(@descripcionTipo);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@descripcionTipo", tipo.descripcion);
           

            sqlConnection.Open();
            int idTipo = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idTipo;
        }

        /// <summary>
        /// Priscilla Mena
        /// 12/septiembnre/2018
        /// Efecto: actualiza un tipo
        /// Requiere: tipo a modificar
        /// Modifica: tipo
        /// Devuelve: -
        /// </summary>
        /// <param name="tipo"></param>
        public void actualizarTipo(Tipo tipo)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Update Tipo " +
                                                    "set descripcionTipo = @descripcionTipo " +
                                                    "where idTipo = @idTipo;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idTipo", tipo.idTipo);
            sqlCommand.Parameters.AddWithValue("@descripcionTipo", tipo.descripcion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

           }

        /// <summary>
        /// Priscilla Mena
        /// 12/septiembre/2018
        /// Efecto: Elimina un tipo de  la base de datos
        /// Requiere: Tipo
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="tipo"></param>
        public void eliminarTipo(Tipo tipo)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete Tipo " +
                                               "where idTipo = @idTipo;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idTipo", tipo.idTipo);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
        
    }
}
