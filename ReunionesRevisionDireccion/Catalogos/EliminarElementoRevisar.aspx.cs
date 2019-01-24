﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReunionesRevisionDireccion.Catalogos
{
    public partial class EliminarElementoRevisar : System.Web.UI.Page
    {
        #region variables globales
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPeromitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);

            if (!IsPostBack)
            {
                ElementoRevisar elementoRevisar = (ElementoRevisar)Session["ElementoRevisarEliminar"];
                txtDescripcionElementoRevisar.Text = elementoRevisar.descripcionElemento;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de ElementoRevisars
        /// elimina el elementoRevisar de la base de datos
        // redireccion a la pantalla de Administracion de ElementoRevisars
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ElementoRevisar ElementoRevisar = (ElementoRevisar)Session["ElementoRevisarEliminar"];
            elementoRevisarServicios.eliminarElementoRevisar(ElementoRevisar);

            String url = Page.ResolveUrl("~/Catalogos/AdministrarElementoRevisar.aspx");
            Response.Redirect(url);
        }


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