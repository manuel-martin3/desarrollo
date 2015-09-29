<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_Proformas.aspx.cs" Inherits="Comercial_Frm_Proformas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>PROFORMAS</title>

    <!-- Bootstrap Core CSS -->
    <link href="Listados/assets/css/bootstrap.css" rel="stylesheet" />    
    <!-- Custom CSS -->
    <link href="Listados/assets/css/grayscale.css" rel="stylesheet" />
    
    <!-- Custom Fonts -->
    <link href="Listados/assets/css/font-awesome.css" rel="stylesheet" type="text/css" />
     <!--
    <link href="http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
     -->  
    <!--STYLE DATEPICKER-->   
    <!--<link rel="stylesheet" href="assets/css/datepicker/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/datepicker/bootstrap-datepicker.min.css" />
    <!--FIN-->
       
    <link href="Listados/assets/datepicker/css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />  
    <link href="Listados/assets/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    
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
    
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

   <%-- <script type="text/javascript">
        function filtro(val1, val2) {           
             $('#<%=Hdffiltro.ClientID%>').val(val1);    
         }        
    </script>--%>
    
    <style type="text/css">
        .ocultar { display:none;
        }
    </style>

    <script type="text/javascript">
        function searchItem() {
            var Button1 = document.getElementById('btnSearch2');
            Button1.click();
        }
    </script>

<%--    <script type="text/javascript">
        function verpedido() {
            var Button1 = document.getElementById('btn_verPedido');
            Button1.click();
        }
    </script>--%>

    <script>
        function myFecha() {
            document.getElementById("fechentrega2").value = document.getElementById("fechentrega").value;            
        }
    </script>
        
        <script type="text/javascript">
            function validar() {
                var param;
                var input = document.getElementById("chk_Bloquear");
                var isChecked = input.checked;
                if (input.checked) {
                    param = "1";
                    document.getElementById('btn_buscar').disabled = true
                    document.getElementById('btn_buscar').className = "btn btn-default"
                    document.getElementById('txt_articidold').disabled = true

                } else {
                    param = "0";
                    document.getElementById('btn_buscar').disabled = false
                    document.getElementById('btn_buscar').className = "btn btn-warning"
                    document.getElementById('txt_articidold').disabled = false

                }

            }
    </script>    


</head>

