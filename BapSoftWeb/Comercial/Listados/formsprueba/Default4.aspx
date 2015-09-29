<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Comercial_Listados_Default4" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Free Bootstrap Admin Template : Binary Admin</title>
	<!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
     <!-- MORRIS CHART STYLES-->

    <!--STYLE DATEPICKER-->   
    <link rel="stylesheet" href="assets/css/datepicker/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/datepicker/bootstrap-datepicker.min.css" />
    <!--FIN-->

    <!-- CUSTOM STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
     <!-- GOOGLE FONTS-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
     <!-- TABLE STYLES-->
    <link href="assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- DATEPICKER-->
    <!-- DATE PICKER -->
    <link href="assets/datepicker/css/jquery-ui.css" rel="stylesheet">
    <!-- DATE PICKER -->
    <script src="assets/datepicker/js/jquery.js"></script>    
    <script src="assets/datepicker/js/jquery-ui.js"></script>
    <script src="assets/datepicker/js/jquery.ui.datepicker-es.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker({
                showOn: "button",
                showButtonPanel: true,
                buttonImage: "assets/datepicker/images/calendar.gif",
                minDate: 0,
                /*maxDate: "+1M +10D",*/
                buttonImageOnly: true,
                buttonText: "Seleccionar fecha"
            });
        });

    </script>


    <style>
    
    /*body{
        font: 62.5% "Trebuchet MS", sans-serif;
        margin: 50px;
    }*/
    .demoHeaders {
        margin-top: 2em;
    }
    #dialog-link {
        padding: .4em 1em .4em 20px;
        text-decoration: none;
        position: relative;
    }
    #dialog-link span.ui-icon {
        margin: 0 5px 0 0;
        position: absolute;
        left: .2em;
        top: 50%;
        margin-top: -8px;
    }
    #icons {
        margin: 0;
        padding: 0;
    }
    #icons li {
        margin: 2px;
        position: relative;
        padding: 4px 0;
        cursor: pointer;
        float: left;
        list-style: none;
    }
    #icons span.ui-icon {
        float: left;
        margin: 0 4px;
    }
    .fakewindowcontain .ui-widget-overlay {
        position: absolute;
    }
    select {
        width: 200px;
    }
    </style>

<script type="text/javascript">
    function Leer(val1) {
        $('#<%=HdF2.ClientID%>').val(val1);
    }
</script>
    <!--Button1.click();-->
