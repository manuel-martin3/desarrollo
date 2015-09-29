<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_ProformaEval.aspx.cs" Inherits="Comercial_Listados_Lst_ProformaEval" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html>

<script runat="server">
    
    //protected void btn_busqueda01_Click(object sender, EventArgs e)
    //{
    //    this.btn_busqueda01.Attributes.Add("OnClick", "javascript:return fnAceptar();");
    //}
    
</script>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Free Bootstrap Admin Template : Binary Admin</title>
	<!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
     <!-- MORRIS CHART STYLES-->

    <!--STYLE DATEPICKER-->   
    <link rel="stylesheet" href="assets/css/datepicker/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/datepicker/bootstrap-datepicker.min.css" />
    <!--FIN-->

    <!-- CUSTOM STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
     <!-- GOOGLE FONTS-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
     <!-- TABLE STYLES-->
    <link href="assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- DATEPICKER-->
    <!-- DATE PICKER -->
    <link href="assets/datepicker/css/jquery-ui.css" rel="stylesheet">
    <!-- DATE PICKER -->
    <script src="assets/datepicker/js/jquery.js"></script>    
    <script src="assets/datepicker/js/jquery-ui.js"></script>
    <script src="assets/datepicker/js/jquery.ui.datepicker-es.js"></script>
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

    <script Language="javascript" type="text/javascript">
        function fnAceptar() {
            alert('El Contenido del TextBox es: ' + document.getElementById("txt_busqueda01").value);
            document.getElementById("txt_busqueda01").value = '';
        }
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

    <script type="text/javascript">
        function Leer(val1) {
            $('#<%=lblnumdoc.ClientID%>').val(val1);
            $('#<%=hfnumdoc.ClientID%>').val(val1);
            $('#<%=HdFNumdoc.ClientID%>').val(val1);
            $('#<%=HdFIdUpd.ClientID%>').val(val1);  
        }
        function Leer2(val1, val2, val3, val4, val5) {
            $('#<%=lblnumdoc2.ClientID%>').val(val1);
            $('#<%=hfnumdoc2.ClientID%>').val(val1);
            $('#<%=lblctacte.ClientID%>').val(val2);
            $('#<%=hfctacte.ClientID%>').val(val2);
            $('#<%=lblctactename.ClientID%>').val(val3);
            $('#<%=hfctactename.ClientID%>').val(val3);
            $('#<%=hfstatus.ClientID%>').val(val4); 
            $('#<%=HdFSerdoc.ClientID%>').val(val5);
        }
    </script>

     <script type="text/javascript">
         function BuscarCliente(val1,val2) {
             $('#<%=lblnumdoc.ClientID%>').val(val1);
              $('#<%=hfnumdoc.ClientID%>').val(val1);
              $('#<%=HdFNumdoc.ClientID%>').val(val1);
              $('#<%=HdFIdUpd.ClientID%>').val(val1);
          }
         function BuscarVendor(val1) {
            $('#<%=lblnumdoc.ClientID%>').val(val1);
            $('#<%=hfnumdoc.ClientID%>').val(val1);
            $('#<%=HdFNumdoc.ClientID%>').val(val1);
            $('#<%=HdFIdUpd.ClientID%>').val(val1);
         }

         function Show(val1,val2) {
             $('#<%=HdFNumdoc.ClientID%>').val(val1);
             $('#<%=HdFSerdoc.ClientID%>').val(val2);
             var Button1 = document.getElementById('btn_search');
             Button1.click();
         }

         function Show2(val1,val2) {
             $('#<%=HdFIdUpd.ClientID%>').val(val1);
             $('#<%=HdFSerdoc.ClientID%>').val(val2);
            var Button1 = document.getElementById('btn_search2');
            Button1.click();
        }

    </script>





