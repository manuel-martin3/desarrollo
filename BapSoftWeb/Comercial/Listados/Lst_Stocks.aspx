<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_Stocks.aspx.cs" Inherits="Comercial_Listados_LstStocks" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
 
    <style>
    
    
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
        var isDetailRowExpanded = new Array();
        function OnRowClick(s, e) {
            if (isDetailRowExpanded[e.visibleIndex] != true)
                s.ExpandDetailRow(e.visibleIndex);
            else
                s.CollapseDetailRow(e.visibleIndex);
        }
        function OnDetailRowExpanding(s, e) {
            isDetailRowExpanded[e.visibleIndex] = true;
        }
        function OnDetailRowCollapsing(s, e) {
            isDetailRowExpanded[e.visibleIndex] = false;
        }
    </script>

<style>
    .myinput {
    background-color: transparent;
    border: 0px solid;
    height: 20px;
    width: 160px;
    color: #CCC;
}
    .myinput:focus{
	outline:0px;
}
</style>
    
</head>
<body>
    <form id="form1" runat="server">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                        <h2><center> ...:: Stock de Articulos ::... </center></h2>                           
                    </div>
                </div>
                
                          <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <!--<div class="panel-heading">
                                            <i class="fa fa-search fa-1x"> &nbsp;</i>Control de Búsqueda
                                        </div>-->
                                        <div class="panel-body">
                                        <!-- -->                                            
                                        <!--    Lista de Items  -->
                                        <!--<div class="table-responsive">-->
                                        <div class="row">
                                        <div class="col-md-4">
                                          <!--   Kitchen Sink -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                     <i class="fa fa-bookmark-o fa-1x"> &nbsp;</i> Búsqueda por Marca
                                                </div>
                                                <div class="panel-body">
                                                    <div class="table-responsive">
                                                        <div class="form-group">
                                                            <asp:DropDownList ID="DDLMark" runat="server" 
                                                                CssClass="form-control"></asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                             <!-- End  Kitchen Sink -->
                                        </div>

                                        <div class="col-md-4">
                                             <!--   Basic Table  -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <i class="fa fa-user fa-1x"> &nbsp;</i>Búsqueda por Género
                                                </div>
                                                <div class="panel-body">
                                                    <div class="table-responsive">
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="DDLGenere" runat="server" 
                                                            CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                              <!-- End  Basic Table  -->
                                        </div>

                                        <div class="col-md-4">
                                             <!--   Basic Table  -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">                                                    
                                                    <i class="fa fa-tags fa-1x"> &nbsp;</i>Búsqueda por Línea
                                                </div>
                                                <div class="panel-body">
                                                    <div class="table-responsive">                                
                                                        <div class="form-group">
                                                        <asp:DropDownList ID="DDLLine" runat="server" 
                                                            CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                              <!-- End  Basic Table  -->
                                        </div>                
                                        <center style="top:0px;">
                                         <button type="submit" class="btn btn-success">
                                             <i class="fa fa-filter fa-1x"> &nbsp;</i> Filtrar Items</button>
                                         </center>
                                         <br />
                                    </div>
                                       <!--</div>-->
                                        </div>
                                    </div>                                    
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">                                            
                                            <i class="fa fa-list-alt fa-1x"> &nbsp;</i>Lista de Items
                                        </div>
                                        <div class="panel-body">
                                        <!-Lista de Items
                                        </div>
                                        <div class="panel-body">
                                        <!-- -->                                            
                                        <!--    Lista de Items  -->
                                        <div class="table-responsive">
                                                                            
                                             <%-- <dx:ASPxGridView ID="AspxDgb_prod" runat="server" AutoGenerateColumns="False" 
                                                  Theme="Aqua" EnableTheming="True" ClientInstanceName="AspxDgb_prod" Width="100%">--%>

                                            <dx:ASPxGridView ID="AspxDgb_prod" runat="server" Theme="Aqua" EnableTheming="True" 
                                                AutoGenerateColumns="False" KeyFieldName="articid" Width="100%">
                                                                                                
                                                <SettingsDetail ShowDetailRow="true" ExportMode="Expanded" />                                                
                                                <ClientSideEvents RowClick="OnRowClick" DetailRowExpanding="OnDetailRowExpanding"
                                                    DetailRowCollapsing="OnDetailRowCollapsing" />

                                                  <Columns>                                                                                                                                                         
                                                      <dx:GridViewDataTextColumn FieldName="articid" VisibleIndex="0" Caption="Codigo" GroupIndex="0" SortIndex="0" SortOrder="Ascending" UnboundExpression="articid" />
                                                      <dx:GridViewDataTextColumn FieldName="articname" VisibleIndex="1" Caption="Articulo" GroupIndex="1" SortIndex="1" SortOrder="Ascending" UnboundExpression="articname" />                                                     
                                                      <dx:GridViewDataTextColumn FieldName="colorname" VisibleIndex="2" UnboundExpression="colorname" Caption="Color"/>
                                                      <dx:GridViewDataTextColumn FieldName="sto01" VisibleIndex="9"  Caption="ta01" />
                                                      <dx:GridViewDataTextColumn FieldName="sto02" VisibleIndex="10" Caption="ta02" />                                                      
                                                      <dx:GridViewDataTextColumn FieldName="sto03" VisibleIndex="11" Caption="ta03" />                                                      
                                                      <dx:GridViewDataTextColumn FieldName="sto04" VisibleIndex="12" Caption="ta04" />                                                    
                                                      <dx:GridViewDataTextColumn FieldName="sto05" VisibleIndex="13" Caption="ta05" />                                                      
                                                      <dx:GridViewDataTextColumn FieldName="sto06" VisibleIndex="14" Caption="ta06" />                                                      
                                                      <dx:GridViewDataTextColumn FieldName="sto07" VisibleIndex="15" Caption="ta07" />                                                   
                                                      <dx:GridViewDataTextColumn FieldName="sto08" VisibleIndex="16" Caption="ta08" />                                                  
                                                      <dx:GridViewDataTextColumn FieldName="sto09" VisibleIndex="17" Caption="ta09" />                                                   
                                                      <dx:GridViewDataTextColumn FieldName="sto10" VisibleIndex="18" Caption="ta10" />                                                
                                                      <dx:GridViewDataTextColumn FieldName="sto11" VisibleIndex="19" Caption="ta11" />                                                 
                                                      <dx:GridViewDataTextColumn FieldName="sto12" VisibleIndex="20" Caption="ta12" />                                                                                                    
                                                  </Columns>
                                                  <Settings ShowGroupPanel="True" VerticalScrollBarMode="Visible" VerticalScrollableHeight="700" />                                                 
                                                  <SettingsPager Mode="ShowAllRecords" />
                                              </dx:ASPxGridView>
                                                                                     

                                        </div>                                            
                                        </div>
                                    </div>                                    
                                </div>
                            </div>



                            <!-- Modal Search -->
                            <div class="modal fade" id="myModalSearch" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;                <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto? 
                                            <img src="assets/img/attach.png" />                                           
                                        </div>
                                        
                                        <div class="modal-footer">                                                                                                                                                  
                                            <!--<asp:TextBox ID="LblIdSer" runat="server" Visible="False"></asp:TextBox>-->
                                            <asp:HiddenField ID="HdFIdSer" runat="server" />
                                            <asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>                                                                          
                                            <asp:LinkButton ID="LkBCancelSer" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
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
                                            ¿Desea visualizar el archivo adjunto?                                            
                                            <img src="assets/img/attach.png" />                                           
                                            <asp:HiddenField ID="HdFIdUpd" runat="server" />      
                                            <!--<asp:TextBox ID="LblIdUpd" runat="server" Visible="False"></asp:TextBox>-->
                                        </div>
                                        <div class="modal-footer">                                            
                                            <asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelUpd" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>
                                            
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
                                            <asp:TextBox ID="LblIdDel" runat="server"></asp:TextBox>                                            
                                            
                                        </div>
                                        <div class="modal-footer">              
                                            <asp:LinkButton ID="LkBDelete" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelDel" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Delete -->
                            <!-- Modal Status -->
                            <div class="modal fade" id="myModalStatus" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H4">Mensaje</h4>
                                        </div>
                                        
                                        <div class="modal-body">                                            
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <!-- Clientes -->
                                                    <div class="panel panel-default">                                                                                                            
                                                        <!--<div class="panel-heading">-->
                                                            <!--Detalles Cliente-->
                                                            <!--Detalle Clientes
                                                        </div>-->
                                                        <div class="panel-body">
                                                            <!--<div class="table-responsive">-->                                                            
                                                                <b>
                                                                    <asp:Label ID="LblIdNam" runat="server" Text="Label"></asp:Label>
                                                                </b>                                            
                                                            <!--</div>-->
                                                        </div>
                                                    </div>
                                                    <!--End Clientes -->
                                                </div>                                                
                                            </div>

                                            <div class="row">
                                                <div class="col-md-7">
                                                  <!--   Detalles Cliente -->
                                                    <!--<div class="panel panel-info">-->
                                                    <div id="detCli">
                                                        <div class="panel-heading">                                                            
                                                        Estado :
                                                            <b style="font-size:small;">
                                                                <asp:Label ID="LblCond" runat="server" Text="Label"></asp:Label>                                                            
                                                                <img id="image" alt="" src="" />
                                                            </b>    
                                                        
                                                        </div>
                                                        <div class="panel-body">
                                                        Número R.U.C : 
                                                            <asp:Label ID="LblIdRuc" runat="server" Text="Label"></asp:Label>                                                            
                                                        <br /> <br /> 
                                                        Número documento :
                                                        <asp:Label ID="LblIdDoc" runat="server" Text="Label"></asp:Label>                                                                                                                                                                               
                                                        </div> 
                                                        <br />                                                       
                                                    </div>
                                                     <!-- End  Detalles Cliente -->
                                                </div>
                                                <div class="col-md-5">
                                                     <!--   Control de Estados  -->
                                                    <div class="panel panel-primary">
                                                        <div class="panel-heading">
                                                            Control de Estados
                                                           
                                                        </div>
                                                    <div class="form-group" style="margin-left:15px;">
                                                        <!--<label>Selector de Estados</label>-->
                                                        <%--<asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Menú Opciones]"  
                                                        ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" 
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">                                                                           
                                                    <ItemTemplate>                                                                      
                                                        <a href="#" data-toggle="modal" data-target="#ModalCliente" class="btn btn-info" style=" text-decoration:none;" 
                                                            onclick="Leer('<%#Eval("articid").ToString()%>');" )">
                                                            <i class="fa fa-print">&nbsp;Detalle</i>
                                                        </a>                                                                                
                                                    </ItemTemplate>
                                                    </asp:TemplateField>--%>                                                        
                                                        <asp:RadioButtonList ID="RBL1" runat="server" AutoPostBack="False">                                        
                                                                <asp:ListItem Value="0">Desaprobado</asp:ListItem>
                                                                <asp:ListItem Value="1">Aprobado</asp:ListItem>                                        
                                                                <asp:ListItem Value="2">Pendiente</asp:ListItem>                                                
                                                        </asp:RadioButtonList>  
                                                                    
                                                                    <!--
                                                                    <hr />
                                                                    <asp:Label ID="resultado" runat="server" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>                                    
                                                                    <asp:Label ID="resultado1" runat="server" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>-->
                                                                    <br />
                                                                    <asp:HiddenField ID="HdF1" runat="server" />               
                                                                    <asp:Label ID="opval" runat="server" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>
                                                    </div>                                                        
                                                    </div>
                                                      <!-- End  Control de Estados  -->
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <!-- Clientes -->
                                                    <div class="panel panel-info">
                                                        <!--<div class="panel-heading">
                                                            Observación
                                                        </div>-->
                                                        <div class="panel-body">
                                                            <div class="table-responsive">                                                                
                                                                <asp:TextBox ID="LblIdObs" runat="server" style=" width:100%; height:75px;" TextMode="MultiLine"></asp:TextBox>
                                                            </div>                            
                                                        </div>
                                                    </div>
                                                    <!--End Clientes -->
                                                </div>
                                            </div>
                                                ¿Desea cambiar el estado del registro?
                                        </div>
                                    
                                        <div class="modal-footer">              
                                            <asp:LinkButton ID="LkBStatus" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelSta" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Status -->
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

        <!--CUSTOM TABLE-->
        <link href="assets/table/css/styles.css" rel="stylesheet" />
        <script src="assets/table/scripts/jquery-1.4.2.min.js"></script>
        <script src="assets/table/scripts/jquery.dataTables.min.js"></script>
        <script src="assets/table/scripts/jquery.metadata.js"></script>              
       
    <!--END CUSTOM TABLE-->
    </form>
</body>
</html>
