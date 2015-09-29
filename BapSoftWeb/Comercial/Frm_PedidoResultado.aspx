<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_PedidoResultado.aspx.cs" Inherits="Comercial_Frm_PedidoResultado" %>

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
    <!--<link href="assets/css/bootstrap.min.css" rel="stylesheet">-->
    <link href="Listados/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <!--<link href="assets/css/grayscale.css" rel="stylesheet">-->
    <link href="Listados/assets/css/grayscale.css" rel="stylesheet" type="text/css" />

    <!-- Custom Fonts -->
    <!--<link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">-->
    <link href="Listados/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <form id="form1" runat="server">    
         
        <!--Espacio inicio cabecera-->

        <header class="intro">            
            <div class="intro-body">                
                <div class="container">
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                        <br /><br />
                            <%--<h1 class="brand-heading">(-_-)</h1>--%>
                           <p class="intro-text">
                               <%--<i class="fa fa-thumbs-o-up fa-3x animated"></i> --%>
                               Su Pedido se generó exitosamente                            
                            <center>
                            
                            </center>
                            <hr /> 

                            <%--<a class="btn btn-circle" data-toggle="modal" data-target="#printItem"><i class="fa fa-file-text-o animated"></i></a>                            --%>
                             <asp:LinkButton ID="LkBtnPrint1" runat="server" class="btn btn-circle" onclick="LkBtnPrint1_Click" ToolTip="Imprimir Contrato" Visible="False"><i class="fa fa-file-text-o animated"></i></asp:LinkButton>
                             <asp:LinkButton ID="LkBtnPrint2" runat="server" class="btn btn-circle" onclick="LkBtnPrint2_Click" ToolTip="Imprimir Pedido" Visible="False"><i class="fa fa-file-text animated"></i></asp:LinkButton>
                            <%--
                            <a class="btn btn-circle" data-toggle="modal" data-target="#printItem"><i class="fa fa-file-text-o animated"></i></a>                            
                            <a href="#search" class="btn btn-circle"><i class="fa fa-file-o animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-home animated"></i></a>                            --%>                                                        
                            <asp:LinkButton ID="LkBtnNew" runat="server" class="btn btn-circle" onclick="LkBtnNew_Click" ToolTip="Hacer un Nuevo Pedido" Visible="False"><i class="fa fa-file-o animated"></i></asp:LinkButton>
                            <asp:LinkButton ID="LkBtnHome" runat="server" class="btn btn-circle" onclick="LkBtnHome_Click" ToolTip="Dirigirse al Inicio" Visible="False"><i class="fa fa-home animated"></i></asp:LinkButton>
                            <asp:LinkButton ID="LkBExit" runat="server" CssClass="btn btn-circle" PostBackUrl="~/Comercial/Frm_Proformas.aspx"><i class="fa fa-power-off fa-1x animated"></i></asp:LinkButton>
                               <%--<a href="#search" class="btn btn-circle"><i class="fa fa-power-off animated"></i></a>   --%>
                        </div>
                    </div>
                </div>
            </div>
        </header>
                <div class="download-section">           
        </div> 

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
                                            <%--<asp:LinkButton ID="LkBtnPrint1" runat="server" class="btn btn-circle" onclick="LkBtnPrint1_Click"><i class="fa fa-print animated"></i></asp:LinkButton>--%>
                                            <br />
                                            ¿ Desea abrir la vista previa de impresión del registro ?
                                            <%--<asp:LinkButton ID="LkBtnPrint2" runat="server" class="btn btn-circle" onclick="LkBtnPrint2_Click"><i class="fa fa-print animated"></i></asp:LinkButton>--%>
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
 <footer class="">
        <div class="container text-center">
            <p style ="color:#428bca;">Copyright &copy; WAMA S.A.C. 2015</p>
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
