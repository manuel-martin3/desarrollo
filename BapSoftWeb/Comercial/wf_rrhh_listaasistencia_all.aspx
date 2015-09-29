<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wf_rrhh_listaasistencia_all.aspx.cs" Inherits="tb_rrhh_wf_rrhh_listaasistencia_all" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%--<%@ Register Src="~/Control/DateTimePicker.ascx" TagName="DateTimePicker" TagPrefix="DateTime" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BRANAT - RRHH</title>
    <link rel="shortcut icon" href="~/images/favicon.ico" />
    <link href="../css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <link href="../css/form.css" rel="stylesheet" type="text/css" />
    <script src="../js/JSfunciones.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%;" border="00" cellspacing="00" cellpadding="00">
            <tr>
                <td align='center' >
                    <table class="tabla_main" cellspacing="00" cellpadding="00">
                        <tr>
                            <td align="center" class="title">
                                <table cellspacing="00" cellpadding="00" width="100%">
                                    <tr>
                                        <td>
                                            <h3>
                                                RRHH :: LISTADO DE ASISTENCIA</h3>
                                        </td>
                                        <td align="center" width="30">
                                            <a href="../main.aspx">
                                                <img alt="Cerrar Formulario" src="../images/cerrar-form.png" border="0" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td align="center" width="1100px">
                                <!-- INICIO CONTENIDO -->
                                <fieldset id="Fieldset1" runat="server" style="width: 500px;">
                                    <legend class="titus_legend">Datos Generales</legend>
                                    <table class="news_marron" width="450">
                                        <tr align="left">
                                            <td>
                                                Del:
                                            </td>
                                            <td>                                                
                                                <dx:ASPxDateEdit ID="FECH1" runat="server" Width="100px" Theme="Office2003Blue">
                                                </dx:ASPxDateEdit>
                                            </td>
                                            <td>
                                                Al:
                                            </td>
                                            <td>                                                
                                                <dx:ASPxDateEdit ID="FECH2" runat="server" Theme="Office2003Blue" Width="100px">
                                                </dx:ASPxDateEdit>
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td>
                                                Area matriz:
                                            </td>
                                            <td class="style8" colspan="3">
                                                <asp:DropDownList ID="IDCC1" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="IDCC1_SelectedIndexChanged"
                                                    CssClass="input_cbo">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td>
                                                Area hija:
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="IDCC2" runat="server" Width="300px" CssClass="input_cbo">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td>
                                                Trabajador:
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="NOMBS" runat="server" Width="300px" CssClass="input_text"></asp:TextBox>
                                            </td>
                                        </tr>                                        
                                    </table>
                                </fieldset>
                                <table cellpadding="0" cellspacing="0" class="style6">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnListar" runat="server" Text="Listar" CssClass="boton_listar" 
                                                Width="69px" OnClick="btnListar_Click" />
                                            &nbsp;<asp:Button ID="btnProcesar" runat="server" Text="Procesar" 
                                                CssClass="boton_proceso" OnClick="btnProcesar_Click"
                                                OnClientClick="javascript:if(!confirm('¿Seguro de Procesar?'))return false"/>
                                            &nbsp;<asp:Button ID="btnExcel" runat="server" Text="Horizontal" 
                                                CssClass="boton_excel" OnClick="btnExcel_Click" />
                                            &nbsp;<asp:Button ID="btnExcel2" runat="server" Text="Vertical" 
                                                CssClass="boton_excel" OnClick="btnExcel2_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                           <asp:Button ID="btnExcel3" runat="server" Text="Reporte" 
                                                CssClass="boton_excel" OnClick="btnExcel3_Click"/>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            OnPageIndexChanging="GridView1_PageIndexChanging" GridLines="None" CssClass="mGrid"
                                            PagerStyle-CssClass="pgr" OnRowCreated="GridView_OnRowCreated" 
                                            Width="1000px">
                                            <Columns>
                                                <asp:BoundField DataField="NBCC2" HeaderText="Área">
                                                    <ItemStyle Font-Names="Arial Narrow" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DDNNI" HeaderText="DNI">
                                                    <%-- <ItemStyle Width="80px" /> --%>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NOMBS" HeaderText="Trabajador">
                                                    <ItemStyle Font-Names="Arial Narrow" Width="300px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NBDIA" HeaderText="Día">
                                                    <ItemStyle Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FECHA" DataFormatString="{0:dd-MM}" HeaderText="Fecha" />
                                                <asp:BoundField DataField="MARCA" HeaderText="Marcación">
                                                    <ItemStyle Width="150px" Wrap="True" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="glosa" HeaderText="Observación">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rango" HeaderText="Rango">
                                                    <ItemStyle Width="220px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EditRowStyle BackColor="#000099" />
                                            <EmptyDataRowStyle BackColor="#000099" />
                                            <PagerStyle CssClass="pgr"></PagerStyle>
                                            <SelectedRowStyle BackColor="#003300" CssClass="SeRoSty" />
                                        </asp:GridView>

                                        
                                        
                                        <!-- Ponemos un DataGridView del Devexpress -->
                                        <dx:ASPxGridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            EnableTheming="True" Width="1000px"  
                                            OnPageIndexChanged="GridView2_PageIndexChanged" 
                                            Styles-Header-BackgroundImage-ImageUrl ="../images/title.gif"
                                            Styles-Header-ForeColor ="White"
                                            Styles-Header-Font-Bold ="true"                                             
                                            CssClass="mGrid" 
                                            StylesPager-Pager-CssClass="pgr" OnHtmlRowCreated="GridView2_HtmlRowCreated"
                                             >                                            
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Area" VisibleIndex="0" FieldName="NBCC2" Width="100px"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="true">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DNI" VisibleIndex="1" FieldName="DDNNI">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Trabajador" VisibleIndex="2" FieldName="NOMBS" Width="300px">
                                                </dx:GridViewDataTextColumn >
                                                <dx:GridViewDataTextColumn Caption="Dia" VisibleIndex="3" FieldName="NBDIA" Width="30px"
                                                    HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="true">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Fecha" VisibleIndex="4" FieldName="FECHA" UnboundType="DateTime">                         
                                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Marcación" VisibleIndex="5" FieldName="MARCA" Width="150px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Observación" VisibleIndex="6" FieldName="GLOSA" Width="180px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Rango" VisibleIndex="7" FieldName="rango" Width="220px">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>





                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!-- FIN CONTENIDO -->
                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
