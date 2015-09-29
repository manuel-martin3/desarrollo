<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_PedidoMenu.aspx.cs" Inherits="Comercial_Frm_PedidoMenu" %>

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
<body id="page-top" data-spy="scroll" data-target="" class="download-section">

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
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="LkBtnSearch" runat="server" class="btn btn-circle" 
                                    onclick="LkBtnSearch_Click"><i class="fa fa-search animated"></i></asp:LinkButton>
                                <asp:LinkButton ID="LkBtnNew" runat="server" class="btn btn-circle" onclick="LkBtnNew_Click"><i class="fa fa-file-o animated"></i></asp:LinkButton>
                                <asp:LinkButton ID="LkBtnEdit" runat="server" class="btn btn-circle"><i class="fa fa-pencil animated"></i></asp:LinkButton>
                                <asp:LinkButton ID="LkBtnDelete" runat="server" class="btn btn-circle"><i class="fa fa-trash-o animated"></i></asp:LinkButton>
                            </ContentTemplate>
                            </asp:UpdatePanel>
<%--
                            <a href="#search" class="btn btn-circle"><i class="fa fa-search animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-file-o animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-pencil animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-trash-o animated"></i></a>                            --%>

                        </div>
                    </div>
                </div>
            </div>
        </header>
    </form>
    
    <!-- Footer -->
    <footer class="download-section">
        <div class="container text-center">
            <p style ="color:white;">Copyright &copy; WAMA S.A.C. 2015</p>
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

