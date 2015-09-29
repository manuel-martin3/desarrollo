<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_StocksArtic.aspx.cs" Inherits="Comercial_Listados_LstStocks" %>

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


    <script type="text/javascript">
        function searchclick(val1) {
            $('#<%=HdFarticid.ClientID%>').val(val1);
            var Button1 = document.getElementById('btn_search');
            Button1.click();

            var Button2 = document.getElementById('btn_buscaCliente');
            Button2.click();
            //$('#ModalCliente').modal('toggle');
            //data-toggle="modal" data-target="#ModalCliente"
        }

        function Close()
        {
            var Button1 = document.getElementById('btnCerrar');
            Button1.click();

            //var Button2 = document.getElementById('btnCerrar2');
            //Button2.click();
        }

    </script>
    

    <script type="text/javascript">
        function searchPopclick() {

            // Setup Metadata plugin
            $.metadata.setType("class");

            // Setup GridView
            $("table.grid").each(function () {
                var jTbl = $(this);

                if (jTbl.find("tbody>tr>th").length > 0) {
                    jTbl.find("tbody").before("<thead><tr></tr></thead>");
                    jTbl.find("thead:first tr").append(jTbl.find("th"));
                    jTbl.find("tbody tr:first").remove();
                }

                // If GridView has the 'sortable' class and has more than 10 rows
                if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 15) {

                    // Run DataTable on the GridView
                    jTbl.dataTable({
                        sPaginationType: "full_numbers",
                        sDom: '<"top"lf>rt<"bottom"ip>',
                        oLanguage: {
                            sInfoFiltered: "(de _MAX_ entradas)",
                            sSearch: "Buscar: "
                        },
                        aoColumnDefs: [
                            { bSortable: false, aTargets: jTbl.metadata().disableSortCols }
                        ]
                    });
                }
            });
            $('#searchProd').modal('toggle');
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
    function Leer(val1, val2, val3, val4, val5, val6) {      
        $('#<%=HdFarticid.ClientID%>').val(val1);      
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
                <div class="row">
                    <div class="col-md-12">
                        <h2><center> ..:: STOCK DE ARTICULOS ::.. </center></h2>                           
                    </div>
                </div>
                
                          <div class="row">
                              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                      <!--    Detalles de Item -->
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">                                            
                                            <i class="fa fa-list-alt fa-1x"> &nbsp;</i>Lista de Articulos
                                        </div>
                                        <div class="panel-body">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                            <div class="row">
                                            <div class="col-md-12">
                                                <div class="modal-body">
                                                    <div class="panel-body">                                                       
                                                        <div class="table-responsive">
                                                                <center>                                                                   
                                                                    <asp:GridView ID="GridViewProd" runat="server" AutoGenerateColumns="False" 
                                                                         CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,2]}" 
                                                                        onrowcommand="GridViewProd_RowCommand">
                                                                        <Columns>                
                                                                            <asp:BoundField DataField="articidold" HeaderText="Código" SortExpression="articidold" />
                                                                            <asp:BoundField DataField="articname" HeaderText="Artículo" SortExpression="articname" />
                                                                            <asp:BoundField DataField="stockdisp" HeaderText="StockDisp" SortExpression="stockdisp" />
                                                                            <asp:BoundField DataField="pvt_cremenor" HeaderText="PrecLista" SortExpression="pvt_cremenor" />
                                                                            <asp:BoundField DataField="prec_etiq" HeaderText="PrecEtiquet" SortExpression="prec_etiq" Visible="false"/>
                                                                            <asp:BoundField DataField="prec_ofer" HeaderText="PrecOferta" SortExpression="prec_ofer" />
                                                                            <asp:BoundField DataField="estadoid" HeaderText="PrecLista" SortExpression="estadoid"  Visible="false"/>
                                                                            <asp:BoundField DataField="estadoname" HeaderText="Estado" SortExpression="estadoname" />
                                                                            <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Menú Opciones]"  ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">                                                                           
                                                                            <ItemTemplate>                                                                      
                                                                               <%-- <a href="#" data-toggle="modal" data-target="#ModalCliente" class="btn btn-info" style=" text-decoration:none;" 
                                                                                    onclick="Leer('<%#Eval("articid").ToString()%>');" )">
                                                                                    <i class="fa fa-print">&nbsp;Detalle</i>
                                                                                </a> --%>
                                                                                <a href="#" class="btn btn-info" style=" text-decoration:none;" onclick="searchclick('<%#Eval("articidold").ToString()%>');" )"><i class="fa fa-print"></i>&nbsp;Detalle</a>                                                                                                                                                                                                                   
                                                                            </ItemTemplate>
                                                                            </asp:TemplateField>                                                                              
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                     <div style=" display:none;">                                        
                                                                        <asp:Button ID="btn_search" runat="server" class="btn btn-default" OnClick="LkBSearch_Click"/>
                                                                        <%--<asp:Button ID="btn_search2" runat="server" class="btn btn-default" data-toggle="modal" data-target="#ModalCliente"/>--%>  
                                                                        <asp:LinkButton ID="btn_buscaCliente" runat="server" CssClass="btn btn-danger" data-toggle="modal" data-target="#ModalCliente">                                                                           
                                                                        </asp:LinkButton>
                                                                                                                                                                                                            
                                                                     </div>
                                                                     <asp:HiddenField ID="HdFarticid" runat="server" />  
                                                                </center>                                                                                                                                                                                                                                               
                                                        </div>                                                        
                                                    </div>
                                                </div>
                                            </div>                                            
                                            </div> 
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                                                                           
                                        </div>
                                    </div>                                    
                                </div>
                            </div>

                            

                            <!-- MODAL CLIENTES -->                                                
                            <div class="modal fade" id="ModalCliente" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <%--<asp:Button ID="btn_search2" runat="server" class="btn btn-default" data-toggle="modal" data-target="#ModalCliente"/>--%>
                                    <div class="panel panel-primary">                                   
                                        <div class="panel-heading">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="H6">....:::: Stock Disponible Detallado ::::....</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <Triggers></Triggers>
                                                    <ContentTemplate>                                                                                                            
                                                        Codigo : <asp:Label ID="lblCod" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                                        Articulo : <asp:Label ID="lblNam" runat="server"></asp:Label><br />                                                                                                                                                                                                                 
                                                        <br />
                                                        <asp:GridView ID="dgb_stockdisponible" runat="server" AutoGenerateColumns="false"
                                                                       CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}">
                                                            <Columns>                                                            
                                                                <asp:BoundField DataField="colorid" HeaderText="Codigo" SortExpression="colorid" />
                                                                <asp:BoundField DataField="colorname" HeaderText="Color" SortExpression="colorname" />
                                                                <asp:BoundField DataField="sto01" HeaderText="ca01" SortExpression="sto01" />
                                                                <asp:BoundField DataField="sto02" HeaderText="ca02" SortExpression="sto02" />
                                                                <asp:BoundField DataField="sto03" HeaderText="ca03" SortExpression="sto03" />
                                                                <asp:BoundField DataField="sto04" HeaderText="ca04" SortExpression="sto04" />
                                                                <asp:BoundField DataField="sto05" HeaderText="ca05" SortExpression="sto05" />
                                                                <asp:BoundField DataField="sto06" HeaderText="ca06" SortExpression="sto06" />
                                                                <asp:BoundField DataField="sto07" HeaderText="ca07" SortExpression="sto07" />
                                                                <asp:BoundField DataField="sto08" HeaderText="ca08" SortExpression="sto08" />
                                                                <asp:BoundField DataField="sto09" HeaderText="ca09" SortExpression="sto09" />
                                                                <asp:BoundField DataField="sto10" HeaderText="ca10" SortExpression="sto10" />
                                                                <asp:BoundField DataField="sto11" HeaderText="ca11" SortExpression="sto11" />
                                                                <asp:BoundField DataField="sto12" HeaderText="ca12" SortExpression="sto12" />
                                                            </Columns>
                                                         </asp:GridView>                                          
                                                      </ContentTemplate>
                                                </asp:UpdatePanel>                                                
                                                </div>      
                                            </div>   
                                        </div>                                        
                                            <div class="modal-footer">                                                                                                                                                                  
                                                <a href="#" class="btn btn-primary" style=" text-decoration:none;" onclick="Close()">Cerrar</a>             
                                                <%--<asp:Button ID="btn_search2" runat="server" class="btn btn-default" data-toggle="modal" data-target="#ModalCliente"/>--%>                   
                                            </div>
                                            <div style=" display:none;">                                          
                                                <%--<div class="modal-content">
                                        <div class="modal-header">--%> 
                                                <asp:Button runat="server" ID="btnCerrar2" class="btn btn-primary" data-dismiss="modal"/>                                           
                                                <%--<i class="btn btn-primary"></i>   --%>                
                                                <asp:LinkButton ID="btnCerrar" runat="server" CssClass="btn btn-danger" OnClick="btnCerrar_Click">                                                                           
                                                </asp:LinkButton>
                                                <%--<button name="btnCerrar2" type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>--%>                                                                                                                                                                                                            
                                            </div>                                           
                                    </div>
                                </div>
                            </div>                                       
                            <!-- END MODAL CLIENTES -->
                    

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
                                            <asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>                                                                          
                                            <asp:LinkButton ID="LkBCancelSer" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
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
                                            <h4 class="modal-title" id="H1">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto?                                            
                                            <img src="assets/img/attach.png" />                                           
                                            <asp:HiddenField ID="HdFIdUpd" runat="server" />      
                                            <!--<asp:TextBox ID="LblIdUpd" runat="server" Visible="False"></asp:TextBox>-->
                                        </div>
                                        <div class="modal-footer">                                            
                                            <asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelUpd" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Update -->


                            <!-- Modal Delete -->
                            <div class="modal fade" id="myModalDelete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea eliminar el registro?
                                            <asp:TextBox ID="LblIdDel" runat="server"></asp:TextBox>                                            
                                            
                                        </div>
                                        <div class="modal-footer">              
                                            <asp:LinkButton ID="LkBDelete" CssClass="btn btn-default" runat="server">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelDel" CssClass="btn btn-primary" data-dismiss="modal" runat="server">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Delete -->

                           
                           
                <!-- /. ROW  -->
    
    
                                 
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
