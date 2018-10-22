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
    ///Clase para administrar las consultas sql para los Elementos a Revisar 
    /// </summary>
    public class ElementoRevisarDatos
    {
        private ConexionDatos conexion = new ConexionDatos();

        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: devuelve una lista con todos los elementoRevisar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de ElementoRevisars
        /// </summary>
        /// <returns></returns>
        public List<ElementoRevisar> getElementosRevisar()
        {

            List<ElementoRevisar> listaElementoRevisar = new List<ElementoRevisar>();

            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("select e.* from  elementoRevisar e;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ElementoRevisar elementoRevisar = new ElementoRevisar();

                elementoRevisar.idElemento = Convert.ToInt32(reader["idElemento"].ToString());
                elementoRevisar.descripcionElemento = reader["descripcionElemento"].ToString();

                listaElementoRevisar.Add(elementoRevisar);
            }

            sqlConnection.Close();

            return listaElementoRevisar;
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/sptiembre/2018
        /// Efecto: inserta en la base de datos un elementoRevisar
        /// Requiere: elementoRevisar
        /// Modifica: -
        /// Devuelve: id del elementoRevisar insertado
        /// </summary>
        /// <param name="elementoRevisar"></param>
        /// <returns></returns>
        public int insertarElementoRevisar(ElementoRevisar elementoRevisar)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into elementoRevisar(descripcionElemento)
                                                    values(@descripcionElemento);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@descripcionElemento", elementoRevisar.descripcionElemento);


            sqlConnection.Open();
            int idElementoRevisar = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idElementoRevisar;
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/septiembnre/2018
        /// Efecto: actualiza un elementoRevisar
        /// Requiere: elementoRevisar a modificar
        /// Modifica: elementoRevisar
        /// Devuelve: -
        /// </summary>
        /// <param name="elementoRevisar"></param>
        public void actualizarElementoRevisar(ElementoRevisar elementoRevisar)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Update elementoRevisar " +
                                                    "set descripcionElemento = @descripcion " +
                                                    "where idElemento = @idElementoRevisar;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idElementoRevisar", elementoRevisar.idElemento);
            sqlCommand.Parameters.AddWithValue("@descripcion", elementoRevisar.descripcionElemento);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        /// 20/septiembre/2018
        /// Efecto: Elimina un elementoRevisar 
        /// Requiere: elementoRevisar
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="elementoRevisar"></param>
        public void eliminarElementoRevisar(ElementoRevisar elementoRevisar)
        {
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand("Delete elementoRevisar " +
                                               "where idElemento = @idElementoRevisar;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@idElementoRevisar", elementoRevisar.idElemento);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: recupera todos los elementos a revisar que no estan asociados a una reunión
        /// Requiere: reunion
        /// Modifica: -
        /// Devuelve: lista de elementos a revisar
        /// </summary>
        /// <param name="reunion"></param>
        public List<ElementoRevisar> getElementosNoEstanEnReunion(Reunion reunion)
        {
            List<ElementoRevisar> listaElementos = new List<ElementoRevisar>();
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select E.idElemento,E.descripcionElemento
                from ElementoRevisar E
                 where  E.idElemento not in (select RE.idElemento 
                 from Reunion_ElementoRevisar RE 
                 where RE.idReunion = @idReunion ) 
             order by E.descripcionElemento;", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
               
                ElementoRevisar elemento = new ElementoRevisar();

                elemento.idElemento= Convert.ToInt32(reader["idElemento"].ToString());
                elemento.descripcionElemento = reader["descripcionElemento"].ToString();
                listaElementos.Add(elemento);
            }

            sqlConnection.Close();

            return listaElementos;

        }

        /// <summary>
        /// Priscilla Mena
        /// 10/10/2018
        /// Efecto: recupera todos los elementos a revisar que  estan asociados a una reunión en específico
        /// Requiere: reunion
        /// Modifica: -
        /// Devuelve: lista de elementos a revisar
        /// </summary>
        /// <param name="reunion"></param>
        public List<ElementoRevisar> getElementosEstanEnReunion(Reunion reunion)
        {
            List<ElementoRevisar> listaElementos = new List<ElementoRevisar>();
            SqlConnection sqlConnection = conexion.conexionRRD();

            SqlCommand sqlCommand = new SqlCommand(@"select E.idElemento,E.descripcionElemento
               from ElementoRevisar E,Reunion_ElementoRevisar RE 
                where RE.idReunion = @idReunion  and E.idElemento = RE.idElemento
                 order by E.descripcionElemento;", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@idReunion", reunion.idReunion);

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                ElementoRevisar elemento = new ElementoRevisar();

                elemento.idElemento = Convert.ToInt32(reader["idElemento"].ToString());
                elemento.descripcionElemento = reader["descripcionElemento"].ToString();
                listaElementos.Add(elemento);
            }

            sqlConnection.Close();

            return listaElementos;

        }

    }
}
    