<body id="page-top" data-spy="scroll" data-target="">

    <form id="form1" runat="server">    
         
        <!--Espacio inicio cabecera-->
        <%--<div class="download-section">   --%>
        <%--<asp:validationsummary forecolor="Red" runat="server" id="validationSummary1">
                        </asp:validationsummary>         --%>
        <%--</div> --%>
        <header class="intro">            
            <div class="intro-body">                
                <div class="container">
                    <div class="row ocultar">
                        <div class="col-md-8 col-md-offset-2 ocultar">
                            <h1 class="brand-heading ocultar">WAMA S.A.C</h1>
                            <p class="intro-text">Gestor de Pedidos<br> en Línea</p>
                            <center>
                            ......::::::::::::::: ][ Menú de Tareas ][ :::::::::::::::......
                            </center>
                            <hr />                            
                            <asp:LinkButton ID="LkBSearch" runat="server" class="btn btn-circle ocultar" OnClick="LkBSearch_Click">
                                <i class="fa fa-search animated"></i>
                            </asp:LinkButton>                            
                           <%-- <asp:LinkButton ID="LkBNew" runat="server" class="btn btn-circle ocultar" OnClick="LkBNew_Click">
                                <i class="fa fa-file-o animated"></i>
                            </asp:LinkButton>--%>
<%--                            <asp:LinkButton ID="LkBEdit" runat="server" class="btn btn-circle ocultar" OnClick="LkBEdit_Click">
                                <i class="fa fa-pencil animated"></i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="LkBDel" runat="server" class="btn btn-circle ocultar" OnClick="LkBDel_Click">
                                <i class="fa fa-trash animated"></i>
                            </asp:LinkButton>--%>
                            <%--<a href="#" class="btn btn-circle"><i class="fa fa-pencil animated" onclick="btn_verPedido()"></i></a>--%>
                            <%--<a href="#" class="btn btn-circle"><i class="fa fa-trash-o animated" onclick="btn_verPedido()"></i></a>--%>
                            <%--<a href="#search" class="btn btn-circle"><i class="fa fa-file-pdf-o animated"></i></a>--%>     
                            <%--<div style=" display:none;">                                        
                                <asp:Button ID="btn_verPedido" runat="server" class="btn btn-default" Text="Si" OnClick="btn_verPedido_Click" />                                
                            </div> --%>
                                               
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <!--Espacio final cabecera-->        
<%--            <div class="download-section">    
                <p class="text-center" style ="color:white;">Copyright &copy; WAMA S.A.C. 2015</p>        
            </div>--%>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- About Section -->
    <section id="about" class="container content-section text-center">
    <br>
            <h2  id="registro"><i class="fa fa-user"></i> Registro de Clientes</h2>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <Triggers>
                    <%-- <asp:PostBackTrigger ControlID="btn_Imprimir" />
                    <asp:PostBackTrigger ControlID="btn_Imprimir2" />--%>
            </Triggers>
            <ContentTemplate>
            <div class="row">                                          
                <div class="col-md-12 text-left">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">            
                    <div class="table-responsive"> 
                        <div class="col-md-3">                                                    
                            <label>N° Proforma</label>                            
                            <asp:TextBox ID="txt_proforma" runat="server" placeholder="Numero de Proforma" Enabled="false" CssClass="form-control">
                            </asp:TextBox>                                        
                            <asp:LinkButton ID="LkBNew" runat="server" CssClass="" OnClick="LkBNew_Click">
                                <i class="fa icon-refresh"> </i> Nuevo
                            </asp:LinkButton>                         
                            <asp:LinkButton ID="LkBEdit" runat="server" CssClass="ocultar" OnClick="LkBEdit_Click">
                                <i class="fa fa-pencil-square-o"></i> 
                            </asp:LinkButton>                         

                            <asp:Label ID="txt_tipdoc" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="txt_serdoc" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="txt_numdoc" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>                    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Tipo de Venta</label>
                                 <asp:DropDownList ID="cmb_tipventa" runat="server" AutoPostBack="true"
                                     OnSelectedIndexChanged="cmb_tipventa_SelectedIndexChanged" CssClass="form-control">                                   
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="val_cmb_tipventa" runat="server" CssClass="validacion" 
                                        ControlToValidate="cmb_tipventa" ErrorMessage="Elegir tipo de venta" ValidationGroup="Validate">
                                        </asp:RequiredFieldValidator>

                                <%-- <dx:ASPxComboBox ID="cmb_tipventa" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="cmb_tipventa_SelectedIndexChanged">
                                     </dx:ASPxComboBox>                                                                                                                        
                                            <asp:RequiredFieldValidator ID="val_cmb_tipventa" runat="server" CssClass="validacion" 
                                            ControlToValidate="cmb_tipventa" ErrorMessage="Elegir tipo de venta" ValidationGroup="Validate">
                                            </asp:RequiredFieldValidator> --%>
                            </div> 
                        </div>
                        <div class="col-md-3">                    
                            <label>Fecha de Emisión</label>    
                            <asp:TextBox ID="fechdoc" runat="server" class="form-control" ReadOnly></asp:TextBox>
                            <asp:RequiredFieldValidator ID="val_fechentrega" runat="server" CssClass="validacion" 
                                    ControlToValidate="fechentrega" ErrorMessage="Elegir fecha" ValidationGroup="Validate">
                                    </asp:RequiredFieldValidator>           
                        </div>

                        <div class="col-md-3">                            
                            <label>Fecha Entrega</label>     
                            <asp:HiddenField ID="idiom" runat="server" />   
                            <div class="date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input2" data-link-format="dd/mm/yyyy">                        
                                <asp:TextBox ID="fechentrega" runat="server" class='input-large fcha form-control' placeholder="Click Aquí"></asp:TextBox>                        
                                <span class="add-on"><i class="icon-calendar"></i></span>
                                <span class="add-on"><i class="icon-remove"></i></span>
                            </div>  
                            <asp:HiddenField ID="tfecha" runat="server" />                             




                            <%--<asp:TextBox ID="fechdoc" runat="server" class="form-control"></asp:TextBox>--%>


                           <%-- <dx:ASPxDateEdit ID="fechdoc" runat="server" CssClass="form-control">
                            </dx:ASPxDateEdit>--%>
                           <%-- <asp:RequiredFieldValidator ID="val_fechdoc" runat="server" CssClass="validacion" 
                                    ControlToValidate="fechdoc" ErrorMessage="Elegir fecha" ValidationGroup="Validate">
                                    </asp:RequiredFieldValidator>                                             --%>                                                                                      
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
                                <asp:TextBox ID="txt_ctacte" runat="server" TabIndex="2" class="form-control" placeholder="Buscar por..."></asp:TextBox>
                                <span class="input-group-btn">
                                <%--<button class="btn btn-warning" type="button" data-toggle="modal" data-target="#searchCust"><i class="fa fa-search"></i></button>--%>
                                 <%--<a href="#" data-toggle="modal" data-target="#searchCust" class="btn btn-warning" style=" text-decoration:none;"
                                        onclick="filtro('PR');" )">    
                                     <i class="fa fa-search"></i>                                
                                 </a> --%>                                    
                                <asp:LinkButton ID="btn_buscaRazon" runat="server" CssClass="btn btn-warning" 
                                      data-toggle="modal" data-target="#searchCust" OnClick="btn_buscaRazon_Click">
                                    <i class="fa fa-search"></i>
                                </asp:LinkButton>                                                                    
                                </span>
                            </div>
                        </div>                    
                        <div class="col-md-3">
                            <label>R.U.C.</label>                                                                               
                            <asp:TextBox ID="txt_ruc" runat="server" TabIndex="3" CssClass="form-control" placeholder="R.U.C.">
                            </asp:TextBox>
                            <%--<asp:requiredfieldvalidator id="RequiredFieldValidator2" errormessage="* Campo R.U.C. es vacio " display="None" controltovalidate="txt_ruc" runat="server">
                            </asp:requiredfieldvalidator>--%>
                        </div>
                        <div class="col-md-6">
                            <label>Razón Social</label>                                                                                   
                            <asp:TextBox ID="txt_ctactename" runat="server" TabIndex="2" CssClass="form-control" placeholder="Razón Social" Enabled="False">
                            </asp:TextBox>
                         <%--   <asp:requiredfieldvalidator id="RequiredFieldValidator1" errormessage="* Campo Razón Social es vacio " display="None" controltovalidate="txt_ruc" runat="server">
                            </asp:requiredfieldvalidator>--%>
                        </div>
                        <div class="col-md-12">                    
                            <label>Dirección de Entrega</label>                            
                            <asp:TextBox ID="direc_entrega" runat="server" TabIndex="6" CssClass="form-control" placeholder="Direccion de Entrega"></asp:TextBox>                   
                        </div>
                        <div class="col-md-8">                    
                            <label>Representante Legal</label>                            
                            <asp:TextBox ID="replegal_name" runat="server" TabIndex="6" CssClass="form-control" placeholder="Representante Legal"></asp:TextBox>                   
                        </div>
                        <div class="col-md-4">                    
                            <label>D.N.I</label>                            
                            <asp:TextBox ID="replegal_dni" runat="server" CssClass="form-control" MaxLength="10" placeholder="DNI"></asp:TextBox>                
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
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Condición de Venta</label>                                
                               <asp:DropDownList ID="cmb_condventaid" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="cmb_condventaid_SelectedIndexChanged">
                               </asp:DropDownList>              
                               <%--<asp:RequiredFieldValidator ID="val_cmb_condventaid" runat="server" CssClass="validacion"
                                        ControlToValidate="cmb_condventaid" ErrorMessage="Elegir condición de venta" ValidationGroup="Validate"></asp:RequiredFieldValidator>--%>
                              <%-- <dx:ASPxComboBox ID="cmb_condventaid" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="cmb_condventaid_SelectedIndexChanged">                                                                
                                </dx:ASPxComboBox>--%>                                        
                            </div>
                        </div>                    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Plazos</label>
                                <asp:DropDownList ID="cmb_plazoday" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmb_plazoday_SelectedIndexChanged">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="val_cmb_plazoday" runat="server" CssClass="validacion" 
                                        ControlToValidate="cmb_plazoday" ErrorMessage="Elegir plazo" ValidationGroup="Validate">
                                </asp:RequiredFieldValidator>--%>
                               
                                <%-- <dx:ASPxComboBox ID="cmb_plazoday" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmb_plazoday_SelectedIndexChanged">                                                                
                                </dx:ASPxComboBox>--%>                                
                            </div>
                        </div>
                        <div class="col-md-3">                            
                            <div class="form-group">
                                <label>Moneda</label>
                                 <asp:DropDownList ID="cmb_moneda" runat="server" CssClass="form-control">
                                     <asp:ListItem Value="S">S/.</asp:ListItem>
                                     <asp:ListItem Value="$">US$</asp:ListItem>
                                </asp:DropDownList>
                                <%--<dx:ASPxComboBox ID="cmb_moneda" runat="server" CssClass="form-control">
                                    <Items>
                                        <dx:ListEditItem Text="S/." Value="S" />
                                        <dx:ListEditItem Text="US$" Value="$" />
                                    </Items>
                                </dx:ASPxComboBox>--%>
                              <%--  <asp:RequiredFieldValidator ID="val_cmb_moneda" runat="server" ControlToValidate="cmb_moneda" CssClass="validacion" ErrorMessage="Elegir moneda" ValidationGroup="Validate">
                                </asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="col-md-2">                    
                            <label>IGV</label>
                            <dx:ASPxComboBox ID="cmb_igv" runat="server" CssClass="form-control" Enabled="False" EnableTheming="False" SelectedIndex="0">
                                <Items>
                                    <dx:ListEditItem Text="SI" Value="S" Selected="True" />
                                    <dx:ListEditItem Text="NO" Value="N" />
                                </Items>
                            </dx:ASPxComboBox>         
                        </div>
                    </div>
                    </div>
                    </div>
                </div>    
                <div class="col-md-4 text-left ocultar">                                      
                    <div class="panel panel-info">
                    <div class="panel-body alert-info">
                    <div class="table-responsive">                        
                        <div class="col-md-9">                        
                            <label>Vendedor</label>                            
                            <asp:TextBox ID="txt_vendorname" runat="server" TabIndex="2" CssClass="form-control" Enabled="False" EnableTheming="True" placeholder="Vendedor">
                            </asp:TextBox>
                        </div>                    
                        <div class="col-md-3">
                            <label>Id</label>                            
                            <asp:TextBox ID="txt_vendorid" runat="server" TabIndex="2" CssClass="form-control"></asp:TextBox>
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
                        <div class="col-md-12">                        
                            <label>Observación</label>                            
                            <asp:TextBox ID="txt_obs" runat="server" TabIndex="2" CssClass="form-control" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    </div>
                    </div>
                </div>                
            </div>
                <!--<a href="#download" class="btn btn-default btn-lg"><span class="network-name">Siguiente</span> <i class="fa fa-chevron-right"></i></a>-->
                <asp:LinkButton ID="LkBSiguiente" runat="server" CssClass="btn btn-primary btn-lg" OnClick="LKBSiguiente_Click" OnClientClick ="myFecha()" ><span class="network-name">Siguiente <i class="fa fa-chevron-right"></i></span>
                </asp:LinkButton>                
                <%--<a href="#page-top" class="btn btn-default btn-lg"><i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span></a>--%>
                <asp:LinkButton ID="lbcancel" runat="server" CssClass="btn alert-danger btn-lg" OnClick="lbcancel_Click"><i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span>
                </asp:LinkButton>                
         </ContentTemplate>
            </asp:UpdatePanel>

        <div></div>
        <br><br><br><br><br>
    </section>
            <div class="download-section">    
                <p class="text-center" style ="color:white;">Copyright &copy; WAMA S.A.C. 2015</p>        
            </div>

    <!-- Download Section -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">     
     <ContentTemplate>

    <section id="download" class="content-section text-center">       
    <br>
        <%--<br><br><br>--%>
        <div class="download-section_">            
            <div class="container">
                <div class="row">
                <div class="col-md-12">
                <div class="col-lg-8 col-lg-offset-2">

                    <h2 id ="lista"><i class="fa fa-list-alt"></i> Listados de Items</h2>                                        
                    <%--<p>You can download Grayscale for free on the preview page at Start Bootstrap.</p>--%>
                </div>
            </div>
        </div>  
                
                
                 				
		<div class="row">
			<div class="col-md-12 text-left">                                      
				<div class="panel panel-info">
				<div class="panel-body alert-info">
				<div class="table-responsive">  
                    <asp:UpdatePanel ID="NestedPanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>                                                                                                                                        						
					<!--<div class="col-md-12">									-->
					<div class="col-md-4">
                                <asp:CheckBox ID="chk_Bloquear" runat="server" ToolTip="Activar para bloquear Item" TextAlign="Left" BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="2px" OnCheckedChanged="chk_Bloquear_CheckedChanged" AutoPostBack="True" CssClass="ocultar" Visible="False" />                                        
								<label>Código</label>
							<div class="form-group input-group">										
                                    <asp:TextBox ID="txt_articidold" runat="server" CssClass="form-control" MaxLength="7" disabled=""></asp:TextBox>                                                                                 
                                    <span class="input-group-btn">
                                    <%-- <button class="btn btn-danger" id="btn01" type="button" data-toggle="modal" data-target="#ModalCliente"><i class="fa fa-search"></i>
                                    </button> --%>                                                            
                                    <%--<asp:Button ID="btn_buscar" runat="server" Text="Search" CssClass="btn btn-warning" OnClick="btn_buscar_Click">
                                        </asp:Button>--%>        
                                        <%--<button class="btn btn-danger" id="btn01" type="button" data-toggle="modal" data-target="#ModalCliente"><i class="fa fa-search"></i>
                                    </button>--%>
                                    <%--   <button id="Button2" class="btn btn-warning" type="button" data-toggle="modal" data-target="#searchArtc"
                                                onclick="searchItem()"><i class="fa fa-search"></i></button>--%>

                                        <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-warning" 
                                            data-toggle="modal" data-target="#searchArtc">
                                        <i class="fa fa-search"></i>
                                        </asp:LinkButton>  
                                                
                                        </span>
                                    <%--<div style=" display:none;">                                        
                                        <asp:Button ID="btn_search" runat="server" class="btn btn-default" Text="Si" OnClick="btn_search_Click"/>
                                    </div> --%>
                                             
							<%--	 <asp:RequiredFieldValidator ID="val_txt_articidold" runat="server" CssClass="validacion" 
                                    ControlToValidate="txt_articidold" ErrorMessage="Elegir Codigo" ValidationGroup="Validate_2">
                                </asp:RequiredFieldValidator>--%>
							</div>
						</div>
					<!--</div>  									-->
					<!--<input type="checkbox" value="" class="checkbox">-->

					<div class="col-md-8">
						<label>Artículo</label>                                                       								
                            <asp:TextBox ID="txt_articname" runat="server" Enabled="False"  CssClass="form-control"></asp:TextBox>                   


					</div>
					<div class="col-md-4">
						<label>Marca</label>                                                       								
                            <asp:TextBox ID="txt_marcaname" runat="server" Enabled="False"  CssClass="form-control"></asp:TextBox>                  
                        <%--<asp:requiredfieldvalidator id="RequiredFieldValidator3" errormessage="* Campo Artículo está vacio " display="None" controltovalidate="txt_marcaname" runat="server">
                            </asp:requiredfieldvalidator>--%>
					</div>
					<div class="col-md-4">
						<label>Precio de Lista</label>                                                       								
                        <asp:TextBox ID="txt_precventa_cre_menor" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>                  
					</div>

                    <div class="col-md-3">
						<div class="form-group">
							<label>Color</label>
                            <asp:DropDownList ID="cmb_colorid" runat="server" CssClass="form-control" OnSelectedIndexChanged="cmb_colorid_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
							<%--<dx:ASPxComboBox ID="cmb_colorid" runat="server" CssClass="form-control">                                                               
                            </dx:ASPxComboBox>--%>
                            <%--<asp:RequiredFieldValidator ID="val_cmb_colorid" runat="server" CssClass="validacion" 
                                    ControlToValidate="cmb_colorid" ErrorMessage="Elegir color" ValidationGroup="Validate_2">
                            </asp:RequiredFieldValidator> --%>

                        <%--    <asp:requiredfieldvalidator id="RequiredFieldValidator6" errormessage="* Campo Color está vacio " display="None" controltovalidate="cmb_colorid" runat="server">
                                </asp:requiredfieldvalidator>--%>
						</div> 
					</div>	
					<div class="col-md-3">
						<div class="form-group">
							<label>Talla</label>
                            <asp:DropDownList ID="cmb_tallaid" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_tallaid_SelectedIndexChanged">
                            </asp:DropDownList>
							<%--<dx:ASPxComboBox ID="cmb_tallaid" runat="server" CssClass="form-control">                                                                
                            </dx:ASPxComboBox>--%>
                            <%--<asp:RequiredFieldValidator ID="val_cmb_tallaid" runat="server" CssClass="validacion" 
                                    ControlToValidate="cmb_tallaid" ErrorMessage="Elegir talla" ValidationGroup="Validate_2">
                            </asp:RequiredFieldValidator>--%>

                            <%-- <asp:requiredfieldvalidator id="RequiredFieldValidator5" errormessage="* Campo Talla está vacio " display="None" controltovalidate="cmb_tallaid" runat="server">
                                </asp:requiredfieldvalidator>--%>
						</div> 
					</div>
							
					<div class="col-md-2">	
						<label>Stock Disponible</label>                                        	                                    
							<div class="form-group input-group">
                                <asp:TextBox ID="txtStkdisp" runat="server" 
                                    class="form-control text-danger" placeholder="" disabled="" ></asp:TextBox>
                                </div>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" 
                        controltovalidate="txtStkdisp" validationgroup="Quanty1" CssClass="label label-danger"
                        errormessage="Enter a city name" runat="Server" InitialValue="0">
                            <i class="fa fa-close"></i>
                            <span class="network-name"> Debe ser mayor a 0 para agregar</span></asp:requiredfieldvalidator>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator8" 
                        controltovalidate="txtStkdisp" validationgroup="Quanty1" CssClass="label label-danger"
                        errormessage="Enter a city name" runat="Server" InitialValue="">
                            <i class="fa fa-close"></i>
                            <span class="network-name"> Requerido</span></asp:requiredfieldvalidator>
                
                            <div class="form-group input-group">                                                                                
						</div>
                        </div> 
                    <asp:HiddenField ID="HdFtalla" runat="server"></asp:HiddenField>			
                    <asp:HiddenField ID="HdFarticid" runat="server"></asp:HiddenField>			
					<div class="col-md-1">							
						<div class="form-group">									
							<label>Cantidad</label>									
							<span>
							<%--<input id="box2" class="form-control" title="DOM title" type="text" value="1"/>		--%>
                            <dx:ASPxSpinEdit ID="spe_cantidad" runat="server" Number="1" 
                                MaxValue="100" MinValue="1" MaxLength="3" CssClass="form-control" Width="80px">
                            </dx:ASPxSpinEdit>                                                                           						
							</span>
						</div> 
                            <asp:Label ID="msgCant" runat="server" Text=""></asp:Label>
					</div>
							
                        </ContentTemplate>

                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="NestedPanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>                                                        
							<div class="col-md-3">
							<br>
								<div class="col-md-12">
								<center>
									<label></label>
									<%--<button class="btn btn-success" data-toggle="modal" data-target="#"><i class="fa fa-plus fa-1x"></i> Agregar a Lista</button>--%>
                                    <asp:Button ID="btn_add" runat="server" Text="Agregar a Lista" CssClass="btn btn-success" TabIndex="24" OnClick="btn_add_Click" causesvalidation="true" validationgroup="Quanty1" />                                    
								</center>
							</div>
							</div>
          
				</div>
				</div>
				</div>

			</div>                
		</div>				
        <br>

        <div class="row">
        <div class="col-md-12">
            <!-- Advanced Tables -->
            <div class="panel panel-primary">
                <div class="panel-heading">
                        Lista de Items
                </div>
                <%--OnSelectedIndexChanged="griddetalle_SelectedIndexChanged"--%>
                <div class="panel-body">
                    <div class="table-responsive text-left">
                        <asp:GridView ID="griddetalle" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" 
                            GridLines="None" PagerStyle-CssClass="pgr" 
                            OnRowDeleting="griddetalle_RowDeleting" 
                            DataKeyNames="articid,colorid,tallaid">
                            <Columns>
                                <asp:BoundField DataField="articid" HeaderText="articid" HeaderStyle-CssClass="ocultar" SortExpression="articid">
                                <HeaderStyle CssClass="ocultar"  />
                                <ItemStyle Wrap="False" CssClass="ocultar"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="articidold" HeaderText="Codigo">
                                <ItemStyle Width="100px" Wrap="false" />
                                </asp:BoundField>
                                        
                                <asp:BoundField DataField="marcaid" HeaderText="marcaid" Visible="false" SortExpression="marcaid">
                                <ItemStyle Width="100px" Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="marcaname" HeaderText="Marca">
                                <ItemStyle Width="100px" Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="articname" HeaderText="Artículo">
                                <ItemStyle Width="100px" Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colorid" HeaderText="colorid" HeaderStyle-CssClass="ocultar"   SortExpression="colorid">
                                <HeaderStyle CssClass="ocultar" />
                                <ItemStyle Width="80px" Wrap="False" CssClass="ocultar"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="colorname" HeaderText="Color">
                                <ItemStyle Width="100px" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tallaid" HeaderText="tallaid" HeaderStyle-CssClass="ocultar" SortExpression="tallaid">
                                <HeaderStyle CssClass="ocultar" />
                                <ItemStyle Wrap="False" CssClass="ocultar" />
                                </asp:BoundField>
                                <asp:BoundField DataField="talla" HeaderText="Talla">
                                <ItemStyle Width="30px" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cantidad" DataFormatString="{0:N}" HeaderText="Cant">
                                <ItemStyle Width="20px" Wrap="False" HorizontalAlign="Right" />
                                </asp:BoundField>                                        
                                <asp:BoundField DataField="precbruto" DataFormatString="{0:N}" HeaderText="PrecLista">
                                <ItemStyle Width="30px" Wrap="False" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="impobruto" DataFormatString="{0:N}" HeaderText="ImpaPLista">
                                <ItemStyle Width="30px" Wrap="True" HorizontalAlign="Right" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="precneto" DataFormatString="{0:N}" HeaderText="PrecConDescto">
                                <ItemStyle Width="50px" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="imponeto" DataFormatString="{0:N}" HeaderText="ImpoConDscto">
                                <ItemStyle Width="50px" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="coltall" HeaderText="coltall" HeaderStyle-CssClass="" SortExpression="coltall">
                                <HeaderStyle CssClass="" />
                                <ItemStyle Wrap="False" CssClass="" />
                                </asp:BoundField>
                                                                          

                                <%-- <asp:CommandField ButtonType="Image" EditImageUrl="~/images/edit.png" EditText="Editar" 
                                    ShowEditButton="True" CancelImageUrl="~/images/btn_cancel.png" ControlStyle-CssClass="btn btn-warning"  
                                    CancelText="Cancelar" UpdateImageUrl="~/images/btn-save.png" DeleteImageUrl="~/images/btn_delete_.png" >
                                <ControlStyle CssClass="btn btn-warning" />
                                </asp:CommandField>--%>
                                        
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.png" ShowDeleteButton="True" 
                                    ControlStyle-CssClass="btn btn-danger" HeaderText="Quitar" >
                                <ControlStyle CssClass="btn btn-danger" />
                                </asp:CommandField>
                                        
                                <asp:TemplateField HeaderText="Acción" ItemStyle-CssClass="ocultar" HeaderStyle-CssClass="ocultar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" Text="Editar" 
                                        CommandArgument='<%# Eval("articid")+ "," + Eval("articidold") + "," + Eval("articname") + "," + Eval("marcaname") + "," + 
                                    Eval("precbruto")+ "," + Eval("colorid")+ "," + Eval("tallaid")+"," + Eval("cantidad") %>' 
                                        OnCommand="EditarFilaSeleccionada"  CssClass=" ocultar " ImageUrl='~/images/edit.png' />

                                </ItemTemplate>
                                    <HeaderStyle CssClass="ocultar" />
                                    <ItemStyle CssClass="ocultar" />
                                </asp:TemplateField>

