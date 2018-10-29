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
 * 20/09/2018
 * Clase para administrar las consultas sql para las reuniones
 */
    public class ReunionDatos
    {
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: devuelve una lista con todas las reuniones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de tipos
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Reunion> getReuniones()
        {

            List<Reunion> listaReuniones = new List<Reunion>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select r.idReunion, r.anno, r.mes, r.consecutivo, r.numero, t.descripcionTipo, t.idTipo " +
                "from Reunion r, Tipo t where r.idTipo = t.idTipo order by r.anno desc, r.numero desc; ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Reunion reunion = new Reunion();

                reunion.idReunion = Convert.ToInt32(reader["idReunion"].ToString());
                reunion.anno = Convert.ToInt32(reader["anno"].ToString());
                reunion.mes = reader["mes"].ToString();
                reunion.consecutivo= reader["consecutivo"].ToString();
                reunion.numero = Convert.ToInt32(reader["numero"].ToString());



                Tipo tipo = new Tipo();
                tipo.idTipo = Convert.ToInt32(reader["idTipo"].ToString());
                tipo.descripcion = reader["descripcionTipo"].ToString();

                reunion.tipo = tipo;

                listaReuniones.Add(reunion);
            }

            sqlConnection.Close();

            return listaReuniones;
        }

        
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: recupera todas las Reuniones de la base de datos que estan asociadas a un tipo en especifico
        /// Requiere: Tipo 
        /// Modifica: -
        /// Devuelve: lista de Reuniones
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public List<Reunion> getReunionesPorTipo(Tipo tipo)
        {

            List<Reunion> listaReuniones = new List<Reunion>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select r.idReunion, r.anno, r.mes, r.consecutivo, r.numero, t.descripcionTipo, t.idTipo" +
                "from Reunion r, Tipo t where r.idTipo = t.idTipo; ; ", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idTipo", tipo.idTipo);


            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Reunion reunion = new Reunion();

                reunion.idReunion = Convert.ToInt32(reader["idReunion"].ToString());
                reunion.anno = Convert.ToInt32(reader["anno"].ToString());
                reunion.mes = reader["mes"].ToString();
                reunion.consecutivo = reader["consecutivo"].ToString();
                reunion.numero = Convert.ToInt32(reader["numero"].ToString());



                Tipo t = new Tipo();
                t.idTipo = Convert.ToInt32(reader["idTipo"].ToString());
                t.descripcion = reader["descripcionTipo"].ToString();

                reunion.tipo = t;

                listaReuniones.Add(reunion);
            }

            sqlConnection.Close();

            return listaReuniones;
        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Inserta una reunion en la base de datos
        /// Requiere: Reunion 
        /// Modifica: Reuniones
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public int insertarReunion(Reunion reunion)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            string consulta = @"INSERT INTO Reunion (anno, mes,idTipo,consecutivo,numero)
                                                     values(@anno, @mes,@idTipo,@consecutivo,@numero);
                                                        SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            Random r = new Random();
            sqlCommand.Parameters.AddWithValue("@idTipo", reunion.tipo.idTipo);
            sqlCommand.Parameters.AddWithValue("@anno", reunion.anno);
            sqlCommand.Parameters.AddWithValue("@mes", reunion.mes);
            sqlCommand.Parameters.AddWithValue("@consecutivo", reunion.consecutivo);
            sqlCommand.Parameters.AddWithValue("@numero", reunion.numero);
            //  sqlCommand.Parameters.AddWithValue("@consecutivo",r.Next(1, 100));
            sqlConnection.Open();
          

            int idReunion = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idReunion;
        }

     
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: actualiza una Reunion en la base de datos
        /// Requiere: Reunion 
        /// Modifica: Reuniones
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public void actualizarReunion(Reunion reunion)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Update Reunion " +
                                                    "set anno = @anno " +
                                                    ",mes = @mes "+
                                                    ",idTipo = @idTipo "+
                                                    "where idReunion = @idReunion;", sqlConnection);

        
            sqlCommand.Parameters.AddWithValue("@anno", reunion.anno);
            sqlCommand.Parameters.AddWithValue("@mes", reunion.mes);
            sqlCommand.Parameters.AddWithValue("@idTipo", reunion.tipo.idTipo);
            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);




            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
          

        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: elimina una Reunion en la base de datos
        /// Requiere: Reunion 
        /// Modifica: Reuniones
        /// Devuelve: -
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public void eliminarReunion(Reunion reunion)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete Reunion " +
                                                    "where idReunion = @idReunion;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

      
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: compara todos los datos para devolver la reunion correspondiente
        /// Requiere: Reunion 
        /// Modifica: -
        /// Devuelve: Reunion
        /// </summary>
        /// <param name="reunion"></param>
        /// <returns></returns>
        public Reunion getReunionPorDatos(Reunion reunion)
        {

            Reunion reunionSalida = new Reunion();

            reunionSalida.idReunion = reunion.idReunion;
            reunionSalida.tipo = reunion.tipo;
            reunionSalida.anno = reunion.anno;
            reunionSalida.mes = reunion.mes;
          

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select * " +
                "from Reunion " +
                "where idTipo = @idTipo and anno = @anno and mes = @mes;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idTipo", reunion.tipo.idTipo);
            sqlCommand.Parameters.AddWithValue("@anno", reunion.anno);
            sqlCommand.Parameters.AddWithValue("@mes", reunion.mes);


            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                reunionSalida.idReunion = Convert.ToInt32(reader["idReunion"].ToString());
            }

            sqlConnection.Close();

            return reunionSalida;
        }

        /// <summary>
        /// Priscilla Mena
        /// 22/10/2018
        /// Efecto: recupera el ultimo numero de las reuniones de la base de datos
        /// Requiere: numero int 
        /// Modifica: -
        /// Devuelve: numero int
        /// </summary>
        /// <param name="anno"></param>
        /// <returns></returns>
        public int getUltimoNumeroPorAnno(int anno)
        {
            int numero = 0;

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select max(numero) as numero from Reunion R where R.anno = @anno;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@anno", anno);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                numero = reader["numero"].ToString() == "" ? 0 : Convert.ToInt32(reader["numero"].ToString());
            }

            sqlConnection.Close();

            return numero;
        }
    }
}
