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
    public partial class AdministrarHallazgo : System.Web.UI.Page
    {
        #region variables globales
        HallazgoServicios hallazgoServicios = new HallazgoServicios();
        public static int rol = 0;
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPeromitidos = { 2,9 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);

            if (!Page.IsPostBack)
            {
                //si el rol es de asistente (9) se desabilita el boton de nueva reunion
                rol = (int)Session["rol"];

                if (rol == 9)
                {
                    btnNuevo.Visible = false;
                }
                Reunion reunionHallazgos =(Reunion) Session["ReunionHallazgos"];
                Session["listaHallazgo"] = null;
                Session["HallazgoEditar"] = null;
                Session["HallazgoEliminar"] = null;
                cargarDatosTblHallazgos();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo para llenar los datos de la tabla con los Hallazgos que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblHallazgos()
        {
            Reunion reunionHallazgos = (Reunion)Session["ReunionHallazgos"];
            List<Hallazgo> listaHallazgo = new List<Hallazgo>();
            listaHallazgo = hallazgoServicios.getHallazgosPorReunion(reunionHallazgos);
            rpHallazgo.DataSource = listaHallazgo;
            rpHallazgo.DataBind();

            Session["listaHallazgo"] = listaHallazgo;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Hallazgo,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Hallazgos/NuevoHallazgo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Hallazgo,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idHallazgo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Hallazgo> listaHallazgos = (List<Hallazgo>)Session["listaHallazgo"];

            Hallazgo hallazgoEditar = new Hallazgo();

            foreach (Hallazgo hallazgo in listaHallazgos)
            {
                if (hallazgo.idHallazgo == idHallazgo)
                {
                    hallazgoEditar = hallazgo;
                    break;
                }
            }

            Session["HallazgoEditar"] = hallazgoEditar;

            String url = Page.ResolveUrl("~/Hallazgos/EditarHallazgo.aspx");
            Response.Redirect(url);


        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un Hallazgo,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idHallazgo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Hallazgo> listaHallazgoes = (List<Hallazgo>)Session["listaHallazgo"];

            Hallazgo hallazgoEliminar = new Hallazgo();

            foreach (Hallazgo Hallazgo in listaHallazgoes)
            {
                if (Hallazgo.idHallazgo == idHallazgo)
                {
                    hallazgoEliminar = Hallazgo;
                    break;
                }
            }

            Session["HallazgoEliminar"] = hallazgoEliminar;

            String url = Page.ResolveUrl("~/Hallazgos/EliminarHallazgo.aspx");
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena
        /// 11/01/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un Hallazgo,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idHallazgo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Hallazgo> listaHallazgoes = (List<Hallazgo>)Session["listaHallazgo"];

            Hallazgo hallazgoVer = new Hallazgo();

            foreach (Hallazgo Hallazgo in listaHallazgoes)
            {
                if (Hallazgo.idHallazgo == idHallazgo)
                {
                    hallazgoVer = Hallazgo;
                    break;
                }
            }

            Session["HallazgoVer"] = hallazgoVer;

            String url = Page.ResolveUrl("~/Hallazgos/VerHallazgo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de regresar
        /// redireccion a la pantalla de Administracion de Reuniones y hallazgos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Hallazgos/AdministrarReunionHallazgo.aspx");
            Response.Redirect(url);
        }



        /// <summary>
        /// Priscilla Mena  
        /// 23/ene/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpHallazgo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnEditar = e.Item.FindControl("btnEditar") as LinkButton;
                LinkButton btnEliminar = e.Item.FindControl("btnEliminar") as LinkButton;

                if (rol == 9)
                {
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                }

            }
        }


        #endregion



    }
}