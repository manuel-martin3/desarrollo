<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_Evaluacion.aspx.cs" Inherits="tb_rrhh_Frm_evaluacion" %>
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
                            <td align="center" class="titulo">
                                <table cellspacing="00" cellpadding="00" width="100%">
                                    <tr>
                                        <td>
                                            <h3>                                                
                                                <asp:Label ID="Label9" runat="server" Text="»» FORMATO DE EVALUACION CREDITICIA" ForeColor="White"></asp:Label>
                                            </h3>
                                        </td>
                                        <td align="center" width="30">
                                          <a href="../main.aspx" ><img alt="Cerrar Formulario" 
                                                src="../images/cerrar-form5.png" border="0" /></a></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="align-content:center"> <%-- AQUI EMPIEZA EL TD GENERAL DONDE CONTIENE TODO --%>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                 <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_Imprimir" />
                                </Triggers>
                                <ContentTemplate>

                                <table runat="server" width="735px" border="0" align="center">
                                    <tr>
                                        <td>
                                            <table id="Table1" runat="server" border="0" style="background:url(../images/prueba.png)repeat-x" width="100%"> 
                                                <tr>
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_Nuevo" runat="server" ImageUrl="~/images/btn_new.png" 
                                                            style="width: 20px" ToolTip="Nuevo" OnClick="btn_Nuevo_Click" Visible="False" />
                                                    </td>                                                      
                                                     <td width="25px">
                                                        <asp:ImageButton ID="btn_Cancelar" runat="server" ImageUrl="~/images/btn_cancel.png" 
                                                            style="width: 20px" ToolTip="Regresar" OnClick="btn_Cancelar_Click" />
                                                    </td>                                            
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_grabar" runat="server" ImageUrl="~/images/btn_grabar.png" 
                                                            style="width: 20px" ToolTip="Grabar" OnClick="btn_grabar_Click" />
                                                    </td>                                                 
                                                    <td width="10px">
                                                        <asp:Label ID="Label7" runat="server" Text="|" Visible="false"></asp:Label>
                                                    </td>
                                                    <td width="25px">
                                                        <asp:ImageButton ID="btn_Imprimir" runat="server" ImageUrl="~/images/btn_imprimir.png" 
                                                            style="width: 20px" ToolTip="Imprimir" OnClick="btn_Imprimir_Click" Visible="False" />
                                                    </td>
                                                    <td style="width:40px">&nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text="|" Visible="false"></asp:Label>
                                                    </td>
                                                    <td style="width:25px">
                                                        <asp:ImageButton ID="btn_first" runat="server" ImageUrl="~/images/go-first_g.png" OnClick="btn_first_Click" style="width: 20px" ToolTip="Primero" Height="20px" Visible="False" />
                                                    </td>
                                                    <td style="width:25px">
                                                        <asp:ImageButton ID="btn_previous" runat="server" ImageUrl="~/images/go-previous_g.png" OnClick="btn_previous_Click" style="width: 20px" ToolTip="Anterior" Height="20px" Width="20px" Visible="False" />
                                                    </td>
                                                    <td style="width:25px">
                                                        <asp:ImageButton ID="btn_next" runat="server" ImageUrl="~/images/go-next_g.png" OnClick="btn_next_Click" style="width: 20px" ToolTip="Siguiente" Height="20px" Width="20px" Visible="False" />
                                                    </td>
                                                    <td style="width:25px">
                                                        <asp:ImageButton ID="btn_last" runat="server" ImageUrl="~/images/go-last_g.png" OnClick="btn_last_Click" style="width: 20px" ToolTip="Ultimo" Height="20px" Visible="False" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td align="right">
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="input_text" Width="40px" Visible="False"></asp:TextBox>
                                                    </td>
                                                    <td style="width:25px">
                                                        <asp:ImageButton ID="btn_buscaRazon" runat="server" ImageUrl="~/images/btn_buscar.png" style="width: 15px" ToolTip="Buscar" Visible="False" />
                                                    </td>
                                                </tr>                                   
                                            </table>
                                            <table id="Table3" runat="server" border="0" width="100%"> 
                                                <tr style="font-weight:bold">
                                                    <td width="37px">&nbsp;</td>
                                                    <td align="center">FORMATO DE EVALUACION CREDITICIA DEL CLIENTE</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr style="font-weight:bold">
                                                    <td width="100px" align="left">
                                                        <asp:Label ID="Label16" runat="server" BackColor="#3399FF" ForeColor="White" Text="Item: "></asp:Label>
                                                        <asp:Label ID="lblitem" runat="server" BackColor="#3399FF" ForeColor="White"></asp:Label>
                                                    </td>
                                                    <td align="center">AREA DE VENTAS HORIZONTALES</td>
                                                    <td align="right">
                                                        <asp:Label ID="Label21" runat="server" BackColor="#3399FF" ForeColor="White" Text="Proforma: "></asp:Label>
                                                        <asp:Label ID="lblnumdoc" runat="server" BackColor="#3399FF" ForeColor="White"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                                                                                                                   
                                                
                                            <table runat="server" width="725px" border="0" cellspacing="00" cellpadding="1">
                                                    <tr>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="left">
                                                             &nbsp;</td>
                                                        <td align="right">
                                                            &nbsp;</td>
                                                        <td align="left">                                                           
                                                             &nbsp;</td>
                                                        <td align="left">                                                           
                                                            &nbsp;</td>
                                                       <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                        <td align="right">1.-&nbsp;</td>
                                                        <td align="left" colspan="7" style="background:url(../images/title1_2.gif)">
                                                            &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="CONDICION JURIDICA DEL CLIENTE" ForeColor="White">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            <dx:ASPxRadioButtonList ID="es_persjuridica" runat="server" RepeatLayout="OrderedList" Theme="MetropolisBlue" ValueType="System.Boolean">
                                                                <Items>
                                                                    <dx:ListEditItem Text="Persona Natural" Value="False" />
                                                                    <dx:ListEditItem Text="Persona Juridica" Value="True" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                            </dx:ASPxRadioButtonList>
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                        <td align="right">2.-&nbsp;</td>
                                                        <td align="left" colspan="7" style="background:url(../images/title1_2.gif)">
                                                            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="DOCUMENTOS PRESENTADOS POR EL CLIENTE" ForeColor="White"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">
                                                            <dx:ASPxCheckBox ID="copia_constitucionempresa" runat="server" Text="Const. de la Empresa" Theme="MetropolisBlue">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                        <td align="left">
                                                            <dx:ASPxCheckBox ID="copia_dni" runat="server" Text="DNI" Theme="MetropolisBlue">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                        <td align="left">
                                                            <dx:ASPxCheckBox ID="titulo_localcom" runat="server" Text="Titulo de Propiedad" Theme="MetropolisBlue">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left" >&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                     <tr>
                                                         <td align="right">&nbsp;</td>
                                                         <td align="right">&nbsp;</td>
                                                         <td align="left">
                                                             <dx:ASPxCheckBox ID="copia_ruc" runat="server" Text="RUC" Theme="MetropolisBlue">
                                                             </dx:ASPxCheckBox>
                                                         </td>
                                                         <td align="left">
                                                             <dx:ASPxCheckBox ID="lic_func" runat="server" Text="Licencia de Funcionamiento" Theme="MetropolisBlue">
                                                             </dx:ASPxCheckBox>
                                                         </td>
                                                         <td align="left">
                                                             <dx:ASPxCheckBox ID="contra_localcom" runat="server" Text="Contrato de Local" Theme="MetropolisBlue">
                                                             </dx:ASPxCheckBox>
                                                         </td>
                                                         <td align="right">
                                                             <dx:ASPxCheckBox ID="recibo_agualuz" runat="server" Text="Recibo Agua o Luz" Theme="MetropolisBlue">
                                                             </dx:ASPxCheckBox>
                                                         </td>
                                                         <td align="left" >&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                        <td align="right">3.-&nbsp;</td>
                                                        <td align="left" colspan="2" style="background:url(../images/title1_2.gif)">
                                                            &nbsp;&nbsp;<asp:Label ID="Label18" runat="server" ForeColor="White" Text="TIENE PROTESTOS DE LETRA ?"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            »&nbsp;</td>
                                                         <td align="left" style="background:url(../images/title1_2.gif)" colspan="4">
                                                            &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" ForeColor="White" Text="TIENE INCUMPLIMIENTO DE PAGOS ?"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">
                                                            <dx:ASPxRadioButtonList ID="tiene_letraprotestada" runat="server" AutoPostBack="True" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean" OnSelectedIndexChanged="tiene_letraprotestada_SelectedIndexChanged">
                                                                <Items>
                                                                    <dx:ListEditItem Text="SI" Value="True" />
                                                                    <dx:ListEditItem Text="NO" Value="False" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                            </dx:ASPxRadioButtonList>
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            <dx:ASPxRadioButtonList ID="tiene_morosidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tiene_morosidad_SelectedIndexChanged" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean">
                                                                <Items>
                                                                    <dx:ListEditItem Text="SI" Value="True" />
                                                                    <dx:ListEditItem Text="NO" Value="False" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                            </dx:ASPxRadioButtonList>
                                                        </td>
                                                        <td align="left" >&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                     <tr style="font-weight:bold">
                                                        <td align="right">4.-&nbsp;</td>
                                                        <td align="left" colspan="7" style="background:url(../images/title1_2.gif)"> 
                                                            &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" ForeColor="White" Text="PRESENTA ANTECEDENTES INFOCORP ?"></asp:Label>
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">
                                                            <dx:ASPxRadioButtonList ID="moroso_infocorp" runat="server" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean" AutoPostBack="True" OnSelectedIndexChanged="moroso_infocorp_SelectedIndexChanged">
                                                                <Items>
                                                                    <dx:ListEditItem Text="SI" Value="True" />
                                                                    <dx:ListEditItem Text="NO" Value="False" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                            </dx:ASPxRadioButtonList>
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                         <td align="right">5.-&nbsp;</td>                                                         
                                                         <td align="left" colspan="2" style="background:url(../images/title1_2.gif)"> 
                                                            &nbsp;&nbsp;<asp:Label ID="Label12" runat="server" ForeColor="White" Text="REFERENCIAS COMERCIALES">
                                                            </asp:Label>
                                                             <br />
                                                         </td>
                                                         <td align="right">6.-&nbsp;</td>
                                                         <td align="left" colspan="4" style="background:url(../images/title1_2.gif)">
                                                            &nbsp;&nbsp;<asp:Label ID="Label6" runat="server" ForeColor="White" Text="REFERENCIAS BANCARIAS">
                                                            </asp:Label>
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right"> 
                                                            &nbsp;</td>
                                                         <td align="left">
                                                             <dx:ASPxComboBox ID="refe_comerc" runat="server" AnimationType="Fade" EnableTheming="True" Theme="MetropolisBlue" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="refe_comerc_SelectedIndexChanged">
                                                                 <Items>
                                                                     <dx:ListEditItem Text="BUENO" Value="B" />
                                                                     <dx:ListEditItem Text="REGULAR" Value="R" />
                                                                     <dx:ListEditItem Text="MALA" Value="M" />
                                                                 </Items>
                                                             </dx:ASPxComboBox>
                                                        </td>
                                                         <td align="right">&nbsp;</td>
                                                         <td align="left" colspan="2">
                                                             <dx:ASPxComboBox ID="refe_banca" runat="server" Theme="MetropolisBlue" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="refe_banca_SelectedIndexChanged">
                                                                 <Items>
                                                                     <dx:ListEditItem Text="BUENO" Value="B" />
                                                                     <dx:ListEditItem Text="REGULAR" Value="R" />
                                                                     <dx:ListEditItem Text="MALA" Value="M" />
                                                                 </Items>
                                                             </dx:ASPxComboBox>
                                                        </td>
                                                         <td align="left" >&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                    </tr>
                                                     <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left" colspan="2">
                                                            &nbsp;</td>
                                                         <td align="right">&nbsp;</td>
                                                         <td align="left">&nbsp;</td>
                                                         <td align="right">&nbsp;</td>
                                                         <td align="left" >&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                        <td align="right">7.-&nbsp;</td>
                                                        <td align="left" colspan="2" style="background:url(../images/title1_2.gif)">&nbsp;&nbsp;<asp:Label ID="Label19" runat="server" ForeColor="White" Text="TIENE BIENES MUEBLES ?"></asp:Label>
                                                        </td>
                                                        <td align="right">»&nbsp;&nbsp;</td>
                                                        <td align="left" colspan="4" style="background:url(../images/title1_2.gif)">&nbsp;&nbsp;<asp:Label ID="Label20" runat="server" ForeColor="White" Text="TIENE BIENES INMUEBLES ?"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style5"></td>
                                                        <td align="right" class="auto-style5"></td>
                                                        <td align="left" class="auto-style5">
                                                            <dx:ASPxRadioButtonList ID="bienes_bienmueble" runat="server" AutoPostBack="True" OnSelectedIndexChanged="bienes_bienmueble_SelectedIndexChanged" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean">
                                                                <Items>
                                                                    <dx:ListEditItem Text="SI" Value="True" />
                                                                    <dx:ListEditItem Text="NO" Value="False" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                            </dx:ASPxRadioButtonList>
                                                        </td>
                                                        <td align="left" class="auto-style5"></td>
                                                        <td align="left" class="auto-style5" colspan="2">
                                                            <dx:ASPxRadioButtonList ID="bienes_inmuebles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="bienes_inmuebles_SelectedIndexChanged" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean">
                                                                <Items>
                                                                    <dx:ListEditItem Text="SI" Value="True" />
                                                                    <dx:ListEditItem Text="NO" Value="False" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                            </dx:ASPxRadioButtonList>
                                                        </td>
                                                        <td align="left" class="auto-style5"></td>
                                                        <td class="auto-style5"></td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                        <td align="right" class="auto-style4"></td>
                                                        <td align="left" class="auto-style4" colspan="2">
                                                            <asp:Label ID="Label17" runat="server" BackColor="#3399FF" Font-Size="Small" ForeColor="White" Text="Puntaje:"></asp:Label>
                                                            <asp:Label ID="lblpuntos" runat="server" Font-Size="Small" ForeColor="#3399FF" Text="0"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style4"></td>
                                                        <td align="left" class="auto-style4"></td>
                                                        <td align="right" class="auto-style4"></td>
                                                        <td align="left" class="auto-style4"></td>
                                                        <td class="auto-style4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="font-weight:bold">»&nbsp;</td>
                                                        <td align="left" colspan="3" style="background:url(../images/title3.gif);font-weight:bold">
                                                            &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" ForeColor="White" Text="OPINION AREA DE VENTAS HORIZONTALES"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="4" rowspan="5">
                                                            <asp:Panel ID="pnlGeren01" runat="server">
                                                                <table id="tb01" runat="server" border="0" width="100%">
                                                                    <tr>
                                                                        <td class="auto-style3"></td>
                                                                        <td style="background:url(../images/title3.gif);font-weight:bold">
                                                                            <asp:Label ID="Label14" runat="server" Text="APROBACION GERENCIA GENERAL" ForeColor="White"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td class="auto-style3"></td>
                                                                        <td>
                                                                            <dx:ASPxRadioButtonList ID="aprob_gerencial" runat="server" RepeatLayout="OrderedList" Theme="iOS">
                                                                                <Items>
                                                                                    <dx:ListEditItem Text="SI" Value="1" />
                                                                                    <dx:ListEditItem Text="NO" Value="0" />
                                                                                </Items>
                                                                                <Border BorderStyle="None" />
                                                                            </dx:ASPxRadioButtonList>
                                                                         </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td class="auto-style3"></td>
                                                                        <td style="background:url(../images/title3.gif);font-weight:bold">
                                                                            <asp:Label ID="Label15" runat="server" ForeColor="White" Text="OBSERVACIÓNES"></asp:Label>
                                                                         </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td class="auto-style3"></td>
                                                                        <td rowspan="2">
                                                                            <asp:TextBox ID="obs_gerencial" runat="server" CssClass="input_text" TabIndex="2" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                                         </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td class="auto-style3"></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style1">&nbsp; &nbsp;</td>
                                                        <td align="right" class="auto-style1"></td>
                                                        <td align="left" class="auto-style1">
                                                            <dx:ASPxComboBox ID="eval_cxcob" runat="server" Theme="MetropolisBlue" Width="200px">
                                                                <Items>
                                                                    <dx:ListEditItem Text="Cliente Aceptable" Value="CA" />
                                                                    <dx:ListEditItem Text="Cliente No Aceptable" Value="CN" />
                                                                    <dx:ListEditItem Text="Cliente Dudoso" Value="CD" />
                                                                </Items>
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                        <td align="right" class="auto-style1"></td>
                                                    </tr>
                                                    <tr style="font-weight:bold">
                                                        <td align="right">»&nbsp;</td>
                                                        <td align="left" colspan="2" style="background:url(../images/title3.gif)">
                                                            &nbsp;&nbsp;<asp:Label ID="Label13" runat="server" ForeColor="White" Text="OTROS COMENTARIOS"></asp:Label>
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left" colspan="2" rowspan="2">
                                                            <asp:TextBox ID="obs_cxcob" runat="server" CssClass="input_text" TabIndex="2" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left" >&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                                                                      
                                        </td>                                   
                                    </tr>                                    
                                </table>                                   
                                                  
                                </ContentTemplate>
                                </asp:UpdatePanel>

        

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
                                                                            AutoPostBack="True" >
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;<asp:TextBox ID="txt_filter" runat="server" onkeydown="enterTo(event,'btnSearch');"
                                                                            Width="200px" CssClass="input_text"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnSearch" runat="server" CssClass="boton_search"
                                                                            Text="Buscar" />
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                Height="24px" GridLines="None" CssClass="mGrid"
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
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
