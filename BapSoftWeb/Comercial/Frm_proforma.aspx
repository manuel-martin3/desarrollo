<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_proforma.aspx.cs" Inherits="Comercial_Frm_proforma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BRANAT - RRHH</title>
    <link rel="shortcut icon" href="~/images/favicon.ico" />
    <link href="../css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <link href="../css/form.css" rel="stylesheet" type="text/css" />
    <script src="../js/JSfunciones.js" type="text/javascript"></script>
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>       
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <table style="width: 100%;" border="00" cellspacing="00" cellpadding="00">
            <tr>
                <td align="center">
                    <table class="tabla_main" cellspacing="00" cellpadding="00">
                        <tr>
                            <td align="center" class="title">
                                <table cellspacing="00" cellpadding="00" width="100%">
                                    <tr>
                                        <td>
                                            <h3>
                                                RRHH :: REGISTRO DE INCIDENCIAS</h3>
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
                            <td align="center" width="800">
                                <!-- INICIO CONTENIDO -->
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_listar" />
                                        <asp:PostBackTrigger ControlID="btn_new" />
                                        <asp:PostBackTrigger ControlID="btn_save" />
                                        <asp:PostBackTrigger ControlID="btn_delete" />
                                        <asp:PostBackTrigger ControlID="btn_print" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <table class="news_marron" width="600">
                                            <tr>
                                                <td align="right" width="200">
                                                    Fecha:
                                                </td>
                                                <td colspan="2" align="left">
                                                    <asp:TextBox ID="FECHA" runat="server" Width="90px" TabIndex="2" 
                                                        CssClass="input_text"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="FECHA"
                                                        Mask="99/99/9999" InputDirection="RightToLeft" AcceptNegative="Left" DisplayMoney="Left"
                                                        ErrorTooltipEnabled="True" MaskType="Date" UserDateFormat="DayMonthYear" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="FECHA"
                                                        Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td align="left" width="400">
                                                    <asp:Button ID="btn_listar" runat="server" Text="Listar" 
                                                        CssClass="boton_listar" 
                                                        Width="60px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    Trabajador :: DNI:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="DDNNI" runat="server" Width="90px" TabIndex="3" CssClass="input_text"
                                                        AutoPostBack="True" MaxLength="8"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="btn_bustrabajador" runat="server" ImageUrl="~/images/btn_buscar.png"
                                                                Style="width: 16px" OnClick="btn_bustrabajador_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="NOMBS" runat="server" Enabled="False" Width="300px" 
                                                        CssClass="input_text"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    Insidencia:
                                                </td>
                                                <td colspan="3" align="left">
                                                    <asp:TextBox ID="GLOSA" runat="server" TabIndex="6" Width="414px" 
                                                        CssClass="input_text"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;<asp:Button ID="btn_new" runat="server" Text="Nuevo" CssClass="boton_nuevo" />
                                                </td>
                                                <td>
                                                    &nbsp;<asp:Button ID="btn_save" runat="server" Text="Grabar" CssClass="boton_grabar" />
                                                </td>
                                                <td>
                                                    &nbsp;<asp:Button ID="btn_delete" runat="server" Text="Anular" 
                                                        CssClass="boton_anular" />
                                                </td>
                                                <td>
                                                    &nbsp;<asp:Button ID="btn_print" runat="server" Text="Reporte" CssClass="boton_pdf" />
                                                </td>
                                            </tr>
                                        </table>

                                        <br />

                                        <asp:GridView ID="gridicidecia" runat="server" AutoGenerateColumns="False" Width="775px"
                                            Height="1px" GridLines="None" CssClass="mGrid" AllowPaging="True" >
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/edit.png" ShowSelectButton="True">
                                                    <ItemStyle Width="10px" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="DDNNI" HeaderText="DNI">
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NOMBS" HeaderText="Trabajador">
                                                    <ItemStyle Width="300px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GLOSA" HeaderText="Incidencia">
                                                    <ItemStyle Width="300px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EditRowStyle BackColor="#000099" />
                                            <EmptyDataRowStyle BackColor="#000099" />
                                            <PagerStyle CssClass="pgr"></PagerStyle>
                                            <SelectedRowStyle BackColor="#33CCFF" CssClass="SeRoSty" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <!-- Dialog box:: Edit linea info style="display:none;" -->
                                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                                <asp:Panel ID="pnlEditData" runat="server" CssClass="modalPopup" Height="360px" Width="640px"
                                    onmouseup="mueve_divbuscar();" Style="display: none;">
                                    <div style="margin: 0px">
                                        <asp:UpdatePanel runat="server" ID="ModalPanel1" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="640" border="00" cellspacing="00" cellpadding="00">
                                                    <tr class="headPopup">
                                                        <td width="320" align="left">
                                                            &nbsp;&nbsp;BUSCAR &nbsp;<asp:Label ID="txt_titulo" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="320" align="right">
                                                            <asp:ImageButton runat="server" ID="btn_cerrar" ImageUrl="~/images/cerrar-form.png"
                                                                OnClientClick="cerrar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="center" colspan="2" style="height: 290px; padding-top: 10px;">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="bus_name" runat="server" Font-Size="11pt" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" CssClass="input_cbo" Width="100px" ID="cbo_filtro"
                                                                            AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;<asp:TextBox ID="txt_filter" runat="server" onkeydown="enterTo(event,'btnSearch');"
                                                                            Width="200px" CssClass="input_text"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearch" runat="server" CssClass="boton_buscar" Text="Buscar" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                Height="24px" GridLines="None" CssClass="mGrid" PageSize="9">
                                                                <Columns>
                                                                </Columns>
                                                                <EditRowStyle BackColor="#000099" />
                                                                <EmptyDataRowStyle BackColor="#000099" />
                                                                <PagerStyle CssClass="pgr"></PagerStyle>
                                                                <SelectedRowStyle BackColor="#33CCFF" CssClass="SeRoSty" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:Button ID="editBox_OK" runat="server" Text="OK" Width="50px" CssClass="boton_grabar_disabled"
                                            Enabled="False" />
                                    </div>
                                </asp:Panel>

                               <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
                                PopupControlID="pnlEditData" BackgroundCssClass="modalBackground" DropShadow="false" OnCancelScript="cancel()" />

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
