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
    }
}
