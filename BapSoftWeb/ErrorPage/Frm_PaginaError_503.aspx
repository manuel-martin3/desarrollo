<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_PaginaError_503.aspx.cs" Inherits="Frm_PaginaError_503" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Grayscale - Start Bootstrap Theme</title>
        
    <!-- Bootstrap Core CSS -->
    <!--<link href="assets/css/bootstrap.min.css" rel="stylesheet">-->
    <link href="../Comercial/Listados/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    
    <!-- Custom CSS -->
    <!--<link href="assets/css/grayscale.css" rel="stylesheet">-->
    <link href="../Comercial/Listados/assets/css/grayscale.css" rel="stylesheet" type="text/css" />

    <!-- Custom Fonts -->
    <!--<link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">-->
    <link href="../Comercial/Listados/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
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
                            <h1 class="brand-heading">¡Error 503!</h1>
                           <p class="intro-text"><i class="fa fa-chain-broken fa-3x animated"></i> 
                           Ocurrió un error durante la operación, 
                           <br />por favor vuelva a intentarlo nuevamente.</p>
                            <center>
                 
                            </center>
                            <hr /> 
                            <%--<a href="#search" class="btn btn-circle"><i class="fa fa-print animated"></i></a>
                            <a href="#search" class="btn btn-circle"><i class="fa fa-file-o animated"></i></a>--%>
                            <%--<a href="#search" class="btn btn-circle"><i class="fa fa-home animated"></i></a>     --%>
                            <asp:LinkButton ID="LkBExit" runat="server" CssClass="btn btn-circle" PostBackUrl="~/Login.aspx">
                                <i class="fa fa-home animated"></i>
                            </asp:LinkButton>                          
                            <%--<a href="#search" class="btn btn-circle"><i class="fa fa-power-off animated"></i></a>--%>
                            <br /><br />
                            <center class=" label-danger">
                                haga click sobre icono para volver a la página inicial
                            </center>
                        </div>                        
                    </div>
                </div>                
            </div>            
        </header>        
        <div class="download-section">           
        </div>                           
    </form>
 
      
 <footer class="">
        <div class="container text-center">
            <p style ="color:#428bca;">Copyright &copy; WAMA S.A.C. 2015</p>
        </div>
    </footer>

    <!-- Bootstrap Core JavaScript -->
    <script src="../Comercial/Listados/assets/js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="../Comercial/Listados/assets/js/jquery.easing.min.js"></script>
    
    <!-- Custom Theme JavaScript -->
    <script src="../Comercial/Listados/assets/js/grayscale.js"></script>
    
</body>
</html>
