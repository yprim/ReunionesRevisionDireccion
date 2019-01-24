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
    public partial class AdministrarElementoRevisar : System.Web.UI.Page
    {
        #region variables globales
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        public static int rol = 0;
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPeromitidos = { 2, 9 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);

            if (!Page.IsPostBack)
            {
                //si el rol es de asistente (9) se desabilita el boton de nueva reunion
                rol = (int)Session["rol"];

                if (rol == 9)
                {
                    btnNuevo.Visible = false;
                }
                Session["listaElementoRevisar"] = null;
                Session["elementoRevisarEditar"] = null;
                Session["elementoRevisarEliminar"] = null;
                cargarDatosTblElementoRevisars();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo para llenar los datos de la tabla con los Elementos a Revisar que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblElementoRevisars()
        {
            List<ElementoRevisar> listaElementoRevisar = new List<ElementoRevisar>();
            listaElementoRevisar = elementoRevisarServicios.getElementosRevisar();
            rpElementoRevisar.DataSource = listaElementoRevisar;
            rpElementoRevisar.DataBind();

            Session["listaElementoRevisar"] = listaElementoRevisar;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo ElementoRevisar,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoElementoRevisar.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un ElementoRevisar,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idElementoRevisar = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<ElementoRevisar> listaElementoRevisars = (List<ElementoRevisar>)Session["listaElementoRevisar"];

            ElementoRevisar ElementoRevisarEditar = new ElementoRevisar();

            foreach (ElementoRevisar ElementoRevisar in listaElementoRevisars)
            {
                if (ElementoRevisar.idElemento == idElementoRevisar)
                {
                    ElementoRevisarEditar = ElementoRevisar;
                    break;
                }
            }

            Session["ElementoRevisarEditar"] = ElementoRevisarEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarElementoRevisar.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un ElementoRevisar,
        /// se activa cuando se presiona el boton de elimiar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idElementoRevisar = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<ElementoRevisar> listaElementoRevisars = (List<ElementoRevisar>)Session["listaElementoRevisar"];

            ElementoRevisar ElementoRevisarEliminar = new ElementoRevisar();

            foreach (ElementoRevisar ElementoRevisar in listaElementoRevisars)
            {
                if (ElementoRevisar.idElemento == idElementoRevisar)
                {
                    ElementoRevisarEliminar = ElementoRevisar;
                    break;
                }
            }

            Session["ElementoRevisarEliminar"] = ElementoRevisarEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarElementoRevisar.aspx");
            Response.Redirect(url);

        }





        /// <summary>
        /// Priscilla Mena
        /// 14/01/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un ElementoRevisar,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idElementoRevisar = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<ElementoRevisar> listaElementoRevisars = (List<ElementoRevisar>)Session["listaElementoRevisar"];

            ElementoRevisar elementoRevisarVer = new ElementoRevisar();

            foreach (ElementoRevisar ElementoRevisar in listaElementoRevisars)
            {
                if (ElementoRevisar.idElemento == idElementoRevisar)
                {
                    elementoRevisarVer = ElementoRevisar;
                    break;
                }
            }

            Session["ElementoRevisarVer"] = elementoRevisarVer;

            String url = Page.ResolveUrl("~/Catalogos/VerElementoRevisar.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        ///Priscilla Mena    
        /// 23/ene/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpElementoRevisar_ItemDataBound(object sender, RepeaterItemEventArgs e)
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