﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarElementoRevisar.aspx.cs" Inherits="ReunionesRevisionDireccion.Catalogos.AdministrarElementoRevisar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <div class="row">

            <%-- titulo pantalla --%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
            <asp:Label ID="lblAdministrarElementoRevisar" runat="server" Text="Administrar Elementos a Revisar" Font-Size="Large" ForeColor="Black"></asp:Label>
        </center>
            </div>
            <%-- fin titulo pantalla --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- tabla--%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">

                <asp:Repeater ID="rpElementoRevisar" runat="server"  OnItemDataBound="rpElementoRevisar_ItemDataBound" >
                    <HeaderTemplate>
                        <table id="tblElementoRevisar" class="row-border table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Descripción</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="btnVer" runat="server" ToolTip="Ver" OnClick="btnVer_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>

                                <asp:LinkButton ID="btnEditar" runat="server" ToolTip="Editar" OnClick="btnEditar_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" ToolTip="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
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
                                <th>Descripción</th>
                            </tr>
                        </thead>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <%-- fin tabla--%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- botones --%>
            <div class="col-md-2 col-sm-2 col-xs-1 col-md-offset-9 col-xs-offset-0 col-sm-offset-8">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Elemento a Revisar" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
            </div>
            <%-- fin botones --%>
        </div>
 

       <!-- script tabla jquery -->
    <script type="text/javascript">

        $('#tblElementoRevisar thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElementoRevisar thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var table = $('#tblElementoRevisar').DataTable({
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
        $("#tblElementoRevisar thead input").on('keyup change', function () {
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });

        function stopPropagation(evt) {
            if (evt.stopPropagation !== undefined) {
                evt.stopPropagation();
            } else {
                evt.cancelBubble = true;
            }
        };
    </script>
    <!-- fin script tabla jquery -->
</asp:Content>