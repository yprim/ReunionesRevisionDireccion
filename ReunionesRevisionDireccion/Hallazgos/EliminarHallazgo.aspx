<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarHallazgo.aspx.cs" Inherits="ReunionesRevisionDireccion.Hallazgos.EliminarHallazgo"  MaintainScrollPositionOnPostback="true" %>
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
                        <asp:Label ID="lblEliminarHallazgo" runat="server" Text=" Eliminar Hallazgo" Font-Size="Large" ForeColor="Black"></asp:Label>
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
                        <asp:Label ID="txtElementoSeleccionado" runat="server" ></asp:Label>
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
                        <asp:Label ID="txtUsuarioSeleccionado" runat="server"></asp:Label>
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
                        <asp:Label  ID="txtObservaciones" runat="server"></asp:Label>
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
                        <asp:Label ID="txtEstados"  runat="server"></asp:Label>
                    </div>
                </div>

                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                   <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha máxima de implementación" Font-Size="Medium" ForeColor="Black" Font-Bold="true" CssClass="label"></asp:Label>
                </div>
               
                 <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label  ID="txtFecha" runat="server"></asp:Label>
               </div>
  
            </div>

                 <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblCodigoAccion" runat="server" Text="Código de Acción " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>

                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:Label  ID="txtCodigoAccion"  TextMode="MultiLine" runat="server"></asp:Label>
                    </div>
                </div>

                <%-- fin campos a llenar --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <hr />
                </div>
                <%-- botones --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="Button1" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
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
   
 

     <script type="text/javascript">

        

          function activarModalUsuarios() {
            $('#modalUsuarios').modal('show');
         };

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



