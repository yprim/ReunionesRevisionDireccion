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
    public partial class NuevaReunion : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        ReunionUsuarioServicios reunionUsuarioServicios = new ReunionUsuarioServicios();
        TipoServicios tipoServicios = new TipoServicios();
        UsuarioServicios usuarioServicios = new UsuarioServicios();
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

                Session["reunionNueva"] = null;
                Session["listaElementosNoAsociados"] = null;
                Session["listaElementosAsociados"] = null;
                Session["idElementoDesasociar"] = null;
                Session["listaArchivosReunionAsociados"] = null;
                Session["listaArchivosReunionNoAsociados"] = null;
                Session["archivos"] = null;
                Session["listaUsuariosNoAsociados"] = null;
                Session["listaUsuariosAsociados"] = null;
                Session["idUsuarioDesasociar"] = null;

                llenarDdlTipos();
                llenarDatos();


            }
            else
            {
                if (fuArchivos.HasFiles)
                {
                    Session["archivos"] = fuArchivos;
                    lblArchivos.Text = fuArchivos.PostedFile.FileName;
                }

                if (Session["archivos"] != null)
                {
                    fuArchivos = (FileUpload)Session["archivos"];
                    lblArchivos.Text = fuArchivos.PostedFiles.Count + " Archivo(s) Seleccionado(s)";
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


        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que carga todos los datos que son asignados a la reunion nueva
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void llenarDatos()
        {
            Reunion reunion = (Reunion)Session["reunionNueva"];
            if (reunion == null)
            {
                reunion = new Reunion();
            }
            reunion.idReunion = reunion.idReunion;

            txtAnno.Text = Convert.ToString(DateTime.Now.Year);

            /*
             * se llena la lista con los elementos a revisar que NO estan asociados a la reunion
             */

            List<ElementoRevisar> listaElementosNoAsociados = new List<ElementoRevisar>();

            if (Session["listaElementosNoAsociados"] == null)
            {
                listaElementosNoAsociados = elementoRevisarServicios.getElementosNoEstanEnReunion(reunion);
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

                listaElementosAsociados = elementoRevisarServicios.getElementosEstanEnReunion(reunion);

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
                listaUsuariosNoAsociados = usuarioServicios.getUsuariosNoEstanEnReunion(reunion);
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

                listaUsuariosAsociados = usuarioServicios.getUsuariosEstanEnReunion(reunion);

                Session["listaUsuariosAsociados"] = listaUsuariosAsociados;
            }
            else
            {
                listaUsuariosAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];
            }

            rpUsuario.DataSource = listaUsuariosAsociados;
            rpUsuario.DataBind();

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
            Reunion Reunion = new Reunion();
            ///   preguntar a leo
            //Reunion.idReunion = Convert.ToInt32(ddlJefeReunion.SelectedValue);

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
            Reunion Reunion = new Reunion();
          
            List<Usuario> listaUsuariosNoAsociados = (List<Usuario>)Session["listaUsuariosNoAsociados"];
            List<Usuario> listaUsuariosSeleccionados = new List<Usuario>();

            int idUsuario = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Usuario Usuario = new Usuario();

            foreach (Usuario usuarioLista in listaUsuariosNoAsociados)
            {
                if (usuarioLista.idUsuario == idUsuario)
                {
                    Usuario = usuarioLista;

                    break;
                }
            }

            listaUsuariosSeleccionados.Add(Usuario);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    /// <summary>
    /// ///
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
                    lblDesasociarUsuario.Text = "Se desasociará el Usuario: " + Usuario.nombre + " <br /> ¿está de acuerdo?";
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

            

            Reunion reunion = new Reunion();
                reunion.mes = ddlMeses.SelectedItem.Text;
                reunion.anno = Convert.ToInt32(txtAnno.Text) ;
                reunion.tipo = tipo;

                int ano = Convert.ToInt32(reunion.anno.ToString().Substring(2, 2));
                int numero = reunionServicios.getUltimoNumeroPorAnno(reunion.anno);

                numero++;

                String numeroCodigo = "";

                if (numero >= 1 && numero <= 9)
                    numeroCodigo += "000" + numero;
                else if (numero >= 10 && numero <= 99)
                    numeroCodigo += "00" + numero;
                else if (numero >= 100 && numero <= 999)
                    numeroCodigo += "0" + numero;

                reunion.consecutivo = numeroCodigo + "-" + ano;
            reunion.numero = numero;


           reunion.idReunion = reunionServicios.insertarReunion(reunion);


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
           
            /*----------------------Asociar elementos a revisar----------------------------------------*/

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

            /*--------------------Inserción de los archivos en el servidor y en la BD--------------------*/


            if (fuArchivos.HasFiles)
            {
                List<ArchivoReunion> listaArchivos = guardarArchivos(reunion, fuArchivos);

                foreach (ArchivoReunion archivo in listaArchivos)
                {
                   
                    archivoReunionServicios.insertarArchivoReunion(archivo);
                }
            }

            /*--------------------Inserción de los archivos en el servidor y en la BD--------------------*/

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
        

        protected void btnDesasociarElementoConfirmar_Click(object sender, EventArgs e)
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



        protected void btnDesasociarUsuarioConfirmar_Click(object sender, EventArgs e)
        {
            int idUsuario = (int)Session["idUsuarioDesasociar"];

            Usuario Usuario = new Usuario();

            Usuario.idUsuario = idUsuario;

            List<Usuario> listaUsuariosAsociados = (List<Usuario>)Session["listaUsuariosAsociados"];

            List<Usuario> listaUsuariosSeleccionados = new List<Usuario>();

            foreach (Usuario Usuarios in listaUsuariosAsociados)
            {
                if (Usuarios.idUsuario == Usuario.idUsuario)
                {
                    listaUsuariosSeleccionados.Add(Usuarios);
                }
            }

            List<Usuario> listaUsuariosNoAsociados = (List<Usuario>)Session["listaUsuariosNoAsociados"];
            List<Usuario> listaUsuariosAsociadosTemp = new List<Usuario>();

            foreach (Usuario Usuarios in listaUsuariosSeleccionados)
            {
                listaUsuariosNoAsociados.Add(Usuarios);
            }

            foreach (Usuario UsuarioAsociado in listaUsuariosAsociados)
            {
                Boolean asociar = true;
                foreach (Usuario Usuarios in listaUsuariosSeleccionados)
                {
                    if (UsuarioAsociado.idUsuario == Usuarios.idUsuario)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaUsuariosAsociadosTemp.Add(UsuarioAsociado);
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

     

        #endregion
    }
}