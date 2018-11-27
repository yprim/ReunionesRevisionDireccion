<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoHallazgo.aspx.cs" Inherits="ReunionesRevisionDireccion.Catalogos.NuevoHallazgo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <!-- ------------------------ VISTA Reunión --------------------------- -->
    <div id="ViewReunion" runat="server" style="display: block">
        <div class="divCuadrado">


            <div class="row">

                <%-- titulo accion--%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblNuevoHallazgo" runat="server" Text=" Nuevo Hallazgo" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin titulo accion --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- campos de reunión --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                       <asp:Label ID="txtConsecutivo" runat="server" ></asp:Label>
                    </div>
                </div>
                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:Label ID="txtTipos" runat="server" ></asp:Label>
                    </div>

                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>


                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblAnno" runat="server" Text="Año " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:Label ID="txtAnno"  runat="server"></asp:Label>
                    </div>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblmes" runat="server" Text="Mes " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:Label ID="txtMes" runat="server">
                           
                        </asp:Label>
                    </div>
                </div>
                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

               
                 
                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                
                 <!-- Archivos Reunion -->
            <div class="col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-md-3 col-sm-3 col-xs-3">
                    <asp:Label ID="lblArchivosAsociados" runat="server" Text="Archivos asociados " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-4">
                    <asp:Repeater ID="rpArchivos" runat="server">
                        <HeaderTemplate>
                            <table id="tblArchivos" class="table table-hover table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>Nombre del archivo</th>
                                      
                                    </tr>
                                </thead>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnVerArchivo" runat="server" Text='<%# Eval("nombreArchivo") %>' OnClick="btnVerArchivo_Click" CommandArgument='<%# Eval("idArchivoReunion")+","+Eval("nombreArchivo")+","+Eval("rutaArchivo") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:TextBox class="form-control" ID="txtArchivos" runat="server" TextMode="MultiLine" ReadOnly="true" Rows="6" Visible="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>

          
            <!-- Fin Archivos Reunion -->
             <%--  fincampos de reunión --%>
                

                <div class="col-xs-12">
                    <br />
                    
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- campos a llenar --%>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblElemento" runat="server" Text="Elemento a Revisar <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:TextBox ID="txtElementoSeleccionado" runat="server" Text="" Rows="3" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div id="divElementoIncorrecto" runat="server" style="display: none" class="col-md-5 col-xs-5 col-sm-5">
                        <asp:Label ID="lblElementoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="col-md-2 col-sm-2 col-xs-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2">
                        <asp:LinkButton ID="btnElemento" runat="server" Text="Seleccionar elemento" OnClick="btnCliente_Click"></asp:LinkButton>
                    </div>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblUsuario" runat="server" Text="Responsable <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:TextBox ID="txtUsuarioSeleccionado" runat="server" Text="" Rows="3" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div id="divUsuarioIncorrecto" runat="server" style="display: none" class="col-md-5 col-xs-5 col-sm-5">
                        <asp:Label ID="lblUsuarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="col-md-2 col-sm-2 col-xs-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2">
                        <asp:LinkButton ID="btnUsuario" runat="server" Text="Seleccionar usuario" OnClick="btnContacto_Click"></asp:LinkButton>
                    </div>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblHallazgo" runat="server" Text="Hallazgo " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>

                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:TextBox class="form-control" ID="txtObservaciones" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

              

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                   <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-3 col-xs-3 col-sm-3">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha máxima para implementación <span style='color:red'>*</span>" Font-Size="Medium" ForeColor="Black" Font-Bold="true" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-3 col-xs-4 col-sm-4 input-group date" id="divFecha">
                        <span class="input-group-addon">
                            <span class="fa fa-calendar"></span>
                        </span>
                        <asp:TextBox CssClass="form-control" ID="txtFecha" runat="server" onInput="validarFecha(this)" onChange="validarFecha(this)" onFocus="validarFecha(this)" placeholder="dd/mm/yyyy"></asp:TextBox>
                    </div>
                </div>

                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                  <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblCodigoAccion" runat="server" Text="Codigo de Acción " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>

                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:TextBox class="form-control" ID="txtCodigoAccion" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="col-xs-12">
                    <br />
                    <div class="col-xs-12">
                        <h6 style="text-align: left">Los campos marcados con <span style='color: red'>*</span> son requeridos.</h6>
                    </div>
                </div>

                <%-- fin campos a llenar --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <hr />
                </div>
                <%-- botones --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>
                <%-- fin botones --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

            </div>
        </div>
    </div>
    <!-- ------------------------ FIN VISTA Reunión --------------------------- -->

     <!-- Modal Clientes-->
    <div id="modalClientes" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Seleccionar cliente</h4>
                </div>
                <div class="modal-body">

                    <!-- tabs -->
                    <ul class="nav nav-tabs">
                        <li id="liClientes" runat="server" role="presentation" class="active">
                            <asp:LinkButton ID="btnViewClientes" runat="server" Text="Clientes" ></asp:LinkButton>
                        </li>
                        <li id="liNuevoCliente" runat="server" role="presentation">
                            <asp:LinkButton ID="btnViewNuevoCliente" runat="server" Text="Nuevo cliente" ></asp:LinkButton>
                        </li>
                    </ul>
                    <!-- fin tabs -->

                    <div class="tab-content">
                        <!-- ------------------------ VISTA Clientes --------------------------- -->
                        <div id="ViewClientes" runat="server" style="display: block">

                            <%-- campos a llenar --%>
                                <div class="row">

                                    <%-- fin campos a llenar --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- tabla--%>
                                    <div class="col-md-12 col-xs-12" style="overflow-y: auto">
                                        <asp:Repeater ID="rpCliente" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblCliente" class="row-border table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Nombre</th>
                                                            <th>Correo electrónico</th>
                                                            <th>Teléfono</th>
                                                            <th>Tipo</th>
                                                            <th>País</th>
                                                            <th>Cédula jurídica</th>
                                                            <th>Cédula física</th>
                                                            <th>Dirección</th>
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="btnSeleccionarCliente" runat="server" ToolTip="Seleccionar" CommandArgument='<%# Eval("idCliente") %>' OnClick="btnSeleccionarCliente_Click"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <%# Eval("nombreCliente") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("correo") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("telefono") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("tipoCliente.descTipoCliente") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("pais.nombrePais") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("cedulaJuridicaCliente") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("cedulaFisica") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("direccion") %>
                                                    </td>
                                                </tr>

                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <thead>
                                                    <tr id="filterrow">
                                                        <td></td>
                                                        <th>Nombre</th>
                                                        <th>Correo electrónico</th>
                                                        <th>Teléfono</th>
                                                        <th>Tipo</th>
                                                        <th>País</th>
                                                        <th>Cédula jurídica</th>
                                                        <th>Cédula física</th>
                                                        <th>Dirección</th>
                                                    </tr>
                                                </thead>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <%-- fin tabla--%>
                                </div>
                        </div>
                        <!-- ------------------------ FIN VISTA Clientes --------------------------- -->

                      </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>

        </div>
    </div>
    <!-- Fin Modal Clientes-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
      <script src="../Scripts/moment.js"></script>
    <script src="../Scripts/transition.js"></script>
    <script src="../Scripts/collapse.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>

    <!-- script -->
    <script type="text/javascript">

        function activarModalEliminarEnsayoModal() {
            $('#modalEliminarEnsayoModal').modal('show');
        };

        function activarModalClientes() {
            $('#modalClientes').modal('show');
        };

        function activarModalEliminarAsignarTrabajoModal() {
            $('#modalAsignarTrabajo').modal('show');
            $('#modalEliminarAsignarTrabajoModal').modal('show');
        };

        function activarModalEliminarAsignarTrabajoModal2() {
            $('#modalEliminarAsignarTrabajoModal2').modal('show');
        };

        function activarModalEliminarLocalidadTransporte() {
            $('#modalEliminarLocalidadTransporte').modal('show');
        };

        function activarModalEliminarTrasladosInternos() {
            $('#modalEliminarTrasladosInternos').modal('show');
        };

        function activarModalEliminarGastoExtra() {
            $('#modalEliminarGastoExtra').modal('show');
        };

        $(function () {
            // Fechas
            $('#divFecha').datetimepicker({
                format: 'DD/MM/YYYY',
                locale: moment.locale('es')
            });
        });

        function validarFecha(txtFecha) {
            patron = /^\d{2}\/\d{2}\/\d{4}$/;

            var id = txtFecha.id.substring(12);

            if (txtFecha.value != "" && patron.test(txtFecha.value)) {
                txtFecha.className = "From-Date form-control";
            } else {
                txtFecha.className = "From-Date form-control alert-danger";
            }
        };

        function activarModalClientes() {
            $('#modalClientes').modal('show');
        };

        function activarModalContactos() {
            $('#modalContactos').modal('show');
        };

        function activarModalLaboratorios() {
            $('#modalLaboratorios').modal('show');
        };

        function activarModalEnsayos() {
            $('#modalEnsayos').modal('show');
        };

        function activarModalHospedajes() {
            $('#modalHospedajes').modal('show');
        };

        function activarModalHospedajesInternos() {
            $('#modalHospedajesInternos').modal('show');
        };

        function activarModalTransportes() {
            $('#modalTransportes').modal('show');
        };

        function activarModalTransportesInternos() {
            $('#modalTransportesInternos').modal('show');
        };

        function activarModalMuestras() {
            $('#modalMuestras').modal('show');
        };

        function activarModalAsignarTrabajo() {
            $('#modalAsignarTrabajo').modal('show');
        };

   </script>
</asp:Content>

