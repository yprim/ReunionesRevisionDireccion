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
    public partial class AdministrarEstado : System.Web.UI.Page
    {
        #region variables globales
        EstadoServicios estadoServicios = new EstadoServicios();
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
                Session["listaEstados"] = null;
                Session["estadoEditar"] = null;
                Session["estadoEliminar"] = null;
                cargarDatosTblEstados();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo para llenar los datos de la tabla con los Estados que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblEstados()
        {
            List<Estado> listaEstados = new List<Estado>();
            listaEstados = estadoServicios.getEstados();
            rpEstado.DataSource = listaEstados;
            rpEstado.DataBind();

            Session["listaEstados"] = listaEstados;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Estado,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoEstado.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Estado,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idEstado = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Estado> listaEstados = (List<Estado>)Session["listaEstados"];

            Estado estadoEditar = new Estado();

            foreach (Estado Estado in listaEstados)
            {
                if (Estado.idEstado == idEstado)
                {
                    estadoEditar = Estado;
                    break;
                }
            }

            Session["estadoEditar"] = estadoEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarEstado.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un Estado,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEstado = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Estado> listaEstados = (List<Estado>)Session["listaEstados"];

            Estado estadoEliminar = new Estado();

            foreach (Estado Estado in listaEstados)
            {
                if (Estado.idEstado == idEstado)
                {
                    estadoEliminar = Estado;
                    break;
                }
            }

            Session["estadoEliminar"] = estadoEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarEstado.aspx");
            Response.Redirect(url);

        }







        #endregion
    }
}