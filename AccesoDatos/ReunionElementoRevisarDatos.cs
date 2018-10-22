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
    /// 09/10/2018
    //////Clase para administrar las consultas sql para los Elementos a Revisar asignados a reuniones
    /// </summary>
    public class ReunionElementoRevisarDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: guarda en la base de datos una asociación entre la reunion con el elemento a revisar
        /// Requiere: Reunión, ElementoRevisar
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarReunionElemento(Reunion reunion, ElementoRevisar elementoRevisar)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("INSERT Reunion_ElementoRevisar (idReunion, idElemento) " +
                "values(@idReunion,@idElemento);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idElemento", elementoRevisar.idElemento);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: método que elimina la asociacion entre la reunion con el elemento a revisar
        /// Requiere: Reunión, ElementoRevisar
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElemento(Reunion reunion, ElementoRevisar elementoRevisar)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Reunion_ElementoRevisar WHERE idReunion = @idReunion and idElemento = @idElemento", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idElemento", elementoRevisar.idElemento);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Priscilla Mena
        /// 09/10/2018
        /// Efecto: metodo que devuelve true si existe un elemento a revisar asociado con una reunión.
        /// Requiere: Reunión, ElementoRevisar
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar
        /// Devuelve: true si el elemento está asociado a una reunión o false si no está asociado
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean elementoAsociadoAReunión(Reunion reunion, ElementoRevisar elementoRevisar)
        {
            Boolean existe = false;

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select R.idReunion " +
                "from Reunion_ElementoRevisar R " +
                "where R.idElemento = @idElemento and R.idReunion = @idReunion;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idElemento", elementoRevisar.idElemento);
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
        /// 09/10/2018
        /// Efecto: devuelve la lista de elementos a revisar que estan asociados a una reunión en específico
        /// Requiere: Reunion
        /// Modifica: -
        /// Devuelve: lista de elementos a revisar
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public List<ElementoRevisar> getElementosAsociadosAReunion(Reunion reunion)
        {
            List<ElementoRevisar> listaElementos = new List<ElementoRevisar>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select E.*
                from Reunion_ElementoRevisar RE, ElementoRevisar E
                where RE.idReunion = @idReunion and E.idElemento = RE.idElemento ;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ElementoRevisar elementoRevisar = new ElementoRevisar();

                elementoRevisar.idElemento = Convert.ToInt32(reader["idElemento"].ToString());
                elementoRevisar.descripcionElemento = reader["descripcionElemento"].ToString();
                listaElementos.Add(elementoRevisar);
            }

            sqlConnection.Close();

            return listaElementos;
        }
    }
}
