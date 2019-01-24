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
    public partial class AdministrarReunion : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios ReunionServicios = new ReuniónServicios();
        UsuarioServicios usuarioServicios = new UsuarioServicios();
        public  static int rol = 0;
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPeromitidos = { 2, 9 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);

            if (!Page.IsPostBack)
            {
                //si el rol es de asistente (9) se desabilita el boton de nueva reunion
                rol = (int)Session["rol"];

                if(rol == 9)
                {
                    btnNuevo.Visible = false;
                }

                Session["listaReunion"] = null;
                Session["ReunionEditar"] = null;
                Session["ReunionEliminar"] = null;
                cargarDatosTblReunions();
                actualizarListaUsuarios();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo para llenar los datos de la tabla con las reuniones que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblReunions()
        {
            List<Reunion> listaReunion = new List<Reunion>();
            listaReunion = ReunionServicios.getReuniones();
            rpReunion.DataSource = listaReunion;
            rpReunion.DataBind();

            Session["listaReunion"] = listaReunion;

        }

        /// <summary>
        /// Priscilla Mena
        /// 15/01/2019
        /// Efecto: Metodo que actualiza e inserta los usuarios en la tabla de Usuarios de la base de datos ReunionesPorLaDireccionDB
        /// los datos los toma de la base de datos de login
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void actualizarListaUsuarios()
        {
            List<Usuario> listaTemp = new List<Usuario>(); //guarda la lista de los usuarios que se deben insertar en la base de datos
            List<Usuario> listaUsuarios = usuarioServicios.getUsuarios(); //lista de usuarios en la base de datos de RevisionesPorLaDireccionDB
            List<Usuario> listaUsuariosLogin = usuarioServicios.getUsuariosLogin(); //lista de usuarios en la base de datos de Login asociados a la aplicacion de RevisionesPorLaDireccionDB

            //se recorre la lista de usuarios que vienen de la base de datos de Login
            foreach (Usuario usuario in listaUsuariosLogin)
            {
                Boolean NoEncontrado = false;//variable para saber si el usuario ya se encuentra en la base de datos de RevisionesPorLaDireccionDB

                //se recorre la lista con los usuarios de la base de datos de RevisionesPorLaDireccionDB
                foreach (Usuario usuarioRRD in listaUsuarios)
                {
                    if (usuarioRRD.nombre == usuario.nombre)
                    {
                        NoEncontrado = true;

                    }
                }

                if (!NoEncontrado)
                {
                    listaTemp.Add(usuario);
                }
            }

            //se insertan los usuarios que no estan en la base de datos de RevisionesPorLaDireccionDB

            foreach (Usuario usuario in listaTemp)
            {
                usuarioServicios.insertarUsuario(usuario);
               
            }

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa una nueva Reunion,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Reuniones/NuevaReunion.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se edita una Reunion,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idReunion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Reunion> listaReuniones = (List<Reunion>)Session["listaReunion"];

            Reunion reunionEditar = new Reunion();

            foreach (Reunion reunion in listaReuniones)
            {
                if (reunion.idReunion == idReunion)
                {
                    reunionEditar = reunion;
                    break;
                }
            }

            Session["ReunionEditar"] = reunionEditar;

            String url = Page.ResolveUrl("~/Reuniones/EditarReunion.aspx");
            Response.Redirect(url);

           
        }

        /// <summary>
        /// Priscilla Mena
        /// 26/09/2018
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina una Reunion,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idReunion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Reunion> listaReuniones = (List<Reunion>)Session["listaReunion"];

            Reunion reunionEditar = new Reunion();

            foreach (Reunion reunion in listaReuniones)
            {
                if (reunion.idReunion == idReunion)
                {
                    reunionEditar = reunion;
                    break;
                }
            }

            Session["ReunionEliminar"] = reunionEditar;

            String url = Page.ResolveUrl("~/Reuniones/EliminarReunion.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 11/01/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se puede ver una Reunion,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idReunion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Reunion> listaReuniones = (List<Reunion>)Session["listaReunion"];

            Reunion reunionVer = new Reunion();

            foreach (Reunion reunion in listaReuniones)
            {
                if (reunion.idReunion == idReunion)
                {
                    reunionVer = reunion;
                    break;
                }
            }

            Session["ReunionVer"] = reunionVer;

            String url = Page.ResolveUrl("~/Reuniones/VerReunion.aspx");
            Response.Redirect(url);
        }


        /// <summary>
        /// Leonardo Carrion    
        /// 23/ene/2019
        /// Efecto: habilita o desabilita los botones de editar y elminar segun el rol
        /// Requiere: -
        /// Modifica: visibilidad de botones
        /// Devuelve: -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpReunion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnEditar = e.Item.FindControl("btnEditar") as LinkButton;
                LinkButton btnEliminar = e.Item.FindControl("btnEliminar") as LinkButton;

                if (rol == 9)
                {
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                }

            }
        }


        #endregion


    }
}