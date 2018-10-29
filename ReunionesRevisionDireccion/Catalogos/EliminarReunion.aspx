<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarReunion.aspx.cs" Inherits="ReunionesRevisionDireccion.Catalogos.EliminarReunion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- tabs -->

    <ul class="nav nav-tabs">
        <li id="liReunion" runat="server" class="active"><a onclick="verViewReunion()">Reunión</a></li>
        <li id="liElementoRevisar" runat="server"><a onclick="verViewElementoRevisar()">Elementos a Revisar</a></li>
    </ul>
    <!-- fin tabs -->

    <!-- ------------------------ VISTA Reunión --------------------------- -->
    <div id="ViewReunion" runat="server" style="display: block">
        <div class="divCuadrado">


            <div class="row">

                <%-- titulo accion--%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblNuevaReunion" runat="server" Text="Eliminar Reunion" Font-Size="Large" ForeColor="Black"></asp:Label>
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
                        <asp:Label ID="lblNumero" runat="server" Text="Número " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                       <asp:Label ID="txtNumero" runat="server" ></asp:Label>
                    </div>
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

                

                <div class="col-xs-12">
                    <br />
                    
                </div>


                <%-- fin campos a llenar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>


                <%-- botones --%>


                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="btnGuardar" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
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

                <%-- tabla mostar Elementos asociados la reunion --%>
                <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                    <asp:Repeater ID="rpElemento" runat="server">
                        <HeaderTemplate>
                            <table id="tblElemento" class="row-border table-striped">
                                <thead>
                                    <tr>
                                      
                                        <th>Descripción del Elemento</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                          
                                <td>
                                    <%# Eval("descripcionElemento") %>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            <thead>
                                <tr id="filterrow">
                                
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

                <%-- fin tabla mostar Elementos asociados  --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- boton cancelar --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
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


    
    <!-- script tabla jquery -->
    <script type="text/javascript">

  

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


        // aplicar filtro
        $("#tblElementoSinAsociar thead input").on('keyup change', function () {
            tblElementoSinAsociar
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
 
    </script>
    <!-- fin script tabla jquery -->



    <script type="text/javascript">

        function verViewElementoRevisar() {
            document.getElementById('<%=liReunion.ClientID%>').className = "";
            document.getElementById('<%=liElementoRevisar.ClientID%>').className = "active";
      

            document.getElementById('<%=ViewElementoRevisar.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewReunion.ClientID%>').style.display = 'none';
         
        };

        function verViewReunion() {
            document.getElementById('<%=liElementoRevisar.ClientID%>').className = "";
            document.getElementById('<%=liReunion.ClientID%>').className = "active";
        

            document.getElementById('<%=ViewElementoRevisar.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewReunion.ClientID%>').style.display = 'block';
          
        };

      

    </script>

</asp:Content>

