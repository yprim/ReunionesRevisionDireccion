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
    public partial class NuevaReunion : System.Web.UI.Page
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

                Session["reunionNueva"] = null;
                Session["listaElementosNoAsociados"] = null;
                Session["listaElementosAsociados"] = null;
                Session["idElementoDesasociar"] = null;
               
                llenarDdlTipos();
                llenarDatos();

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


            reunionServicios.insertarReunion(reunion);

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
        

        protected void btnDesasociarElemento_Click(object sender, EventArgs e)
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