</head>
<body>
    <form id="form1" runat="server">
           <%-- <div id="page-wrapper" >--%>
            <div id="page-inner">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row">
                    <div class="col-md-12">
                        <h2><center> ..:: EVALUACIÓN DE PEDIDOS ::.. </center></h2>   
                        <%-- <h5>Bienvenido. 
                            <asp:Label ID="lblusu" runat="server"></asp:Label>
                        </h5>  --%>                     
                    </div>
                </div>
                 <!-- /. ROW  -->
                <%-- <hr />--%>                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                
                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Buscar por
                                        </div>
                                        <div class="panel-body">
                                        <!-- Cliente -->
                                        <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-4">
                                              <!--    Detalles de Item -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <label><asp:CheckBox ID="chk_cliente" runat="server" AutoPostBack="true"
                                                                OnCheckedChanged="chk_cliente_CheckedChanged" />Seleccionar Cliente</label>                                                    
                                                </div>
                                                <div class="panel-body">
                                                <!-- -->
                                                <div class="form-group">                                                                                                        
                                                    <div class="form-group input-group">                                                      
                                                        <asp:HiddenField ID="txt_ctacte" runat="server" />
                                                        <asp:TextBox ID="txt_ctactename" runat="server" CssClass="form-control" placeholder="Buscar Cliente"></asp:TextBox>
                                                        <span class="input-group-btn">                                                                                                                                                                 
                                                             <asp:LinkButton ID="btn_buscaCliente" runat="server" CssClass="btn btn-danger" 
                                                              data-toggle="modal" data-target="#ModalCliente">
                                                             <i class="fa fa-search"></i>
                                                             </asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div> 
                                                <!-- -->
                                                </div>
                                            </div>
                                            </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- End Cliente -->

                                        <!-- Vendedor -->
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        <div class="col-md-4">
                                              <!--    Detalles de Item -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">                                                    
                                                    <label><asp:CheckBox ID="chk_vendedor" runat="server" 
                                                        AutoPostBack="true" OnCheckedChanged="chk_vendedor_CheckedChanged" />Seleccionar Vendedor</label>
                                                </div>
                                                <div class="panel-body">
                                                <!-- -->
                                                <div class="form-group">                                                        
                                                     <div class="form-group input-group">
                                                        <asp:HiddenField ID="txt_vendorid" runat="server" />
                                                        <asp:TextBox ID="txt_vendorname" runat="server" CssClass="form-control" placeholder="Buscar Vendedor"></asp:TextBox>
                                                        <span class="input-group-btn">                                                           
                                                              <asp:LinkButton ID="btn_buscaVendor" runat="server" CssClass="btn btn-danger" 
                                                              data-toggle="modal" data-target="#ModalVendedor">
                                                            <i class="fa fa-search"></i>
                                                        </asp:LinkButton> 
                                                        </span>
                                                    </div>
                                                </div> 
                                                <!-- -->
                                                </div>
                                            </div>
                                        </div>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- End Vendedor -->


                                        <!-- Proforma -->
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                        <div class="col-md-4">
                                              <!--    Detalles de Item -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <label><asp:CheckBox ID="chk_estado" runat="server" 
                                                        AutoPostBack="true" OnCheckedChanged="chk_estado_CheckedChanged" />ESTADO</label>
                                                </div>
                                                <div class="panel-body">
                                                <!-- -->
                                                <div class="form-group">                                                      
                                                    <div class="form-group input-group">
                                                        <asp:DropDownList ID="cmbestado" runat="server" CssClass="form-control" Width="250px">                                                                        
                                                        </asp:DropDownList>                                                                                                              
                                                    </div>
                                                </div> 
                                                <!-- -->
                                                </div>
                                            </div>
                                        </div>
                                         </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- End Proforma -->

                                        </div>
                                        <hr style="margin-top:-15px;" />
                                        <!-- Botones -->
                                        <center style="margin-bottom:15px; margin-top:-10px;">                                  
                                            <asp:Button ID="btn_buscar" runat="server" CssClass="btn btn-success" Text="Buscar" OnClick="btn_buscar_Click"></asp:Button>
                                        </center>
                                        <!-- End Botones -->
                                    </div>                                    
                                </div>
                            </div>            

                        

                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Lista de Items
                                        </div>
                            <div class="panel-body">
                            <!-- -->
                    
                            <!--    Lista de Items  -->
                            <div class="table-responsive">                                
                                <asp:GridView ID="dgb_evalcred" runat="server" CssClass="table table-striped table-bordered table-hover" 
                                    AutoGenerateColumns="False" OnRowEditing="dgb_evalcred_RowEditing" OnSelectedIndexChanged="dgb_evalcred_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField HeaderText="RUC" DataField="nmruc" SortExpression="nmruc" />
                                        <asp:BoundField HeaderText="ctacte" DataField="ctacte" SortExpression="ctacte" Visible="false"/>
                                        <asp:BoundField HeaderText="Cliente" DataField="ctactename" SortExpression="ctactename" />
                                        <asp:BoundField HeaderText="serdoc" DataField="serdoc" SortExpression="serdoc" Visible="false"/>
                                        <asp:BoundField HeaderText="Documento" DataField="numdoc" SortExpression="numdoc" />
                                        <asp:BoundField HeaderText="Vendedor" DataField="vendorname" SortExpression="vendorname" />
                                        <asp:BoundField HeaderText="Estado" DataField="estado" SortExpression="estado" />
                                        <asp:TemplateField HeaderText="&nbsp;[EDITAR]" ControlStyle-CssClass="odd gradeX" HeaderStyle-CssClass="Center"  ItemStyle-CssClass="Center">
                                            <ItemTemplate>                                                                                                            
                                                     <a href="#" data-toggle="modal" data-target="#myModalEvaluacion" class="btn btn-warning" style=" text-decoration:none;"
                                                     onclick="Leer2('<%#Eval("numdoc").ToString()%>','<%#Eval("ctacte").ToString()%>','<%#Eval("ctactename").ToString()%>','<%#Eval("aprob_gerencial").ToString()%>','<%#Eval("serdoc").ToString()%>');" )">
                                                   <%-- <i class="fa fa-bookmark"></i>Editar--%>
                                                    <i class="fa fa-pencil-square-o"></i>
                                                </a>                                               
                                            </ItemTemplate>
                                        </asp:TemplateField> 

                                        <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DOCUMETOS ADJUNTOS]" ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                               <a href="#" class="btn btn-info" style=" text-decoration:none;" onclick="Show('<%#Eval("numdoc").ToString()%>','<%#Eval("serdoc").ToString()%>');"><i class="fa fa-print"></i> Pedido &nbsp;</a>
                                               <a href="#" class="btn btn-info" style=" text-decoration:none;" onclick="Show2('<%#Eval("numdoc").ToString()%>','<%#Eval("serdoc").ToString()%>');" )"><i class="fa fa-print"></i> Evaluación</a>                                                                                                                                                                                                                                                                   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                                                                                                                                                                                                                                                                                                                                                                
                                    </Columns>
                                </asp:GridView>                                                                    
                                <div style=" display:none;">                                        
                                    <asp:Button ID="btn_search" runat="server" class="btn btn-default" OnClick="LkBSearch_Click"/>
                                    <asp:Button ID="btn_search2" runat="server" class="btn btn-default" OnClick="LkBUpdate_Click"/>
                                </div>
                               <asp:HiddenField ID="HdFNumdoc" runat="server" />
                               <asp:HiddenField ID="HdFSerdoc" runat="server" />
                               <asp:HiddenField ID="HdFIdUpd" runat="server" />
                               <asp:HiddenField ID="hfstatus" runat="server" /> 
                            </div>


                     <!--  End  Lista de Items  -->

                                        </div>
                                    </div>                                    
                                </div>
                            </div>

                     <%--     </ContentTemplate>
                  </asp:UpdatePanel>--%>

                            <!-- Modal Search -->
                            <div class="modal fade" id="myModalSearch" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H4">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto? 
                                            <img src="assets/img/attach.png" />                                           
                                        </div>
                                        
                                        <div class="modal-footer">                                                                                                                                                  
                                            <!--<asp:TextBox ID="LblIdSer" runat="server" Visible="False"></asp:TextBox>-->
                                            
                                            <%--<asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" runat="server" OnClick="LkBSearch_Click">Aceptar</asp:LinkButton>--%>                                                                          
                                            <asp:LinkButton ID="LkBCancelSer" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelSer_Click">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Search -->

                            <!-- Modal Update -->
                            <div class="modal fade" id="myModalUpdate" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H5">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto?                                            
                                            <img src="assets/img/attach.png" />                                           
                                            
                                            <!--<asp:TextBox ID="LblIdUpd" runat="server" Visible="False"></asp:TextBox>-->
                                        </div>
                                        <div class="modal-footer">                                            
                                            <%--<asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" runat="server" OnClick="LkBUpdate_Click">Aceptar</asp:LinkButton>--%>
                                            <asp:LinkButton ID="LkBCancelUpd" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelUpd_Click">Cancelar</asp:LinkButton>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Update -->
                        


                            <!-- Modal Reporte -->
                            <div class="modal fade" id="MyModalReporte" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H2">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">                                            
                                            Proforma :&nbsp;&nbsp;<asp:TextBox ID="lblnumdoc" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>                                                                                                                                
                                            <asp:HiddenField ID="hfnumdoc" runat="server" /><br />
                                            ¿Desea ver reporte del registro?                                            
                                        </div>
                                        <div class="modal-footer">
                                            <asp:LinkButton ID="LkBAceptar" CssClass="btn btn-default" runat="server" OnClick="LkBAceptar_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelar" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelar_Click">Cancelar</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Reporte -->


                            <!-- Modal Editar Evaluacion -->
                            <div class="modal fade" id="myModalEvaluacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H3">Formato de Evaluación Crediticia</h4>
                                        </div>
                                        <div class="modal-body">                                            
                                             Proforma :&nbsp;&nbsp;<asp:TextBox ID="lblnumdoc2" runat="server" BorderStyle="None" ReadOnly="true"></asp:TextBox>
                                             <asp:HiddenField ID="hfnumdoc2" runat="server" /><br />
                                             Cliente :&nbsp;&nbsp;<asp:TextBox ID="lblctacte" runat="server" BorderStyle="None" Width="55px" ReadOnly="true"></asp:TextBox>
                                            <asp:HiddenField ID="hfctacte" runat="server" />
                                            - <asp:TextBox ID="lblctactename" runat="server" BorderStyle="None" Width="400px" ReadOnly="true"></asp:TextBox><br />
                                            <asp:HiddenField ID="hfctactename" runat="server" />
                                            ¿Desea Editar la Evaluación?                               
                                        </div>
                                        <div class="modal-footer">
                                            <asp:LinkButton ID="LkBEditar" CssClass="btn btn-default" runat="server" OnClick="LkBEditar_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancel" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancel_Click">Cancelar</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Editar Evaluación -->


                                                         
                           

                            <!-- MODAL CLIENTES -->                            
                            <div class="modal fade" id="ModalCliente" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="panel panel-primary">                                   
                                        <div class="panel-heading">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H6">Lista de Clientes</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <Triggers></Triggers>
                                                    <ContentTemplate>

                                                         <table id="Table2" border="0" cellspacing="00" cellpadding="00" runat="server">
                                                            <tr>
                                                                <td style="width:54px">                                                               
                                                                    <asp:DropDownList ID="cmbcliente" runat="server" CssClass="form-control" Width="100px">
                                                                        <asp:ListItem Value="01">Codigo</asp:ListItem>
                                                                        <asp:ListItem Value="02">Cliente</asp:ListItem>
                                                                        <asp:ListItem Value="03">RUC</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_buscar" runat="server" CssClass="form-control" placeholder="Busqueda" Width="360px"></asp:TextBox>                                                              
                                                                </td>  
                                                                <td>                                                                                                                                
                                                                    <asp:Button ID="btn_buscar01" runat="server" CssClass="btn btn-danger" Text="Buscar" OnClick="btn_buscar01_Click"></asp:Button>
                                                                </td>                                                       
                                                            </tr>                                                                                               
                                                        </table>  
                                                        <br />
                                                         <asp:GridView ID="dgb_cliente" runat="server" AutoGenerateColumns="false" 
                                                                       CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                                       PageSize="5" AllowPaging="True" OnSelectedIndexChanged="dgb_cliente_SelectedIndexChanged"
                                                              OnPageIndexChanging="dgb_cliente_PageIndexChanging" OnRowCreated="dgb_cliente_RowCreated" >
                                                            <Columns>                
                                                                <asp:BoundField DataField="ctacte" HeaderText="Codigo" SortExpression="ctacte" />
                                                                <asp:BoundField DataField="nmruc" HeaderText="R.U.C." SortExpression="nmruc" />
                                                                <asp:BoundField DataField="ctactename" HeaderText="Cliente" SortExpression="ctactename" />                                                                     
                                                            </Columns>
                                                         </asp:GridView>                                          
                                                      </ContentTemplate>
                                                </asp:UpdatePanel>                                                
                                                </div>      
                                            </div>   
                                        </div>
                                        <div class="modal-footer">                                     
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>                            
                            <!-- END MODAL CLIENTES -->


                            <!-- MODAL VENDEDORES -->
                            <div class="modal fade" id="ModalVendedor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="panel panel-primary">                                   
                                        <div class="panel-heading">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H7">Lista de Vendedores</h4>
                                        </div>
                                        <div class="modal-body">
                                             <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <Triggers></Triggers>
                                                    <ContentTemplate>

                                                    <table runat="server" id="Table1"> 
                                                        <tr>
                                                            <td style="width:54px">                                                               
                                                                <asp:DropDownList ID="cmbvendedor" runat="server" CssClass="form-control" Width="100px">
                                                                    <asp:ListItem Value="01">Codigo</asp:ListItem>
                                                                    <asp:ListItem Value="02">Vendedor</asp:ListItem>                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txt_busqueda02" runat="server" CssClass="form-control" placeholder="Busqueda" Width="360px"></asp:TextBox>                                                              
                                                            </td>  
                                                            <td>                                                                                                                                
                                                                <asp:Button ID="btn_buscar02" runat="server" CssClass="btn btn-danger" Text="Buscar" OnClick="btn_buscar02_Click"></asp:Button>
                                                            </td>                                                       
                                                        </tr>                                                                                            
                                                    </table>   
                                                    <br />
                                                    <asp:GridView ID="dgb_vendedor" runat="server" AutoGenerateColumns="false" 
                                                                    CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                        OnPageIndexChanging="dgb_vendedor_PageIndexChanging" OnSelectedIndexChanged="dgb_vendedor_SelectedIndexChanged">
                                                        <Columns>                
                                                            <asp:BoundField DataField="vendorid" HeaderText="Codigo" SortExpression="vendorid" />                                                                        
                                                            <asp:BoundField DataField="vendorname" HeaderText="Vendedor" SortExpression="vendorname" />
                                                        </Columns>
                                                    </asp:GridView>                                                                                             
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>                                                
                                                </div>      
                                            </div>                                           
                                        </div>
                                        <div class="modal-footer">                                     
                                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END MODAL VENDEDORES -->

                           
                            




                            <!-- Modal Eliminar -->
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea eliminar el registro?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Si</button>
                                            <button type="button" class="btn btn-primary">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Eliminar -->

                            <!-- Modal Actualizar -->
                            <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H1">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea grabar los cambios en el registro?
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Si</button>
                                            <button type="button" class="btn btn-primary">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Actualizar -->

                <!-- /. ROW  -->
                <!-- Botones -->
                <!-- End Botones -->

                </div>
           <%-- </div>--%>

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
