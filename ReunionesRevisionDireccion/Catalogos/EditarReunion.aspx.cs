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
    public partial class EditarReunion : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        TipoServicios tipoServicios = new TipoServicios();
        ArchivoReunionServicios archivoReunionServicios = new ArchivoReunionServicios();
        UsuarioServicios usuarioServicios = new UsuarioServicios();
        ReunionUsuarioServicios reunionUsuarioServicios = new ReunionUsuarioServicios();

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
                Reunion reunionEditar = (Reunion)Session["ReunionEditar"];
                Session["listaElementosNoAsociados"] = null;
                Session["listaElementosAsociados"] = null;
                Session["idElementoDesasociar"] = null;
                Session["listaArchivosReunionAsociados"] = null;
                Session["listaArchivosReunionNoAsociados"] = null;
                Session["archivo"] = null;
                Session["listaUsuariosNoAsociados"] = null;
                Session["listaUsuariosAsociados"] = null;
                Session["idUsuarioDesasociar"] = null;


                llenarDdlTipos();
                llenarDatos();
                //arvhivos
                List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(reunionEditar);
                Session["listaArchivosReunionAsociados"] = listaArchivosReunion;
                cargarArchivosReunion();

                txtAnno.Text = reunionEditar.anno.ToString();
                txtConsecutivo.Text = reunionEditar.consecutivo.ToString();
           
                int contIndexTipos = 0;
                foreach (ListItem item in ddlTipos.Items)
                {
                    if (Convert.ToInt32(item.Value) == reunionEditar.tipo.idTipo)
                    {
                        ddlTipos.SelectedIndex = contIndexTipos;
                        break;
                    }
                    contIndexTipos++;
                }

                int contIndexMeses= 0;
                foreach (ListItem item in ddlMeses.Items)
                {
                    if (item.Text == reunionEditar.mes)
                    {
                        ddlMeses.SelectedIndex = contIndexMeses;
                        break;
                    }
                    contIndexMeses++;
                }

            }
            else
            {

                if (fuArchivos.HasFile)
                {
                    Session["archivo"] = fuArchivos;
                    lblArchivo.Text = fuArchivos.PostedFile.FileName;
                }

                if (Session["archivo"] != null)
                {
                    fuArchivos = (FileUpload)Session["archivoOriginal"];
                    lblArchivo.Text = "Archivo(s) Seleccionado(s)";
                }
            }

          
        }

        #endregion

        #region logica

        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que carga todos los Tipos en el DropDownList
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void llenarDdlTipos()
        {
            List<Tipo> listaTipoes = tipoServicios.getTipos();
            ddlTipos.DataSource = listaTipoes;
            ddlTipos.DataTextField = "descripcion";
            ddlTipos.DataValueField = "idTipo";
            ddlTipos.DataBind();
      
        }

        public void llenarDatos()
        {
            Reunion reunionEditar = (Reunion)Session["ReunionEditar"];
            if (reunionEditar == null)
            {
                reunionEditar = new Reunion();
            }
            reunionEditar.idReunion = reunionEditar.idReunion;

            /*
             * se llena la lista con los elementos a revisar que NO estan asociados a la reunion
             */

            List<ElementoRevisar> listaElementosNoAsociados = new List<ElementoRevisar>();

            if (Session["listaElementosNoAsociados"] == null)
            {
                listaElementosNoAsociados = elementoRevisarServicios.getElementosNoEstanEnReunion(reunionEditar);
            }
            else
            {
                listaElementosNoAsociados = (List<ElementoRevisar>)Session["listaElementosNoAsociados"];
            }

            Session["listaElementosNoAsociados"] = listaElementosNoAsociados;

            rpElementoSinAsociar.DataSource = listaElementosNoAsociados;
            rpElementoSinAsociar.DataBind();

            /*
             * se llena la tabla de elementos que estan asociados a la reunion escogida
             */

            List<ElementoRevisar> listaElementosAsociados = new List<ElementoRevisar>();

            if (Session["listaElementosAsociados"] == null)
            {

                listaElementosAsociados = elementoRevisarServicios.getElementosEstanEnReunion(reunionEditar);

                Session["listaElementosAsociados"] = listaElementosAsociados;
            }
            else
            {
                listaElementosAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];
            }

            rpElemento.DataSource = listaElementosAsociados;
            rpElemento.DataBind();

            /*
        * se llena la lista con los usuarios que NO estan asociados a la reunion
        */

            List<Usuario> listaUsuariosNoAsociados = new List<Usuario>();

            if (Session["listaUsuariosNoAsociados"] == null)
            {
                listaUsuariosNoAsociados = usuarioServicios.getUsuariosNoEstanEnReunion(reunionEditar);
            }
            else
            {
                listaUsuariosNoAsociados = (List<Usuario>)Session["listaUsuariosNoAsociados"];
            }

            Session["listaUsuariosNoAsociados"] = listaUsuariosNoAsociados;

            rpUsuarioSinAsociar.DataSource = listaUsuariosNoAsociados;
            rpUsuarioSinAsociar.DataBind();

            /*
             * se llena la tabla de usuarios que estan asociados a la reunion escogida
             */

            List<Usuario> listaUsuariosAsociados = new List<Usuario>();

            if (Session["listaUsuariosAsociados"] == null)
            {

                listaUsuariosAsociados = usuarioServicios.getUsuariosEstanEnReunion(reunionEditar);

                Session["listaUsuariosAsociados"] = listaUsuariosAsociados;
            }
            else
            {
                listaUsuariosAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];
            }

            rpUsuario.DataSource = listaUsuariosAsociados;
            rpUsuario.DataBind();

        }

        /// <summary>
        /// Priscilla Mena
        /// 24/10/2018
        /// Efecto:descarga el archivo para que el usuario lo pueda ver
        /// redireccion a la pantalla de Administracion de Reunions
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
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
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de asociar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAsociar_Click(object sender, EventArgs e)
        {
           
            List<ElementoRevisar> listaElementosNoAsociados = (List<ElementoRevisar>)Session["listaElementosNoAsociados"];
            List<ElementoRevisar> listaElementosSeleccionados = new List<ElementoRevisar>();

            int idElementoRevisar = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            ElementoRevisar elementoRevisar = new ElementoRevisar();

            foreach (ElementoRevisar elementoRevisarLista in listaElementosNoAsociados)
            {
                if (elementoRevisarLista.idElemento == idElementoRevisar)
                {
                    elementoRevisar = elementoRevisarLista;

                    break;
                }
            }

            listaElementosSeleccionados.Add(elementoRevisar);

            List<ElementoRevisar> listaElementoRevisarAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];

            foreach (ElementoRevisar elementoRevisarLista in listaElementosSeleccionados)
            {
                listaElementoRevisarAsociados.Add(elementoRevisarLista);
            }

            List<ElementoRevisar> listaElementoRevisarNoAsociadosTemp = new List<ElementoRevisar>();

            foreach (ElementoRevisar elementoRevisarNoAsociado in listaElementosNoAsociados)
            {
                Boolean asociar = true;
                foreach (ElementoRevisar elementoRevisarLista in listaElementosSeleccionados)
                {
                    if (elementoRevisarLista.idElemento == elementoRevisarNoAsociado.idElemento)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaElementoRevisarNoAsociadosTemp.Add(elementoRevisarNoAsociado);
                }

            }

            Session["listaElementosNoAsociados"] = listaElementoRevisarNoAsociadosTemp;
            Session["listaElementosAsociados"] = listaElementoRevisarAsociados;

            llenarDatos();

            /*para que se quede en el tab de ElementoRevisars despues del posback*/
            liReunion.Attributes["class"] = "";
            liElementoRevisar.Attributes["class"] = "active";


            ViewElementoRevisar.Style.Add("display", "block");
            ViewReunion.Style.Add("display", "none");


            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModal();", true);
        }


        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de asociar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAsociarUsuario_Click(object sender, EventArgs e)
        {

            List<Usuario> listaUsuariosNoAsociados = (List<Usuario>)Session["listaUsuariosNoAsociados"];
            List<Usuario> listaUsuariosSeleccionados = new List<Usuario>();

            int idUsuario = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Usuario usuario = new Usuario();

            foreach (Usuario usuarioLista in listaUsuariosNoAsociados)
            {
                if (usuarioLista.idUsuario == idUsuario)
                {
                    usuario = usuarioLista;

                    break;
                }
            }

            listaUsuariosSeleccionados.Add(usuario);

            List<Usuario> listaUsuarioAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];

            foreach (Usuario usuarioLista in listaUsuariosSeleccionados)
            {
                listaUsuarioAsociados.Add(usuarioLista);
            }

            List<Usuario> listaUsuarioNoAsociadosTemp = new List<Usuario>();

            foreach (Usuario usuarioNoAsociado in listaUsuariosNoAsociados)
            {
                Boolean asociar = true;
                foreach (Usuario usuarioLista in listaUsuariosSeleccionados)
                {
                    if (usuarioLista.idUsuario == usuarioNoAsociado.idUsuario)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaUsuarioNoAsociadosTemp.Add(usuarioNoAsociado);
                }

            }

            Session["listaUsuariosNoAsociados"] = listaUsuarioNoAsociadosTemp;
            Session["listaUsuariosAsociados"] = listaUsuarioAsociados;

            llenarDatos();

            /*para que se quede en el tab de Usuarios despues del posback*/
            liReunion.Attributes["class"] = "";
            liUsuario.Attributes["class"] = "active";


            ViewUsuario.Style.Add("display", "block");
            ViewReunion.Style.Add("display", "none");


            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalUsuario();", true);
        }


        protected void btnDesasociar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalDesasociarElementos();", true);

            int idElementoRevisar = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Session["idElementoDesasociar"] = idElementoRevisar;

            List<ElementoRevisar> listaElementoRevisarAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];

            List<ElementoRevisar> listaElementoRevisarsSeleccionados = new List<ElementoRevisar>();

            foreach (ElementoRevisar elementoRevisar in listaElementoRevisarAsociados)
            {
                if (elementoRevisar.idElemento == idElementoRevisar)
                {
                    lblDesasocaiarElemento.Text = "Se desasociará el elemento: " + elementoRevisar.descripcionElemento + " <br /> ¿está de acuerdo?";
                }
            }

            /*para que se quede en el tab de ElementoRevisar despues del posback*/
            liReunion.Attributes["class"] = "";
            liElementoRevisar.Attributes["class"] = "active";


            ViewElementoRevisar.Style.Add("display", "block");
            ViewReunion.Style.Add("display", "none");

        }


        protected void btnDesasociarUsuario_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalDesasociarUsuarios();", true);

            int idUsuario = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Session["idUsuarioDesasociar"] = idUsuario;

            List<Usuario> listaUsuarioAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];

            List<Usuario> listaUsuariosSeleccionados = new List<Usuario>();

            foreach (Usuario Usuario in listaUsuarioAsociados)
            {
                if (Usuario.idUsuario == idUsuario)
                {
                    lblDesasocaiarUsuario.Text = "Se desasociará el Usuario: " + Usuario.nombre + " <br /> ¿está de acuerdo?";
                }
            }

            /*para que se quede en el tab de Usuario despues del posback*/
            liReunion.Attributes["class"] = "";
            liUsuario.Attributes["class"] = "active";


            ViewUsuario.Style.Add("display", "block");
            ViewReunion.Style.Add("display", "none");

        }

        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de guardar
        /// y guarda un registro en la base de datos
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

            tipo.idTipo = Convert.ToInt32(ddlTipos.SelectedValue);
            tipo.descripcion = ddlTipos.SelectedItem.Text;

            Reunion reunion = (Reunion)Session["ReunionEditar"];
            reunion.mes = ddlMeses.SelectedItem.Text;
            reunion.anno = Convert.ToInt32(txtAnno.Text);
            reunion.tipo = tipo;

            reunionServicios.actualizarReunion(reunion);

            reunion = reunionServicios.getReunionPorDatos(reunion);

            /*----------------------Asociar elementos a revisar----------------------------------------*/

            List<ElementoRevisar> listaElementosAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];

            foreach (ElementoRevisar elementoRevisar in listaElementosAsociados)
            {
                if (!reunionElementoRevisarServicios.elementoAsociadoAReunión(reunion, elementoRevisar))
                {
                    reunionElementoRevisarServicios.insertarReunionElemento(reunion, elementoRevisar);
                }
            }

            List<ElementoRevisar> listaElementosNoAsociados = (List<ElementoRevisar>)Session["listaElementosNoAsociados"];

            foreach (ElementoRevisar ElementoRevisar in listaElementosNoAsociados)
            {
                if (reunionElementoRevisarServicios.elementoAsociadoAReunión(reunion, ElementoRevisar))
                {
                    reunionElementoRevisarServicios.eliminarReunionElemento(reunion, ElementoRevisar);
                }
            }

            /*--------------------- Fin-Asociar Elementos----------------------------------------*/

            /*----------------------Asociar Usuarios----------------------------------------*/

            List<Usuario> listaUsuariosAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];

            foreach (Usuario Usuario in listaUsuariosAsociados)
            {
                if (!reunionUsuarioServicios.usuarioAsociadoAReunión(reunion, Usuario))
                {
                    reunionUsuarioServicios.insertarReunionUsuario(reunion, Usuario);
                }
            }

            List<Usuario> listaUsuariosNoAsociados = (List<Usuario>)Session["listaUsuariosNoAsociados"];

            foreach (Usuario Usuario in listaUsuariosNoAsociados)
            {
                if (reunionUsuarioServicios.usuarioAsociadoAReunión(reunion, Usuario))
                {
                    reunionUsuarioServicios.eliminarReunionUsuario(reunion, Usuario);
                }
            }

            /*--------------------- Fin-Asociar Usuarios----------------------------------------*/


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


        protected void btnConfirmarDesasociarElemento_Click(object sender, EventArgs e)
        {
            int idElementoRevisar = (int)Session["idElementoDesasociar"];

            ElementoRevisar elementoRevisar = new ElementoRevisar();

            elementoRevisar.idElemento = idElementoRevisar;

            List<ElementoRevisar> listaElementosAsociados = (List<ElementoRevisar>)Session["listaElementosAsociados"];

            List<ElementoRevisar> listaElementosSeleccionados = new List<ElementoRevisar>();

            foreach (ElementoRevisar elementos in listaElementosAsociados)
            {
                if (elementos.idElemento == elementoRevisar.idElemento)
                {
                    listaElementosSeleccionados.Add(elementos);
                }
            }

            List<ElementoRevisar> listaElementosNoAsociados = (List<ElementoRevisar>)Session["listaElementosNoAsociados"];
            List<ElementoRevisar> listaElementosAsociadosTemp = new List<ElementoRevisar>();

            foreach (ElementoRevisar ElementoRevisars in listaElementosSeleccionados)
            {
                listaElementosNoAsociados.Add(ElementoRevisars);
            }

            foreach (ElementoRevisar ElementoRevisarAsociado in listaElementosAsociados)
            {
                Boolean asociar = true;
                foreach (ElementoRevisar ElementoRevisars in listaElementosSeleccionados)
                {
                    if (ElementoRevisarAsociado.idElemento == ElementoRevisars.idElemento)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaElementosAsociadosTemp.Add(ElementoRevisarAsociado);
                }
            }

            Session["listaElementosAsociados"] = listaElementosAsociadosTemp;
            Session["listaElementosNoAsociados"] = listaElementosNoAsociados;

            llenarDatos();

            /*para que se quede en el tab de ElementoRevisars despues del posback*/
            liReunion.Attributes["class"] = "";
            liElementoRevisar.Attributes["class"] = "active";


            ViewElementoRevisar.Style.Add("display", "block");
            ViewReunion.Style.Add("display", "none");

        }



        protected void btnConfirmarDesasociarUsuario_Click(object sender, EventArgs e)
        {
            int idUsuario = (int)Session["idUsuarioDesasociar"];

            Usuario usuario = new Usuario();

            usuario.idUsuario = idUsuario;

            List<Usuario> listaUsuariosAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];

            List<Usuario> listaUsuariosSeleccionados = new List<Usuario>();

            foreach (Usuario usuarios in listaUsuariosAsociados)
            {
                if (usuarios.idUsuario == usuario.idUsuario)
                {
                    listaUsuariosSeleccionados.Add(usuarios);
                }
            }

            List<Usuario> listaUsuariosNoAsociados = (List<Usuario>)Session["listaUsuariosNoAsociados"];
            List<Usuario> listaUsuariosAsociadosTemp = new List<Usuario>();

            foreach (Usuario Usuarios in listaUsuariosSeleccionados)
            {
                listaUsuariosNoAsociados.Add(Usuarios);
            }

            foreach (Usuario usuarioAsociado in listaUsuariosAsociados)
            {
                Boolean asociar = true;
                foreach (Usuario Usuarios in listaUsuariosSeleccionados)
                {
                    if (usuarioAsociado.idUsuario == Usuarios.idUsuario)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaUsuariosAsociadosTemp.Add(usuarioAsociado);
                }
            }

            Session["listaUsuariosAsociados"] = listaUsuariosAsociadosTemp;
            Session["listaUsuariosNoAsociados"] = listaUsuariosNoAsociados;

            llenarDatos();

            /*para que se quede en el tab de Usuarios despues del posback*/
            liReunion.Attributes["class"] = "";
            liUsuario.Attributes["class"] = "active";


            ViewUsuario.Style.Add("display", "block");
            ViewReunion.Style.Add("display", "none");

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
        /// 24/10/2018
        /// Efecto:elimina el archivo seleccionado de la reunion a editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminarArchivo_Click(object sender, EventArgs e)
        {
            String[] arg = new String[2];

            // Como estamos pasando dos argumentos a través de CommandArgument, entonces tenemos que separarlos por el ";" que agregamos en medio de ellos
            arg = (((LinkButton)(sender)).CommandArgument).ToString().Split(';');

            int idArchivo = Convert.ToInt32(arg[0]);
            String nombreArchivoEliminar = arg[1];
            String ruta = arg[2];

            ArchivoReunion archivoReunion = new ArchivoReunion();
            archivoReunion.idArchivoReunion = idArchivo;
            archivoReunion.nombreArchivo = nombreArchivoEliminar;
            archivoReunion.rutaArchivo = ruta;

            if (System.IO.File.Exists(@ruta))
            {
                try
                {
                    System.IO.File.Delete(@ruta);

                }
                catch (Exception ex)
                {
                    (this.Master as Site).Mensaje("No se pudo eliminar el archivo", "¡Alerta!");
                }
            }

            archivoReunionServicios.eliminarArchivoReunion(archivoReunion);

            Reunion Reunion = (Reunion)Session["ReunionEditar"];
            List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(Reunion);

            //Session["listaArchivosReunionAsociados"] = listaArchivosReunion.Count > 0 ? listaArchivosReunion : null;
            Session["listaArchivosReunionAsociados"] = listaArchivosReunion;


            cargarArchivosReunion();
        }

      
        /// <summary>
        /// Priscilla Mena
        /// 24/10/2018
        /// Efecto:guarda los archivos en el servidor
        /// Requiere: fileupload y muestra
        /// Modifica: -
        /// Devuelve: lista de archivos de muestra
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<ArchivoReunion> guardarArchivos(Reunion reunion, FileUpload fuArchivos)
        {
            List<ArchivoReunion> listaArchivos = new List<ArchivoReunion>();

            String archivosRepetidos = "";

            foreach (HttpPostedFile file in fuArchivos.PostedFiles)
            {
                String nombreArchivo = Path.GetFileName(file.FileName);
                nombreArchivo = nombreArchivo.Replace(' ', '_');
                DateTime fechaHoy = DateTime.Now;
                String carpeta = reunion.idReunion + "-" + reunion.numero;

                int guardado = Utilidades.SaveFile(file, fechaHoy.Year, nombreArchivo, carpeta);

                if (guardado == 0)
                {
                    ArchivoReunion archivoReunion = new ArchivoReunion();
                    archivoReunion.nombreArchivo = nombreArchivo;
                    archivoReunion.rutaArchivo = Utilidades.path + fechaHoy.Year + "\\" + carpeta + "\\" + nombreArchivo;
                    archivoReunion.fechaCreacion = fechaHoy;
                    archivoReunion.reunion = reunion;
                    archivoReunion.creadoPor = (String)Session["nombreCompleto"];

                    listaArchivos.Add(archivoReunion);
                }
                else
                {
                    archivosRepetidos += "* " + nombreArchivo + ", \n";
                }
            }

            if (archivosRepetidos.Trim() != "")
            {
                archivosRepetidos = archivosRepetidos.Remove(archivosRepetidos.Length - 3);
                (this.Master as Site).Mensaje("Los archivos " + archivosRepetidos + " no se pudieron guardar porque ya había archivos con ese nombre", "¡Alerta!");
            }

            return listaArchivos;
        }

        /// <summary>
        /// Priscilla Mena
        /// 24/10/2018
        /// Efecto:agregar archivos a la reunion a editar
        /// Requiere: 
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAgregarArchivos_Click(object sender, EventArgs e)
        {
            fuArchivos = (FileUpload)Session["archivo"];
            if (fuArchivos != null && fuArchivos.HasFiles)
            {
                Reunion reunion = (Reunion)Session["ReunionEditar"];
                // Inserción de los archivos en el servidor y en la BD
                List<ArchivoReunion> listaArchivos = guardarArchivos(reunion, fuArchivos);

                foreach (ArchivoReunion archivo in listaArchivos)
                {
                  
                    archivoReunionServicios.insertarArchivoReunion(archivo);
                }

                List<ArchivoReunion> listaArchivosReunion = archivoReunionServicios.getArchivosReunionPorIdReunion(reunion);

                Session["listaArchivosReunionAsociados"] = listaArchivosReunion;

                cargarArchivosReunion();
            }
            else
            {
                (this.Master as Site).Mensaje("Si desea agregar un(os) archivos a esta Reunion, primero debe \"Elegir archivos\" y luego darle clic al botón \"Agregar archivos\".", "¡Alerta!");
            }
        }

        #endregion

    }
}