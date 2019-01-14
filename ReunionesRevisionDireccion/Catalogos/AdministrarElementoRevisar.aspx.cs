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


        #endregion
    }
}