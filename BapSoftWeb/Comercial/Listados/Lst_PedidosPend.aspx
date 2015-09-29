<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_PedidosPend.aspx.cs" Inherits="Comercial_Listados_Lst_ProformaAprob" %>

<!DOCTYPE html>

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
        function Leer(val1, val2, val3, val4, val5, val6) {
            $('#<%=HdFOpenItem.ClientID%>').val(val1);
            $('#<%=HdFDeleteItem.ClientID%>').val(val1);
            $('#<%=HdFUpdateItem.ClientID%>').val(val1);
            $('#<%=HdFStatus.ClientID%>').val(val2);
            $('#<%=HdFNumdoc.ClientID%>').val(val1); 
            $('#<%=HdFSerdoc.ClientID%>').val(val3);
        }


        function Show(val1, val2) {
            $('#<%=HdFNumdoc.ClientID%>').val(val1);
            $('#<%=HdFSerdoc.ClientID%>').val(val2);
            var Button1 = document.getElementById('btn_search');
            Button1.click();
        }

    </script>

<style>
    .myinput {
    background-color: transparent;
    border: 0px solid;
    height: 20px;
    width: 160px;
    color: #CCC;
}
    .myinput:focus{
	outline:0px;
}
</style>
    <!--Button1.click();-->
</head>
<body>
    <form id="form1" runat="server">
          <div id="page-inner">
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="row">
                    <div class="col-md-12">
                        <h2><center> ..:: LISTADO DE PEDIDOS ::.. </center></h2>                       
                    </div>
                </div>
                 <!-- /. ROW  -->
                <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            Buscar por
                                        </div>
                                        <div class="panel-body">
                                        <!-- Cliente -->
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_buscar"/>
                                            </Triggers>
                                        <ContentTemplate>
                                            <center style="margin-bottom:15px; margin-top:-10px;">                                  
                                                <asp:Button ID="btn_buscar" runat="server" CssClass="btn btn-success" Text="Buscar" OnClick="btn_buscar_Click"></asp:Button>
                                            </center>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
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
                                            <!--    Lista de Items  -->
                                           <div class="table-responsive">
                                               <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" 
                                                     CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                   onrowcommand="GridView_RowCommand" DataKeyNames="aprob_status">
                                                    <Columns>
                                                        <asp:BoundField DataField="nmruc" HeaderText="R.U.C." SortExpression="key" />
                                                        <asp:BoundField DataField="ctactename" HeaderText="CLIENTE" SortExpression="ctactename" />
                                                        <asp:BoundField DataField="serdoc" HeaderText="Serdoc" SortExpression="serdoc" Visible="false"/>
                                                        <asp:BoundField DataField="numdoc" HeaderText="DOCUMENTO" SortExpression="numdoc" />
                                                        <asp:BoundField DataField="aprob_status" HeaderText="status" SortExpression="aprob_status" Visible="false" />
                                                        <asp:BoundField DataField="fecre" HeaderText="FECHA EMISIÓN" SortExpression="fecre" />
                                                        <asp:BoundField DataField="estado" HeaderText="ESTADO" SortExpression="estado" />                                                                                    
                                                        <%--<asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DOCUMETOS ADJUNTOS]" ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>                                                             
                                                            <a href="#" data-toggle="modal" data-target="#myModalSearch" class="btn btn-default" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-bookmark"></i> Proforma &nbsp;</a>
                                                            <a href="#" data-toggle="modal" data-target="#myModalUpdate" class="btn btn-default" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>');" )"><i class="fa fa-bookmark"></i> Evaluación</a>                                                    
                                                        </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Menú Opciones]"  ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                                                        <ItemTemplate>   
                                                            <a href="#" class="btn btn-info" style=" text-decoration:none;" onclick="Show('<%#Eval("numdoc").ToString()%>','<%#Eval("serdoc").ToString()%>');" )"><i class="fa fa-print"></i> </a>
                                                            <a href="#" data-toggle="modal" data-target="#updateItem" class="btn btn-warning" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>','<%#Eval("aprob_status").ToString()%>','<%#Eval("serdoc").ToString()%>');")"><i class="fa fa-pencil-square-o"></i> </a>
                                                            <a href="#" data-toggle="modal" data-target="#deleteItem" class="btn btn-danger" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>','<%#Eval("aprob_status").ToString()%>','<%#Eval("serdoc").ToString()%>');")"><i class="fa fa-trash-o"></i> </a>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                               <div style=" display:none;">                                        
                                                    <asp:Button ID="btn_search" runat="server" class="btn btn-default" OnClick="LkBPrint_Click"/>                                                   
                                               </div>                                                
                                               <asp:HiddenField ID="HdFNumdoc" runat="server" />
                                               <asp:HiddenField ID="HdFSerdoc" runat="server" />
                                            </div>                                            
                                        </div>
                                    </div>                                    
                                </div>
                            </div>


                            <!-- Modal Search -->
                            <div class="modal fade" id="myModalSearch" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H3">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto? 
                                            <img src="assets/img/attach.png" />                                           
                                        </div>
                                        
                                        <div class="modal-footer">                                                                                                                                                  
                                            <!--<asp:TextBox ID="LblIdSer" runat="server" Visible="False"></asp:TextBox>-->
                                            <asp:HiddenField ID="HdFIdSer" runat="server" />
                                            <asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" runat="server" OnClick="LkBSearch_Click">Aceptar</asp:LinkButton>                                                                          
                                            <asp:LinkButton ID="LkBCancelSer" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelSer_Click">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Search -->

                            
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
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
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
                    

                            <section id="modalPrint">    
                                <div class="modal fade" id="printItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="panel panel-primary">                                   
                                            <div class="panel-heading">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="H1"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                            </div>
                                            <div class="modal-body">
                                                    Usted ha presionado sobre el botón Imprimir.<br>
                                                ¿ Desea visualizar el registro ?                                                          
                                                <img src="assets/img/attach.png" />                                           
                                            </div>                    
                       
                                            <div class="modal-footer">
                                                    
                                                    <%--<asp:LinkButton ID="LkBPrint" CssClass="btn btn-default" runat="server" OnClick="LkBPrint_Click">Aceptar</asp:LinkButton>--%>
                                                    <asp:LinkButton ID="LkBCancelPrint" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                            
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </section>
                                 
                            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">                                        
                            <ContentTemplate> 
                                <section id="modalOpen">                                       
                                    <!-- Modal Search -->
                                    <div class="modal fade" id="openItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H9">Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                        Usted ha presionado sobre el botón Abrir.<br>
                                                    ¿ Desea abrir el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                                  
                                                    <asp:HiddenField ID="HdFOpenItem" runat="server" />
                                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>                                                                          
                                                    <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>                  
                                <section id="modalDelete">        
                                    <div class="modal fade" id="deleteItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="myModalLabel"><i class="fa fa-trash-o fa-1x"></i> Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                        Usted ha presionado sobre el botón Eliminar<br>
                                                    ¿ Desea eliminar el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                              
                                                    <asp:HiddenField ID="HdFDeleteItem" runat="server" />
                                                    <asp:LinkButton ID="LkBDelete" CssClass="btn btn-default" runat="server" OnClick="LkBDelete_Click">Aceptar</asp:LinkButton>
                                                    <asp:LinkButton ID="LkBCancelDelete" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>   
                   
                                <section id="modalSave">        
                                    <div class="modal fade" id="saveItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H5"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                        Usted ha presionado sobre el botón Guardar.<br>
                                                    ¿ Desea guardar el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                                  
                                                    <asp:HiddenField ID="HdFSaveItem" runat="server" />
                                                    <asp:LinkButton ID="LkBSave" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>
                                                    <asp:LinkButton ID="LkBCancelSave" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>

                                <section id="modalUpdate">        
                                    <div class="modal fade" id="updateItem" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title" id="H8"><i class="fa fa-exclamation-triangle fa-1x"></i> Mensaje</h4>
                                                </div>
                                                <div class="modal-body">
                                                        Usted ha presionado sobre el botón Modificar.<br>
                                                    ¿ Desea modificar el registro ?                                                          
                                                    <img src="assets/img/attach.png" />                                           
                                                </div>
                                        
                                                <div class="modal-footer">                                                                                                                                                                                                  
                                                    <asp:HiddenField ID="HdFStatus" runat="server" />
                                                    <asp:HiddenField ID="HdFUpdateItem" runat="server" />
                                                    <asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" runat="server" OnClick="LkBUpdate_Click">Aceptar</asp:LinkButton>
                                                    <asp:LinkButton ID="LkBCancelUpdate" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelUpdate_Click">Cancelar</asp:LinkButton>                                                                          
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </ContentTemplate>
                            </asp:UpdatePanel>  

                            <!-- Modal Status -->
                            <div class="modal fade" id="myModalStatus" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H4">Mensaje</h4>
                                        </div>
                                        
                                        <div class="modal-body">                                            
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <!-- Clientes -->
                                                    <div class="panel panel-default">                                                                                                            
                                                        <!--<div class="panel-heading">-->
                                                            <!--Detalles Cliente-->
                                                            <!--Detalle Clientes
                                                        </div>-->
                                                        <div class="panel-body">
                                                            <!--<div class="table-responsive">-->                                                            
                                                                <b>
                                                                    <asp:Label ID="LblIdNam" runat="server" Text="Label"></asp:Label>
                                                                </b>                                            
                                                            <!--</div>-->
                                                        </div>
                                                    </div>
                                                    <!--End Clientes -->
                                                </div>                                                
                                            </div>

                                            <div class="row">
                                                <div class="col-md-7">
                                                  <!--   Detalles Cliente -->
                                                    <!--<div class="panel panel-info">-->
                                                    <div id="detCli">
                                                        <div class="panel-heading">                                                            
                                                        Estado :
                                                            <b style="font-size:small;">
                                                                <asp:Label ID="LblCond" runat="server" Text="Label"></asp:Label>                                                            
                                                                <img id="image" alt="" src="" />
                                                            </b>    
                                                        
                                                        </div>
                                                        <div class="panel-body">
                                                        Número R.U.C : 
                                                            <asp:Label ID="LblIdRuc" runat="server" Text="Label"></asp:Label>                                                            
                                                        <br /> <br /> 
                                                        Número documento :
                                                        <asp:Label ID="LblIdDoc" runat="server" Text="Label"></asp:Label>                                                                                                                                                                               
                                                        </div> 
                                                        <br />                                                       
                                                    </div>
                                                     <!-- End  Detalles Cliente -->
                                                </div>
                                                <div class="col-md-5">
                                                     <!--   Control de Estados  -->
                                                    <div class="panel panel-primary">
                                                        <div class="panel-heading">
                                                            Control de Estados
                                                           
                                                        </div>
                                                    <div class="form-group" style="margin-left:15px;">
                                                        <!--<label>Selector de Estados</label>-->
