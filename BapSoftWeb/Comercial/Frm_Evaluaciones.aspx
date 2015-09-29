<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_Evaluaciones.aspx.cs" Inherits="Comercial_Frm_Evaluaciones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Free Bootstrap Admin Template : Binary Admin</title>
	<!-- BOOTSTRAP STYLES-->
    <link href="Listados/assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="Listados/assets/css/font-awesome.css" rel="stylesheet" />
     <!-- MORRIS CHART STYLES-->

    <!--STYLE DATEPICKER-->   
    <link rel="stylesheet" href="Listados/assets/css/datepicker/bootstrap.min.css" />
    <link rel="stylesheet" href="Listados/assets/css/datepicker/bootstrap-datepicker.min.css" />
    <!--FIN-->

    <!-- CUSTOM STYLES-->
    <link href="Listados/assets/css/custom.css" rel="stylesheet" />
     <!-- GOOGLE FONTS-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
     <!-- TABLE STYLES-->
    <link href="Listados/assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- DATEPICKER-->
    <!-- DATE PICKER -->
    <link href="Listados/assets/datepicker/css/jquery-ui.css" rel="stylesheet">
    <!-- DATE PICKER -->
    <script src="Listados/assets/datepicker/js/jquery.js"></script>    
    <script src="Listados/assets/datepicker/js/jquery-ui.js"></script>
    <script src="Listados/assets/datepicker/js/jquery.ui.datepicker-es.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker({
                showOn: "button",
                showButtonPanel: true,
                buttonImage: "assets/datepicker/images/calendar.gif",
                minDate: 0,
                /*maxDate: "+1M +10D",*/
                buttonImageOnly: true,
                buttonText: "Seleccionar fecha"
            });
        });

    </script>

    <style>
        /*body{
        font: 62.5% "Trebuchet MS", sans-serif;
        margin: 50px;
    }*/
        .demoHeaders {
            margin-top: 2em;
        }

        #dialog-link {
            padding: .4em 1em .4em 20px;
            text-decoration: none;
            position: relative;
        }

            #dialog-link span.ui-icon {
                margin: 0 5px 0 0;
                position: absolute;
                left: .2em;
                top: 50%;
                margin-top: -8px;
            }

        #icons {
            margin: 0;
            padding: 0;
        }

            #icons li {
                margin: 2px;
                position: relative;
                padding: 4px 0;
                cursor: pointer;
                float: left;
                list-style: none;
            }

            #icons span.ui-icon {
                float: left;
                margin: 0 4px;
            }

        .fakewindowcontain .ui-widget-overlay {
            position: absolute;
        }

        select {
            width: 200px;
        }
    </style>
   
