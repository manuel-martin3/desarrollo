<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lst_ProformaPendAprob.aspx.cs" Inherits="Comercial_Listados_Lst_ProformaAprob" %>

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



<script type="text/javascript">    
    function Leer(val1, val2, val3, val4, val5, val6) {

        $('#<%=HdF2.ClientID%>').val(val1);                        

        $('#<%=HdFIdSer.ClientID%>').val(val1);                        
        $('#<%=HdFIdUpd.ClientID%>').val(val1);                            
        $('#<%=LblIdDel.ClientID%>').val(val1);                    
        $('#<%=LblIdDoc.ClientID%>').text(val1);                   
        $('#<%=LblIdNam.ClientID%>').text(val2);                   
        $('#<%=LblIdRuc.ClientID%>').text(val3);    
        $('#<%=LblCond.ClientID%>').text(val4);            
        $('#<%=LblIdObs.ClientID%>').text(val6).trim;  
        
        $('#<%=HdF1.ClientID%>').val(val5); // AL LEVANTAR EL POPUP DENTRA A ESTA FUNCION Y ASIGNA EL VALOR  AL --> HDF1

        switch (val5.toString()) {
            case "11":
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').addClass('panel panel-warning')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;

            case "19":
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').addClass('panel panel-danger')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;

            case "22":
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').addClass('panel panel-success')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;

            case "29":
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').addClass('panel panel-danger')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;
                   
            case "32":
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').addClass('panel panel-success')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;

            case "39":
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').addClass('panel panel-danger')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;

            default:
                $('#detCli').removeClass('panel panel-success')
                $('#detCli').removeClass('panel panel-danger')
                $('#detCli').removeClass('panel panel-warning')
                $('#detCli').addClass('panel panel-warning')
                $('#image').attr({ src: "assets/table/IMG_PNG/" + val5.toString() + ".png" })
                $('#Cmb_Estados [value="' + val5.toString() + '"]').attr('selected', true);
                $('#resultado').text(val5.toString());
                break;
        }
    }



    function ShowSelected() {
        var combo = document.getElementById("Cmb_Estados");
        //var selected = combo.options[combo.selectedIndex].val
        var porId = document.getElementById("Cmb_Estados").value;
        $('#<%=HdF1.ClientID%>').val(porId);
        //alert(porId);
        //document.getElementById("HdF1").value = selected.value;       
    }

    function Show(val1, val2)
    {
        $('#<%=HdFIdSer.ClientID%>').val(val1);
        $('#<%=HdFSerdoc.ClientID%>').val(val2);
        var Button1 = document.getElementById('btn_search');
        Button1.click();      
    }

    function Show2(val1, val2)
    {
        $('#<%=HdFIdUpd.ClientID%>').val(val1);
        $('#<%=HdFSerdoc.ClientID%>').val(val2);
        var Button1 = document.getElementById('btn_search2');
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
                        <h2><center> ...:: PEDIDOS PENDIENTES DE APROBACIÓN ::..</center></h2>                           
                    </div>
                </div>
                 <!-- /. ROW  -->
                <%-- <hr />--%>



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
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="modal-body">
                                                    <div class="panel-body">
                                                        <div class="table-responsive">
                                                                <center>

                                                               <asp:GridView ID="GridViewProd" runat="server" AutoGenerateColumns="false" 
                                                                     CssClass="table table-striped table-bordered table-hover grid sortable {disableSortCols: [0,4]}" 
                                                                   onrowcommand="GridView_RowCommand" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                                                                    <Columns>                
                                                                        <asp:BoundField DataField="nmruc" HeaderText="R.U.C." SortExpression="key" />
                                                                        <asp:BoundField DataField="ctactename" HeaderText="Cliente" SortExpression="ctactename" />
                                                                        <asp:BoundField DataField="serdoc" HeaderText="serdoc" SortExpression="serdoc" Visible="false" />
                                                                        <asp:BoundField DataField="numdoc" HeaderText="Documento" SortExpression="numdoc" />
                                                                        <asp:BoundField DataField="vendorname" HeaderText="Vendedor" SortExpression="vendorname" />

                                                                        <asp:TemplateField HeaderText="&nbsp;[ESTADO]" ControlStyle-CssClass="odd gradeX" HeaderStyle-CssClass="Center"  ItemStyle-CssClass="Center">
                                                                        <ItemTemplate>              
                                                                            <a href="#" data-toggle="modal" data-target="#myModalStatus" class="btn btn-link" style=" text-decoration:none;" onclick="Leer('<%#Eval("numdoc").ToString()%>','<%#Eval("ctactename").ToString()%>','<%#Eval("nmruc").ToString()%>','<%#Eval("condicion").ToString()%>','<%#Eval("status").ToString()%>','<%#Eval("aprob_obser").ToString()%>');" )">
                                                                            &nbsp;&nbsp;<asp:Image ID="Image1"  runat="server" ImageUrl='<%# Eval("imgEstado") %>'/>                                                    
                                                                            </a>                                                    
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>                                                       

                                                                        <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DOCUMETOS ADJUNTOS]" ControlStyle-CssClass="odd gradeX" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>                                                             
                                                                            <a href="#" class="btn btn-info" style=" text-decoration:none;" onclick="Show('<%#Eval("numdoc").ToString()%>','<%#Eval("serdoc").ToString()%>');" )"><i class="fa fa-print"></i> Pedido &nbsp;</a>                                                  
                                                                            <a href="#" class="btn btn-info" style=" text-decoration:none;" onclick="Show2('<%#Eval("numdoc").ToString()%>','<%#Eval("serdoc").ToString()%>');" )"><i class="fa fa-print"></i> Evaluación</a>                                                    
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>                                                 
                                                                    </Columns>
                                                                </asp:GridView>
                                                               <div style=" display:none;">                                        
                                                                    <asp:Button ID="btn_search" runat="server" class="btn btn-default" OnClick="LkBSearch_Click"/>
                                                                    <asp:Button ID="btn_search2" runat="server" class="btn btn-default" OnClick="LkBUpdate_Click"/>
                                                               </div>
                                                               <asp:HiddenField ID="HdFIdSer" runat="server" />
                                                               <asp:HiddenField ID="HdFIdUpd" runat="server" /> 
                                                               <asp:HiddenField ID="HdFSerdoc" runat="server" />
                                             
                                                               </center>                                                                                                                                                                                                                            
                                                            <asp:HiddenField ID="HdFarticid" runat="server" />                                                                                                                                                                                     
                                                        </div> 
                                                    </div>
                                                </div>
                                            </div>                                            
                                        </div>                                                                                                                                  
                                        </div>
                                    </div>                                    
                                </div>
                            </div>

                            
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
                                            <%--<asp:HiddenField ID="HdFIdSer" runat="server" />--%>
                                            <asp:LinkButton ID="LkBSearch" CssClass="btn btn-default" runat="server" OnClick="LkBSearch_Click">Aceptar</asp:LinkButton>                                                                          
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
                                            <h4 class="modal-title" id="H1">Mensaje</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Desea visualizar el archivo adjunto?                                            
                                            <img src="assets/img/attach.png" />                                           
                                               
                                            <!--<asp:TextBox ID="LblIdUpd" runat="server" Visible="False"></asp:TextBox>-->
                                        </div>
                                        <div class="modal-footer">                                            
                                            <asp:LinkButton ID="LkBUpdate" CssClass="btn btn-default" runat="server" OnClick="LkBUpdate_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelUpd" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelUpd_Click">Cancelar</asp:LinkButton>
                                            
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
                                            <asp:LinkButton ID="LkBDelete" CssClass="btn btn-default" runat="server" OnClick="LkBDelete_Click">Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="LkBCancelDel" CssClass="btn btn-primary" data-dismiss="modal" runat="server" OnClick="LkBCancelDel_Click">Cancelar</asp:LinkButton>                                                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal Delete -->
                            <!-- Modal Status -->
                            <div class="modal fade" id="myModalStatus" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">                                                                      
                                    <div class="panel panel-primary">                                   
                                        <div class="panel-heading">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>                                                                                 
                                            <h4 class="modal-title" id="H5">Mensaje</h4>
                                        </div>
                                        
                                        <div class="modal-body">                                            
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <!-- Clientes -->
                                                    <div class="panel panel-danger">                                                                                                            
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
                                                            <br />                                                        
                                                            <asp:DropDownList ID="Cmb_Estados" runat="server" 
                                                                CssClass="form-control" onchange="ShowSelected()" Width="210px">                                                               
                                                            </asp:DropDownList>                                                                                                                                                                                         
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
        </div>        
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
