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
    public partial class AdministrarTipo : System.Web.UI.Page
    {
        #region variables globales
        TipoServicios tipoServicios = new TipoServicios();
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

                Session["listaTipos"] = null;
                Session["tipoEditar"] = null;
                Session["tipoEliminar"] = null;
                cargarDatosTblTipos();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo para llenar los datos de la tabla con los tipos que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblTipos()
        {
            List<Tipo> listaTipos = new List<Tipo>();
            listaTipos = tipoServicios.getTipos();
            rpTipo.DataSource = listaTipos;
            rpTipo.DataBind();

            Session["listaTipos"] = listaTipos;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo tipo,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoTipo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un tipo,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idTipo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Tipo> listaTipos = (List<Tipo>)Session["listaTipos"];

            Tipo tipoEditar = new Tipo();

            foreach (Tipo tipo in listaTipos)
            {
                if (tipo.idTipo == idTipo)
                {
                    tipoEditar = tipo;
                    break;
                }
            }

            Session["tipoEditar"] = tipoEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarTipo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un tipo,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idTipo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Tipo> listaTipos = (List<Tipo>)Session["listaTipos"];

            Tipo tipoEliminar = new Tipo();

            foreach (Tipo tipo in listaTipos)
            {
                if (tipo.idTipo == idTipo)
                {
                    tipoEliminar = tipo;
                    break;
                }
            }

            Session["tipoEliminar"] = tipoEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarTipo.aspx");
            Response.Redirect(url);

        }


        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un tipo,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idTipo = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Tipo> listaTipos = (List<Tipo>)Session["listaTipos"];

            Tipo tipoVer = new Tipo();

            foreach (Tipo tipo in listaTipos)
            {
                if (tipo.idTipo == idTipo)
                {
                    tipoVer = tipo;
                    break;
                }
            }

            Session["tipoVer"] = tipoVer;

            String url = Page.ResolveUrl("~/Catalogos/VerTipo.aspx");
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
        protected void rpTipo_ItemDataBound(object sender, RepeaterItemEventArgs e)
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