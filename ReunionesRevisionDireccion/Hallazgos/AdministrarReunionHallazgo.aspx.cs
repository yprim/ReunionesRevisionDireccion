using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReunionesRevisionDireccion.Catalogos
{
    public partial class AdministrarReunionHallazgo : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios ReunionServicios = new ReuniónServicios();
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPeromitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);

            if (!Page.IsPostBack)
            {
                Session["listaReunion"] = null;
                Session["ReunionHallazgos"] = null;

                cargarDatosTblReunions();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo para llenar los datos de la tabla con las reuniones que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblReunions()
        {
            List<Reunion> listaReunion = new List<Reunion>();
            listaReunion = ReunionServicios.getReuniones();
            rpReunion.DataSource = listaReunion;
            rpReunion.DataBind();

            Session["listaReunion"] = listaReunion;
            Session["ReunionHallazgos"] = null;
        }
        #endregion

        #region eventos

      

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ven los hallazgos dde esa reunión
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnReunionHallazgo_Click(object sender, EventArgs e)
        {
            int idReunion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Reunion> listaReuniones = (List<Reunion>)Session["listaReunion"];

            Reunion reunionHallazgos = new Reunion();

            foreach (Reunion reunion in listaReuniones)
            {
                if (reunion.idReunion == idReunion)
                {
                    reunionHallazgos = reunion;
                    break;
                }
            }

            Session["ReunionHallazgos"] = reunionHallazgos;

            String url = Page.ResolveUrl("~/Catalogos/AdministrarHallazgo.aspx");
            Response.Redirect(url);


        }
    }

}
#endregion