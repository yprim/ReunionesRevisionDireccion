using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReunionesRevisionDireccion.Hallazgos
{
    public partial class VerHallazgo : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        ArchivoReunionServicios archivoReunionServicios = new ArchivoReunionServicios();
        UsuarioServicios usuarioServicios = new UsuarioServicios();
        EstadoServicios estadoServicios = new EstadoServicios();
        ReunionUsuarioServicios reunionUsuarioServicios = new ReunionUsuarioServicios();
        HallazgoServicios hallazgoServicios = new HallazgoServicios();
        ReunionElementoRevisarHallazgoServicios reunionElementoRevisarHallazgoServicios = new ReunionElementoRevisarHallazgoServicios();
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
                Session["usuarioSeleccionado"] = null;

                Hallazgo HallazgoVer = (Hallazgo)Session["HallazgoVer"];

                //archivos
                List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(reunionHallazgos);
                Session["listaArchivosReunionAsociados"] = listaArchivosReunion;
                cargarArchivosReunion();

                // datos de la reunion 
                txtAnno.Text = reunionHallazgos.anno.ToString();
                txtConsecutivo.Text = reunionHallazgos.consecutivo.ToString();
                txtMes.Text = reunionHallazgos.mes.ToString();
                txtTipos.Text = reunionHallazgos.tipo.descripcion;
                // fin datos de la reunion

                // datos del hallazgo
                ElementoRevisar elementoHallazgo = reunionElementoRevisarHallazgoServicios.getElementoHallazgo(reunionHallazgos, HallazgoVer);
                txtElementoSeleccionado.Text = elementoHallazgo.descripcionElemento;
                txtUsuarioSeleccionado.Text = HallazgoVer.usuario.nombre;
                txtObservaciones.Text = HallazgoVer.observaciones;
                txtEstados.Text = HallazgoVer.estado.descripcionEstado;

                txtFecha.Text = HallazgoVer.fechaMaximaImplementacion.ToString();
                txtCodigoAccion.Text = HallazgoVer.codigoAccion;
                //cargarDatosTblUsuarios();
                //llenarDdlEstados();

            }



        }
        #endregion

        #region logica




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
            String url = Page.ResolveUrl("~/Hallazgos/AdministrarHallazgo.aspx");
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
            String url = Page.ResolveUrl("~/Hallazgos/AdministrarHallazgo.aspx");
            Response.Redirect(url);
        }


        #endregion
    }
}