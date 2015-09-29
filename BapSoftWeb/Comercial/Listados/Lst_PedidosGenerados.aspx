<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_PedidosGenerados.aspx.cs" Inherits="Comercial_Listados_Lst_PedidosGenerados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title></title>
    <!-- Bootstrap Core CSS -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="assets/css/grayscale.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <link href="assets/datepicker/_css/jquery-ui.css" rel="stylesheet" />
    <script src="assets/datepicker/_js/jquery.js"></script>
    <script src="assets/datepicker/_js/jquery-ui.js"></script>    
    <link href="assets/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    
<script type="text/javascript">
    function Leer(val1, val2, val3, val4, val5, val6) {
        $('#<%=HdFOpenItem.ClientID%>').val(val1);
        $('#<%=HdFDeleteItem.ClientID%>').val(val1);
        $('#<%=HdFUpdateItem.ClientID%>').val(val1);
        $('#<%=HdFPrintItem.ClientID%>').val(val1);        
    }
</script>
    
</head>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">    
    <form id="form1" runat="server">    
         
        <!--Espacio inicio cabecera-->
        <div class="download-section">            
        </div>
        <header class="intro">            
            <div class="intro-body">                
                <div class="container">
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                            <h1 class="brand-heading">WAMA S.A.C</h1>
                            <p class="intro-text">Gestor de proformas<br> en línea</p>
                            <center>
                            ......::::::::::::::: ][ Menú de Tareas ][ :::::::::::::::......
                            </center>
                            <hr />
                            <a href="#search" class="btn btn-circle"><i class="fa fa-search animated"></i></a>                            
                            <asp:LinkButton ID="LkBNew" runat="server" class="btn btn-circle" OnClick="LkBNew_Click">
                                <i class="fa fa-file-o animated"></i>
                            </asp:LinkButton>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-pencil animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-trash-o animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-file-pdf-o animated"></i></a>                        
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <!--Espacio final cabecera-->
        <section id="download" class="content-section text-center download-section">    
            <div class="download-section">            
            </div>               
        </section>
       
        <!--Sección buscar-->
       
        
        <section id="search" class="container content-section">
            <br><br>
                <h2  id="lista" class="text-center"><i class="fa fa-search animated"></i> Busqueda de Pedidos</h2>                    
                    <div class="col-md-4">                    
                    <div class="form-group input-group">
                        <!--<input type="text" class="form-control">-->
                        <%--<asp:TextBox ID="txtSearch" runat="server" class="form-control"></asp:TextBox>
                        <span class="input-group-btn">
                            <button class="btn btn-warning" type="button"><i class="fa fa-search"></i>
                            </button>
                        </span>--%>
                    </div>                    
                    </div>
                <div class="row">
                    <div class="col-md-12">
                        <!-- Advanced Tables -->
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                 Lista de Items
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" 
                                             CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                           onrowcommand="GridView_RowCommand" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                                            <Columns>                
                                                <asp:BoundField DataField="numdoc" HeaderText="Proforma" SortExpression="numdoc" />
                                                <asp:BoundField DataField="ctactename" HeaderText="Cliente" SortExpression="ctactename" />
                                                <asp:BoundField DataField="canalventaname" HeaderText="Tipo de Venta" SortExpression="canalventaname" />
                                                <asp:BoundField DataField="vendorname" HeaderText="Vendedor" SortExpression="vendorname" />
                                                <asp:BoundField DataField="imponeto" HeaderText="Monto de Venta" SortExpression="imponeto" />
                                                <asp:BoundField DataField="fecre" HeaderText="Fecha Emisión" SortExpression="fecre" />
                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Menú Opciones]"  ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                                <ItemTemplate>   
                                                    <a href="#" data-toggle="modal" data-target="#printItem" class="btn btn-info" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-print"></i> </a>
                                                    <a href="#" data-toggle="modal" data-target="#updateItem" class="btn btn-warning" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-pencil-square-o"></i> </a>
                                                    <a href="#" data-toggle="modal" data-target="#deleteItem" class="btn btn-danger" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-trash-o"></i> </a>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                </div>      
                            </div>
                        </div>
                        <!--End Advanced Tables -->
                    </div>
                </div>
                <center>
                    <a href="#page-top" class="btn btn-default btn-lg">
                        <i class="fa fa-power-off"></i> <span class="network-name">Salir</span></a>                    
                </center>
        </section>

        <section id="modalPrint">    
                <div class="modal fade" id="printItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="H2"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                            </div>
                            <div class="modal-body">
                                    Usted ha presionado sobre el botón Imprimir.<br>
                                ¿ Desea visualizar el registro ?                                                          
                                <img src="assets/img/attach.png" />                                           
                            </div>                    
                       
                            <div class="modal-footer">
                                    <asp:HiddenField ID="HdFPrintItem" runat="server" />
                                    <asp:LinkButton ID="LkBPrint" CssClass="btn btn-default" runat="server" OnClick="LkBPrint_Click">Aceptar</asp:LinkButton>
                                    <asp:LinkButton ID="LkBCancelPrint" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelPrint_Click">Cancelar</asp:LinkButton>                                            
                            </div>

                        </div>
                    </div>
                </div>
        </section>
     
        <asp:ScriptManager ID="ScriptManager1" runat="server" />    
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">                                        
        <ContentTemplate> 
            <section id="modalOpen">        
                               
                                    <!-- Modal Search -->
                                    <div class="modal fade" id="openItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H9">Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                      Usted ha presionado sobre el botón Abrir.<br>
                                                    ¿ Desea abrir el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                                  
                                                    <asp:HiddenField ID="HdFOpenItem" runat="server" />
                                                    <asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" runat="server" OnClick="LkBSearch_Click">Aceptar</asp:LinkButton>                                                                          
                                                    <asp:LinkButton ID="LkBCancelSer" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelSer_Click">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>
            </section>                  
            <section id="modalDelete">        
                                    <div class="modal fade" id="deleteItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="myModalLabel"><i class="fa fa-trash-o fa-1x"></i> Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                      Usted ha presionado sobre el botón Eliminar<br>
                                                    ¿ Desea eliminar el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                              
                                                    <asp:HiddenField ID="HdFDeleteItem" runat="server" />
                                                    <asp:LinkButton ID="LkBDelete" CssClass="btn btn-default" runat="server" OnClick="LkBDelete_Click">Aceptar</asp:LinkButton>
                                                    <asp:LinkButton ID="LkBCancelDelete" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelDelete_Click">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>
            </section>          
            <section id="modalSave">        
                                    <div class="modal fade" id="saveItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H1"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                      Usted ha presionado sobre el botón Guardar.<br>
                                                    ¿ Desea guardar el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                                  
                                                    <asp:HiddenField ID="HdFSaveItem" runat="server" />
                                                    <asp:LinkButton ID="LkBSave" CssClass="btn btn-default" runat="server" OnClick="LkBSave_Click">Aceptar</asp:LinkButton>
                                                    <asp:LinkButton ID="LkBCancelSave" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelSave_Click">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>

            </section>
            <section id="modalUpdate">        
                                    <div class="modal fade" id="updateItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H7"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                      Usted ha presionado sobre el botón Modificar.<br>
                                                    ¿ Desea modificar el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                                  
                                                    <asp:HiddenField ID="HdFUpdateItem" runat="server" />
                                                    <asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" runat="server" OnClick="LkBUpdate_Click">Aceptar</asp:LinkButton>
                                                    <asp:LinkButton ID="LkBCancelUpdate" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelUpdate_Click">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>

            </section>
        </ContentTemplate>
        </asp:UpdatePanel>   
        
        <section id="modalSerchProduct">
                                        <div class="modal fade" id="searchProd" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="H3"><i class="fa fa-list fa-1x"></i> Listado de Productos</h4>
                                            </div>
                                            <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="modal-body">
                                                        <div class="panel-body">
                                                            <div class="table-responsive">
                                                                <table class="table table-striped table-bordered table-hover" id="dataTables-example3">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Código</th>
                                                                            <th>Artículo</th>                                            
                                                                            <th>Marca</th>                                                                
                                                                            <th>Precio Lista</th>                                                                
                                                                            <th><center>Menú Opciones</center></th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr class="odd gradeX">
                                                                            <td>Trident</td>
                                                                            <td>Internet Explorer 4.0</td>
                                                                            <td>Win 95+</td>                                                                
                                                                            <td>90.00</td>                                                                
                                                                            <td class="center"> 
                                                                                <input type="checkbox" value="" class="checkbox">Elegir
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="even gradeC">
                                                                            <td>Trident</td>
                                                                            <td>Internet Explorer 5.0</td>
                                                                            <td>Win 95+</td> 
                                                                            <td>80.00</td>
                                                                            <td class="center"> 
                                                                                <input type="checkbox" value="" class="checkbox">Elegir
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="odd gradeA">
                                                                            <td>Trident</td>
                                                                            <td>Internet Explorer 5.5</td>
                                                                            <td>Win 95+</td>
                                                                            <td>70.00</td>
                                                                            <td class="center">                                               
                                                                               <input type="checkbox" value="" class="checkbox">Elegir
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="even gradeA">
                                                                            <td>Trident</td>
                                                                            <td>Internet Explorer 6</td>
                                                                            <td>Win 98+</td>
                                                                            <td>60.00</td>
                                                                            <td class="center"> 
                                                                                <input type="checkbox" value="" class="checkbox">Elegir
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>      
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-12">
                                                    <div class="col-md-4">
                                                         <div class="form-group">
                                                            <label>Color</label>
                                                            <select class="form-control">
                                                                <option>One Vale</option>
                                                                <option>Two Vale</option>
                                                                <option>Three Vale</option>
                                                                <option>Four Vale</option>
                                                            </select>
                                                        </div>                                                
                                                    </div>
                                                    <div class="col-md-4">
                                                         <div class="form-group">
                                                            <label>Talla</label>
                                                            <select class="form-control">
                                                                <option>One Vale</option>
                                                                <option>Two Vale</option>
                                                                <option>Three Vale</option>
                                                                <option>Four Vale</option>
                                                            </select>
                                                        </div>                                                
                                                    </div>
                                                    <div class="col-md-4">
                                                         <div class="form-group">
                                                            <label>Cantidad</label>
                                                            <select class="form-control">
                                                                <option>One Vale</option>
                                                                <option>Two Vale</option>
                                                                <option>Three Vale</option>
                                                                <option>Four Vale</option>
                                                            </select>
                                                        </div>                                                
                                                    </div>                                                
                                                </div>
                                                </div>
                                                </div>

                                            </div>                                  
                                        
                                            <br>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default">Agregar</button>
                                                <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
        </section>
        <section id="modalSerchCustomer">
                                        <div class="modal fade" id="searchCust" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="H4"><i class="fa fa-list fa-1x"></i> Listado de Clientes Registrados</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="panel-body">
                                                    <div class="table-responsive">
                                                        <table class="table table-striped table-bordered table-hover" id="dataTables-example4">
                                                            <thead>
                                                                <tr>
                                                                    <th>Cta. Cte</th>
                                                                    <th>Razón Social</th>                                            
                                                                    <th>R.U.C.</th>                                                                
                                                                    <th><center>Menú Opciones</center></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td>Trident</td>
                                                                    <td>Internet Explorer 4.0</td>
                                                                    <td>Win 95+</td>                                                                
                                                                    <td class="center"> 
                                                                        <input type="checkbox" value="" class="checkbox"> Elegir
                                                                    </td>
                                                                </tr>
                                                                <tr class="even gradeC">
                                                                    <td>Trident</td>
                                                                    <td>Internet Explorer 5.0</td>
                                                                    <td>Win 95+</td>                                                                
                                                                    <td class="center"> 
                                                                        <input type="checkbox" value="" class="checkbox"> Elegir
                                                                    </td>
                                                                </tr>
                                                                <tr class="odd gradeA">
                                                                    <td>Trident</td>
                                                                    <td>Internet Explorer 5.5</td>
                                                                    <td>Win 95+</td>                                                                
                                                                    <td class="center">                                                                   
                                                                        <input type="checkbox" value="" class="checkbox"> Elegir
                                                                    </td>
                                                                </tr>
                                                                <tr class="even gradeA">
                                                                    <td>Trident</td>
                                                                    <td>Internet Explorer 6</td>
                                                                    <td>Win 98+</td>                                                                
                                                                    <td class="center"> 
                                                                        <input type="checkbox" value="" class="checkbox"> Elegir
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>      
                                                </div>
                                            </div>
                                            <br>

                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default">Aceptar</button>
                                               <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
        </section>
        <section id="modalUpdateCalendar">
                                            <div class="modal fade" id="updateCalendar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H5"><i class="fa fa-calendar fa-1x"></i> Actualización de Cronograma Pago</h4>
                                                </div>
                                                <div class="modal-body">               
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="col-md-3">                                                
                                                             <div class="form-group">
                                                                <label>N° Cuotas</label>
                                                                <select class="form-control">
                                                                    <option>1</option>
                                                                    <option>2</option>
                                                                    <option>3</option>
                                                                    <option>4</option>
                                                                </select>
                                                            </div>                                                
                                                        </div>
                                                        <div class="col-md-3">                                                
                                                             <div class="form-group">
                                                                <label>Monto a Pagar</label>
                                                                <select class="form-control">
                                                                    <option>5</option>
                                                                    <option>25</option>
                                                                    <option>50</option>
                                                                    <option>100</option>
                                                                </select>
                                                            </div>                                                
                                                        </div>  
                                                        <div class="col-md-6">
                                                            <label>Fecha de Pago</label>                                                       
                                                            <input id="datepicker1" class="form-control" type="text" disabled="">
                                                        </div>
                                                    </div>
                                                </div>

                                                </div>
                                                <br>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                    <button type="button" class="btn btn-primary">Guardar</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
            </section>
	    <section id="modalCheckControlsItem">        
				<div class="modal fade" id="checkControlsItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
					<div class="modal-dialog">
						<div class="modal-content">
							<div class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
								<h4 class="modal-title" id="H6"><i class="fa fa-times fa-1x"></i> Mensaje</h4>
							</div>
							<div class="modal-body">                                            
								Su formulario contiene algunas casillas vacías,
								recuerde que los campos con (*) deben ser llenados obligatoriamente,
								corrija para poder continuar.                                        
							</div>
							<div class="modal-footer">
								<button type="button" class="btn btn-default" >Si</button>
								<button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
							</div>
						</div>
					</div>
				</div>

	    </section>

        

    
    <!-- Footer -->
    <footer>
        <div class="container text-center">
            <p>Copyright &copy; WAMA S.A.C. 2015</p>
        </div>
    </footer>
    </form>
    <!-- Bootstrap Core JavaScript -->
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="assets/js/jquery.easing.min.js"></script>

    <!-- Google Maps API Key - Use your own API key to enable the map feature. More information on the Google Maps API can be found at https://developers.google.com/maps/ -->
    <!--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCRngKslUGJTlibkQ3FkfTxj3Xss1UlZDA&sensor=false"></script>-->

    <!-- Custom Theme JavaScript -->
    <!--<script src="assets/js/grayscale.js"></script>-->

         <!-- DATA TABLE SCRIPTS -->
    <script src="assets/dataTables/jquery.dataTables.js"></script>
    <script src="assets/dataTables/dataTables.bootstrap.js"></script>
        <script>
            $(document).ready(function () {
                $('#dataTables-example').dataTable();
                $('#dataTables-example1').dataTable();
                $('#dataTables-example2').dataTable();
                $('#dataTables-example3').dataTable();
                $('#dataTables-example4').dataTable();
            });
    </script>


</body>
</html>