<%--                                                        <div class="radio">
                                                            <label>
                                                                <!--<input type="radio" name="optionsRadios" id="optionsRadios1" value="option1"/>-->
                                                                <asp:RadioButton ID="RdB1" runat="server" Checked="false" />Aprobar
                                                            </label>
                                                        </div>
                                                        <div class="radio">
                                                            <label>
                                                                <!--<input type="radio" name="optionsRadios" id="optionsRadios2" value="option2"/>Desaprobar-->
                                                                <asp:RadioButton ID="RdB2" runat="server" Checked="false" />Desaprobar
                                                            </label>
                                                        </div>
                                                        <div class="radio">
                                                            <!--<label>
                                                                <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked />Pendiente
                                                            </label>-->
                                                            <br />
                                                        </div>--%>                                                        
                                                        <asp:RadioButtonList ID="RBL1" runat="server" AutoPostBack="False">                                        
                                                                <asp:ListItem Value="0">Desaprobado</asp:ListItem>
                                                                <asp:ListItem Value="1">Aprobado</asp:ListItem>                                        
                                                                <asp:ListItem Value="2">Pendiente</asp:ListItem>                                                
                                                        </asp:RadioButtonList>  
                                                                    
                                                                    <!--
                                                                    <hr />
                                                                    <asp:Label ID="resultado" runat="server" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>                                    
                                                                    <asp:Label ID="resultado1" runat="server" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>-->
                                                                    <br />
                                                                    <asp:HiddenField ID="HdF1" runat="server" />               
                                                                    <asp:Label ID="opval" runat="server" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>
                                                    </div>                                                        
                                                    </div>
                                                      <!-- End  Control de Estados  -->
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <!-- Clientes -->
                                                    <div class="panel panel-info">
                                                        <!--<div class="panel-heading">
                                                            Observación
                                                        </div>-->
                                                        <div class="panel-body">
                                                            <div class="table-responsive">                                                                
                                                                <asp:TextBox ID="LblIdObs" runat="server" style=" width:100%; height:75px;" TextMode="MultiLine"></asp:TextBox>
                                                            </div>                            
                                                        </div>
                                                    </div>
                                                    <!--End Clientes -->
                                                </div>
                                            </div>
                                                ¿Desea cambiar el estado del registro?
                                        </div>
                                    
                                        <div class="modal-footer">              
                                            <asp:LinkButton ID="LkBStatus" CssClass="btn btn-default" runat="server" OnClick="LkBStatus_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelSta" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelSta_Click">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Status -->
                            <!-- Modal Help -->
                            <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H2">Manual de Usuario</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p style="text-align : justify;">
                            <b>Bienvenido Sr(a). Juan Perez</b>,                             
                             en esta sección usted podrá visualizar el listado de todos los pedidos pendientes de aprobación.
                              Este listado contienen una sección o columna con botones que se aprecian de distintos colores para un mejor manejo de los registros.
                            </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Ver PDF(botón color blanco), se visualizará un documento en formato PDF del registro seleccionado.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Editar(botón color azul) se visualizará una ventana emergente con los datos del registro que desea editar, una vez realizado los cambios deseados, presione sobre el botón guardar para grabar los cambios.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Eliminar (botón color rojo), se visualizará una ventana, la cual le solicitará la confirmación de la orden seleccionada, para el caso de eliminar el registro presionar sobre en botón Si o No en caso contrario no desee eliminar.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Ver PDF(botón color blanco), se visualizará un documento en formato PDF del registro seleccionado.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Editar(botón color azul) se visualizará una ventana emergente con los datos del registro que desea editar, una vez realizado los cambios deseados, presione sobre el botón guardar para grabar los cambios.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Eliminar (botón color rojo), se visualizará una ventana, la cual le solicitará la confirmación de la orden seleccionada, para el caso de eliminar el registro presionar sobre en botón Si o No en caso contrario no desee eliminar.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Ver PDF(botón color blanco), se visualizará un documento en formato PDF del registro seleccionado.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Editar(botón color azul) se visualizará una ventana emergente con los datos del registro que desea editar, una vez realizado los cambios deseados, presione sobre el botón guardar para grabar los cambios.
                              </p>
                              <p>
                              Si aplicara o presionara con el puntero del mouse sobre el botón Eliminar (botón color rojo), se visualizará una ventana, la cual le solicitará la confirmación de la orden seleccionada, para el caso de eliminar el registro presionar sobre en botón Si o No en caso contrario no desee eliminar.
                              </p>
                            <!--
                              visualización que se encuentran de botón blanco), además de editarlos (botón azul) y/o eliminarlos (botón rojo), según la opción seleccionada de la columna <b>[Menú Opciones]</b> de la tabla llamada Lista de Items, las cuales se ubican al lado derecho de la lista.
                            </p>
                        -->
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <!--<button type="button" class="btn btn-primary">No</button>-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Help -->
                <!-- /. ROW  -->
                <!-- Botones -->                            
                <asp:HiddenField ID="HdF2" runat="server" />               
                <!-- End Botones -->


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
                $('#GridView').dataTable();
            });
    </script>
         <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>

        <!--CUSTOM TABLE-->
        <link href="assets/table/css/styles.css" rel="stylesheet" />
        <script src="assets/table/scripts/jquery-1.4.2.min.js"></script>
        <script src="assets/table/scripts/jquery.dataTables.min.js"></script>
        <script src="assets/table/scripts/jquery.metadata.js"></script>              

       
    <!--END CUSTOM TABLE-->
    </form>
</body>
</html>
