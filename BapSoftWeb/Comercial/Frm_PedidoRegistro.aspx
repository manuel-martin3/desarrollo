<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_PedidoRegistro.aspx.cs" Inherits="Comercial_Frm_PedidoRegistro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Grayscale - Start Bootstrap Theme</title>

    <!-- Bootstrap Core CSS -->
    <link href="Listados/assets/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="Listados/assets/css/grayscale.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="Listados/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!--STYLE DATEPICKER-->   
    <!--<link rel="stylesheet" href="assets/css/datepicker/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/datepicker/bootstrap-datepicker.min.css" />
    <!--FIN-->

    <!-- DATEPICKER-->
    <!-- DATE PICKER -->
    <link href="Listados/assets/datepicker/css/jquery-ui.css" rel="stylesheet">
    <!-- DATE PICKER -->
    <script src="Listados/assets/datepicker/js/jquery.js"></script>    
    <script src="Listados/assets/datepicker/js/jquery-ui.js"></script>
    <script src="Listados/assets/datepicker/js/jquery.ui.datepicker-es.js"></script>
    <script>
        $(function () {

            $("#datepicker").datepicker({
                showOn: "button",
                showButtonPanel: true,
                buttonImage: "Listados/assets/datepicker/images/calendar.gif",
                minDate: 0,
                /*maxDate: "+1M +10D",*/
                buttonImageOnly: true,
                buttonText: "Seleccionar fecha"
            });

            $("#datepicker1").datepicker({
                showOn: "button",
                showButtonPanel: true,
                buttonImage: "Listados/assets/datepicker/images/calendar.gif",
                minDate: 0,
                /*maxDate: "+1M +10D",*/
                buttonImageOnly: true,
                buttonText: "Seleccionar fecha"
            });

            $("#datepicker2").datepicker({
                showOn: "button",
                showButtonPanel: true,
                buttonImage: "Listados/assets/datepicker/images/calendar.gif",
                minDate: 0,
                /*maxDate: "+1M +10D",*/
                buttonImageOnly: true,
                buttonText: "Seleccionar fecha"
            });

        });
    </script>
    
    <script>
        function myFecha() {
            document.getElementById("TextBox3").value = document.getElementById("datepicker2").value;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <!-- About Section -->
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
    <section id="about" class="container content-section text-center">
            <h2><i class="fa fa-user"></i> Registro de Clientes</h2>
            <p>You can download Grayscale for free on the preview page at Start Bootstrap.</p>         
            <div class="row">
                <div class="col-md-12 text-left">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">
                    <div class="table-responsive">                        
                        <div class="col-md-3">                        
                            <label>N° Proforma</label>
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>
                            <!--<input class="form-control" placeholder="" disabled="">-->
                        </div>                    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Tipo de Venta</label>
                                <asp:DropDownList ID="DropDownList0" runat="server" class="form-control">
                                    <asp:ListItem>uno</asp:ListItem>
                                    <asp:ListItem>dos</asp:ListItem>
                                    <asp:ListItem>tres</asp:ListItem>
                                    <asp:ListItem>cuatro</asp:ListItem>                                    
                                </asp:DropDownList>                
                                <!--
                                <select class="form-control">
                                    <option>One Vale</option>
                                    <option>Two Vale</option>
                                    <option>Three Vale</option>
                                    <option>Four Vale</option>
                                </select>-->
                            </div> 
                        </div>
                        <div class="col-md-3">
                            <label>Fecha Entrega</label>
                            <asp:TextBox ID="datepicker2" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>
                            <!--<input id="datepicker2" class="form-control" type="text" disabled="">-->
                                <asp:requiredfieldvalidator id="RequiredFieldValidator1" controltovalidate="datepicker2" validationgroup="customer" CssClass="label label-danger"
                                errormessage="Enter a city name" runat="Server"><i class="fa fa-close"></i><span class="network-name"> Campo requerido</span></asp:requiredfieldvalidator>
                        </div>
                        <div class="col-md-3">                    
                            <label>Fecha de Emisión</label>
                            <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>
                            <!--<input class="form-control" placeholder="" disabled="">-->
                        </div>
                    </div>
                    </div>
                    </div>
                </div>                
            </div>   
                   
            <div class="row">
                <div class="col-md-12 text-left">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">
                    <div class="table-responsive">                        
                        <div class="col-md-3">
                            <label>N° Cta. Cte.</label>                            
                            <div class="form-group input-group">
                                <!--<input type="text" class="form-control" placeholder="Buscar por...">-->
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Buscar por..." disabled=""></asp:TextBox>
                                <span class="input-group-btn">
                                <button class="btn btn-warning" type="button" data-toggle="modal" data-target="#searchCust"><i class="fa fa-search"></i></button>
                                </span>                                
                            </div>
                        </div>                    
                        <div class="col-md-3">
                            <label>R.U.C.</label>
                            <asp:TextBox ID="TextBox4" runat="server" Text="123456" class="form-control" placeholder="R.U.C." disabled="" ></asp:TextBox>
                            <!--<input class="form-control" placeholder="R.U.C." disabled="">-->
                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" controltovalidate="TextBox4" validationgroup="customer" CssClass="label label-danger"
                                errormessage="Enter a city name" runat="Server"><i class="fa fa-close"></i><span class="network-name"> Campo requerido</span></asp:requiredfieldvalidator>
                        </div>
                        <div class="col-md-6">                    
                            <label>Razón Social</label>                                                        
                            <!--<input class="form-control" placeholder="Razón Social" disabled="">-->
                            <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="Razón Social" disabled=""></asp:TextBox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" controltovalidate="TextBox3" validationgroup="customer" CssClass="label label-danger"
                                errormessage="Enter a city name" runat="Server"><i class="fa fa-close"></i><span class="network-name"> Campo requerido</span></asp:requiredfieldvalidator>
                        </div>
                        <div class="col-md-12">                    
                            <label>Dirección de Entrega</label>
                            <asp:TextBox ID="TextBox6" runat="server" class="form-control" placeholder=""></asp:TextBox>
                            <!--<input class="form-control" placeholder="">-->
                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" controltovalidate="TextBox6" validationgroup="customer" CssClass="label label-danger"
                                errormessage="Enter a city name" runat="Server"><i class="fa fa-close"></i><span class="network-name"> Campo requerido</span></asp:requiredfieldvalidator>
                        </div>
                        <div class="col-md-3">                    
                            <label>Representante Legal</label>
                            <asp:TextBox ID="TextBox7" runat="server" class="form-control" placeholder=""></asp:TextBox>
                            <!--<input class="form-control" placeholder="" disabled="">-->
                        </div>
                        <div class="col-md-9">                    
                            <label>D.N.I</label>
                            <asp:TextBox ID="TextBox8" runat="server" class="form-control" placeholder=""></asp:TextBox>
                            <!--<input class="form-control" placeholder="" disabled="">-->
                        </div>
                    </div>
                    </div>
                    </div>
                </div>                
            </div>            
            <div class="row">
                <div class="col-md-8 text-left">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">
                    <div class="table-responsive">                        
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Condición de Venta</label>
                                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                    <asp:ListItem>uno</asp:ListItem>
                                    <asp:ListItem>dos</asp:ListItem>
                                    <asp:ListItem>tres</asp:ListItem>
                                    <asp:ListItem>cuatro</asp:ListItem>                                    
                                </asp:DropDownList>                
                                <!--                
                                <select class="form-control">
                                    <option>One Vale</option>
                                    <option>Two Vale</option>
                                    <option>Three Vale</option>
                                    <option>Four Vale</option>
                                </select>-->

                            </div>
                        </div>                    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Plazos</label>
                                <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                    <asp:ListItem>uno</asp:ListItem>
                                    <asp:ListItem>dos</asp:ListItem>
                                    <asp:ListItem>tres</asp:ListItem>
                                    <asp:ListItem>cuatro</asp:ListItem>                                    
                                </asp:DropDownList>     
                                <!--<select class="form-control">
                                    <option>One Vale</option>
                                    <option>Two Vale</option>
                                    <option>Three Vale</option>
                                    <option>Four Vale</option>
                                </select>-->
                            </div>
                        </div>
                        <div class="col-md-3">                            
                            <div class="form-group">
                                <label>Moneda</label>
                                <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                    <asp:ListItem>uno</asp:ListItem>
                                    <asp:ListItem>dos</asp:ListItem>
                                    <asp:ListItem>tres</asp:ListItem>
                                    <asp:ListItem>cuatro</asp:ListItem>                                    
                                </asp:DropDownList>     
                                <!--<select class="form-control">
                                    <option>One Vale</option>
                                    <option>Two Vale</option>
                                    <option>Three Vale</option>
                                    <option>Four Vale</option>
                                </select>-->
                            </div>
                        </div>
                        <div class="col-md-2">                    
                            <label>IGV</label>
                            <!--<input class="form-control" placeholder="SI" disabled=""> -->
                            <asp:TextBox ID="TextBox9" runat="server" class="form-control" placeholder="SI" disabled=""></asp:TextBox>            
                        </div>
                    </div>
                    <br />
                    </div>                    
                    </div>                    
                </div>    
                <div class="col-md-4 text-left">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">
                    <!--<div class="table-responsive">   -->
                        <div class="row">
                        <div class="col-md-12">                        
                            <label>Vendedor</label>
                            <!--<input class="form-control" placeholder="" disabled="">-->
                            <asp:TextBox ID="TextBox10" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>            
                        </div>                    
                        </div>                 
                        <div class="row">
                        <div class="col-md-12">
                            <!--<label>Id</label>-->
                            <!--<input class="form-control" placeholder="" disabled="">-->
                            <asp:TextBox ID="TextBox11" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>            
                        </div>       
                        </div>
                    <!--</div>-->
                    </div>
                    </div>                    
                </div>             
            </div>
            <div class="row">
                <div class="col-md-12 text-left">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">
                    <div class="table-responsive">                        
                        <div class="col-md-12">                               
                            <i class="fa fa-eye fa-2x"></i>                 
                            <label>Observación</label>                            
                            <asp:TextBox ID="TextBox12" runat="server" class="form-control" placeholder="">
                            </asp:TextBox>                                        
                            <!--<input class="form-control" placeholder="" disabled="">-->
                        </div>
                    </div>
                    </div>
                    </div>
                </div>                
            </div>    

                <asp:LinkButton ID="LkBtnNext" runat="server" 
                class="btn btn-primary btn-lg" onclick="LkBtnNext_Click" causesvalidation="true" validationgroup="customer"><span class="network-name" onclick="myFecha()">Siguiente</span> <i class="fa fa-chevron-right"></i></asp:LinkButton>

                <a class="btn alert-danger" data-toggle="modal" data-target="#cancelItem"> <i class="fa fa-minus-square"></i> <span class="network-name"> Cancelar</span></a>                
                <!---
                <a href="#download" class="btn btn-default btn-lg"><span class="network-name">Siguiente</span> <i class="fa fa-chevron-right"></i></a>
                <a href="#page-top" class="btn btn-default btn-lg"><i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span></a>
                -->
        <div></div>   
	</ContentTemplate>
    </asp:UpdatePanel>             
    </section>
    
    <section id="modaCancel">        
            <div class="modal fade" id="cancelItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-trash-o fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            Usted ha presionado sobre el botón Cancelar.<br>
                                            ¿ Está seguro que desea calcelar el proceso de registro ?
                                        </div>
                                        <div class="modal-footer">
                                        <asp:LinkButton ID="LkBtnCancel" runat="server" class="btn btn-default" 
                                                onclick="LkBtnCancel_Click">Si</asp:LinkButton>
                                        <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                            <%--<button type="button" class="btn btn-default" >Si</button>--%>
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
                                            <h4 class="modal-title" id="H1"><i class="fa fa-list fa-1x"></i> Listado de Clientes Registrados</h4>
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

  <%--  <section id="modaSave">        
            <div class="modal fade" id="saveItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            Usted ha presionado sobre el botón Guardar.<br>
                                            ¿ Está seguro que desea guardar este registro ?

                                            <!--Su documento se ha guardado exitosamente<br>
                                            ¿ Desea Imprimir su documento ?-->
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" >Si</button>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </section>
    <section id="modaPrint">        
            <div class="modal fade" id="printItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">                                            
                                            ¿ Desea abrir la vista previa de impresión del registro ?
                                            <!--Su documento se ha guardado exitosamente<br>
                                            ¿ Desea Imprimir su documento ?-->
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" >Si</button>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </section>
    <section id="modalSerchProduct">
            <div class="modal fade" id="searchProd" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-list fa-1x"></i> Listado de Productos</h4>
                                        </div>
                                        <div class="modal-body">
                                            <!--
                                            Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                        -->


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
                                                                        <!--<th><center>Menú Opciones</center></th>-->
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr class="odd gradeX">
                                                                        <td>Trident</td>
                                                                        <td>Internet Explorer 4.0</td>
                                                                        <td>Win 95+</td>                                                                
                                                                        <td>90.00</td>                                                                
                                                                        <!--
																		<td class="center"> 
                                                                            <input type="checkbox" value="" class="checkbox">Elegir
                                                                        </td>-->
																		
                                                                    </tr>
                                                                    <tr class="even gradeC">
                                                                        <td>Trident</td>
                                                                        <td>Internet Explorer 5.0</td>
                                                                        <td>Win 95+</td> 
                                                                        <td>80.00</td>
                                                                        <!--
																		<td class="center"> 
                                                                            <input type="checkbox" value="" class="checkbox">Elegir
                                                                        </td>-->
                                                                    </tr>
                                                                    <tr class="odd gradeA">
                                                                        <td>Trident</td>
                                                                        <td>Internet Explorer 5.5</td>
                                                                        <td>Win 95+</td>
                                                                        <td>70.00</td>
																		<!--
                                                                        <td class="center">                                               
                                                                           <input type="checkbox" value="" class="checkbox">Elegir
                                                                        </td>-->
                                                                    </tr>
                                                                    <tr class="even gradeA">
                                                                        <td>Trident</td>
                                                                        <td>Internet Explorer 6</td>
                                                                        <td>Win 98+</td>
                                                                        <td>60.00</td>
																		<!--
                                                                        <td class="center"> 
                                                                            <input type="checkbox" value="" class="checkbox">Elegir
                                                                        </td>-->
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>      
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--
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
													-->
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

    <section id="modalUpdateCalendar">
            <div class="modal fade" id="updateCalendar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="myModalLabel"><i class="fa fa-calendar fa-1x"></i> Actualización de Cronograma Pago</h4>
                                            </div>
                                            <div class="modal-body">
                                                <!--
                                                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                                            -->                       

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
                                                <h4 class="modal-title" id="myModalLabel"><i class="fa fa-times fa-1x"></i> Mensaje</h4>
                                            </div>
                                            <div class="modal-body">                                            
                                                Su formulario contiene algunas casillas vacías,
                                                recuerde que los campos con (*) deben ser llenados obligatoriamente,
                                                corrija para poder continuar.
                                                <!--Su documento se ha guardado exitosamente<br>
                                                ¿ Desea Imprimir su documento ?-->
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" >Si</button>
                                                <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
    </section>--%>

                 

           
    </form>
            
    <footer>
            <div class="download-section">    
                <p class="text-center" style ="color:white;">Copyright &copy; WAMA S.A.C. 2015</p>        
            </div>
    </footer>
    
    <!-- Bootstrap Core JavaScript -->
    <script src="Listados/assets/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="Listados/assets/js/jquery.easing.min.js"></script>
    
    <!-- Custom Theme JavaScript -->
    <script src="Listados/assets/js/grayscale.js"></script>


</body>
</html>
