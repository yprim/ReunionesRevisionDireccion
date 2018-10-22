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
    public partial class EliminarUsuario : System.Web.UI.Page
    {

        #region variables globales
        UsuarioServicios usuarioServicios = new UsuarioServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["UsuarioEliminar"];
                txtDescripcionUsuario.Text = usuario.nombre;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Usuarios
        /// elimina el usuario de la base de datos
        // redireccion a la pantalla de Administracion de Usuarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario Usuario = (Usuario)Session["UsuarioEliminar"];
            usuarioServicios.eliminarUsuario(Usuario);

            String url = Page.ResolveUrl("~/Catalogos/AdministrarUsuario.aspx");
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Usuarios
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarUsuario.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}