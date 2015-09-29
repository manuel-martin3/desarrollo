<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>»» Inicio Sesion ««</title>                   
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="Comercial/Listados/assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="Comercial/Listados/assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLES-->
    <link href="Comercial/Listados/assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
</head>
<body>
        <div class="container">
        <div class="row text-center ">
            <div class="col-md-12">
                <br /><br />                
                <h2> Autenticación de Usuarios </h2>                                                                            
                <br />
            </div>
        </div>
         <div class="row ">
               
                  <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                        <strong><img src="images/logo01.png"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;INGRESO AL SISTEMA</strong>  
                            </div>
                            <div class="panel-body">
                                <form role="form" runat="server">
                                       <br />
                                        <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>                                           
                                            <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                                        </div>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>                                           
                                            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                                        </div>
                                    <div class="form-group">
                                            <%--<label class="checkbox-inline">
                                                <%--<input type="checkbox" /> Recordar
                                            </label>
                                            <span class="pull-right">
                                                  <%-- <a href="#" >¿Olvidó su Contraseña? </a> 
                                            </span>--%>
                                    </div>                                                                          
                                    <asp:Button ID="btnAceptar" runat="server" Text="Ingresar"  CssClass="btn btn-primary " OnClick="btnAceptar_Click"/>
                                    <hr />
                                    <img src="images/peru.png"/>&nbsp;&nbsp;©&nbsp;
                                    <asp:Label  runat="server" Text="2015 » Lima-Perú"></asp:Label>                                    
                                    <%--¿No está registrado? <a href="Registro.aspx" >click aquí </a>--%> 
                                  </form>
                            </div>
                           
                        </div>
                    </div>
                
                
        </div>
    </div>


     <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="Comercial/Listados/assets/js/jquery-1.10.2.js"></script>
      <!-- BOOTSTRAP SCRIPTS -->
    <script src="Comercial/Listados/assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="Comercial/Listados/assets/js/jquery.metisMenu.js"></script>
      <!-- CUSTOM SCRIPTS -->
    <script src="Comercial/Listados/assets/js/custom.js"></script>
</body>
</html>
