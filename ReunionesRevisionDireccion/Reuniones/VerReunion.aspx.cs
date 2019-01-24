using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReunionesRevisionDireccion.Reuniones
{
    public partial class VerReunion : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        ReunionElementoRevisarHallazgoServicios reunionElementoRevisarHallazgoServicios = new ReunionElementoRevisarHallazgoServicios();
        HallazgoServicios hallazgoServicios = new HallazgoServicios();
        ArchivoReunionServicios archivoReunionServicios = new ArchivoReunionServicios();
        UsuarioServicios usuarioServicios = new UsuarioServicios();
        ReunionUsuarioServicios reunionUsuarioServicios = new ReunionUsuarioServicios();
        #endregion
        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el ElementoRevisar
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2, 9 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {
                Reunion reunionVer = (Reunion)Session["reunionVer"];
                Session["listaElementosNoAsociados"] = null;
                Session["listaElementosAsociados"] = null;
                Session["idElementoDesasociar"] = null;
                Session["listaArchivosReunionAsociados"] = null;
                Session["listaUsuariosNoAsociados"] = null;
                Session["listaUsuariosAsociados"] = null;
                Session["idUsuarioDesasociar"] = null;
                llenarDatos();

                //archivos
                List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(reunionVer);
                Session["listaArchivosReunionAsociados"] = listaArchivosReunion;
                cargarArchivosReunion();

                txtAnno.Text = reunionVer.anno.ToString();
                txtConsecutivo.Text = reunionVer.consecutivo.ToString();
                txtMes.Text = reunionVer.mes.ToString();
                txtTipos.Text = reunionVer.tipo.descripcion;
            }
        }

        #endregion
        #region logica


        public void llenarDatos()
        {
            Reunion reunionVer = (Reunion)Session["reunionVer"];
            if (reunionVer == null)
            {
                reunionVer = new Reunion();
            }
            reunionVer.idReunion = reunionVer.idReunion;



            /*
             * se llena la tabla de elementos que estan asociados a la reunion escogida
             */

            List<ElementoRevisar> listaElementosAsociados = new List<ElementoRevisar>();

            if (Session["listaElementosAsociados"] == null)
            {

                listaElementosAsociados = elementoRevisarServicios.getElementosEstanEnReunion(reunionVer);

                Session["listaElementosAsociados"] = listaElementosAsociados;
            }
            else
            {
                listaElementosAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];
            }

            rpElemento.DataSource = listaElementosAsociados;
            rpElemento.DataBind();

            /*
            * se llena la tabla de usuarios que estan asociados a la reunion escogida
            */

            List<Usuario> listaUsuariosAsociados = new List<Usuario>();

            if (Session["listaUsuariosAsociados"] == null)
            {

                listaUsuariosAsociados = usuarioServicios.getUsuariosEstanEnReunion(reunionVer);

                Session["listaUsuariosAsociados"] = listaUsuariosAsociados;
            }
            else
            {
                listaUsuariosAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];
            }

            rpUsuario.DataSource = listaUsuariosAsociados;
            rpUsuario.DataBind();

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
            Reunion Reunion = (Reunion)Session["ReunionEditar"];

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
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de cancelar
        /// redireccion a la pantalla de Administracion de Reunions
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Reuniones/AdministrarReunion.aspx");
            Response.Redirect(url);
        }





        /// <summary>
        /// Priscilla Mena
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de cancelar
        /// redireccion a la pantalla de Administracion de Reunions
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Reuniones/AdministrarReunion.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}