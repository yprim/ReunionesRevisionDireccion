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
    public partial class EditarTipo : System.Web.UI.Page
    {
        #region variables globales
        TipoServicios tipoServicios = new TipoServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tipo tipo = (Tipo)Session["tipoEditar"];
                txtDescripcionTipo.Text = tipo.descripcion;
                txtDescripcionTipo.Attributes.Add("oninput", "validarTexto(this)");
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

            #region validacion descripcion tipo

            String DescripcionTipo = txtDescripcionTipo.Text;

            if (DescripcionTipo.Trim() == "")
            {
                txtDescripcionTipo.CssClass = "form-control alert-danger";
                divDescripcionTipoIncorrecto.Style.Add("display", "block");
                lblDescripcionTipoIncorrecto.Visible = true;

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
        protected void txtDescripcionTipo_Changed(object sender, EventArgs e)
        {
            txtDescripcionTipo.CssClass = "form-control";
            lblDescripcionTipo.Visible = false;
        }

        /// <summary>
        /// Priscilla Mena
        /// 07/09/2018
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
       ///redireccion a la pantalla de Administracion de tipos
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
                Tipo tipo = (Tipo)Session["tipoEditar"];
                tipo.descripcion = txtDescripcionTipo.Text;

                tipoServicios.actualizarTipo(tipo);

                String url = Page.ResolveUrl("~/Catalogos/AdministrarTipo.aspx");
                Response.Redirect(url);
            }


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