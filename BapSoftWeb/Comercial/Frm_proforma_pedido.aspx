<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_proforma_pedido.aspx.cs" Inherits="tb_rrhh_Frm_proforma_pedido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PROFORMA PEDIDO</title>
    <link rel="shortcut icon" href="~/images/favicon.ico" />
    <link href="../css/ui-lightness/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />        
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <link href="../css/form.css" rel="stylesheet" type="text/css" />
    <script src="../js/JSfunciones.js" type="text/javascript"></script>            
    <style type="text/css">
        .auto-style1 {
            width: 114px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>              
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
        <table runat="server" style="width: 100%;" border="0" cellspacing="00" cellpadding="00">
            <tr>
                <td align="center">
                    <table runat="server" class="tabla_main" cellspacing="00" cellpadding="00">
                        <tr>
                            <td align="center" class="title">
                                <table cellspacing="00" cellpadding="00" width="100%">
                                    <tr>
                                        <td>
                                            <h3>
                                                »» PROFORMA</h3>
                                        </td>
                                        <td align="center" width="30">
                                          <a href="../main.aspx" ><img alt="Cerrar Formulario" 
                                                src="../images/cerrar-form.png" border="0" /></a></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="align-content:center"> <%-- AQUI EMPIEZA EL TD GENERAL DONDE CONTIENE TODO --%>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <Triggers>                                                                                                                                                                                                                                       
                                </Triggers>
                                <ContentTemplate>

                                <table runat="server" width="1100px" border="0" align="center">
                                    <tr>
                                        <td valign="top">
                                            <table id="Table1" runat="server" border="0" style="background:url(../images/prueba.png)repeat-x" > 
                                                <tr>
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_Nuevo" runat="server" ImageUrl="~/images/btn_new.png" 
                                                            style="width: 20px" ToolTip="Nuevo" OnClick="btn_Nuevo_Click" />
                                                    </td> 
                                                     <td width="25px">
                                                        <asp:ImageButton ID="btn_Editar" runat="server" ImageUrl="~/images/btn_edit.png" 
                                                            style="width: 20px" ToolTip="Editar" OnClick="btn_Editar_Click" />
                                                    </td>
                                                     <td width="25px">
                                                        <asp:ImageButton ID="btn_Cancelar" runat="server" ImageUrl="~/images/btn_cancel.png" 
                                                            style="width: 20px" ToolTip="Cancelar" OnClick="btn_Cancelar_Click" />
                                                    </td>                                            
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_grabar" runat="server" ImageUrl="~/images/btn_grabar.png" 
                                                            style="width: 20px" ToolTip="Grabar" OnClick="btn_grabar_Click" />
                                                    </td>
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_Eliminar" runat="server" ImageUrl="~/images/btn_delete.png" 
                                                            style="width: 20px" ToolTip="Eliminar"  />
                                                    </td>
                                                    <td width="10px">
                                                        |
                                                    </td>
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_Imprimir" runat="server" ImageUrl="~/images/btn_imprimir.png" 
                                                            style="width: 20px" ToolTip="Imprimir" OnClick="btn_Imprimir_Click" />
                                                    </td>
                                                    <td style="width:40px">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>                                   
                                            </table>
                                            <table id="Table3" runat="server" border="0"> 
                                                <tr>
                                                    <td width="37px">
                                                        &nbsp;&nbsp;
                                                    </td> 
                                                    <td align="right">
                                                        Proforma:&nbsp;&nbsp;
                                                    </td>                                                                                                                                                             
                                                    <td>
                                                       <asp:TextBox ID="txt_tipdoc" runat="server" CssClass="input_text_enabled" Enabled="False" MaxLength="2" Width="15px"></asp:TextBox>
	                                                   <asp:TextBox ID="txt_serdoc" runat="server" CssClass="input_text_enabled" Enabled="False" MaxLength="4" Width="30px"></asp:TextBox>
	                                                   <asp:TextBox ID="txt_numdoc" runat="server" CssClass="input_text" MaxLength="10" Width="60px"></asp:TextBox>
	                                                   <asp:ImageButton ID="btn_BuscarProforma" runat="server" ImageUrl="~/images/btn_buscar.png" style="width: 15px" ToolTip="Cargar Proforma" OnClick="btn_BuscarProforma_Click" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>                                   
                                            </table>
                                            <asp:Panel runat="server" ID="pnl01" Width="730px">
                                            <fieldset id="Field02" runat="server" style="width:725px;">
                                                <legend class="titus_legend">Datos</legend>
                                                <table runat="server" width="725px" border="0" cellspacing="00" cellpadding="1">
                                                    <tr>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="right" width="100">
                                                            Tip.Venta:&nbsp;&nbsp;</td>
                                                        <td align="left" class="auto-style13">
                                                            <dx:ASPxComboBox ID="cmb_tipventa" runat="server" Theme="BlackGlass" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="cmb_tipventa_SelectedIndexChanged">
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                        <td align="right" class="auto-style10">
                                                            &nbsp;</td>
                                                        <td align="left" class="auto-style9">                                                            
                                                            &nbsp;</td>
                                                       <td align="right" class="auto-style10">
                                                           &nbsp;</td>
                                                        <td align="left" class="auto-style9">                                                            
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>                                                       
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right" width="100">Proforma:&nbsp;&nbsp; </td>
                                                        <td align="left" class="auto-style13">
                                                            <asp:TextBox ID="txt_tipdoc2" runat="server" CssClass="input_text_enabled" Enabled="False" MaxLength="2" Width="15px"></asp:TextBox>
	                                                        <asp:TextBox ID="txt_serdoc2" runat="server" CssClass="input_text_enabled" Enabled="False" MaxLength="4" Width="30px"></asp:TextBox>
	                                                        <asp:TextBox ID="txt_numdoc2" runat="server" CssClass="input_text_enabled" MaxLength="10" Width="60px"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="auto-style10">Fech Doc:&nbsp;&nbsp;</td>
                                                        <td align="left" class="auto-style9">
                                                            <dx:ASPxDateEdit ID="fechdoc" runat="server" Theme="BlackGlass" Width="100px">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                        <td align="right" class="auto-style10">Entregar:&nbsp;&nbsp;</td>
                                                        <td align="left" class="auto-style9">
                                                            <dx:ASPxDateEdit ID="fechentrega" runat="server" Theme="BlackGlass" Width="100px">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                        <td>&nbsp; </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            </td>
                                                        <td align="right">
                                                            Raz.Social:&nbsp;&nbsp;
                                                        </td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="txt_ctacte" runat="server" TabIndex="2" Width="40px" CssClass="input_text"></asp:TextBox>
                                                            <asp:ImageButton ID="btn_buscaRazon" runat="server" ImageUrl="~/images/btn_buscar.png"
                                                                                    ToolTip="Buscar Razon Social" style="width: 15px" OnClick="btn_buscaRazon_Click" />                                                            
                                                            <asp:TextBox ID="txt_ctactename" runat="server" TabIndex="2" Width="195px" CssClass="input_text_enabled" Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td align="right">
                                                            Ruc:&nbsp;&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txt_ruc" runat="server" TabIndex="3" Width="80px" CssClass="input_text"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upPanel" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btn_popup" runat="server" OnClick="btn_popup_Click" TabIndex="24"
                                                                        CssClass="boton_sunat" Width="20px" Text="." Visible="False"/>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            Dir.Entrega:&nbsp;&nbsp;
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="direc_entrega" runat="server" TabIndex="6" Width="350px" CssClass="input_text"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            Rep.Legal:&nbsp;&nbsp;
                                                        </td>
                                                        <td align="left">
                                                             <asp:TextBox ID="replegal_name" runat="server" TabIndex="6" Width="180px" CssClass="input_text"></asp:TextBox>                                                           
                                                        </td>
                                                        <td align="right">
                                                            Dni:&nbsp;&nbsp;</td>
                                                        <td align="left">                                                           
                                                             <asp:TextBox ID="replegal_dni" runat="server" Width="80px"
                                                                CssClass="input_text" MaxLength="10"></asp:TextBox>
                                                        </td>
                                                        <td align="left">                                                           
                                                            &nbsp;</td>
                                                       <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            Cond.Venta:&nbsp;&nbsp;</td>
                                                        <td align="left">                                                           
                                                            <dx:ASPxComboBox ID="cmb_condventaid" runat="server" Width="100px" AutoPostBack="true" Theme="BlackGlass" OnSelectedIndexChanged="cmb_condventaid_SelectedIndexChanged">                                                                
                                                            </dx:ASPxComboBox>
                                                         </td>
                                                       <td align="right">
                                                         Plazo:&nbsp;&nbsp;</td>
                                                       <td align="left">                                                           
                                                            <dx:ASPxComboBox ID="cmb_plazoday" runat="server" Width="80px" Theme="BlackGlass"  AutoPostBack="true" OnSelectedIndexChanged="cmb_plazoday_SelectedIndexChanged">                                                                
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                        <td align="right">
                                                            Moneda:&nbsp;&nbsp;</td>
                                                       <td align="left" class="auto-style13">                                                           
                                                            <dx:ASPxComboBox ID="cmb_moneda" runat="server" Width="80px" Theme="BlackGlass">
                                                                <Items>
                                                                    <dx:ListEditItem Text="S/." Value="S" />
                                                                    <dx:ListEditItem Text="US$" Value="$" />                                                                                                                                 
                                                                </Items>
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style12">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            Vendedor:&nbsp;&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="txt_vendorid" runat="server" TabIndex="2" Width="40px" CssClass="input_text"></asp:TextBox>
                                                            <asp:ImageButton ID="btn_busvendedor" runat="server" ImageUrl="~/images/btn_buscar.png"
                                                                                    ToolTip="Buscar Vendedor" style="width: 15px" OnClick="btn_busvendedor_Click" />
                                                            <asp:TextBox ID="txt_vendorname" runat="server" TabIndex="2" Width="180px" CssClass="input_text_enabled" Enabled="False" EnableTheming="True"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="auto-style11">
                                                            &nbsp;</td>
                                                        <td align="right" class="auto-style10">
                                                            IGV:&nbsp;&nbsp;</td>
                                                        <td align="left">                                                           
                                                            <dx:ASPxComboBox ID="cmb_igv" runat="server" Theme="Office2003Blue" Width="40px" Enabled="False" EnableTheming="False" SelectedIndex="0">
                                                                <Items>
                                                                    <dx:ListEditItem Text="SI" Value="S" Selected="True" />
                                                                    <dx:ListEditItem Text="NO" Value="N" />
                                                                </Items>
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                       <td align="right" class="auto-style6">
                                                            &nbsp;</td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style12">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            Observación:&nbsp;&nbsp;</td>
                                                        <td align="left" class="auto-style13" colspan="4">                                                           
                                                            <asp:TextBox ID="txt_obs" runat="server" TabIndex="2" Width="400px" CssClass="input_text" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                       <td align="left">                                                           
                                                            <asp:Button ID="btn_act01" runat="server" CssClass="boton_next2" TabIndex="24" Text="Siguiente" OnClick="btn_act01_Click" />
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style12">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left" class="auto-style13" colspan="4">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style12">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left" class="auto-style13" colspan="4">
                                                            <asp:HyperLink ID="HyperLink1"  
                                                                NavigateUrl="~/Reportes/CONTRATO_NRO_.docx"
                                                                runat="server" ImageUrl="~/images/btn_imprimir.png" ></asp:HyperLink>
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            </asp:Panel>                                            
                                        </td>
                                        <td rowspan="1" style="vertical-align:top">
                                            <table id="Table2" runat="server" border="0"> 
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>                                                    
                                                </tr>  
                                                 <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>                                                    
                                                </tr>                                             
                                            </table>

                                            <asp:Panel runat="server" ID="pnl03" Width="400px">
                                            <fieldset id="Field03" runat="server" style="width: 400px;">
                                            <legend class="titus_legend">Cronograma de Pagos</legend>
                                            <table runat="server" border="0" id="tblcrono">
                                                <tr>                                                    
                                                     <td align="right">NETO:&nbsp;&nbsp;</td>
                                                     <td align="left">                                                       
                                                         <asp:TextBox ID="imponeto2" runat="server" BackColor="#FFCC00" CssClass="_text2" Enabled="False" Width="80px">0.00</asp:TextBox>
                                                     </td>
                                                     <td align="right">&nbsp;</td>
                                                     <td align="center">                                                       
                                                         &nbsp;</td>
                                                     <td align="right">&nbsp;</td>
                                                     <td align="right">                                                      
                                                         &nbsp;</td>                                                                                             
                                                </tr>                                                
                                                
                                                <tr>
                                                    <td align="right">Medio Pago:&nbsp;&nbsp;</td>
                                                    <td align="left" class="auto-style1">
                                                        <dx:ASPxComboBox ID="cmb_mediopagoid" runat="server" AutoPostBack="true" Theme="BlackGlass" Width="100px" OnSelectedIndexChanged="cmb_mediopagoid_SelectedIndexChanged">
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                    <td align="right">Núm Docs:&nbsp;&nbsp;</td>
                                                    <td align="center">
                                                        <dx:ASPxSpinEdit ID="spe_numdocs" runat="server" AutoPostBack="true" Height="21px" Number="0" Theme="BlackGlass" Width="40px" OnNumberChanged="spe_numdocs_NumberChanged">
                                                        </dx:ASPxSpinEdit>
                                                    </td>
                                                    <td align="right">&nbsp;</td>
                                                    <td align="right">
                                                        <asp:Button ID="btn_ok" runat="server" CssClass="boton_add2" Enabled="false" OnClick="btn_ok_Click" TabIndex="24" Text="OK" />
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="vertical-align:text-top" colspan="6" class="auto-style2">
                                                    <asp:Panel runat="server" ScrollBars="Vertical" Height="170px">
                                                    <asp:GridView ID="gridcronpagos" runat="server" AutoGenerateColumns="False"
                                                        GridLines="None" CssClass="mGrid" PageSize="6" 
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
                                                            <asp:BoundField DataField="num_unico" HeaderText="NumUnico">
                                                                <ItemStyle Width="60px" Wrap="False" />
                                                            </asp:BoundField>
                                                            
                                                            <asp:TemplateField HeaderText="Importe" Visible="true" HeaderStyle-Width="60px" SortExpression="monto">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="monto" runat="server" CssClass="_text" Width="60px" Enabled="False" Text='<%# Eval("monto", "{0:n}") %>'>
                                                                            </asp:TextBox>                                                                                                                                                                                                                           
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="60px" />
                                                            </asp:TemplateField>                                                           

                                                            <asp:TemplateField HeaderText="FechVenc" Visible="true" HeaderStyle-Width="60px" SortExpression="fechven">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="fechven" runat="server" CssClass="_text" Width="60px" Enabled="False" Text='<%# Bind("fechven") %>'>
                                                                    </asp:TextBox>    
                                                                    <cc1:MaskedEditExtender ID="fecha_MaskedEditExtender" runat="server" Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" 
                                                                                            TargetControlID="fechven" UserDateFormat="DayMonthYear"/>
                                                                    <cc1:CalendarExtender ID="fecha_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="fechven">
                                                                    </cc1:CalendarExtender>                                                                   
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="60px" />
                                                            </asp:TemplateField>

                                                           <asp:CommandField ButtonType="Image" EditImageUrl="~/images/edit.png" EditText="Editar" 
                                                            ShowEditButton="True" CancelImageUrl="~/images/btn_cancel.png"  
                                                            CancelText="Cancelar" UpdateImageUrl="~/images/btn-save.png" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="False"
                                                                    CommandName="Delete" ImageUrl="~/images/delete.png" Text="Eliminar" 
                                                                    OnClientClick="javascript:if(!confirm('¿Seguro de Eliminar?'))return false"/>
                                                                    </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <EditRowStyle BackColor="#0033FF" />
                                                        <EmptyDataRowStyle BackColor="#0033FF" />
                                                        <PagerStyle CssClass="pgr"></PagerStyle>
                                                        <SelectedRowStyle BackColor="#3399CC" ForeColor="#ffffff" CssClass="SeRoSty" />
                                                    </asp:GridView>
                                                    </asp:Panel>                                                                                                         
                                                    </td>
                                                </tr>
                                            </table>
                                             </fieldset>
                                            </asp:Panel>
                                        </td>
                                    </tr>                                    
                                </table>                                   
                                <table runat="server" border="0" style="align-content:center">
                                    <tr>
                                        <td align="center">
                                            <asp:Panel runat="server" ID="pnl02" Width="1100px">
                                            <fieldset id="Field04" runat="server">
                                                <legend class="titus_legend">Detalle</legend>
                                                <table runat="server">
                                                    <tr>
                                                        <td align="left">&nbsp;Codigo:</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;Marca:</td>
                                                        <td align="left">&nbsp;Articulo:</td>
                                                        <td align="left">&nbsp;Color:</td>
                                                        <td align="left">&nbsp;Talla:</td>
                                                        <td align="left">&nbsp;Cantidad:</td>
                                                        <td align="left">&nbsp;Prec.Lista:</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>

                                                    <tr style="vertical-align:middle">
                                                        <td align="left" class="auto-style5">                                                
                                                            <asp:TextBox ID="txt_articidold" runat="server" Width="60px" CssClass="_text" MaxLength="7">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="auto-style4">
                                                            <asp:ImageButton ID="btn_buscar" runat="server" ImageUrl="~/images/btn_buscar.png" OnClick="btn_buscar_Click" ToolTip="Buscar Articulo" style="height: 16px" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txt_marcaname" runat="server" Enabled="False" Width="80px" CssClass="input_text_enabled" MaxLength="4">
                                                            </asp:TextBox>   
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txt_articname" runat="server" Enabled="False" Width="200px" CssClass="input_text_enabled" MaxLength="4">
                                                            </asp:TextBox>   
                                                        </td>
                                                        <td align="left">
                                                                        <dx:ASPxComboBox ID="cmb_colorid" runat="server" Width="100px" Theme="BlackGlass">                                                               
                                                                        </dx:ASPxComboBox>
                                                         </td>
                                                        <td align="left">
                                                             <dx:ASPxComboBox ID="cmb_tallaid" runat="server" Width="50px" Theme="BlackGlass">                                                                
                                                             </dx:ASPxComboBox>
                                                        </td>
                                                        <td align="left">
                                                                     <dx:ASPxSpinEdit ID="spe_cantidad" runat="server" Height="21px" Number="0" Width="50px" Theme="BlackGlass">
                                                                     </dx:ASPxSpinEdit> 
                                                                    </td>
                                                        <td align="left">&nbsp;<asp:TextBox ID="txt_precventa_cre_menor" runat="server" Enabled="False" Width="50px"
                                                                            CssClass="input_text_enabled" MaxLength="4"></asp:TextBox>   </td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">
                                                                    <asp:Button ID="btn_add" runat="server" Text="Add" 
                                                                CssClass="boton_add2" TabIndex="24" OnClick="btn_add_Click"/></td>
                                                        <td align="left">                                                
                                                            <asp:Button ID="btn_act02" runat="server" CssClass="boton_next2" TabIndex="24" Text="Siguiente" OnClick="btn_act02_Click" Enabled="true"/>
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align:text-top" colspan="12">
                                                            <asp:Panel runat="server" ID="panel_detalle" ScrollBars="Vertical" Height="200px">
                                                            <asp:GridView ID="griddetalle" runat="server" AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" 
                                                                PagerStyle-CssClass="pgr" OnRowDeleting="griddetalle_RowDeleting" DataKeyNames="articid,colorid,tallaid">
                                                                <Columns>
                                                                    <asp:BoundField DataField="articid" HeaderText="articid" Visible="false" SortExpression="articid">
                                                                    <ItemStyle Wrap="False"  />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="articidold" HeaderText="Codigo">
                                                                    <ItemStyle Width="100px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="marcaid" HeaderText="marcaid" Visible="false" SortExpression="marcaid">
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="marcaname" HeaderText="Marca">
                                                                    <ItemStyle Width="100px" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="articname" HeaderText="Artículo">
                                                                    <ItemStyle Width="300px" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="colorid" HeaderText="colorid" Visible="false" SortExpression="colorid">
                                                                    <ItemStyle Width="80px" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="colorname" HeaderText="Color">
                                                                    <ItemStyle Width="100px" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="tallaid" HeaderText="tallaid" Visible="false" SortExpression="tallaid">
                                                                    <ItemStyle Wrap="False" />
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
                                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.png" ShowDeleteButton="True" />
                                                                </Columns>
                                                                <EditRowStyle BackColor="#0033FF" />
                                                                <EmptyDataRowStyle BackColor="#0033FF" />
                                                                <PagerStyle CssClass="pgr" />
                                                                <SelectedRowStyle BackColor="#3399CC" CssClass="SeRoSty" ForeColor="#ffffff" />
                                                            </asp:GridView>
                                                            </asp:Panel>                                               
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            </asp:Panel>
                                
                                            <table runat="server" cellpadding="2" cellspacing="0" width="1100px">
                                                <tr>
                                                    <td align="left">
                                                      <asp:Panel ID="pnlpie" Enabled="false" runat="server">
                                                        <fieldset id="Field05" runat="server" style="width: 500px;">
                                                            <legend class="titus_legend">Gerencia</legend>
                                                            <table cellpadding="2" cellspacing="0">
                                                                <tr>
                                                                    <td rowspan="2" align="left">
                                                                        <asp:RadioButtonList ID="aprob_status" runat="server" CssClass="input_cbo">
                                                                            <asp:ListItem Value="0">Aprobado</asp:ListItem>
                                                                            <asp:ListItem Value="1">Desaprobado</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                    <td rowspan="2">
                                                                        <asp:TextBox ID="aprob_obs" runat="server" Width="180px" Height="40px"
                                                                            CssClass="input_text" MaxLength="4" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                    <td width="80px" align="right">FechAprob:&nbsp;&nbsp;</td>
                                                                    <td width="80px" align="left">
                                                                        <dx:ASPxDateEdit ID="aprob_fech" runat="server" Theme="BlackGlass" Width="100px">
                                                                        </dx:ASPxDateEdit>
                                                                    </td>
                                     
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>                                      
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                      </asp:Panel>
                                                    </td>                                        
                                                    <td>
                                                        <table cellpadding="2" cellspacing="0" width="500px">
                                                                <tr>                                                       
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td width="80px"><asp:TextBox ID="txt_impobruto" runat="server" Enabled="False" Width="80px"
                                                                            CssClass="_text2" BackColor="#FFCC00">0.00</asp:TextBox>   </td>
                                                                    <td width="80px"><asp:TextBox ID="txt_tasadescto" runat="server" Enabled="False" Width="80px"
                                                                            CssClass="_text2" BackColor="#FFCC00">0.00</asp:TextBox>   </td>                                     
                                                                    <td width="80px"><asp:TextBox ID="txt_imponeto" runat="server" Enabled="False" Width="80px"
                                                                            CssClass="_text2" BackColor="#FFCC00">0.00</asp:TextBox>   </td>
                                     
                                                                    <td>&nbsp;</td>
                                     
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>Vta.Prec.Lista:</td>
                                                                    <td>%Dcscto:</td>                                      
                                                                    <td>VtaConDscto:</td>                                      
                                                                    <td>&nbsp;</td>                                      
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>                                      
                                                                    <td>&nbsp;</td>                                      
                                                                    <td>&nbsp;</td>                                      
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>
                                                                    <td>&nbsp;</td>                                      
                                                                    <td>&nbsp;</td>                                      
                                                                    <td>&nbsp;</td>                                      
                                                                </tr>
                                                            </table>
                                                    </td>
                                                </tr>
                                            </table>    
                                       </td>
                                   </tr>
                                </table>                     
                                </ContentTemplate>
                                </asp:UpdatePanel>


                                <!-- POPUP DE IMAGEN CAPTCHA -->                                
                                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none;"/>                                
                                <asp:Panel ID="pnlEditData" runat="server" CssClass="modalPopup" Height="120px" Width="340px"
                                    onmouseup="mueve_divbuscar();" Style="display: none;">

                                    <div style="margin: 0px">
                                        <asp:UpdatePanel runat="server" ID="ModalPanel1" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="340" border="00" cellspacing="00" cellpadding="00">
                                                    <tr class="headPopup">
                                                        <td width="320" align="left">
                                                            &nbsp;&nbsp;»» &nbsp;<asp:Label ID="txt" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="320" align="right">
                                                            <asp:ImageButton runat="server" ID="btn_cerrar" ImageUrl="~/images/cerrar-form.png"
                                                                OnClientClick="cerrar();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="center" colspan="2" style="padding-top: 5px;">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:Image ID="ImagenSunat" runat="server" Width="80px" Height="50"/>
                                                                    </td>
                                                                    <td rowspan="2">
                                                                        <asp:Button ID="btnRefresh" runat="server" CssClass="boton_refresh" OnClick="btnRefresh_Click" Text="." Width="20px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td align="center"><asp:TextBox ID="txtimgcaptcha" runat="server" Width="50px" Height="20px"
                                                                CssClass="_text" MaxLength="4" Font-Bold="True" Font-Size="12pt"></asp:TextBox>   

                                                                    </td>
                                                                    <td rowspan="2">
                                                                        <asp:Button ID="btn_sgte" runat="server" CssClass="boton_none" OnClick="btn_sgte_Click" Text="Sgte" />
                                                                    </td>
                                                                </tr>                                                               
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </asp:Panel>                                                               
                                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                    TargetControlID="hiddenTargetControlForModalPopup"
                                    PopupControlID="pnlEditData" BackgroundCssClass="modalBackground" DropShadow="false"
                                    OkControlID="btn_sgte" OnOkScript="ok()" OnCancelScript="cancel()" />                                                                                        
                                <!-- FIN CONTENIDO -->



                                  <!-- Dialog box:: Edit linea info style="display:none;" -->
                                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup2" Style="display: none" />
                                <asp:Panel ID="pnlEditData1" runat="server" CssClass="modalPopup" Height="370px" Width="640px"
                                    onmouseup="mueve_divbuscar();" Style="display: none;">
                                    <div style="margin: 0px">
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel2" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table width="640" border="00" cellspacing="00" cellpadding="00">
                                                    <tr class="headPopup">
                                                        <td width="320" align="left">
                                                            &nbsp;&nbsp;BUSCAR &nbsp;<asp:Label ID="txt_titulo" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="320" align="right">
                                                            <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/images/cerrar-form.png"
                                                                OnClientClick="cerrar2();" />
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
                                                                            AutoPostBack="True" OnSelectedIndexChanged="cbo_filtro_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;<asp:TextBox ID="txt_filter" runat="server" onkeydown="enterTo(event,'btnSearch');"
                                                                            Width="200px" CssClass="input_text"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearch" runat="server" CssClass="boton_search" OnClick="btnSearch_Click"
                                                                            Text="Buscar" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                Height="24px" GridLines="None" CssClass="mGrid" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                OnRowCreated="GridView_OnRowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                                                PageSize="9">
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
                                    </div>
                                </asp:Panel>
                                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="hiddenTargetControlForModalPopup2"
                                    PopupControlID="pnlEditData1" BackgroundCssClass="modalBackground" DropShadow="false"/>
                                <!-- FIN    CONTENIDO -->
                             
                            


                            </td>
                        </tr>   
                        <tr>
                            <td>&nbsp;</td>
                        </tr> 
                        <tr>
                            <td>&nbsp;</td>
                        </tr>                    

                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
