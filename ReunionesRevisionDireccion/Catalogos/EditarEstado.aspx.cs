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
    public partial class EditarEstado : System.Web.UI.Page
    {
        #region variables globales
        EstadoServicios estadoServicios = new EstadoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Estado estado = (Estado)Session["EstadoEditar"];
                txtDescripcionEstado.Text = estado.descripcionEstado;
                txtDescripcionEstado.Attributes.Add("oninput", "validarTexto(this)");
            }
        }

        #endregion

        #region logica


        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto:Metodo que valida los campos que debe ingresar el usuario
        /// devuelve true si todos los campos esta con datos correctos
        /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuntran mal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            #region validacion descripcion Estado

            String DescripcionEstado = txtDescripcionEstado.Text;

            if (DescripcionEstado.Trim() == "")
            {
                txtDescripcionEstado.CssClass = "form-control alert-danger";
                divDescripcionEstadoIncorrecto.Style.Add("display", "block");
                lblDescripcionEstadoIncorrecto.Visible = true;

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtDescripcionEstado_Changed(object sender, EventArgs e)
        {
            txtDescripcionEstado.CssClass = "form-control";
            lblDescripcionEstado.Visible = false;
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de actualizar los datos en la base de datos
            if (validarCampos())
            {
                Estado estado = (Estado)Session["EstadoEditar"];
                estado.descripcionEstado= txtDescripcionEstado.Text;

                estadoServicios.actualizarEstado(estado);

                String url = Page.ResolveUrl("~/Catalogos/AdministrarEstado.aspx");
                Response.Redirect(url);
            }


        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarEstado.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}