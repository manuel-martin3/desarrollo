<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_PedidoDetalle.aspx.cs" Inherits="Comercial_Frm_PedidoDetalle" %>

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
    
	<!--TOGGLE-->
    <!--<link href="assets/toggle/css/bootstrap.min.css" rel="stylesheet">-->
    <link href="Listados/assets/toggle/css/bootstrap-toggle.css" rel="stylesheet">      
    <script src="Listados/assets/toggle/js/jquery-2.1.1.min.js"></script>   
    
    <link href="Listados/assets/dataTables/dataTables.bootstrap.css" rel="stylesheet" />    
	
	<!-- NUMPICKER SCRIPTS -->
    <!--<script src="assets/numpicker/js/jquery-2.1.0.min.js"></script>  	-->
	<!--<![endif]-->	
	<script src="Listados/assets/numpicker/js/userincr.js"></script>
	<script>
	    $(function () {
	        $("#box2").data({ 'min': 1, 'max': 1000, 'step': 1 }).userincr();
	    });
	</script>
    
        <script type="text/javascript">
            function validar() {
                var param;
                var input = document.getElementById("chk_Bloquear");
                var isChecked = input.checked;
                if (input.checked) {
                    param = "1";
                    document.getElementById('search').disabled = true
                    document.getElementById('search').className = "btn btn-default"
                    document.getElementById('txt_articidold').disabled = true
                    //document.getElementById('txt_articidold') = document.getElementById('txt_articidold')

                    //document.getElementById('txt_articname') = document.getElementById('txt_articname')
                    //document.getElementById('txt_marcaname') = document.getElementById('txt_marcaname')
                    //document.getElementById('txt_precventa_cre_menor') = document.getElementById('txt_precventa_cre_menor')

                    //document.getElementById('btn_add').disabled = true
                    //document.getElementById('btn_add').className = "btn btn-default  btn-block"
                } else {
                    param = "0";
                    document.getElementById('search').disabled = false
                    document.getElementById('search').className = "btn btn-warning"
                    document.getElementById('txt_articidold').disabled = false
                    //document.getElementById('txt_articidold') = document.getElementById('txt_articidold')
                    //document.getElementById('btn_add').disabled = false
                    //document.getElementById('btn_add').className = "btn btn-success  btn-block"
                }
                
            }
    </script>

    
    <link href="Listados/assets/Grilla/css/styles.css" rel="stylesheet" />    
    <script src="Listados/assets/Grilla/scripts/jquery.dataTables.min.js"></script>
    <script src="Listados/assets/Grilla/scripts/jquery.metadata.js"></script>
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
                if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 15) {

                    // Run DataTable on the GridView
                    jTbl.dataTable({
                        sPaginationType: "full_numbers",
                        sDom: '<"top"lf>rt<"bottom"ip>',
                        oLanguage: {
                            sInfoFiltered: "(de _MAX_ entradas)",
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

    <script type="text/javascript">    
        function Leer(val1, val2, val3, val4, val5, val6, val7) {
            $('#<%=HdFarticid.ClientID%>').val(val2);
            $('#<%=HdFtallaid.ClientID%>').val(val3);
            $('#<%=HdFmarcaid.ClientID%>').val(val4);

            $('#<%=txt_articidold.ClientID%>').val(val1);
            $('#<%=txt_articname.ClientID%>').val(val5);
            $('#<%=txt_marcaname.ClientID%>').val(val6);
            $('#<%=txt_precventa_cre_menor.ClientID%>').val(val7);

            $('#detCli').addClass('text alert-danger')
            $('#resultado').text('Usted seleccionó:' + ' ' + val5.toString());
            $('#res').text('Presionar botón [Si] / [No] para confirmar selección');

        }
    </script>
    <script type="text/javascript">
        function darclick() {     
        var Button1 = document.getElementById('BtnOk');        
        Button1.click();
        $('#detCli').removeClass('text alert-danger')
        $('#resultado').text('');
        $('#res').text('');
        }
</script>

<script type="text/javascript">
        function addclick() {
            var Button1 = document.getElementById('btn_add');
            Button1.click();            
        }
</script>

<script type="text/javascript">
        function searchclick() {
            var Button1 = document.getElementById('btn_search');
            Button1.click();
            //$('#searchProd').modal('toggle');
        }
</script>
<script type="text/javascript">
    function searchStk() {
        var Button1 = document.getElementById('btnStk');
            Button1.click();        
    }
</script>
    


<script type="text/javascript">
    function searchPopclick() {

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
                if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 15) {

                    // Run DataTable on the GridView
                    jTbl.dataTable({
                        sPaginationType: "full_numbers",
                        sDom: '<"top"lf>rt<"bottom"ip>',
                        oLanguage: {
                            sInfoFiltered: "(de _MAX_ entradas)",
                            sSearch: "Buscar: "
                        },
                        aoColumnDefs: [
                            { bSortable: false, aTargets: jTbl.metadata().disableSortCols }
                        ]
                    });
                }
            });            
            $('#searchProd').modal('toggle');
            
    }
</script>

<script type="text/javascript">
    function ShowSelected() {
        var combo = document.getElementById("cmb_tallaid");
        var selected = combo.options[combo.selectedIndex].text
        //alert(selected);    
        //document.getElementById("HdFtalla").value = selected.value;
        $('#<%=HdFtalla.ClientID%>').attr(selected);

    }
</script> 

</head>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>        
    <!-- Download Section -->
    <section id="about" class="container content-section text-center">
    
        <div class="">            
            <div class="container">
                <div class="row">
                <div class="col-md-12">
                <div class="col-lg-8 col-lg-offset-2">

                    <h2><i class="fa fa-list-alt"></i> Listados de Items</h2>                                        
                    <p>You can download Grayscale for free on the preview page at Start Bootstrap.</p>
                </div>
            </div>
        </div>          
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
				    <div class="row">
					    <div class="col-md-12 text-left">                                      
						    <div class="panel panel-info">
						    <div class="panel-body alert-info">
						    <div class="table-responsive">                        						
							    <div class="col-md-4">																		
                                        <asp:HiddenField ID="HdFpar" runat="server" />
                                        <input id="chk_Bloquear" type="checkbox" onclick="validar()" /> 
								        <label>Bloquear Código</label>                                    
									    <div class="form-group input-group">
                                            <asp:TextBox ID="txt_articidold" runat="server" class="form-control" placeholder="Buscar por..." ></asp:TextBox>										
										    <span class="input-group-btn">
										    <button id="search" class=" l btn btn-warning" type="button" onclick="searchclick()"><i class="fa fa-search"></i></button>										                                        										
                                            </span>							                                        
                                         </div>                                                                          
                                         <div class="form-group input-group">                                                                                
								    </div>
							    </div>  									
							    <div class="col-md-8">
								    <label>Artículo</label>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator5" controltovalidate="txt_articname" validationgroup="Quanty" CssClass="label label-danger"
                                    errormessage="Enter a city name" runat="Server"><i class="fa fa-close"></i><span class="network-name"> Campo requerido, haga click sobre lupa para buscar...</span></asp:requiredfieldvalidator>
                                    <asp:TextBox ID="txt_articname" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>							
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" controltovalidate="txt_articname" 
                                        validationgroup="customer" CssClass="label label-danger" errormessage="Enter a city name" runat="Server">
                                        <i class="fa fa-close"></i><span class="network-name"> Campo requerido, haga click sobre lupa para buscar...</span></asp:requiredfieldvalidator>                                
							    </div>
							    <div class="col-md-6">
								    <label>Marca</label>                                                       
								    <asp:TextBox ID="txt_marcaname" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>                                
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" controltovalidate="txt_marcaname" 
                                        validationgroup="customer" CssClass="label label-danger" errormessage="Enter a city name" runat="Server">
                                        <i class="fa fa-close"></i><span class="network-name"> Campo requerido, haga click sobre lupa para buscar...</span></asp:requiredfieldvalidator>                                
							    </div>
							    <div class="col-md-2">
								    <label>Precio de Lista</label>                              
                                    <asp:TextBox ID="txt_precventa_cre_menor" runat="server" class="form-control" placeholder="" disabled=""></asp:TextBox>                         								
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" controltovalidate="txt_precventa_cre_menor" 
                                        validationgroup="customer" CssClass="label label-danger" errormessage="Enter a city name" runat="Server">
                                        <i class="fa fa-close"></i><span class="network-name"> Campo requerido </span></asp:requiredfieldvalidator>                                
							    </div>														
							    <br />
								<label></label>
						    </div>
						    </div>
						    </div>
					    </div>                
				    </div>
                   </ContentTemplate>
                   <Triggers>                        
                       
                   </Triggers>
               </asp:UpdatePanel>    
                <div class="row">
                    <div class="col-md-12 text-left">
                        <div class="panel panel-info">
                            <div class="panel-body alert-info">
                                <%--<div class="table-responsive">--%>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server"  UpdateMode="Conditional">
                                    <ContentTemplate>
							        <div class="col-md-2">
								        <div class="form-group">
									        <label>Color</label>
                                            <asp:DropDownList ID="cmb_colorid" runat="server" class="form-control" AutoPostBack="false" 
                                                OnSelectedIndexChanged="cmb_colorid_SelectedIndexChanged">                                                
                                            </asp:DropDownList> 

                                        <asp:requiredfieldvalidator id="RequiredFieldValidator6" controltovalidate="cmb_colorid" 
                                            validationgroup="Quanty" CssClass="label label-danger" errormessage="Enter a city name" runat="Server">
                                            <i class="fa fa-close"></i><span class="network-name"> Campo requerido </span></asp:requiredfieldvalidator>               
								        </div> 
							        </div>

							        <div class="col-md-2">
								        <div class="form-group">
									        <label>Talla</label>
                                            <asp:DropDownList ID="cmb_tallaid" runat="server" class="form-control" AutoPostBack="false" 
                                                OnSelectedIndexChanged="cmb_tallaid_SelectedIndexChanged" onchange="ShowSelected()">                                                
                                            </asp:DropDownList> 
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator7" controltovalidate="cmb_tallaid" 
                                            validationgroup="Quanty" CssClass="label label-danger" errormessage="Enter a city name" runat="Server">
                                            <i class="fa fa-close"></i><span class="network-name"> Campo requerido </span></asp:requiredfieldvalidator>               
								        </div> 
							        </div>


                                    <div style=" display:none;">                                        
                                        <asp:Button ID="BtnOk" runat="server" class="btn btn-default" Text="Si" onclick="BtnOk_Click" />
                                    </div>
                                    <div style=" display:none;">                                                                                                                       
                                        <asp:HiddenField ID="HdFtalla" runat="server" />                                          
                                    </div>
                                    <%--                                    <div class="col-md-3">															                                                    
									    <label>Stock Disponible</label>																		        
                                        <div class="form-group input-group">								    
                                        <asp:TextBox ID="txtStkdisp" runat="server" Text="0" class="form-control" placeholder="Buscar por..."  ></asp:TextBox>									        
										    <span class="input-group-btn">
										    <button id="Button1" class="btn btn-warning" type="button" onclick="searchclick()"><i class="fa fa-search"></i></button>										                                        										
                                            </span>	
									        
								        <asp:requiredfieldvalidator id="RequiredFieldValidator4" 
                                        controltovalidate="txtStkdisp" validationgroup="Quanty" CssClass="label label-danger"
                                        errormessage="Enter a city name" runat="Server" InitialValue="0"><i class="fa fa-close"></i><span class="network-name"> Debe ser mayor a 0 para agregar</span></asp:requiredfieldvalidator>                                   
							            </div>                                    
                                    </div> --%>  
							        <div class="col-md-3">	
							            <label>Stock Disponible</label>																	                                            
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator8" 
                                        controltovalidate="txtStkdisp" validationgroup="Quanty1" CssClass="label label-danger"
                                        errormessage="Enter a city name" runat="Server" InitialValue="">
                                            <i class="fa fa-close"></i>
                                            <span class="network-name"> Requerido</span></asp:requiredfieldvalidator>
                                        	                                    
									        <div class="form-group input-group">
                                                <asp:TextBox ID="txtStkdisp" runat="server" class="form-control text-danger" placeholder="000" disabled="" ></asp:TextBox>																				        
                                                <span class="input-group-btn">										        
                                                    <button id="Button1" class="btn btn-danger" type="button" onclick="searchStk()"><i class="fa fa-eye"></i></button>
                                                </span>							                                        
                                             </div>                                         

                                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" 
                                        controltovalidate="txtStkdisp" validationgroup="Quanty1" CssClass="label label-danger"
                                        errormessage="Enter a city name" runat="Server" InitialValue="0">
                                            <i class="fa fa-close"></i>
                                            <span class="network-name"> Debe ser mayor a 0 para agregar</span></asp:requiredfieldvalidator>
                
                                         <div class="form-group input-group">                                                                                
								        </div>
                                </div> 
                                    <div style=" display:none;">                                        
                                        <asp:Button ID="btnStk" runat="server" class="btn btn-default" Text="Si" onclick="btnStk_Click" 
                                             causesvalidation="true" validationgroup="Quanty" />
                                    </div> 
                                    <div style=" display:none;">                                        
                                            <asp:Button ID="btn_add" runat="server" class="btn btn-default" Text="Si" OnClick="btn_add_Click" 
                                                causesvalidation="true" validationgroup="Quanty1" />
                                    </div> 
                                    </ContentTemplate>  
                                        <Triggers>                                                                                        
                                            <asp:AsyncPostBackTrigger ControlID="btn_add" EventName="Click" />	  
                                            <asp:AsyncPostBackTrigger ControlID="btnStk" EventName="Click" />	                                       
                                        </Triggers>                                        
                                    </asp:UpdatePanel>      
                                                                         	
							        <div class="col-md-2">							
								        <div class="form-group">									
									        <label>Cantidad</label>									
									        <span>
                                            <asp:TextBox ID="box2" runat="server" class="form-control" title="DOM title" value="1"></asp:TextBox>									        
									        </span>
									
								        </div> 								    
							        </div>

                                    <div class="col-md-2" style="padding-top:2px;">                                        
                                        <br />                                        
                                        <button type="button" class="btn btn-default" onclick="addclick()" data-dismiss="modal">Agregar a Lista</button>                                         
                                    </div>

                                    <div style=" display:none;">                                        
                                        <asp:Button ID="BtnEnable" runat="server" class="btn btn-default" Text="Si" onclick="BtnEnable_Click" />
                                    </div>


                                <%--</div>--%>
                            </div>
                        </div>
                    </div>
                </div>              				
                <br />

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>  
                <div class="row">
                <div class="col-md-12">
                    <!-- Advanced Tables -->
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                             Lista de Items
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">                                
                                 <%--onrowcommand="GridView_RowCommand" OnSelectedIndexChanged="GridView_SelectedIndexChanged"--%>

                                        <asp:GridView ID="GridViewPedido" runat="server" AutoGenerateColumns="false" 
                                             CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" >
                                            <Columns>                
                                                <asp:BoundField DataField="articidold" HeaderText="Código" SortExpression="articidold" />
                                                <asp:BoundField DataField="articname" HeaderText="Artículo" SortExpression="articname" />                                                
                                                <asp:BoundField DataField="marcaname" HeaderText="Marca" SortExpression="articname" />                                                
                                                <%--<asp:BoundField DataField="articid" HeaderText="Artículo" SortExpression="articname" />                                                --%>
                                                <asp:BoundField DataField="pvt_cremenor" HeaderText="Precio Venta" SortExpression="articname" />                                                
                                                <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Menú Opciones]"  ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                                <ItemTemplate>  
                                                     <%--<asp:LinkButton ID="LkBSelect" runat="server">Seleccionar</asp:LinkButton>--%>
                                                    <%--<a href="#" data-toggle="modal" data-target="#printItem" class="btn btn-info" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-print"></i> </a>
                                                    <a href="#" data-toggle="modal" data-target="#updateItem" class="btn btn-warning" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-pencil-square-o"></i> </a>
                                                    <a href="#" data-toggle="modal" data-target="#deleteItem" class="btn btn-danger" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-trash-o"></i> </a>--%>
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

                <div class="row">
                <div class="col-md-12 text-left">                    
                    <div class="col-md-3">
                        <label>Total Items</label>
                        <asp:TextBox ID="TextBox5" runat="server" class="form-control" placeholder="0" disabled=""></asp:TextBox>
                        <!--<input class="form-control" placeholder="0" disabled="">-->
                    </div>

                    <div class="col-md-3">
                        <label>Vta. Precio Lista</label>
                        <asp:TextBox ID="txt_impobruto" runat="server" class="form-control" placeholder="00.000" disabled=""></asp:TextBox>
                        <!--<input class="form-control" placeholder="00.000" disabled="">-->
                    </div>

                    <div class="col-md-3">
                        <label>% Descuento</label>
                        <asp:TextBox ID="txt_tasadescto" runat="server" class="form-control" placeholder="00.000" disabled=""></asp:TextBox>
                        <!--<input class="form-control" placeholder="00.000" disabled="">-->
                    </div>
                    <div class="col-md-3">
                        <label>Vta. con Descuento</label>
                        <asp:TextBox ID="txt_imponeto" runat="server" class="form-control" placeholder="00.000" disabled=""></asp:TextBox>
                        <!--<input class="form-control" placeholder="00.000" disabled="">-->
                    </div>

                </div>
            </div>                    
                <!--</div>-->
                </ContentTemplate>
                   <Triggers>                        
                        <asp:AsyncPostBackTrigger ControlID="btn_add" EventName="Click" />
                   </Triggers>
            </asp:UpdatePanel>

            </div>
            <br /><br /><br />
        <asp:LinkButton ID="LkBtnPrev" runat="server" class="btn alert-info" 
                onclick="LkBtnPrev_Click"><i class="fa fa-chevron-left"></i> <span class="network-name">Anterior</span></asp:LinkButton>
        <asp:LinkButton ID="LkBtnNext" runat="server" class="btn btn-primary btn-lg" 
                onclick="LkBtnNext_Click" causesvalidation="true" validationgroup="customer"><span class="network-name">Siguiente</span> <i class="fa fa-chevron-right"></i></asp:LinkButton>
                        
        <a class="btn alert-danger" data-toggle="modal" data-target="#cancelItem"><i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span></a>
        <!--
        <a href="#about" class="btn btn-info"><i class="fa fa-chevron-left"></i> <span class="network-name">Anterior</span></a>
        <a href="#contact" class="btn btn-primary btn-lg"><span class="network-name">Siguiente</span> <i class="fa fa-chevron-right"></i></a>
        <a href="#page-top" class="btn alert-danger"><i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span></a>
        -->
        </div>
    </section>

    <section id="modalCancel">        
             <div class="modal fade" id="cancelItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H1"><i class="fa fa-minus-square fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            Usted ha presionado sobre el botón Cancelar<br>
                                            ¿ Está seguro que desea cancelar este registro ?
                                        </div>
                                        <div class="modal-footer">
                                        <asp:LinkButton ID="LkBtnCancel" runat="server" class="btn btn-default" 
                                                onclick="LkBtnCancel_Click"> Si</asp:LinkButton>

                                            <%--<button type="button" class="btn btn-default" >Si</button>--%>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
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
                                            <h4 class="modal-title" id="H2"><i class="fa fa-trash-o fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            Usted ha presionado sobre el botón Eliminar<br>
                                            ¿ Está seguro que desea eliminar este registro ?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" >Si</button>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
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
                                            <h4 class="modal-title" id="H3"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            Usted ha presionado sobre el botón Modificar<br>
                                            ¿ Está seguro que desea modificar este registro ?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" >Si</button>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </section>  

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <section id="modalSerchProduct">
            <div class="modal fade bs-example-modal-lg" id="searchProd" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-list fa-1x"></i> Listado de Productos</h4>
                                        </div>
                                        <div class="modal-body">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="modal-body">
                                                    <div class="panel-body">
                                                        <div class="table-responsive">
                                                                <center>
                                                                    <asp:GridView ID="GridViewProd" runat="server" AutoGenerateColumns="False" 
                                                                         CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,2]}" 
                                                                        onrowcommand="GridViewProd_RowCommand">
                                                                        <Columns>                
                                                                            <asp:BoundField DataField="articidold" HeaderText="Código" SortExpression="articidold" />
                                                                            <asp:BoundField DataField="articname" HeaderText="Artículo" SortExpression="articname" />                                                
                                                                           <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Menú Opciones]"  ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">                                                                           
                                                                            <ItemTemplate>                                                                      
                                                                                <a href="#" style=" text-decoration:none; color:Black;" 
                                                                                    onclick="Leer(
                                                                                    '<%#Eval("articidold").ToString()%>',
                                                                                    '<%#Eval("articid").ToString()%>',
                                                                                    '<%#Eval("tallaid").ToString()%>',
                                                                                    '<%#Eval("marcaid").ToString()%>',

                                                                                    '<%#Eval("articname").ToString()%>',                        
                                                                                    '<%#Eval("marcaname").ToString()%>',                        
                                                                                    '<%#Eval("pvt_cremenor").ToString()%>'
                                                                                    );" )" >                                                                                    
                                                                                    [Seleccionar]</a>                                                                                
                                                                            </ItemTemplate>
                                                                            </asp:TemplateField>                                                                              
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </center>   
                                                            <div style=" display:none;">                                        
                                                                <asp:Button ID="btn_search" runat="server" class="btn btn-default" Text="Si" OnClick="btn_search_Click"/>
                                                            </div>                                                                                                              
                                                            <asp:HiddenField ID="HdFarticidold" runat="server" /><asp:HiddenField ID="HdFarticname" runat="server" />               
                                                            <asp:HiddenField ID="HdFmarcaid" runat="server" /><asp:HiddenField ID="HdFmarcaname" runat="server" />
                                                            <asp:HiddenField ID="HdFpvtacremenor" runat="server" />
                                                            <asp:HiddenField ID="HdFtallaid" runat="server" /><asp:HiddenField ID="HdFarticid" runat="server" />   
                                                            <br /><br />
                                                            <div id="detCli">
                                                                <center><label id="resultado"></label></center>
                                                                <center><label id="res"></label></center>
                                                            </div>                                                            
                                                        </div> 
                                                    </div>
                                                </div>
                                            </div>                                            
                                        </div>                          
                                        </div>
                                       <%-- <br />       --%>                                                                        
                                            <%--<input name="txtTabla" type="text" id="txtTabla" value="" style ="text-align:center; font-size:24px; text-transform:uppercase; font-weight:bold; width:100%; border:none;"/>                     --%>
                                            <%--<asp:Label ID="lblErr" runat="server" Visible="False" CssClass='tex1, titulo2'></asp:Label>                  --%>                                        
                                        <div class="modal-footer">                                            
                                            <button type="button" class="btn btn-default" onclick="darclick()" data-dismiss="modal">Si</button>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                    <%--        <div style=" display:none;">
                                <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" Visible="True" /></div>
                            </div> --%>
    </section>
        </ContentTemplate>

    </asp:UpdatePanel>

    <%--    <section id="modaDelete">        
            <div class="modal fade" id="deleteItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-trash-o fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            Usted ha presionado sobre el botón Eliminar.<br>
                                            ¿ Está seguro que desea eleminar este registro ?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" >Si</button>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </section>          
    <section id="modaSave">        
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
   
    <section id="modalSerchCustomer">
            <div class="modal fade" id="searchCust" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel"><i class="fa fa-list fa-1x"></i> Listado de Clientes Registrados</h4>
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

    <!-- jQuery -->
    <!--<script src="assets/js/jquery.js"></script>-->

    <!--TOGGLE-->    
    <script src="Listados/assets/toggle/js/bootstrap-toggle.js"></script>
	
    <!-- Bootstrap Core JavaScript -->
    <script src="Listados/assets/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="Listados/assets/js/jquery.easing.min.js"></script>

   
    <!-- Custom Theme JavaScript -->
    <script src="Listados/assets/js/grayscale.js"></script>

    <!-- DATA TABLE SCRIPTS -->
    <script src="Listados/assets/dataTables/jquery.dataTables.js"></script>
    <script src="Listados/assets/dataTables/dataTables.bootstrap.js"></script>
        <script>
            $(document).ready(function () {
                $('#dataTables-example').dataTable();
                $('#dataTables-example1').dataTable();
                $('#dataTables-example2').dataTable();
                $('#<%=GridViewProd.ClientID%>').dataTable();
                $('#dataTables-example4').dataTable();
            });
    </script>


	<%--$('#<%=HdFOpenItem.ClientID%>')--%>
    

</body>
</html>
