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
    public partial class EliminarTipo : System.Web.UI.Page
    {

        #region variables globales
        TipoServicios tipoServicios = new TipoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tipo tipo = (Tipo)Session["tipoEliminar"];
                txtDescripcionTipo.Text = tipo.descripcion;
                
            }

        }
        #endregion

        #region eventos

       
        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de tipos
        /// elimina el tipo de la base de datos
        // redireccion a la pantalla de Administracion de tipos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Tipo tipo = (Tipo)Session["tipoEliminar"];
            tipoServicios.eliminarTipo(tipo);

            String url = Page.ResolveUrl("~/Catalogos/AdministrarTipo.aspx");
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de tipos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarTipo.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}