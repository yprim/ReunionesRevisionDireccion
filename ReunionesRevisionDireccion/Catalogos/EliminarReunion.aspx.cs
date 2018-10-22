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
    public partial class EliminarReunion : System.Web.UI.Page
    {
        #region variables globales
        ReuniónServicios reunionServicios = new ReuniónServicios();
        ElementoRevisarServicios elementoRevisarServicios = new ElementoRevisarServicios();
        ReunionElementoRevisarServicios reunionElementoRevisarServicios = new ReunionElementoRevisarServicios();
        TipoServicios tipoServicios = new TipoServicios();

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


                //llenarDdlTipos();
                llenarDatos();

                txtAnno.Text = reunionEliminar.anno.ToString();
                txtConsecutivo.Text = reunionEliminar.consecutivo.ToString();
                txtNumero.Text = reunionEliminar.numero.ToString();
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

        #endregion


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
    }
}