<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro</title>                   
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
        <div class="row text-center  ">
            <div class="col-md-12">
                <br /><br />
                <h2> Admin : Registrar</h2>
               
                <h5>( Registrar a ti mismo para conseguir el acceso )</h5>
                 <br />
            </div>
        </div>
         <div class="row">
               
                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                        <strong>  Nuevo Usuario ? Registrese Uds. Mismo </strong>  
                            </div>
                            <div class="panel-body">
                                <form role="form" runat="server">
                                    <br/>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-circle-o-notch"  ></i></span>                                            
                                            <asp:TextBox ID="txtusuario" runat="server" CssClass="form-control" placeholder="Su Nombre"></asp:TextBox>
                                        </div>
                                     <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>                                            
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                                        </div>
                                     <%-- <div class="form-group input-group">
                                            <span class="input-group-addon">@</span>                                            
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Tu Correo Electrónico"></asp:TextBox>
                                      </div>--%>
                                      <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>                                            
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Introducir La Contraseña"></asp:TextBox>
                                        </div>
                                     <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>                                            
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Repite La Contraseña"></asp:TextBox>
                                        </div>
                                     
                                     <a href="index.html" class="btn btn-primary ">Registrarme</a>
                                    <hr />
                                    Ya Registrado ? <a href="Login.aspx" >Entre Aquí</a>
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
