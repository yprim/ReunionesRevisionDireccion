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
    * 24/10/2018
    * Clase para administrar las consultas sql para los archivos de reunión
    */
    public class ArchivoReunionDatos
    { 
     private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: recupera todos los archivos de reuniones de la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de archivos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<ArchivoReunion> getArchivosReunion()
    {

        List<ArchivoReunion> listaArchivosReunion = new List<ArchivoReunion>();

        SqlConnection sqlConnection = conexion.conexionRRD();

        SqlCommand sqlCommand = new SqlCommand(@"select AR.idArchivoReunion, AR.idReunion, AR.fechaCreacion,
        AR.creadoPor, AR.nombreArchivo, AR.rutaArchivo
        from archivoReunion AR order by AR.nombreArchivo; ", sqlConnection);

        SqlDataReader reader;
        sqlConnection.Open();
        reader = sqlCommand.ExecuteReader();

        while (reader.Read())
        {
            ArchivoReunion archivoReunion = new ArchivoReunion();
            archivoReunion.idArchivoReunion = Convert.ToInt32(reader["idArchivoReunion"].ToString());
            archivoReunion.fechaCreacion = Convert.ToDateTime(reader["fechaCreacion"].ToString());
            archivoReunion.creadoPor = reader["creadoPor"].ToString();
            archivoReunion.nombreArchivo = reader["nombreArchivo"].ToString();
            archivoReunion.rutaArchivo = reader["rutaArchivo"].ToString();
         

            listaArchivosReunion.Add(archivoReunion);
        }

        sqlConnection.Close();

        return listaArchivosReunion;
    }


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: recupera todos los archivos de Reuniones de la base de datos que estan asociados a una Reunion en especifico
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de archivos
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public List<ArchivoReunion> getArchivosReunionPorIdReunion(Reunion reunion)
    {

        List<ArchivoReunion> listaArchivosReunion = new List<ArchivoReunion>();

        SqlConnection sqlConnection = conexion.conexionRRD();

        SqlCommand sqlCommand = new SqlCommand(@"select AR.idArchivoReunion, AR.idReunion, AR.fechaCreacion, 
        AR.creadoPor, AR.nombreArchivo, AR.rutaArchivo 
        from archivoReunion AR 
        where AR.idReunion = @idReunion 
        order by AR.nombreArchivo;", sqlConnection);

        sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

        SqlDataReader reader;
        sqlConnection.Open();
        reader = sqlCommand.ExecuteReader();

        while (reader.Read())
        {
            ArchivoReunion ArchivoReunion = new ArchivoReunion();
          

            ArchivoReunion.idArchivoReunion = Convert.ToInt32(reader["idArchivoReunion"].ToString());
            ArchivoReunion.fechaCreacion = Convert.ToDateTime(reader["fechaCreacion"].ToString());
            ArchivoReunion.creadoPor = reader["creadoPor"].ToString();
            ArchivoReunion.nombreArchivo = reader["nombreArchivo"].ToString();
            ArchivoReunion.rutaArchivo = reader["rutaArchivo"].ToString();
     

            listaArchivosReunion.Add(ArchivoReunion);
        }

        sqlConnection.Close();

        return listaArchivosReunion;
    }


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: inserta un archivo Reunion en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve:  devuelve el id del archivo ingresado
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int insertarArchivoReunion(ArchivoReunion archivoReunion)
    {
        SqlConnection connection = conexion.conexionRRD();

        String consulta
            = @"INSERT archivoReunion (idReunion, fechaCreacion, creadoPor, nombreArchivo, rutaArchivo) 
                    VALUES (@idReunion, @fechaCreacion, @creadoPor, @nombreArchivo, @rutaArchivo);
                    SELECT SCOPE_IDENTITY();";

        SqlCommand command = new SqlCommand(consulta, connection);
        command.Parameters.AddWithValue("@idReunion", archivoReunion.reunion.idReunion);
        command.Parameters.AddWithValue("@fechaCreacion", archivoReunion.fechaCreacion);
        command.Parameters.AddWithValue("@creadoPor", archivoReunion.creadoPor);
        command.Parameters.AddWithValue("@nombreArchivo", archivoReunion.nombreArchivo);
        command.Parameters.AddWithValue("@rutaArchivo", archivoReunion.rutaArchivo);

        connection.Open();
        int idArchivo = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return idArchivo;
    }


        /// <summary>
        /// Priscilla Mena
        /// 24/octubre/2018
        /// Efecto: metodo que elimina un archivo Reunion en la base de datos
        /// Requiere: -
        /// Modifica: elimina el registro del archivo de la base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="archivoReunion"></param>
        /// <returns></returns>
        public void eliminarArchivoReunion(ArchivoReunion archivoReunion)
    {

        SqlConnection sqlConnection = conexion.conexionRRD();

        SqlCommand sqlCommand = new SqlCommand("Delete ArchivoReunion " +
                                                "where idArchivoReunion = @idArchivoReunion;", sqlConnection);

        sqlCommand.Parameters.AddWithValue("@idArchivoReunion", archivoReunion.idArchivoReunion);

        sqlConnection.Open();
        sqlCommand.ExecuteReader();

        sqlConnection.Close();
    }
}
}
