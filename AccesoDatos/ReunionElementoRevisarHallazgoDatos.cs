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
    /// 22/11/2018
    //////Clase para administrar las consultas sql para Hallazgos
    public class ReunionElementoRevisarHallazgoDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: guarda en la base de datos una asociación entre la reunion con el elemento a revisar y hallazgo
        /// Requiere: Reunión, ElementoRevisar, Hallazgo
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar_Hallazgo
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarReunionElementoHallazgo(Reunion reunion, ElementoRevisar elementoRevisar, Hallazgo hallazgo)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("INSERT Reunion_ElementoRevisar_Hallazgo (idReunion, idElemento, idHallazgo) " +
                "values(@idReunion,@idElemento,@idHallazgo);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idElemento", elementoRevisar.idElemento);
            sqlCommand.Parameters.AddWithValue("@idHallazgo", hallazgo.idHallazgo);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }




        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: método que elimina la asociacion entre la reunion con el elemento a revisar y hallazgo
        /// Requiere: Reunión, ElementoRevisar, Hallazgo
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar_Hallazgo
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// <param name="elementoRevisar"></param>
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElementoHallazgo(Reunion reunion, ElementoRevisar elementoRevisar, Hallazgo hallazgo)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Reunion_ElementoRevisar_Hallazgo WHERE idReunion = @idReunion and idElemento = @idElemento and idHallazgo = @idHallazgo", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idElemento", elementoRevisar.idElemento);
            sqlCommand.Parameters.AddWithValue("@idHallazgo", hallazgo.idHallazgo);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }



        /// <summary>
        /// Priscilla Mena
        /// 14/12/2018
        /// Efecto: método que elimina todas las asociaciones que poseen ese hallazgo
        /// Requiere: Reunión, ElementoRevisar, Hallazgo
        /// Modifica: inserta en la base de datos un registro de Reunion_ElementoRevisar_Hallazgo
        /// Devuelve: -
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElementoHallazgo( Hallazgo hallazgo)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Reunion_ElementoRevisar_Hallazgo WHERE idHallazgo = @idHallazgo", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idHallazgo", hallazgo.idHallazgo);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        /// 22/11/2018
        /// Efecto: método que elimina  todas las relaciones que contengan esa reunión
        /// Requiere: Reunión
        /// Modifica: -
        /// Devuelve: -
        /// <param name="reunion"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarReunionElementoHallazgo(Reunion reunion)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Reunion_ElementoRevisar_Hallazgo WHERE idReunion = @idReunion", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();


        }

        /// <summary>
        /// Priscilla Mena
        /// 14/12/2018
        /// Efecto: recupera el elemento a revisar asociado a ese hallazgo
        /// Requiere: Hallazgo
        /// Modifica: -
        /// Devuelve: ElemenetoRevisar
        /// <param name="hallazgo"></param>
        /// </summary>
        /// <returns></returns>
        public ElementoRevisar getElementoHallazgo(Reunion reunion,Hallazgo hallazgo)
        {
            ElementoRevisar elemento = new ElementoRevisar();
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select e.idElemento, e.descripcionElemento 
FROM ElementoRevisar e, Reunion_ElementoRevisar_Hallazgo reh
where reh.idReunion = @idReunion and reh.idHallazgo = @idHallazgo and 
e.idElemento = reh.idElemento; ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@idHallazgo", hallazgo.idHallazgo);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {

                elemento.idElemento = Convert.ToInt32(reader["idElemento"].ToString());
                elemento.descripcionElemento = reader["descripcionElemento"].ToString();

            }


            sqlConnection.Close();
            return elemento;





        }



    }
}