</head>
<body>
     <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--  <div id="page-wrapper" >--%>
        <div id="page-inner">     
            <div class="row">
                <div class="col-md-12">
                    <h2>FORMATO DE EVALUACION CREDITICIA - <asp:Label ID="lblnumdoc" runat="server">
                        </asp:Label><asp:Label ID="lblitem" runat="server" Visible="false"></asp:Label>    
                    </h2>                                                                    
                </div>                
            </div>           
            <!-- /. ROW  -->
            <hr />
            
            <div class="row">

                <div class="col-md-4">
                    <!-- Advanced Tables -->
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            I. CONDICION JURIDICA DEL CLIENTE
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">                                   
                                    <tbody>
                                        <tr>
                                            <td>
                                                <dx:ASPxRadioButtonList ID="es_persjuridica" runat="server" RepeatLayout="OrderedList" Theme="MetropolisBlue" ValueType="System.Boolean">
                                                                <Items>
                                                                    <dx:ListEditItem Text="Persona Natural" Value="False" />
                                                                    <dx:ListEditItem Text="Persona Juridica" Value="True" />
                                                                </Items>
                                                                <Border BorderStyle="None" />
                                                </dx:ASPxRadioButtonList>
                                            </td>        
                                        </tr>                                                                   
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!--End Advanced Tables -->                  
                </div>

                <div class="col-md-8">
                     <div class="panel panel-primary">
                        <div class="panel-heading">
                            II. DOCUMENTOS PRESENTADOS POR EL CLIENTE
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                 <table class="table table-striped table-bordered table-hover col-md-12">                                   
                                    <tbody>
                                        <tr>
                                            <td class="col-md-4">                                                
                                                <dx:ASPxCheckBox ID="copia_constitucionempresa" runat="server" Text="Const. de la Empresa" Theme="MetropolisBlue">
                                                </dx:ASPxCheckBox>                                               
                                                <dx:ASPxCheckBox ID="copia_ruc" runat="server" Text="RUC" Theme="MetropolisBlue">
                                                </dx:ASPxCheckBox>                                                                                          
                                                <dx:ASPxCheckBox ID="copia_dni" runat="server" Text="DNI" Theme="MetropolisBlue">
                                                </dx:ASPxCheckBox>                                               
                                            </td>
                                            <td class="col-md-4">                                                                                              
                                                    <dx:ASPxCheckBox ID="lic_func" runat="server" Text="Licencia de Funcionamiento" Theme="MetropolisBlue">
                                                    </dx:ASPxCheckBox>                                               
                                                    <dx:ASPxCheckBox ID="titulo_localcom" runat="server" Text="Titulo de Propiedad" Theme="MetropolisBlue">
                                                    </dx:ASPxCheckBox>
                                                    <dx:ASPxCheckBox ID="contra_localcom" runat="server" Text="Contrato de Local" Theme="MetropolisBlue">
                                                    </dx:ASPxCheckBox>
                                            </td>  
                                            <td class="col-md-4">                                                                                               
                                                 <dx:ASPxCheckBox ID="recibo_agualuz" runat="server" Text="Recibo Agua o Luz" Theme="MetropolisBlue">
                                                 </dx:ASPxCheckBox>
                                            </td>                                                                                
                                        </tr>                                       
                                    </tbody>
                                </table>
                            </div> 
                        </div>
                    </div>
                </div>

            </div>

            <div class="row">

                <!-- PRIMERA FILA -->

                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           III. TIENE PROTESTOS DE LETRA ?
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                               <dx:ASPxRadioButtonList ID="tiene_letraprotestada" runat="server" AutoPostBack="True" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean" OnSelectedIndexChanged="tiene_letraprotestada_SelectedIndexChanged">
                                    <Items>
                                        <dx:ListEditItem Text="SI" Value="True" />
                                        <dx:ListEditItem Text="NO" Value="False" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           »» TIENE INCUMPLIMIENTO DE PAGOS ?
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <dx:ASPxRadioButtonList ID="tiene_morosidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="tiene_morosidad_SelectedIndexChanged" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean">
                                    <Items>
                                        <dx:ListEditItem Text="SI" Value="True" />
                                        <dx:ListEditItem Text="NO" Value="False" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           IV. TIENE ANTECEDENTES INFOCORP ?
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <dx:ASPxRadioButtonList ID="moroso_infocorp" runat="server" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean" AutoPostBack="True" OnSelectedIndexChanged="moroso_infocorp_SelectedIndexChanged">
                                    <Items>
                                        <dx:ListEditItem Text="SI" Value="True" />
                                        <dx:ListEditItem Text="NO" Value="False" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- END PRIMERA FILA -->

                <!-- SEGUNDA FILA -->

                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           V. REFERENCIAS COMERCIALES
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive"> 
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">                               
                                <ContentTemplate>                                                              
                                   <dx:ASPxComboBox ID="refe_comerc" runat="server" AnimationType="Fade" EnableTheming="True" Theme="MetropolisBlue" AutoPostBack="True" 
                                       CssClass="form-control" OnSelectedIndexChanged="refe_comerc_SelectedIndexChanged">
                                        <Items>
                                            <dx:ListEditItem Text="» BUENO" Value="B" />
                                            <dx:ListEditItem Text="» REGULAR" Value="R" />
                                            <dx:ListEditItem Text="» MALA" Value="M" />
                                        </Items>
                                    </dx:ASPxComboBox>  
                                </ContentTemplate>
                                </asp:UpdatePanel>                                                                                                   
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           VI. REFERENCIAS BANCARIAS
                        </div>
                        <div class="panel-body">
                             <div class="table-responsive">  
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">                               
                                <ContentTemplate>                               
                                 <dx:ASPxComboBox ID="refe_banca" runat="server" Theme="MetropolisBlue"  AutoPostBack="True" 
                                     CssClass="form-control" OnSelectedIndexChanged="refe_banca_SelectedIndexChanged">
                                    <Items>
                                        <dx:ListEditItem Text="» BUENO" Value="B" />
                                        <dx:ListEditItem Text="» REGULAR" Value="R" />
                                        <dx:ListEditItem Text="» MALA" Value="M" />
                                    </Items>
                                </dx:ASPxComboBox>
                                </ContentTemplate>
                                </asp:UpdatePanel>                                        
                            </div>
                        </div>
                    </div>
                </div>

                <!-- END SEGUNDA FILA -->


                <!-- TERCERA FILA -->

                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                          VII. TIENE BIENES MUEBLES ?
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">                               
                               <dx:ASPxRadioButtonList ID="bienes_bienmueble" runat="server" AutoPostBack="True" OnSelectedIndexChanged="bienes_bienmueble_SelectedIndexChanged" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean">
                                    <Items>
                                        <dx:ListEditItem Text="SI" Value="True" />
                                        <dx:ListEditItem Text="NO" Value="False" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>                                      
                            </div>
                        </div>
                    </div>
                </div>            

                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           »» TIENE BIENES INMUEBLES ?
                        </div>
                        <div class="panel-body">
                             <div class="table-responsive">                               
                                <dx:ASPxRadioButtonList ID="bienes_inmuebles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="bienes_inmuebles_SelectedIndexChanged" RepeatLayout="OrderedList" Theme="iOS" ValueType="System.Boolean">
                                    <Items>
                                        <dx:ListEditItem Text="SI" Value="True" />
                                        <dx:ListEditItem Text="NO" Value="False" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>                                        
                            </div>
                        </div>
                    </div>
                </div>

                <!-- END TERCERA FILA -->

            </div>



            <div class="row">

                <!-- PRIMERA FILA -->

                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                           »» OPINION AREA DE VENTAS HORIZONTALES
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">                               
                                <ContentTemplate> 

                               <dx:ASPxComboBox ID="eval_cxcob" runat="server" Theme="MetropolisBlue"  CssClass="form-control">
                                    <Items>
                                        <dx:ListEditItem Text="» CLIENTE ACEPTABLE" Value="CA" />
                                        <dx:ListEditItem Text="» CLIENTE NO ACEPTABLE" Value="CN" />
                                        <dx:ListEditItem Text="» CLIENTE DUDOSO" Value="CD" />
                                    </Items>
                                </dx:ASPxComboBox>                                
                                <br />
                                <label>OTROS COMENTARIOS</label>                               
                                <asp:TextBox ID="obs_cxcob" runat="server" CssClass="form-control" TabIndex="2" TextMode="MultiLine"></asp:TextBox>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>    

                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           »» APROBACION GERENCIA GENERAL
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                               <dx:ASPxRadioButtonList ID="aprob_gerencial" runat="server" RepeatLayout="OrderedList" Theme="iOS" Enabled="False">
                                    <Items>
                                        <dx:ListEditItem Text="SI" Value="1" />
                                        <dx:ListEditItem Text="NO" Value="0" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>
                                <br />
                                <label>OBSERVACIÓNES</label>                                
                                <asp:TextBox ID="obs_gerencial" runat="server" CssClass="form-control" TabIndex="2" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- END PRIMERA FILA -->                                    
            </div>

            
             <div class="row">
                <div class="col-md-2">
                     <div class="panel panel-success">
                        <div class="panel-heading">
                           <h5>PUNTOS : <asp:Label ID="lblpuntos" runat="server" Font-Size="Small" Text="0"></asp:Label></h5> 
                        </div>
                    </div>  
                </div>

                 <div class="col-md-8">                                     
                  <div class="panel panel-primary">
                        <div class="panel-body">                 
                        <center style="margin-bottom:5px; margin-top:5px;">       
                                <asp:Button ID="btn_grabar" runat="server" CssClass="btn btn-primary" Text="Grabar" OnClick="btn_grabar_Click" ></asp:Button>      
                                <asp:Button ID="btn_Cancelar" runat="server" CssClass="btn btn-default" Text="Retornar" OnClick="btn_Cancelar_Click"></asp:Button>                                                                   
                        </center>
                        </div>
                    </div>                                    
                  </div>
            </div>



        </div>

     <%--</div>--%>

    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
      <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
     <!-- DATA TABLE SCRIPTS -->
    <script src="assets/js/dataTables/jquery.dataTables.js"></script>
    <script src="assets/js/dataTables/dataTables.bootstrap.js"></script>
        <script>
            $(document).ready(function () {
                $('#dataTables-example').dataTable();
            });
    </script>
         <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
   </form>
</body>
</html>


