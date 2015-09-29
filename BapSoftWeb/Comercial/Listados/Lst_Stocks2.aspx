<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_Stocks2.aspx.cs" Inherits="Comercial_Listados_LstStocks" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
 
    <style>
    
    
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
    
</head>
<body>
    <form id="form1" runat="server">
            <div id="page-inner">
                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="56000">
                </asp:ScriptManager>
                <div class="row">
                    <div class="col-md-12">
                        <h2><center> ...:: Stock de Articulos ::... </center></h2>                           
                    </div>
                </div>                
                          <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <!--<div class="panel-heading">
                                            <i class="fa fa-search fa-1x"> &nbsp;</i>Control de Búsqueda
                                        </div>-->
                                        <div class="panel-body">
                                   
                                        <!-- Articulo -->
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>                                   
                                        <div class="col-md-3">
                                        <!--    Detalles de Item -->
                                        <div class="panel panel-info">
                                            <div class="panel-heading">                                                
                                                 <label><asp:CheckBox ID="chk_articulo" runat="server" AutoPostBack="true"
                                                     OnCheckedChanged="chk_articulo_CheckedChanged"/>Seleccionar Articulo</label>                                                   
                                            </div>
                                            <div class="panel-body">
                                            <!-- -->
                                            <div class="form-group">                                                                                                        
                                                <div class="form-group input-group">                                                      
                                                    <asp:HiddenField ID="hf_articid" runat="server" />
                                                    <asp:TextBox ID="txt_articname" runat="server" CssClass="form-control" placeholder="Buscar Artículo"></asp:TextBox>
                                                    <span class="input-group-btn">                                                                                                                                                                 
                                                            <asp:LinkButton ID="btn_buscaArticulo" runat="server" CssClass="btn btn-danger" data-toggle="modal" data-target="#ModalArticulo">
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
                                        <!-- End Articulo -->

                                        <!-- Marca -->
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                        <div class="col-md-3">
                                              <!--    Detalles de Item -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">                                                    
                                                    <label><asp:CheckBox ID="chk_marca" runat="server" AutoPostBack="true" OnCheckedChanged="chk_marca_CheckedChanged" />Seleccionar Marca</label>                                                       
                                                </div>
                                                <div class="panel-body">
                                                <!-- -->
                                                <div class="form-group">                                                        
                                                     <div class="form-group input-group">
                                                        <asp:HiddenField ID="hf_marcaid" runat="server" />
                                                        <asp:TextBox ID="txt_marcaname" runat="server" CssClass="form-control" placeholder="Buscar Marca"></asp:TextBox>
                                                        <span class="input-group-btn">                                                           
                                                              <asp:LinkButton ID="btn_buscaMarca" runat="server" CssClass="btn btn-danger" 
                                                              data-toggle="modal" data-target="#ModalMarca">
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
                                        <!-- End Marca -->


                                        <!-- Linea -->
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        <div class="col-md-3">
                                              <!--    Detalles de Item -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">                                                    
                                                    <label><asp:CheckBox ID="chk_linea" runat="server" AutoPostBack="true" OnCheckedChanged="chk_linea_CheckedChanged" />Seleccionar Linea</label>                                                        
                                                </div>
                                                <div class="panel-body">
                                                <!-- -->
                                                <div class="form-group">                                                        
                                                     <div class="form-group input-group">
                                                        <asp:HiddenField ID="hf_lineaid" runat="server" />
                                                        <asp:TextBox ID="txt_lineaname" runat="server" CssClass="form-control" placeholder="Buscar Linea"></asp:TextBox>
                                                        <span class="input-group-btn">                                                           
                                                              <asp:LinkButton ID="btn_buscaLinea" runat="server" CssClass="btn btn-danger" 
                                                              data-toggle="modal" data-target="#ModalLinea">
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
                                        <!-- End Linea -->


                                        <!-- Genero -->
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                        <div class="col-md-3">
                                              <!--    Detalles de Item -->
                                            <div class="panel panel-info">
                                                <div class="panel-heading">                                                    
                                                     <label><asp:CheckBox ID="chk_genero" runat="server" AutoPostBack="true" OnCheckedChanged="chk_genero_CheckedChanged" />Seleccionar Genero</label>                                                      
                                                </div>
                                                <div class="panel-body">
                                                <!-- -->
                                                <div class="form-group">                                                        
                                                     <div class="form-group input-group">
                                                        <asp:HiddenField ID="hf_generoid" runat="server" />
                                                        <asp:TextBox ID="txt_generoname" runat="server" CssClass="form-control" placeholder="Buscar Genero"></asp:TextBox>
                                                        <span class="input-group-btn">                                                           
                                                              <asp:LinkButton ID="btn_buscaGenero" runat="server" CssClass="btn btn-danger" 
                                                              data-toggle="modal" data-target="#ModalGenero">
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
                                        <!-- End Genero -->

                                        </div>
                                    </div>                                    
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">                                            
                                            <i class="fa fa-list-alt fa-1x"> &nbsp;</i>Lista de Items
                                        </div>
                                        <div class="panel-body">
                                        <!-Lista de Items
                                        </div>
                                        <div class="panel-body">
                                        <!-- -->                                            
                                        <!--    Lista de Items  -->
                                        <div class="table-responsive">                                                                                                                
                                             <rsweb:ReportViewer ID="ReportViewer1" Height="1000px" runat="server" Width="1222px" Font-Names="Verdana" Font-Size="8pt" 
                                                 WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                                                 <LocalReport ReportPath="Comercial\Listados\Rpt_StockDisp.rdlc">
                                                     <DataSources>
                                                         <rsweb:ReportDataSource DataSourceId="Obj_StockDisp" Name="Ds_StockDisp" />
                                                     </DataSources>
                                                 </LocalReport>
                                             </rsweb:ReportViewer>                                                                                     
                                        </div>                                            
                                        </div>
                                    </div>                                    
                                </div>
                            </div>


                          
                            <!-- Modal ARTICULO -->
                            <div class="modal fade" id="ModalArticulo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H6">Lista de Articulos</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">                                                       
                                                    <ContentTemplate>
                                                         <table id="Table2" border="0" cellspacing="00" cellpadding="00" runat="server">
                                                            <tr>
                                                                <td style="width:54px">                                                               
                                                                    <asp:DropDownList ID="cmb_articulo" runat="server" CssClass="form-control" Width="100px">
                                                                        <asp:ListItem Value="01">Codigo</asp:ListItem>
                                                                        <asp:ListItem Value="02">Artículo</asp:ListItem>                                                                     
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
                                                         <asp:GridView ID="dgb_articulo" runat="server" AutoGenerateColumns="false" 
                                                                       CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                                       PageSize="5" AllowPaging="True" OnPageIndexChanging="dgb_articulo_PageIndexChanging" OnSelectedIndexChanged="dgb_articulo_SelectedIndexChanged" >
                                                            <Columns>                
                                                                <asp:BoundField DataField="artidic" HeaderText="AricId" SortExpression="articid" />
                                                                <asp:BoundField DataField="articidold" HeaderText="Codigo" SortExpression="articidold" />
                                                                <asp:BoundField DataField="articname" HeaderText="Articulo" SortExpression="articname" />                                                                     
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
                            <!-- End Modal ARTICULO -->

                            
                            
                            <!-- Modal MARCA -->
                            <div class="modal fade" id="ModalMarca" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H1">Lista de Marcas</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">                                                       
                                                    <ContentTemplate>
                                                         <table id="Table1" border="0" cellspacing="00" cellpadding="00" runat="server">
                                                            <tr>
                                                                <td style="width:54px">                                                               
                                                                    <asp:DropDownList ID="cmb_marca" runat="server" CssClass="form-control" Width="100px">
                                                                        <asp:ListItem Value="01">Codigo</asp:ListItem>
                                                                        <asp:ListItem Value="02">Marca</asp:ListItem>                                                                     
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_buscar2" runat="server" CssClass="form-control" placeholder="Busqueda" Width="360px"></asp:TextBox>                                                              
                                                                </td>  
                                                                <td>                                                                                                                                
                                                                    <asp:Button ID="btn_buscar02" runat="server" CssClass="btn btn-danger" Text="Buscar" OnClick="btn_buscar02_Click"></asp:Button>
                                                                </td>                                                       
                                                            </tr>                                                                                               
                                                        </table>  
                                                        <br />
                                                         <asp:GridView ID="dgb_marca" runat="server" AutoGenerateColumns="false" 
                                                                       CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                                       PageSize="5" AllowPaging="True" OnPageIndexChanging="dgb_marca_PageIndexChanging" OnSelectedIndexChanged="dgb_marca_SelectedIndexChanged" >
                                                            <Columns>                
                                                                <asp:BoundField DataField="marcaid" HeaderText="Codigo" SortExpression="marcaid" />                                                                
                                                                <asp:BoundField DataField="marcaname" HeaderText="Marca" SortExpression="marcaname" />                                                                     
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
                            <!-- End Modal MARCA -->

                    

                            <!-- Modal LINEA -->
                            <div class="modal fade" id="ModalLinea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H2">Lista de Lineas</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">                                                       
                                                    <ContentTemplate>
                                                         <table id="Table3" border="0" cellspacing="00" cellpadding="00" runat="server">
                                                            <tr>
                                                                <td style="width:54px">                                                               
                                                                    <asp:DropDownList ID="cmb_lineas" runat="server" CssClass="form-control" Width="100px">
                                                                        <asp:ListItem Value="01">Codigo</asp:ListItem>
                                                                        <asp:ListItem Value="02">Linea</asp:ListItem>                                                                     
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_buscar3" runat="server" CssClass="form-control" placeholder="Busqueda" Width="360px"></asp:TextBox>                                                              
                                                                </td>  
                                                                <td>                                                                                                                                
                                                                    <asp:Button ID="btn_buscar03" runat="server" CssClass="btn btn-danger" Text="Buscar" OnClick="btn_buscar03_Click"></asp:Button>
                                                                </td>                                                       
                                                            </tr>                                                                                               
                                                        </table>  
                                                        <br />
                                                         <asp:GridView ID="dgb_linea" runat="server" AutoGenerateColumns="false" 
                                                                       CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                                       PageSize="5" AllowPaging="True" OnPageIndexChanging="dgb_linea_PageIndexChanging" OnSelectedIndexChanged="dgb_linea_SelectedIndexChanged" >
                                                            <Columns>                
                                                                <asp:BoundField DataField="lineaid" HeaderText="Codigo" SortExpression="lineaid" />                                                                
                                                                <asp:BoundField DataField="lineaname" HeaderText="Linea" SortExpression="lineaname" />                                                                     
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
                            <!-- End Modal LINEA -->
                           
                          
                        
                            
                            <!-- Modal GENERO -->
                            <div class="modal fade" id="ModalGenero" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H3">Lista de Genero</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">                                                       
                                                    <ContentTemplate>
                                                         <table id="Table4" border="0" cellspacing="00" cellpadding="00" runat="server">
                                                            <tr>
                                                                <td style="width:54px">                                                               
                                                                    <asp:DropDownList ID="cmb_genero" runat="server" CssClass="form-control" Width="100px">
                                                                        <asp:ListItem Value="01">Codigo</asp:ListItem>
                                                                        <asp:ListItem Value="02">Genero</asp:ListItem>                                                                     
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt_buscar4" runat="server" CssClass="form-control" placeholder="Busqueda" Width="360px"></asp:TextBox>                                                              
                                                                </td>  
                                                                <td>                                                                                                                                
                                                                    <asp:Button ID="btn_buscar04" runat="server" CssClass="btn btn-danger" Text="Buscar" OnClick="btn_buscar04_Click"></asp:Button>
                                                                </td>                                                       
                                                            </tr>                                                                                               
                                                        </table>  
                                                        <br />
                                                         <asp:GridView ID="dgb_genero" runat="server" AutoGenerateColumns="false" 
                                                                       CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                                       PageSize="5" AllowPaging="True" OnPageIndexChanging="dgb_genero_PageIndexChanging" OnSelectedIndexChanged="dgb_genero_SelectedIndexChanged" >
                                                            <Columns>                
                                                                <asp:BoundField DataField="generoid" HeaderText="Codigo" SortExpression="generoid" />                                                                
                                                                <asp:BoundField DataField="generoname" HeaderText="Genero" SortExpression="generoname" />                                                                     
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
                            <!-- End Modal GENERO -->





                            <!-- /. ROW  -->
                            <!-- Botones -->
                            <%--<div class="row">
                                <div class="col-md-12">
                                        <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                        <!-- -->
                                        <center style="margin-bottom:5px; margin-top:5px;">                                            
                                            <a href="confirmacion.html" class="btn btn-primary">Continuar</a>
                                            <button type="submit" class="btn btn-default">Salir</button>
                                        </center>
                                        </div>
                                    </div>                                    
                                </div>
                            </div>--%>
                            <asp:HiddenField ID="HdF2" runat="server" />               
                                                                                     

                                             <asp:ObjectDataSource ID="Obj_StockDisp" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNew" TypeName="Ds_StockDispTableAdapters.tb_me_stock_disp_horizontalTableAdapter">
                                                 <InsertParameters>
                                                     <asp:Parameter Name="marcaid" Type="String" />
                                                     <asp:Parameter Name="lineaid" Type="String" />
                                                     <asp:Parameter Name="generoid" Type="String" />
                                                     <asp:Parameter Name="fecha" Type="DateTime" />
                                                     <asp:Parameter Name="articidold" Type="String" />
                                                     <asp:Parameter Name="articname" Type="String" />
                                                     <asp:Parameter Name="colorid" Type="String" />
                                                     <asp:Parameter Name="colorname" Type="String" />
                                                     <asp:Parameter Name="tallaid" Type="String" />
                                                     <asp:Parameter Name="sto01" Type="Int32" />
                                                     <asp:Parameter Name="sto02" Type="Int32" />
                                                     <asp:Parameter Name="sto03" Type="Int32" />
                                                     <asp:Parameter Name="sto04" Type="Int32" />
                                                     <asp:Parameter Name="sto05" Type="Int32" />
                                                     <asp:Parameter Name="sto06" Type="Int32" />
                                                     <asp:Parameter Name="sto07" Type="Int32" />
                                                     <asp:Parameter Name="sto08" Type="Int32" />
                                                     <asp:Parameter Name="sto09" Type="Int32" />
                                                     <asp:Parameter Name="sto10" Type="Int32" />
                                                     <asp:Parameter Name="sto11" Type="Int32" />
                                                     <asp:Parameter Name="sto12" Type="Int32" />
                                                     <asp:Parameter Name="stott" Type="Int32" />
                                                     <asp:Parameter Name="ta01" Type="String" />
                                                     <asp:Parameter Name="ta02" Type="String" />
                                                     <asp:Parameter Name="ta03" Type="String" />
                                                     <asp:Parameter Name="ta04" Type="String" />
                                                     <asp:Parameter Name="ta05" Type="String" />
                                                     <asp:Parameter Name="ta06" Type="String" />
                                                     <asp:Parameter Name="ta07" Type="String" />
                                                     <asp:Parameter Name="ta08" Type="String" />
                                                     <asp:Parameter Name="ta09" Type="String" />
                                                     <asp:Parameter Name="ta10" Type="String" />
                                                     <asp:Parameter Name="ta11" Type="String" />
                                                     <asp:Parameter Name="ta12" Type="String" />
                                                 </InsertParameters>
                                                 <SelectParameters>
                                                     <asp:ControlParameter ControlID="hf_marcaid" Name="marcaid" PropertyName="Value" Type="String" />
                                                     <asp:ControlParameter ControlID="hf_lineaid" Name="lineaid" PropertyName="Value" Type="String" />
                                                     <asp:ControlParameter ControlID="hf_generoid" Name="generoid" PropertyName="Value" Type="String" />
                                                     <asp:ControlParameter ControlID="hf_articid" Name="articidold" PropertyName="Value" Type="String" />
                                                 </SelectParameters>
                                             </asp:ObjectDataSource>
                                                                                     

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
