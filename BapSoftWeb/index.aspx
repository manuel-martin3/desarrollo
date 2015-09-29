<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BRANAT</title>
    <link rel="shortcut icon" href="~/images/favicon.ico" />

    <link rel="stylesheet" href="lib/css/global.css" type="text/css" />
    <link rel="stylesheet" href="lib/css/documentation.css" type="text/css" />

    <link href="css/form.css" rel="stylesheet" type="text/css" />
    
    <!-- TABLE STYLES-->
    <link href="Comercial/Listados/assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
     <!-- CUSTOM STYLES-->
    <link href="Comercial/Listados/assets/css/custom.css" rel="stylesheet" />


    <!--[if lte IE 7]>
        <style type="text/css"> body { font-size: 85%; } </style>
    <![endif]-->
    <script type="text/javascript" src="lib/js/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="lib/js/jquery-ui-1.7.2.js"></script>
    <script type="text/javascript" src="lib/js/jquery.layout-latest.js"></script>
    <script type="text/javascript" src="lib/js/global.js"></script>
    <script type="text/javascript">

        var pageLayout;

        $(document).ready(function () {

            // create page layout

            pageLayout = $('body').layout({

                scrollToBookmarkOnLoad: false // handled by custom code so can 'unhide' section first

        , defaults: {
        }

        , north: {
            size: 55
        , spacing_open: 0
        , closable: false
        , resizable: false

        }

        , west: {

            size: 250
        , spacing_closed: 20
        , togglerLength_closed: 140
        , togglerAlign_closed: "top"
        , togglerContent_closed: "<strong>¦¦¦¦<BR>M<BR>E<BR>N<BR>U<BR>¦¦¦¦</strong>"
        , togglerTip_closed: "Open & Pin Contents"
        , sliderTip: "Slide Open Contents"
        , slideTrigger_open: "mouseover"

        }
            });

        });
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- INICIO PANEL SUPERIO >>>> MENU SUPERIOR -->
        <div class="ui-layout-north">                                                                            
                <div class="table-responsive">
                    <table class="table table-striped table-bordered table-hover" width="100%">
                        <tbody>
                        <tr>
                            <td width="8%">
                                <h4>&nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo01.png"/></h4>
                            </td>
                            <td>
                                <h4><asp:Label ID="modulo_emp" runat="server" Text="Label" CssClass="modulo"></asp:Label></h4>
                            </td>
                            <td align="right"  width="5%">
                                <asp:Menu ID="mnu_cerrartodo" runat="server" OnMenuItemClick="mnu_cerrartodo_MenuItemClick" Width="50">
                                    <Items>
                                        <asp:MenuItem ImageUrl="~/images/boton_salir.png" Text="" Value="Logout"></asp:MenuItem>
                                    </Items>
                                </asp:Menu>
                            </td>
                        </tr>
                        </tbody>
                    </table>                                            
                </div>                                                                                                                         
        </div>

        <!-- INICIO PANEL SUPERIO -->
        <!-- INICIO PANEL PRINCIPAL >>>> FORMULARIOS DE PAGINA WEB -->

        <iframe class="ui-layout-center" src="main.aspx" frameborder="0" scrolling="auto"
            id="frameMain" name="frameMain"></iframe>
        <!-- FIN PANEL PRINCIPAL -->
        <!-- INICIO PANEL MENU USUARIO >>>> FORMULARIOS DE PAGINA WEB -->
        <div class="ui-layout-west">

            
            <table runat="server" width="240px" border="0" cellspacing="1" cellpadding="1" >
                <tr>
                    <td align="center" class="title_foto">
                        FOTO
                    </td>
                </tr>
                <tr>
                    <td align="center" style="padding-top: 5px;">
                        <asp:Image ID="foto2" runat="server" Height="160px" Width="140px"/>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;Usuario :&nbsp;&nbsp;<asp:Label ID="lblusuario" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="title_foto" valign="top">                        
                    </td>
                </tr>
            </table>
           
                
            <div class="ui-layout-content">
                <!-- <div id="lateral"> -->
                <div style="background-color: #f0efef; float: left; margin-left: 0px; width: 100%; border: 1px; border-color: #3e3c3c;">
                    <cc1:Accordion ID="accmenuperfil" runat="server" CssClass="accordion" HeaderCssClass="header">
                    </cc1:Accordion>
                </div>
                <!--</div> -->
            </div>
        </div>
        <!-- FIN PANEL MENU USUARIO -->
    </form>
</body>
</html>
