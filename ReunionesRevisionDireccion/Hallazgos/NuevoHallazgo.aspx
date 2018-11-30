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
                        <asp:Label ID="lblElementoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Debe seleccionar un elemento" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="col-md-2 col-sm-2 col-xs-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2">
                        <asp:LinkButton ID="btnElemento" runat="server" Text="Seleccionar elemento" OnClick="btnElemento_Click"></asp:LinkButton>
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
                        <asp:Label ID="lblUsuarioIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Debe seleccionar un responsable" ForeColor="Red"></asp:Label>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="col-md-2 col-sm-2 col-xs-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2">
                        <asp:LinkButton ID="btnUsuario" runat="server" Text="Seleccionar usuario" OnClick="btnUsuario_Click"></asp:LinkButton>
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
                    <div id="divObservacionesIncorrecto" runat="server" style="display: none" class="col-md-5 col-xs-5 col-sm-5">
                        <asp:Label ID="lblObservacionesIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                    </div>

                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

              

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>

                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:DropDownList ID="ddlEstados" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                    </div>
                </div>

                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                   <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha máxima de implementación<span style='color:red'>*</span>" Font-Size="Medium" ForeColor="Black" Font-Bold="true" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4 input-group date" id="divFecha">
                    <span class="input-group-addon">
                        <span class="fa fa-calendar"></span>
                    </span>
                    <asp:TextBox CssClass="form-control" ID="txtFecha" runat="server" onInput="validarFecha(this)" onChange="validarFecha(this)" onFocus="validarFecha(this)" placeholder="dd/mm/yyyy"></asp:TextBox>
                </div>
                <div class="col-md-5 col-xs-5 col-sm-5" id="divFechaIncorrecta" runat="server" style="display: none;">
                 <asp:Label ID="lblFechaIncorrecta" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
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
                        <asp:TextBox class="form-control" ID="txtCodigoAccion" runat="server"></asp:TextBox>
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
   
    
    <!-- Modal Elemento a revisar-->
    <div id="modalElementos" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Seleccionar elemento a revisar</h4>
                </div>
                <div class="modal-body">

                   

                    <div class="tab-content">
                       
                        <div id="ViewClientes" runat="server" style="display: block">

                            <%-- campos a llenar --%>
                                <div class="row">

                                    <%-- fin campos a llenar --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- tabla--%>
                                    <div class="col-md-12 col-xs-12" style="overflow-y: auto">
                                        <asp:Repeater ID="rpElemento" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblElemento" class="row-border table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Decripcion</th>
                                                            
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="btnSeleccionarCliente" runat="server" ToolTip="Seleccionar" CommandArgument='<%# Eval("idElemento") %>' OnClick="btnSeleccionarElemento_Click"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <%# Eval("descripcionElemento") %>
                                                    </td>
                                                   
                                                </tr>

                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <thead>
                                                    <tr id="filterrow">
                                                        <td></td>
                                                        <th>Descripcion</th>
                                                       
                                                    </tr>
                                                </thead>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <%-- fin tabla--%>
                                </div>
                        </div>
                     
                    </div>
                </div>
               
            </div>

        </div>
    </div>
    <!-- Fin Modal  Elemento a Revisar-->

    <!-- Modal Elemento a revisar-->
    <div id="modalUsuarios" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Seleccionar usuario responsable</h4>
                </div>
                <div class="modal-body">

                   

                    <div class="tab-content">
                      
                        <div id="Div1" runat="server" style="display: block">

                            <%-- campos a llenar --%>
                                <div class="row">

                                    <%-- fin campos a llenar --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- tabla--%>
                                    <div class="col-md-12 col-xs-12" style="overflow-y: auto">
                                        <asp:Repeater ID="rpUsuario" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblUsuario" class="row-border table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Nombre</th>
                                                            
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="btnSeleccionarCliente" runat="server" ToolTip="Seleccionar" CommandArgument='<%# Eval("idUsuario") %>' OnClick="btnSeleccionarUsuario_Click"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <%# Eval("nombre") %>
                                                    </td>
                                                   
                                                </tr>

                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <thead>
                                                    <tr id="filterrow">
                                                        <td></td>
                                                        <th>Nombre</th>
                                                       
                                                    </tr>
                                                </thead>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <%-- fin tabla--%>
                                </div>
                        </div>

                    </div>
                </div>
               
            </div>

        </div>
    </div>

    
    <script src="../Scripts/moment.js"></script>
    <script src="../Scripts/transition.js"></script>
    <script src="../Scripts/collapse.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>
    

    <!-- Fin Modal Usuarios-->
     <script type="text/javascript">

          function activarModalElementos() {
            $('#modalElementos').modal('show');
         };

          function activarModalUsuarios() {
            $('#modalUsuarios').modal('show');
         };


            /****************************** TABLA Elementos a revisar ***********************************/
        $('#tblElemento thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElemento thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var tblElemento = $('#tblElemento').DataTable({
            orderCellsTop: true,
            "iDisplayLength": 10,
            "aLengthMenu": [[2, 5, 10, -1], [2, 5, 10, "All"]],
            "colReorder": true,
            "select": false,
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
                'pdf', 'excel', 'copy', 'print'
            ],
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        // aplicar filtro
        $("#tblElemento thead input").on('keyup change', function () {
            tblElemento
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /****************************** FIN TABLA Elementos ***********************************/

           /****************************** TABLA Usuario ***********************************/
        $('#tblUsuario thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblUsuario thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var tblUsuario = $('#tblUsuario').DataTable({
            orderCellsTop: true,
            "iDisplayLength": 10,
            "aLengthMenu": [[2, 5, 10, -1], [2, 5, 10, "All"]],
            "colReorder": true,
            "select": false,
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
                'pdf', 'excel', 'copy', 'print'
            ],
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        // aplicar filtro
        $("#tblUsuario thead input").on('keyup change', function () {
            tblUsuario
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /****************************** FIN TABLA Usuarios ***********************************/
         </script>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

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
            var fechaIncorrecta;

            fechaIncorrecta = document.getElementById('<%= divFechaIncorrecta.ClientID %>');

            if (txtFecha.value != "" && patron.test(txtFecha.value)) {
                txtFecha.className = "From-Date form-control";
                fechaIncorrecta.style.display = 'none';
            } else {
                txtFecha.className = "From-Date form-control alert-danger";
                fechaIncorrecta.style.display = 'block';
            }
        };


    </script>
</asp:Content>
