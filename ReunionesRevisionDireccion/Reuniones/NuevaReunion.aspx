<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaReunion.aspx.cs" Inherits="ReunionesRevisionDireccion.Catalogos.NuevaReunion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- tabs -->

    <ul class="nav nav-tabs">
        <li id="liReunion" runat="server" class="active"><a onclick="verViewReunion()">Reunión</a></li>
        <li id="liElementoRevisar" runat="server"><a onclick="verViewElementoRevisar()">Elementos a Revisar</a></li>
         <li id="liUsuario" runat="server"><a onclick="verViewUsuarios()">Participantes</a></li>
    </ul>
    <!-- fin tabs -->

    <!-- ------------------------ VISTA Reunión --------------------------- -->
    <div id="ViewReunion" runat="server" style="display: block">
        <div class="divCuadrado">


            <div class="row">

                <%-- titulo accion--%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblNuevaReunion" runat="server" Text="Nueva Reunion" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin titulo accion --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- campos a llenar --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:DropDownList ID="ddlTipos" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
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
                        <asp:TextBox ID="txtAnno" class="btn btn-default dropdown-toggle" runat="server" type="number"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlMeses" class="btn btn-default dropdown-toggle" runat="server" Width="150px" AutoPostBack="true">
                            <asp:ListItem Text="Enero" Value="1" />
                            <asp:ListItem Text="Febrero" Value="2" />
                            <asp:ListItem Text="Marzo" Value="3" />
                            <asp:ListItem Text="Abril" Value="4" />
                            <asp:ListItem Text="Mayo" Value="5" />
                            <asp:ListItem Text="Junio" Value="6" />
                            <asp:ListItem Text="Julio" Value="7" />
                            <asp:ListItem Text="Agosto" Value="8" />
                            <asp:ListItem Text="Septiembre" Value="9" />
                             <asp:ListItem Text="Octubre" Value="10" />
                             <asp:ListItem Text="Noviembre" Value="11" />
                             <asp:ListItem Text="Diciembre" Value="12" />
                        </asp:DropDownList>
                    </div>
                </div>

                 <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>


                 <!-- Archivos Reunion -->
   
            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <div class="col-md-3 col-xs-3 col-sm-3">
                    <asp:Label ID="lblArchivos" runat="server" Text="Archivos " Font-Size="Medium" ForeColor="Black" Font-Bold="true" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:FileUpload ID="fuArchivos" runat="server" AllowMultiple="true" oninput="validarArchivos(this);" onchange="validarArchivos(this);" />
                </div>
                <div class="col-md-5 col-xs-5 col-sm-5" id="divArchivosVacio" runat="server" style="display: none;">
                    <asp:Label ID="lblArchivosVacio" runat="server" Font-Size="Small" CssClass="label alert-danger" Text="Debe seleccionar al menos un archivo" ForeColor="Red" Visible="false"></asp:Label>
                </div>
            </div>
           
            <!-- Fin Archivos Reunion -->

                 <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>






                <%-- fin campos a llenar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>


                <%-- botones --%>


                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>

                  <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <%-- fin botones --%>
            </div>
        </div>
    </div>
    <!-- ------------------------ FIN VISTA Reunión --------------------------- -->

    <!-- ------------------------ VISTA Elementos a revisar --------------------------- -->
    <div id="ViewElementoRevisar" runat="server" style="display: none">
       
           <div class="divCuadrado">
            <div class="row">

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="alertdialog">
                    <div class="modal-dialog modal-lg">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Asociar Elementos a Revisar</h4>
                            </div>
                            <div class="modal-body">
                                <%-- cuerpo modal --%>

                                <div class="row">

                                    <%-- Escoger Elementos --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                                        <asp:Repeater ID="rpElementoSinAsociar" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblElementoSinAsociar" class="row-border table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Descripción del Elemento</th>
                                                           
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="btnAsocair" runat="server" ToolTip="Asociar" OnClick="btnAsociar_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-ok-circle"></span></asp:LinkButton>
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
                                                        <th>Descripcion del Elemento</th>
                                                        
                                                    </tr>
                                                </thead>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- fin Escoger Elementos --%>
                                </div>

                                <%-- Fin cuerpo modal --%>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                        <!-- Fin Modal content-->

                    </div>
                </div>
                <!-- Fin Modal -->

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <%-- Mostrar Elementos Asociados --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblElementosAsociados" runat="server" Text="Elementos a revisar asociados a la reunión" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin Mostrar Elementos Asociados --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- tabla mostar Elementos asociados al laboratorio --%>
                <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                    <asp:Repeater ID="rpElemento" runat="server">
                        <HeaderTemplate>
                            <table id="tblElemento" class="row-border table-striped">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Descripción del Elemento</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnDesasociar" runat="server" ToolTip="Desasociar" OnClick="btnDesasociar_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-remove-circle"></span></asp:LinkButton>
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
                                    <th>Descripción del Elemento</th>

                                </tr>
                            </thead>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <button id="btnModal" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Asociar</button>
                </div>
                <%-- fin tabla mostar Elementos asociados al laboratorio --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- boton cancelar --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="btnActualizar2" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnRegresar_Click" />
                </div>
                <%-- fin boton cancelar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

            </div>
        </div>

    </div>
    <!-- ------------------------ FIN VISTA Elementos a revisar --------------------------- -->


     <!-- Modal Confirmar Desasociar Elementos a revisar -->
    <div id="modalDesasociarElementos" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirmar</h4>
                </div>
                <div class="modal-body">
                    <%-- campos a llenar --%>
                    <div class="row">

                        <%-- fin campos a llenar --%>

                        <div class="col-md-12 col-xs-12 col-sm-12">
                            <br />
                        </div>

                        <div class="col-md-12 col-xs-12 col-sm-12" style="text-align:center">
                                <asp:Label ID="lblDesasocaiarElemento" runat="server" Text="¿Está seguro o segura que desea desasociar el elemento a revisar?" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                        </div>


                    </div>
                </div>
                <div class="modal-footer" style="text-align:center">
                    <asp:Button ID="btnDesasociarElemento" runat="server" Text="Si" CssClass="btn btn-primary" OnClick="btnDesasociarElementoConfirmar_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>

        </div>
    </div>
    <!-- Fin Confirmar Eliminar Norma -->

