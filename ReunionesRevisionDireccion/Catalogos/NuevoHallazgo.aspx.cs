using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReunionesRevisionDireccion.Catalogos
{
    public partial class NuevoHallazgo : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        ArchivoReunionServicios archivoReunionServicios = new ArchivoReunionServicios();
        UsuarioServicios usuarioServicios = new UsuarioServicios();
        ReunionUsuarioServicios reunionUsuarioServicios = new ReunionUsuarioServicios();
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el ElementoRevisar
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {
                Reunion reunionHallazgos = (Reunion)Session["ReunionHallazgos"];
                Session["listaArchivosReunionAsociados"] = null;
                Session["listaElementos"] = null;
                Session["listaUsuarios"] = null;
                Session["elementoSeleccionado"] = null;
                Session["usuarioSeleccionado"] = null;

                //archivos
                List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(reunionHallazgos);
                Session["listaArchivosReunionAsociados"] = listaArchivosReunion;
                cargarArchivosReunion();

                txtAnno.Text = reunionHallazgos.anno.ToString();
                txtConsecutivo.Text = reunionHallazgos.consecutivo.ToString();
                txtMes.Text = reunionHallazgos.mes.ToString();
                txtTipos.Text = reunionHallazgos.tipo.descripcion;
                cargarDatosTblElementos();
                cargarDatosTblUsuarios();
            }

        }

        #endregion

        #region logica
        public void llenarDatos()
        {
            Reunion reunionHallazgos = (Reunion)Session["ReunionHallazgos"];
            if (reunionHallazgos == null)
            {
                reunionHallazgos = new Reunion();
            }
            reunionHallazgos.idReunion = reunionHallazgos.idReunion;

        }

        /// <summary>
        /// Leonardo Carrion
        /// 03/nov/2017
        /// Efecto: carga los clientes en la tabla de clientes
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        private void cargarDatosTblElementos()
        {
            List<ElementoRevisar> listaElementos = new List<ElementoRevisar>();
            listaElementos = elementoRevisarServicios.getElementosRevisar();
            rpElemento.DataSource = listaElementos;
            rpElemento.DataBind();

            Session["listaElementos"] = listaElementos;
        }

        private void cargarDatosTblUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = usuarioServicios.getUsuarios();
            rpUsuario.DataSource = listaUsuarios;
            rpUsuario.DataBind();

            Session["listaUsuarios"] = listaUsuarios;
        }

        private void descargar(string fileName, Byte[] file)
        {
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.BinaryWrite(file);
            Response.Flush();
            Response.End();

        }

        /// <summary>
        /// Priscilla Mena
        /// 24/10/2018
        /// Efecto:Crea una tabla donde se muestran los archivos asociados a una Reunion
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void cargarArchivosReunion()
        {
            Reunion reunion = (Reunion)Session["ReunionHallazgos"];

            List<ArchivoReunion> listaArchivosReunion = (List<ArchivoReunion>)Session["listaArchivosReunionAsociados"];

            if (listaArchivosReunion.Count == 0)
            {
                txtArchivos.Text = "No hay archivos asociados a esta Reunion";
                txtArchivos.Visible = true;
                rpArchivos.Visible = false;
            }
            else
            {
                txtArchivos.Visible = false;
                rpArchivos.Visible = true;
            }

            rpArchivos.DataSource = listaArchivosReunion;
            rpArchivos.DataBind();
        }

        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 24/10/2018
        /// Efecto:descarga el archivo para que el usuario lo pueda ver
        /// Requiere: clic en el enlace al archivo
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVerArchivo_Click(object sender, EventArgs e)
        {
            String[] infoArchivo = (((LinkButton)(sender)).CommandArgument).ToString().Split(',');
            String nombreArchivo = infoArchivo[1];
            String rutaArchivo = infoArchivo[2];

            FileStream fileStream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            Byte[] blobValue = binaryReader.ReadBytes(Convert.ToInt32(fileStream.Length));

            fileStream.Close();
            binaryReader.Close();

            descargar(nombreArchivo, blobValue);
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de eliminar
        /// y guarda un registro en la base de datos
        /// redireccion a la pantalla de Administracion de Reuniones y Hallazgos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {



            String url = Page.ResolveUrl("~/Catalogos/AdministrarHallazgo.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de cancelar
        /// redireccion a la pantalla de Administracion de Reuniones y Hallazgos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarHallazgo.aspx");
            Response.Redirect(url);
        }





        /// <summary>
        /// Priscilla Mena
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de cancelar
        /// redireccion a la pantalla de Administracion de Reuniones y Hallazgos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarHallazgo.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 29/11/2018
        /// Efecto:Metodo que se activa cuando se le da click al enlace de elemntos a revisar
        /// Carga un modal con los elementos a revisar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnElemento_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalElementos();", true);

         
        }
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalUsuarios();", true);
        }


        /// <summary>
        /// Leonardo Carrion
        /// 06/nov/2017
        /// Efecto: se encarga de llenar el textbox con el nombre del cliente seleccionado y llenar la tabla de contactos
        /// Requiere: clic en el boton de "✓"
        /// Modifica: la lista de contactos
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarElemento_Click(object sender, EventArgs e)
        {

            int idElementoRevisar = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<ElementoRevisar> listaElementos = (List<ElementoRevisar>)Session["listaElementos"];

            ElementoRevisar elementoSeleccionar = new ElementoRevisar();

            foreach (ElementoRevisar elemento in listaElementos)
            {
                if (elemento.idElemento == idElementoRevisar)
                {
                    elementoSeleccionar = elemento;
                    break;
                }
            }

            txtElementoSeleccionado.Text = elementoSeleccionar.descripcionElemento;
        
            Session["elementoSeleccionado"] = elementoSeleccionar;
         

        }


        /// <summary>
        /// Leonardo Carrion
        /// 06/nov/2017
        /// Efecto: se encarga de llenar el textbox con el nombre del cliente seleccionado y llenar la tabla de contactos
        /// Requiere: clic en el boton de "✓"
        /// Modifica: la lista de contactos
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Usuario> listaUsuarios = (List<Usuario>)Session["listaUsuarios"];

            Usuario UsuarioSeleccionar = new Usuario();

            foreach (Usuario Usuario in listaUsuarios)
            {
                if (Usuario.idUsuario == idUsuario)
                {
                    UsuarioSeleccionar = Usuario;
                    break;
                }
            }

            txtUsuarioSeleccionado.Text = UsuarioSeleccionar.nombre;
            Session["usuarioSeleccionado"] = UsuarioSeleccionar;
        }

        

    }

        #endregion

    
}