</head>
<body>
    <form id="form1" runat="server">
          <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                        <h2><center> Pedidos Pendientes de Aprobación </center></h2>   
                        <h5>
                            <p style="text-align : justify;">
                            <b>Bienvenido Sr(a). Juan Perez</b>,                             
                             en esta sección usted podrá visualizar el listado de todos los pedidos pendientes de aprobación 
                             <a style="color:#31708f;" href="#" data-toggle="modal" data-target="#myModal2">[si necesita ayuda haga click aquí...]</a>
                             <!--
                             (botón blanco), además de editarlos (botón azul) y/o eliminarlos (botón rojo), según la opción seleccionada de la columna <b>[Menú Opciones]</b> de la tabla llamada Lista de Items, las cuales se ubican al lado derecho de la lista.-->
                            </p>
                        </h5>
                    </div>
                </div>
                 <!-- /. ROW  -->
                 <hr />


                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Lista de Items
                                        </div>
                                        <div class="panel-body">
                                        <!-- -->
                    <!--    Lista de Items  -->
                                   <div class="table-responsive">
                                       <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" 
                                             CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,2]}" 
                                            onrowcommand="GridView_RowCommand" OnSelectedIndexChanged="GridView_SelectedIndexChanged" PageSize="3">
                                            <Columns>                
                                                <asp:BoundField DataField="nmruc" HeaderText="R.U.C." SortExpression="key" />
                                                <asp:BoundField DataField="ctactename" HeaderText="Cliente" SortExpression="descrip" />
                                                <asp:BoundField DataField="numdoc" HeaderText="Proforma" SortExpression="descrip" />
                                                <asp:BoundField DataField="vendorname" HeaderText="Vendedor" SortExpression="descrip" />

                                                <asp:TemplateField HeaderText="[MENU OPCIONES]" ControlStyle-CssClass="odd gradeX">
                                                <ItemTemplate>                    
                                                    <a href="#" data-toggle="modal" data-target="#myModalSearch" class="btn btn-default" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-laptop"></i> Ver PDF</a>
                                                    <a href="#" data-toggle="modal" data-target="#myModalUpdate" class="btn btn-primary" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-edit"></i> Editar&nbsp;&nbsp;&nbsp;&nbsp;</a>
                                                    <a href="#" data-toggle="modal" data-target="#myModalDelete" class="btn btn-danger" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-pencil"></i> Eliminar&nbsp;</a>                                                                                                        
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                       </div>
                     <!--  End  Lista de Items  
                         grid sortable {disableSortCols: [0,2]}
                         <button class="btn btn-primary" data-toggle="modal" data-target="#myModal1"><i class="fa fa-edit "></i> Editar&nbsp;&nbsp;&nbsp;&nbsp;</button>
                                            <button class="btn btn-danger" data-toggle="modal" data-target="#myModal"><i class="fa fa-pencil"></i> Eliminar&nbsp;</button>
                         -->

                                        </div>
                                    </div>                                    
                                </div>
                            </div>
                            <!-- Modal Search -->
                            <div class="modal fade" id="myModalSearch" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H3">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto?
                                        </div>
                                        <div class="modal-footer">              
                                            <asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" data-dismiss="modal" runat="server" OnClick="LkBSearch_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelSer" CssClass="btn btn-primary" runat="server" OnClick="LkBCancelSer_Click">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Search -->
                            <!-- Modal Update -->
                            <div class="modal fade" id="myModalUpdate" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H1">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea grabar los cambios realizados en el registro?                                            
                                        </div>
                                        <div class="modal-footer">                                            
                                            <asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" data-dismiss="modal" runat="server" OnClick="LkBUpdate_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelUpd" CssClass="btn btn-primary" runat="server" OnClick="LkBCancelUpd_Click">Cancelar</asp:LinkButton>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Update -->
                            <!-- Modal Delete -->
                            <div class="modal fade" id="myModalDelete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea eliminar el registro?
                                        </div>
                                        <div class="modal-footer">              
                                            <asp:LinkButton ID="LkBDelete" CssClass="btn btn-default" data-dismiss="modal" runat="server" OnClick="LkBDelete_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelDel" CssClass="btn btn-primary" runat="server" OnClick="LkBCancelDel_Click">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Delete -->
                            <!-- Modal Help -->
                            <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H2">Manual de Usuario</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p style="text-align : justify;">
                            <b>Bienvenido Sr(a). Juan Perez</b>,                             
                             en esta sección usted podrá visualizar el listado de todos los pedidos pendientes de aprobación.
                              Este listado contienen una sección o columna con botones que se aprecian de distintos colores para un mejor manejo de los registros.
                            </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Ver PDF(botón color blanco), se visualizará un documento en formato PDF del registro seleccionado.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Editar(botón color azul) se visualizará una ventana emergente con los datos del registro que desea editar, una vez realizado los cambios deseados, presione sobre el botón guardar para grabar los cambios.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Eliminar (botón color rojo), se visualizará una ventana, la cual le solicitará la confirmación de la orden seleccionada, para el caso de eliminar el registro presionar sobre en botón Si o No en caso contrario no desee eliminar.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Ver PDF(botón color blanco), se visualizará un documento en formato PDF del registro seleccionado.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Editar(botón color azul) se visualizará una ventana emergente con los datos del registro que desea editar, una vez realizado los cambios deseados, presione sobre el botón guardar para grabar los cambios.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Eliminar (botón color rojo), se visualizará una ventana, la cual le solicitará la confirmación de la orden seleccionada, para el caso de eliminar el registro presionar sobre en botón Si o No en caso contrario no desee eliminar.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Ver PDF(botón color blanco), se visualizará un documento en formato PDF del registro seleccionado.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Editar(botón color azul) se visualizará una ventana emergente con los datos del registro que desea editar, una vez realizado los cambios deseados, presione sobre el botón guardar para grabar los cambios.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Eliminar (botón color rojo), se visualizará una ventana, la cual le solicitará la confirmación de la orden seleccionada, para el caso de eliminar el registro presionar sobre en botón Si o No en caso contrario no desee eliminar.
                              </p>
                            <!--
                              visualización que se encuentran de botón blanco), además de editarlos (botón azul) y/o eliminarlos (botón rojo), según la opción seleccionada de la columna <b>[Menú Opciones]</b> de la tabla llamada Lista de Items, las cuales se ubican al lado derecho de la lista.
                            </p>
                        -->
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <!--<button type="button" class="btn btn-primary">No</button>-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Help -->
                <!-- /. ROW  -->
                <!-- Botones -->
                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                        <!-- -->
                                        <center style="margin-bottom:5px; margin-top:5px;">                                            
                                            <a href="confirmacion.html" class="btn btn-primary">Continuar</a>
                                            <button type="submit" class="btn btn-default">Salir</button>
                                        </center>
                                        </div>
                                    </div>                                    
                                </div>
                            </div>
              <asp:HiddenField ID="HdF2" runat="server" />               
                <!-- End Botones -->
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
      <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
     <!-- DATA TABLE SCRIPTS -->
    <script src="assets/js/dataTables/jquery.dataTables.js"></script>
    <script src="assets/js/dataTables/dataTables.bootstrap.js"></script>
        <script>
            $(document).ready(function () {
                $('#GridView').dataTable();
            });
    </script>
         <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>




        <link href="assets/table/css/styles.css" rel="stylesheet" />
        <script src="assets/table/scripts/jquery-1.4.2.min.js"></script>
        <script src="assets/table/scripts/jquery.dataTables.min.js"></script>
        <script src="assets/table/scripts/jquery.metadata.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {

                // Setup Metadata plugin
                $.metadata.setType("class");

                // Setup GridView
                $("table.grid").each(function () {
                    var jTbl = $(this);

                    if (jTbl.find("tbody>tr>th").length > 0) {
                        jTbl.find("tbody").before("<thead><tr></tr></thead>");
                        jTbl.find("thead:first tr").append(jTbl.find("th"));
                        jTbl.find("tbody tr:first").remove();
                    }

                    // If GridView has the 'sortable' class and has more than 10 rows
                    if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 10) {

                        // Run DataTable on the GridView
                        jTbl.dataTable({
                            sPaginationType: "full_numbers",
                            sDom: '<"top"lf>rt<"bottom"ip>',
                            oLanguage: {
                                sInfoFiltered: "(de _MAX_ registados)",
                                sSearch: "Buscar: "
                            },
                            aoColumnDefs: [
                                { bSortable: false, aTargets: jTbl.metadata().disableSortCols }
                            ]
                        });
                    }
                });
            });

    </script>

    </form>
</body>
</html>