<!--****************************************************************************************** -->
       <!-- ------------------------ VISTA Usuarios --------------------------- -->
    <div id="ViewUsuario" runat="server" style="display: none">
       
           <div class="divCuadrado">
            <div class="row">

                <!-- Modal -->
                <div id="myModalUsuario" class="modal fade" role="alertdialog">
                    <div class="modal-dialog modal-lg">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Agregar participantes a reunión</h4>
                            </div>
                            <div class="modal-body">
                                <%-- cuerpo modal --%>

                                <div class="row">

                                    <%-- Escoger Usuarios --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                                        <asp:Repeater ID="rpUsuarioSinAsociar" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblUsuarioSinAsociar" class="row-border table-striped">
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
                                                        <asp:LinkButton ID="btnAsociar" runat="server" ToolTip="Asociar" OnClick="btnAsociarUsuario_Click" CommandArgument='<%# Eval("idUsuario") %>'><span class="glyphicon glyphicon-ok-circle"></span></asp:LinkButton>
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

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- fin Escoger Elementos --%>
                                </div>

                                <%-- Fin cuerpo modal --%>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                        <!-- Fin Modal content-->

                    </div>
                </div>
                <!-- Fin Modal -->

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <%-- Mostrar Usuarios Asociados --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblUsuariosAsociados" runat="server" Text="Participantes en la reunión" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin Mostrar Usuarios Asociados --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- tabla mostar Usuarios asociados a la reunion --%>
                <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
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
                                    <asp:LinkButton ID="btnDesasociar" runat="server" ToolTip="Desasociar" OnClick="btnDesasociarUsuario_Click" CommandArgument='<%# Eval("idUsuario") %>'><span class="glyphicon glyphicon-remove-circle"></span></asp:LinkButton>
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

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <button id="btnModalUsuario" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModalUsuario">Asociar</button>
                </div>
                <%-- fin tabla mostar usuarios asociados a la reunion --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- boton cancelar --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnRegresar_Click" />
                </div>
                <%-- fin boton cancelar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

            </div>
        </div>

    </div>
    <!-- ------------------------ FIN VISTA Usuarios --------------------------- -->


     <!-- Modal Confirmar Desasociar Usuarios -->
    <div id="modalDesasociarUsuarios" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirmar</h4>
                </div>
                <div class="modal-body">
                    <%-- campos a llenar --%>
                    <div class="row">

                        <%-- fin campos a llenar --%>

                        <div class="col-md-12 col-xs-12 col-sm-12">
                            <br />
                        </div>

                        <div class="col-md-12 col-xs-12 col-sm-12" style="text-align:center">
                                <asp:Label ID="lblDesasociarUsuario" runat="server" Text="¿Está seguro o segura que desea desasociar el usuario de la reunión ?" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                        </div>


                    </div>
                </div>
                <div class="modal-footer" style="text-align:center">
                    <asp:Button ID="btnDesasociarUsuario" runat="server" Text="Si" CssClass="btn btn-primary" OnClick="btnDesasociarUsuarioConfirmar_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>

        </div>
    </div>
    <!-- Fin Confirmar Eliminar Norma -->

     <!--****************************************************************************************** -->
    
    <!-- script tabla jquery -->
    <script type="text/javascript">

        function activarModalDesasociarElementos() {
            $('#modalDesasociarElementos').modal('show');
        };

         function activarModalDesasociarUsuarios() {
            $('#modalDesasociarUsuarios').modal('show');
        };


        /*tabla Elemento asociados*/
        $('#tblElemento thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElemento thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var table = $('#tblElemento').DataTable({
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
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Elementos asociados*/

        /*tabla Elementos sin asociados*/
        $('#tblElementoSinAsociar thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElementoSinAsociar thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var tblElementoSinAsociar = $('#tblElementoSinAsociar').DataTable({
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
        $("#tblElementoSinAsociar thead input").on('keyup change', function () {
            tblElementoSinAsociar
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Elementos sin asociados*/

       

        $('#tblElemento tbody').on('click', 'tr', function () {
            var prueba = table.row(this).data();
        });

        function stopPropagation(evt) {
            if (evt.stopPropagation !== undefined) {
                evt.stopPropagation();
            } else {
                evt.cancelBubble = true;
            }
        }

        function activarModal() {
            $('#myModal').modal('show');
        };

        ///////////////////////

          /*tabla Usuarios asociados*/
        $('#tblElemento thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElemento thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var table2 = $('#tblUsuario').DataTable({
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
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Usuarios asociados*/

        /*tabla Usuario sin asociar*/
        $('#tblUsuarioSinAsociar thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblUsuarioSinAsociar thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var tblUsuarioSinAsociar = $('#tblUsuarioSinAsociar').DataTable({
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
        $("#tblUsuarioSinAsociar thead input").on('keyup change', function () {
            tblUsuarioSinAsociar
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Usuarios sin asociados*/

       

        $('#tblUsuario tbody').on('click', 'tr', function () {
            var prueba = table.row(this).data();
        });

        function activarModalUsuario() {
            $('#myModalUsuario').modal('show');
        };

      
    </script>
    <!-- fin script tabla jquery -->



    <script type="text/javascript">

        function verViewElementoRevisar() {
            document.getElementById('<%=liReunion.ClientID%>').className = "";
             document.getElementById('<%=liUsuario.ClientID%>').className = "";
            document.getElementById('<%=liElementoRevisar.ClientID%>').className = "active";
      

            document.getElementById('<%=ViewElementoRevisar.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewReunion.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewUsuario.ClientID%>').style.display = 'none';
          
        };

        function verViewReunion() {
            document.getElementById('<%=liElementoRevisar.ClientID%>').className = "";
              document.getElementById('<%=liUsuario.ClientID%>').className = "";
            document.getElementById('<%=liReunion.ClientID%>').className = "active";
        

            document.getElementById('<%=ViewElementoRevisar.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewReunion.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewUsuario.ClientID%>').style.display = 'none';
          
        };

        function verViewUsuarios() {
            document.getElementById('<%=liReunion.ClientID%>').className = "";
            document.getElementById('<%=liElementoRevisar.ClientID%>').className = "";
            document.getElementById('<%=liUsuario.ClientID%>').className = "active";
      

            document.getElementById('<%=ViewUsuario.ClientID%>').style.display = 'block';
             document.getElementById('<%=ViewReunion.ClientID%>').style.display = 'none';
             document.getElementById('<%=ViewElementoRevisar.ClientID%>').style.display = 'none';
          
        };

         function validarArchivos(fileUpload) {
            var id = fileUpload.id.substring(12);

            var divArchivoIncorrecta = document.getElementById('<%= divArchivosVacio.ClientID %>');

            if (fileUpload.files.length > 0) {
                divArchivoIncorrecta.style.display = "none";
            } else {
                divArchivoIncorrecta.style.display = "block";
            }
        };

      

    </script>

</asp:Content>

