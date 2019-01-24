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
    public partial class VerElementoRevisar : System.Web.UI.Page
    {
        #region variables globales
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el ElementoRevisar
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2, 9 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {
                ElementoRevisar elementoRevisar = (ElementoRevisar)Session["ElementoRevisarVer"];
                txtDescripcionElementoRevisar.Text = elementoRevisar.descripcionElemento;

            }

        }
        #endregion

        #region eventos




        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de ElementoRevisars
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarElementoRevisar.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}