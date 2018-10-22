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
    public partial class AdministrarUsuario : System.Web.UI.Page
    {
        #region variables globales
        UsuarioServicios usuarioServicios = new UsuarioServicios();
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
                Session["listaUsuario"] = null;
                Session["UsuarioEditar"] = null;
                Session["UsuarioEliminar"] = null;
                cargarDatosTblUsuarios();

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
        private void cargarDatosTblUsuarios()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario = usuarioServicios.getUsuarios();
            rpUsuario.DataSource = listaUsuario;
            rpUsuario.DataBind();

            Session["listaUsuario"] = listaUsuario;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo usuario,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoUsuario.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un usuario,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Usuario> listaUsuarios = (List<Usuario>)Session["listaUsuario"];

            Usuario UsuarioEditar = new Usuario();

            foreach (Usuario Usuario in listaUsuarios)
            {
                if (Usuario.idUsuario == idUsuario)
                {
                    UsuarioEditar = Usuario;
                    break;
                }
            }

            Session["UsuarioEditar"] = UsuarioEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarUsuario.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 20/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un usuario,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Usuario> listaUsuarios = (List<Usuario>)Session["listaUsuario"];

            Usuario UsuarioEliminar = new Usuario();

            foreach (Usuario Usuario in listaUsuarios)
            {
                if (Usuario.idUsuario == idUsuario)
                {
                    UsuarioEliminar = Usuario;
                    break;
                }
            }

            Session["UsuarioEliminar"] = UsuarioEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarUsuario.aspx");
            Response.Redirect(url);

        }


        #endregion
    }
}