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
 public partial class NuevoEstado : System.Web.UI.Page
{
    #region variables globales
    EstadoServicios estadoServicios = new EstadoServicios();
    #endregion

    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
        //si no tiene permiso de ver la pagina se redirecciona a login
        int[] rolesPermitidos = { 2 };
        Utilidades.escogerMenu(Page, rolesPermitidos);

        if (!IsPostBack)
        {
            txtDescripcionEstado.Attributes.Add("oninput", "validarTexto(this)");
        }

    }

    #endregion


    #region logica


    /// <summary>
    /// Priscilla Mena
    /// 19/09/2018
    /// Efecto:Metodo que valida los campos que debe ingresar el usuario
    /// devuelve true si todos los campos esta con datos correctos
    /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuentran mal
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

        String descripcionEstado = txtDescripcionEstado.Text;

        if (descripcionEstado.Trim() == "")
        {
            txtDescripcionEstado.CssClass = "form-control alert-danger";
            divDescripcionEstadoIncorrecto.Style.Add("display", "block");

            validados = false;
        }
        #endregion

        return validados;
    }

    #endregion

    #region eventos
    /// <summary>
    /// Priscilla Mena
    /// 19/09/2018
    /// Efecto:Metodo que se activa cuando se cambia el nombre
    /// Requiere: -
    /// Modifica: -
    /// Devuelve: -
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    protected void txtNombrePais_TextChanged(object sender, EventArgs e)
    {
        txtDescripcionEstado.CssClass = "form-control";
        lblDescripcionEstadoIncorrecto.Visible = false;
    }


    /// <summary>
    /// Priscilla Mena
    /// 19/09/2018
    /// Efecto:Metodo que se activa cuando se da click al boton de guardar
    /// valida que todos los campos se hayan ingrsado correctamente 
    /// y guarda los datos en la base de datos 
    /// redirecciona a la pantalla de administacion de Estados
    /// Requiere: -
    /// Modifica: -
    /// Devuelve: -
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        //se validan los campos antes de guardar los datos en la base de datos
        if (validarCampos())
        {
            Estado estado = new Estado();
            estado.descripcionEstado = txtDescripcionEstado.Text;

            estadoServicios.insertarEstado(estado);

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