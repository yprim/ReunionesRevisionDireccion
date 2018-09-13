using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReunionesRevisionDireccion.Configuracion
{
    public partial class Configuracion : System.Web.UI.Page
    {
        #region Variables
        private Archivo archivo = new Archivo();
        private BaseDatos baseDatos = new BaseDatos();
        private ConexionServicios conexionServicios = new ConexionServicios();
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {
                baseDatos = archivo.leerArchivo();

                /*Base de datos BI*/
                txtNombreServidorCND.Text = baseDatos.servidorRRD;
                txtNombreBdCND.Text = baseDatos.baseRRD;
                txtNombreUsuarioBdCND.Text = baseDatos.usuarioRRD;
                txtContrasenaBdCND.Text = baseDatos.contrasenaRRD;

                /*Base de datos Login*/
                txtNombreServidorLogin.Text = baseDatos.servidorLogin;
                txtNombreBdLogin.Text = baseDatos.baseLogin;
                txtNombreUsuarioBdLogin.Text = baseDatos.usuarioLogin;
                txtContrasenaBdLogin.Text = baseDatos.contrasenaLogin;
            }
        }
        #endregion

        /*
         * Leonardo Carrion
         * 17/04/17
         * Evento que actualiza los datos para conexión de base de datos almacenados en el archivo de texto
         */
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            baseDatos = archivo.leerArchivo();

            /*Base de datos CTL*/
            baseDatos.servidorRRD = txtNombreServidorCND.Text;
            baseDatos.baseRRD = txtNombreBdCND.Text;
            baseDatos.usuarioRRD = txtNombreUsuarioBdCND.Text;
            if (txtContrasenaBdCND.Text.Trim() != "")
            {
                baseDatos.contrasenaRRD = txtContrasenaBdCND.Text;
            }

            /*Base de datos Login*/
            baseDatos.baseLogin = txtNombreBdLogin.Text;
            baseDatos.usuarioLogin = txtNombreUsuarioBdLogin.Text;
            if (txtContrasenaBdLogin.Text.Trim() != "")
            {
                baseDatos.contrasenaLogin = txtContrasenaBdLogin.Text;
            }
            baseDatos.servidorLogin = txtNombreServidorLogin.Text;

            archivo.guardarArchivo(baseDatos);

            (this.Master as Site).Mensaje("Se han actualizado los datos", "Información");
        }
    }
}