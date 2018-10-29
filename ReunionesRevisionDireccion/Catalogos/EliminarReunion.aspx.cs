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
    public partial class EliminarReunion : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        TipoServicios tipoServicios = new TipoServicios();
        ArchivoReunionServicios archivoReunionServicios = new ArchivoReunionServicios();

        #endregion
        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el ElementoRevisar
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {
                Reunion reunionEliminar = (Reunion)Session["reunionEliminar"];
                Session["listaElementosNoAsociados"] = null;
                Session["listaElementosAsociados"] = null;
                Session["idElementoDesasociar"] = null;
                Session["listaArchivosReunionAsociados"] = null;


                //llenarDdlTipos();
                llenarDatos();
                //arvhivos
                List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(reunionEliminar);
                Session["listaArchivosReunionAsociados"] = listaArchivosReunion;
                cargarArchivosReunion();

                txtAnno.Text = reunionEliminar.anno.ToString();
                txtConsecutivo.Text = reunionEliminar.consecutivo.ToString();
                txtMes.Text = reunionEliminar.mes.ToString();
                txtTipos.Text = reunionEliminar.tipo.descripcion;
            }



        }

        #endregion

        #region logica

       

        public void llenarDatos()
        {
            Reunion ReunionEliminar = (Reunion)Session["reunionEliminar"];
            if (ReunionEliminar == null)
            {
                ReunionEliminar = new Reunion();
            }
            ReunionEliminar.idReunion = ReunionEliminar.idReunion;

          

            /*
             * se llena la tabla de elementos que estan asociados a la reunion escogida
             */

            List<ElementoRevisar> listaElementosAsociados = new List<ElementoRevisar>();

            if (Session["listaElementosAsociados"] == null)
            {

                listaElementosAsociados = elementoRevisarServicios.getElementosEstanEnReunion(ReunionEliminar);

                Session["listaElementosAsociados"] = listaElementosAsociados;
            }
            else
            {
                listaElementosAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];
            }

            rpElemento.DataSource = listaElementosAsociados;
            rpElemento.DataBind();

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
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de eliminar
        /// y elimina un registro en la base de datos
        /// redireccion a la pantalla de Administracion de Reunions
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Tipo tipo = new Tipo();

            //tipo.idTipo = Convert.ToInt32(txtTipos.SelectedValue);
            //tipo.descripcion = txtTipos.SelectedItem.Text;

            Reunion reunion = (Reunion)Session["reunionEliminar"];
            //reunion.mes = txtMes.SelectedItem.Text;
            reunion.anno = Convert.ToInt32(txtAnno.Text);
            reunion.tipo = tipo;

            

            reunion = reunionServicios.getReunionPorDatos(reunion);

            /*----------------------Eliminar los elementos a revisar asociados a esa reunión----------------------------------------*/

            List<ElementoRevisar> listaElementosAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];

            foreach (ElementoRevisar elementoRevisar in listaElementosAsociados)
            {
                
                    reunionElementoRevisarServicios.eliminarReunionElemento(reunion, elementoRevisar);
                
            }

            /*----------------------Eliminar los archivos asociados a esa reunión----------------------------------------*/

            List<ArchivoReunion> listaArchivosAsociados = (List<ArchivoReunion>)Session["listaArchivosReunionAsociados"];

            foreach (ArchivoReunion archivoAsociado in listaArchivosAsociados)
            {
                if (System.IO.File.Exists(archivoAsociado.rutaArchivo))
                {
                    try
                    {
                        System.IO.File.Delete(archivoAsociado.rutaArchivo);

                    }
                    catch (Exception ex)
                    {
                        (this.Master as Site).Mensaje("No se pudo eliminar el archivo", "¡Alerta!");
                    }
                }

                archivoReunionServicios.eliminarArchivoReunion(archivoAsociado);

            }
            reunionServicios.eliminarReunion(reunion);

            String url = Page.ResolveUrl("~/Catalogos/AdministrarReunion.aspx");
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
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarReunion.aspx");
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
            String url = Page.ResolveUrl("~/Catalogos/AdministrarReunion.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}