<%--                                <asp:TemplateField HeaderText="Nr">  
                                    <ItemTemplate>  
                                    <asp:Label ID="Label1" runat="server"  
                                        Text='<%# (griddetalle.PageSize * griddetalle.PageIndex) + Container.DisplayIndex + 1 %>'>  
                                    </asp:Label>  
                                    </ItemTemplate>  
                                </asp:TemplateField> --%>
                                                            
                                    
                            </Columns>
                            <EditRowStyle BackColor="#000099" />
                            <EmptyDataRowStyle BackColor="#000099" />
                            <PagerStyle CssClass="pgr"></PagerStyle>
                            <SelectedRowStyle BackColor="#d6e9c6" ForeColor="#3c763d"  CssClass="SeRoSty" />
<%--                                    <EditRowStyle BackColor="#0033FF" />
                            <EmptyDataRowStyle BackColor="#0033FF" />
                            <PagerStyle CssClass="pgr" />
                            <SelectedRowStyle BackColor="#3399CC" CssClass="SeRoSty" ForeColor="#ffffff" />--%>
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
                <asp:Label ID="items" runat="server" Text="0" ForeColor="Red" Visible="true" CssClass="form-control"></asp:Label>
            </div>

            <div class="col-md-3">
                <label>Vta. Precio Lista</label>                        
                <asp:TextBox ID="txt_impobruto" runat="server" Enabled="False" CssClass="form-control" BackColor="#FFCC00">0.00</asp:TextBox>
            </div>

            <div class="col-md-3">
                <label>% Descuento</label>
                <asp:TextBox ID="txt_tasadescto" runat="server" Enabled="False" CssClass="form-control" BackColor="#FFCC00">0.00</asp:TextBox>
            </div>
            <div class="col-md-3">
                <label>Vta. con Descuento</label>
                <asp:TextBox ID="txt_imponeto" runat="server" Enabled="False" BackColor="#FFCC00" CssClass="form-control">0.00</asp:TextBox>
            </div>
        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>                       
        <!--</div>-->
                </div>
            <br><br>
        <a href="#about" class="btn alert-info btn-lg"><i class="fa fa-chevron-left"></i> <span class="network-name">Anterior</span></a>
        <%--<a href="#contact" class="btn btn-primary btn-lg"><span class="network-name">Siguiente</span> <i class="fa fa-chevron-right"></i></a> --%>
            <%--OnClick="btn_Cancelar2_Click"--%>
        <asp:LinkButton ID="btn_act02" runat="server" CssClass="btn btn-primary btn-lg" PostBackUrl="#contact" OnClick="btn_act02_Click">
             <span class="network-name">Siguiente</span> <i class="fa fa-chevron-right"></i>
        </asp:LinkButton>

        <asp:LinkButton ID="btn_Cancelar2" runat="server" CssClass="btn alert-danger btn-lg" PostBackUrl="#page-top">
            <i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span>
        </asp:LinkButton>

        </div>
        <br><br>

    </section>
    </ContentTemplate>
    </asp:UpdatePanel>
            <div class="download-section">    
                <p class="text-center" style ="color:white;">Copyright &copy; WAMA S.A.C. 2015</p>        
            </div>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <%-- <asp:PostBackTrigger ControlID="btn_Imprimir" />
            <asp:PostBackTrigger ControlID="btn_Imprimir2" />--%>
    </Triggers>
    <ContentTemplate>

    <!-- Contact Section -->    
    <section id="contact" class="container content-section text-center">   
    <br>
        <%--<br><br><br><br>--%>
            <h2><i class="fa fa-calendar"></i> Cronograma de Pago</h2>                    
                   <%-- <p>You can download Grayscale for free on the preview page at Start Bootstrap.</p>--%>
            <div class="row">
                <div class="col-md-12 text-left">    
                    <div class="col-md-3">
                        <label>N° Proforma</label>                        
                        <asp:TextBox ID="txt_proforma2" runat="server" placeholder="Numero de Proforma" Enabled="false" CssClass="form-control">
                        </asp:TextBox>
                        <asp:Label ID="txt_tipdoc2" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="txt_serdoc2" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="txt_numdoc2" runat="server" Text="Label" Visible="false"></asp:Label>
                    </div>                    
                    <div class="col-md-3">
                        <label>Neto a Pagar</label>                                                                    
                        <asp:TextBox ID="imponeto2" runat="server" BackColor="#FFCC00" CssClass="form-control" Enabled="False">0.00</asp:TextBox>
                    </div>
                    <div class="col-md-3">                    
                        <label>Fecha de Emisión</label>
                        <asp:TextBox ID="fechdoc2" runat="server" Text="" CssClass="form-control" disabled=""></asp:TextBox>                        
                    </div>
                    <div class="col-md-3">                        
                        <label>Fecha Entrega</label>                                                    
                        <!--<input id="datepicker" class="form-control" type="text" disabled="">-->
                        <!--<input class="form-control" type="text" disabled="">-->
                          <asp:TextBox ID="fechentrega2" runat="server" Text="" CssClass="form-control" disabled=""></asp:TextBox>
                    </div>
                </div>
            </div>
            <br>

            <div class="row">
            <div class="col-md-12 text-left">                    
                <div class="col-md-3">
                    <!--<label>Neto a Pagar</label>
                    <input class="form-control" placeholder="" disabled="">
                    <br>-->

                    <div class="form-group">
                        <label>Medio de Pago</label>                      
                        <dx:ASPxComboBox ID="cmb_mediopagoid" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="cmb_mediopagoid_SelectedIndexChanged">
                        </dx:ASPxComboBox>
                        <%--<asp:requiredfieldvalidator id="RequiredFieldValidator4" errormessage="* Campo Medio de Pago está vacio " display="None" controltovalidate="cmb_mediopagoid" runat="server">
                        </asp:RequiredFieldValidator>--%>
                    </div> 
                    <br>                   
                        <label>Número de Cuotas</label>                                     
                         <dx:ASPxSpinEdit ID="spe_numdocs" runat="server" AutoPostBack="true" Number="1" CssClass="form-control" 
                             OnNumberChanged="spe_numdocs_NumberChanged" MinValue="1" MaxLength="3" MaxValue="6">
                         </dx:ASPxSpinEdit>
                    <br>
                    <br>
                </div>  
            


                <div class="col-md-9">
                    <!-- Advanced Tables -->
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                             Lista de Items
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">                           

                                <asp:GridView ID="gridcronpagos" runat="server" AutoGenerateColumns="False"
                                    GridLines="None" CssClass="table table-striped table-bordered table-hover" PageSize="6" 
                                    OnRowCancelingEdit="gridcronpagos_RowCancelingEdit" OnRowDataBound="gridcronpagos_RowDataBound" 
                                    OnRowDeleting="gridcronpagos_RowDeleting" OnRowEditing="gridcronpagos_RowEditing" 
                                    OnRowUpdating="gridcronpagos_RowUpdating">
                                    <Columns>                                                           
                                        <asp:BoundField DataField="item" HeaderText="Item">
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="num_interno" HeaderText="Numdoc">
                                            <ItemStyle Width="60px" Wrap="False" HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="num_unico" HeaderText="NumUnico"  HeaderStyle-CssClass="ocultar" Visible="False">
                                            <HeaderStyle CssClass="ocultar" />
                                            <ItemStyle Width="60px" Wrap="False"  CssClass="ocultar" />
                                        </asp:BoundField>
                                                            
                                        <asp:TemplateField HeaderText="Importe" Visible="true" HeaderStyle-Width="60px" SortExpression="monto">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="monto" runat="server" CssClass="_text" Width="60px" Enabled="False" Text='<%# Eval("monto", "{0:n}") %>'>
                                                        </asp:TextBox>                                                                                                                                                                                                                           
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="60px" />
                                        </asp:TemplateField>                                                           

                                        <asp:TemplateField HeaderText="FechVenc" Visible="true" HeaderStyle-Width="80px" SortExpression="fechven">
                                            <ItemTemplate>
                                                <asp:TextBox ID="fechven" runat="server" CssClass="_text" Width="80px" Enabled="False" Text='<%# Bind("fechven") %>'>
                                                </asp:TextBox>    
                                                <cc1:MaskedEditExtender ID="fecha_MaskedEditExtender" runat="server" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" 
                                                                        TargetControlID="fechven" UserDateFormat="DayMonthYear"/>
                                                <cc1:CalendarExtender ID="fecha_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="fechven">
                                                </cc1:CalendarExtender>                                                                   
                                            </ItemTemplate>
                                            <HeaderStyle Width="60px" />
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/images/edit.png" EditText="Editar" 
                                        ShowEditButton="True" CancelImageUrl="~/images/btn_cancel.png" ControlStyle-CssClass="btn btn-warning"  
                                        CancelText="Cancelar" UpdateImageUrl="~/images/btn-save.png" HeaderText="Modificar" >
                                        
                                         <ControlStyle CssClass="btn btn-warning" />
                                        <ItemStyle Width="15px" />
                                        </asp:CommandField>
                                        
                                         <asp:TemplateField HeaderText="Quitar">                                 
                                              <ItemTemplate>
                                                <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                CommandName="Delete" ImageUrl="~/images/delete.png" Text="Eliminar" 
                                                OnClientClick="javascript:if(!confirm('¿Seguro de Eliminar?'))return false"/>
                                            </ItemTemplate>
                                              <ItemStyle Width="15px" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataRowStyle BackColor="#000099" />
                                    <PagerStyle CssClass="pgr"></PagerStyle>
                                    <SelectedRowStyle BackColor="#d6e9c6" ForeColor="#3c763d"  CssClass="SeRoSty" />
                                </asp:GridView>

                            </div>      
                        </div>
                    </div>
                    <!--End Advanced Tables -->
                </div>
                </div>
                <a href="#download" class="btn alert-info btn-lg"><i class="fa fa-chevron-left"></i> <span class="network-name">Anterior</span></a>                                             
                <button class="btn btn-primary btn-lg" data-toggle="modal" data-target="#saveItem"><i class="fa fa-save"></i> Guardar</button>
             

                 <asp:LinkButton ID="btn_cancelar3" runat="server" CssClass="btn alert-danger btn-lg" OnClick="btn_Cancelar3_Click" PostBackUrl="#page-top">
                    <i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span>
                </asp:LinkButton>

                <%--<a href="#page-top" class="btn btn-default btn-lg"><i class="fa fa-minus-square"></i> <span class="network-name">Cancelar</span></a>--%>
                
                <%-- <a href="#page-top" class="btn btn-default btn-lg" data-toggle="modal" data-target="#printItem"><i class="fa fa-print"></i> 
                <span class="network-name">Imprimir</span></a>--%>

                 <asp:LinkButton ID="btn_Imprimir" runat="server" CssClass="btn btn-default btn-lg ocultar">
                    <i class="fa fa-print"></i> <span class="network-name">Imprimir</span>
                </asp:LinkButton>

               <%-- <asp:Button ID="btn_Imprimir" runat="server" Text="Imprimir" class="btn btn-default btn-lg"></asp:Button>--%>

                
                
            </div>
            <br><br><br><br>
    </section>
    <section id="modalValidate">        
                                <div class="modal fade" id="validateItems" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="H8"><i class="fa fa-trash-o fa-1x"></i> Mensaje</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:validationsummary forecolor="Red" runat="server" id="validationSummary">
                                                    </asp:validationsummary>

                                            </div>
            <%--                                <div class="modal-footer">
                                                <button type="button" class="btn btn-default" >Si</button>
                                                <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>

        </section>
    </ContentTemplate>
    </asp:UpdatePanel>
      
    
    <section id="modaDelete">        
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
                                            <h4 class="modal-title" id="H1"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            <label style="padding-left:25px;">Por favor, elija como se guardará su pedido.</label><br />
                                            <!--Su documento se ha guardado exitosamente<br>
                                            ¿ Desea Imprimir su documento ?-->
                                            <div class="form-group panel-body alert-success">
                                            
                                            <ul class="text-center" style="list-style-type: none;">
                                                <li>
                                                    <%--<asp:LinkButton ID="LkBEdit" runat="server" class="btn btn-success btn-lg" OnClick="LkBEdit_Click">--%>
                                                    <asp:LinkButton ID="LkBStaus11" runat="server" class="btn btn-success btn-lg" OnClick="LkBStaus11_Click">
                                                          <i class="fa fa-check-square-o"></i>  <span class="network-name">Edición Posterior</span>
                                                    </asp:LinkButton>
                                            
                                                    <%--<asp:LinkButton ID="LkBDel" runat="server" class="btn btn-danger btn-lg" OnClick="LkBDel_Click">--%>
                                                    <asp:LinkButton ID="LkBStaus12" runat="server" class="btn btn-danger btn-lg" OnClick="LkBStaus12_Click">
                                                        <i class="fa fa-check-square-o"></i>  <span class="network-name">Pedido Finalizado</span>
                                                    </asp:LinkButton>                                                
                                                </li>
                                            </ul>

                                                <ul class="text-danger">
                                                    <b>Nota:</b>
                                                    <li>Si selecciona la opción <b>Edición Posterior</b>, el pedido podrá ser editado posteriormente</li>
                                                    <li>Si selecciona la opción <b>Pedido Finalizado</b>, el pedido no podrá ser editado posteriormente</li>
                                                </ul>
                                                    
                                            </div>                                       
                                        </div>
                                        <div class="modal-footer">
                                            <%--<button type="button" class="btn btn-default" >Si</button>--%>
                                            <%--<asp:LinkButton ID="btn_grabar" runat="server" OnClick="btn_grabar_Click" CssClass="btn btn-default">
                                                <span class="network-name">Guardar</span>
                                            </asp:LinkButton>  --%>
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
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
                                            <h4 class="modal-title" id="H2"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
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
                                            <h4 class="modal-title" id="H3"><i class="fa fa-list fa-1x"></i> Listado de Productos</h4>
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
        
    <section id="modalSerchCustomer">
                                <div class="modal fade" id="searchCust" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H4"><i class="fa fa-list fa-1x"></i> 
                                            <asp:Label ID="txt_titulo" runat="server" Text="Listado de Clientes Registrados"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <Triggers></Triggers>
                                                    <ContentTemplate>
                                                    <table border="00" cellspacing="00" cellpadding="00" runat="server">                                                    
                                                    <tr>
                                                        <td valign="top" align="center">                                                                                                                       
                                                            <table runat="server" id="tb01">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="bus_name" runat="server" Font-Size="11pt" Text="Buscar por: "></asp:Label>
                                                                        <%--<asp:HiddenField ID="Hdffiltro" runat="server"></asp:HiddenField>--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="cbo_filtro"
                                                                            AutoPostBack="True" OnSelectedIndexChanged="cbo_filtro_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_filter" runat="server" onkeydown="enterTo(event,'btnSearch');"
                                                                           CssClass="form-control"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click" Text="Buscar"/>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                GridLines="None" CssClass="table table-striped table-bordered table-hover"  
                                                                OnPageIndexChanging="GridView1_PageIndexChanging"                                                                
                                                                OnRowCreated="GridView_OnRowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                                                PageSize="5" >
                                                                <Columns>
                                                                </Columns>                                                                
                                                                 <EditRowStyle BackColor="#000099" />
                                                                <EmptyDataRowStyle BackColor="#000099" />
                                                                <PagerStyle CssClass="pgr"></PagerStyle>
                                                                <SelectedRowStyle BackColor="#d6e9c6" ForeColor="#3c763d"  CssClass="SeRoSty" />

                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>

                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                                
                                                </div>      
                                            </div>                                            
                                        </div>
                                        <%--<br />--%>
                                        <div class="modal-footer">
                                           <%-- <button type="button" class="btn btn-default">Aceptar</button>--%>
                                           <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </section>
        
    <section id="SectionArticulo">
                                <div class="modal fade" id="searchArtc" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H7"><i class="fa fa-list fa-1x"></i> 
                                            <asp:Label ID="Label1" runat="server" Text="Listado de Articulos Registrados"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <Triggers></Triggers>
                                                    <ContentTemplate>
                                                    <table id="Table1" border="00" cellspacing="00" cellpadding="00" runat="server">                                                    
                                                    <tr>
                                                        <td valign="top" align="center">                                                                                                                       
                                                            <table runat="server" id="Table2">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Font-Size="11pt" Text="Buscar por: "></asp:Label>
                    
                                                                     </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                      <div class="row">
                                                                        <div class="col-md-12 text-left">                    
                                                                            <div class="col-md-4" style="display:none;">
                                                                                <asp:DropDownList runat="server" CssClass="form-control" ID="cbo_filtro2"
                                                                            AutoPostBack="True" OnSelectedIndexChanged="cbo_filtro2_SelectedIndexChanged">
                                                                        </asp:DropDownList>                                                                                
                                                                            </div>
                                                                        
                                                                        <div class="form-group input-group">
                                                                        <asp:TextBox ID="txt_filter2" runat="server" class="form-control" 
                                                                            placeholder="Buscar por..." ></asp:TextBox>										
										                                <span class="input-group-btn">
										                                <button id="boton1" class="btn btn-warning" type="button" 
                                                                            onclick="searchItem()"><i class="fa fa-search"></i></button>										                                        										
                                                                        </span>							                                        
                                                                     </div>     
                                                                   </div> 
                                                               </div>     

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <div style=" display:none;">                                        
                                                                <asp:Button ID="btnSearch2" runat="server" class="btn btn-default" 
                                                                    Text="Si" onclick="btnSearch2_Click" />
                                                            </div>
                                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                GridLines="None" CssClass="table table-striped table-bordered table-hover "  
                                                                OnPageIndexChanging="GridView2_PageIndexChanging"                                                                
                                                                OnRowCreated="GridView2_OnRowCreated" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
                                                                PageSize="5" >
                                                                <Columns>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#000099" />
                                                                <EmptyDataRowStyle BackColor="#000099" />
                                                                <PagerStyle CssClass="pgr"></PagerStyle>
                                                                <SelectedRowStyle BackColor="#d6e9c6" ForeColor="#3c763d"  CssClass="SeRoSty" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>

                                                </ContentTemplate>
                                                </asp:UpdatePanel>                                                    
                                                </div>      
                                            </div>                                            
                                        </div>                      
                                        <div class="modal-footer">
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
                                                <h4 class="modal-title" id="H6"><i class="fa fa-times fa-1x"></i> Mensaje</h4>
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

        </section>
        
    </form>

  
    <!-- Map Section -->
    <!--<div id="map"></div>-->

    <!-- Footer -->
    <footer class="download-section">
        <div class="container text-center">
            <p style ="color:white;">Copyright &copy; WAMA S.A.C. 2015</p>
        </div>
    </footer>

    <!-- jQuery -->
    <!--<script src="assets/js/jquery.js"></script>-->
    <!--<script src="Listados/assets/js/jquery-1.10.2.js"></script>-->
    <!--TOGGLE-->    
    <link href="Listados/assets/toggle/css/bootstrap-toggle.css" rel="stylesheet" />
    <script src="Listados/assets/toggle/js/bootstrap-toggle.js"></script>
    <script src="Listados/assets/toggle/js/jquery-2.1.1.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="Listados/assets/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="Listados/assets/js/jquery.easing.min.js"></script>

    <!-- Google Maps API Key - Use your own API key to enable the map feature. More information on the Google Maps API can be found at https://developers.google.com/maps/ -->
    <!--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCRngKslUGJTlibkQ3FkfTxj3Xss1UlZDA&sensor=false"></script>-->

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
                $('#dataTables-example3').dataTable();
                $('#dataTables-example4').dataTable();
            });
    </script>
    <script src="Listados/assets/datepicker/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="Listados/assets/datepicker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="Listados/assets/datepicker/js/locales/bootstrap-datetimepicker.es.js" type="text/javascript"></script>
    <script type="text/javascript">
        var fecha = $("#<%= tfecha.ClientID %>").val();
        var idioma = $("#<%= idiom.ClientID %>").val();
        $('.form_datetime').datetimepicker({
            //language:  'es',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 1,
            forceParse: 0,
            showMeridian: 1
        });
        $('.form_date').datetimepicker({
            language: idioma,
            format: 'dd/mm/yyyy',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            startDate: fecha
        });
        $("#<%= fechentrega.ClientID %>") = fecha.val();         

    </script>


</body>
</html>

