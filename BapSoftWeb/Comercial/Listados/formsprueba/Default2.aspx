<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Comercial_Listados_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />  
    <title></title>  

        <link href="css/styles.css" rel="stylesheet" />
        <script src="scripts/jquery-1.4.2.min.js"></script>
        <script src="scripts/jquery.dataTables.min.js"></script>
        <script src="scripts/jquery.metadata.js"></script>



    <style type ="text/css">
    .boton {
    background: #ffffff url('/Grilla/IMG_PNG/boton.png')repeat-x;    
    border: solid 1px #CCCCCC;
    background-repeat: repeat-x;
    height: 30px;
    font-family: "Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif;
    cursor: pointer;
    width: 130px;
    }
    
.tex1
        {width:150px; 
         padding: 0px 0px 0px 0px;
         }
         
.tex2
        {
        font-size: 14px;
        background-color: transparent;
        color: #A80024;    
        font-family: Calibri;   
        padding: 0px 0px 0px 0px;                
        font-weight:bold;
         }
         
.tex3
        {
        font-size: 12px;
        background-color: transparent;
        color: #000000;    
        font-family: Calibri;   
        padding: 0px 0px 0px 0px;                
        font-weight:lighter;
         }
         
.titulo1{    
    font-size: 22px;
    background-color: transparent;
    color: #A80024;    
    font-family: Calibri;   
    font-weight:bold;
    text-transform:uppercase;
} 

.titulo2{    
    font-size: 16px;
    background-color: transparent;
    color: #A80024;    
    font-family: Calibri;   
}    
</style>  
    <script type="text/javascript">
        $(document).ready(function () {

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
                if (jTbl.hasClass("sortable") && jTbl.find("tbody:first > tr").length > 10) {

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
        });

    </script>
</head>  
<body>  
    <form id="form1" runat="server">  
      
          <div>  
            <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"  
                runat="server" CssClass="grid sortable {disableSortCols: [0,2]}" 
                AutoGenerateColumns="false">  
                <Columns>  
                    <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />  
                    <asp:BoundField DataField="Name" HeaderText="Nombre" ItemStyle-Width="150" />  
                    <asp:BoundField DataField="Country" HeaderText="Ciudad" ItemStyle-Width="150" />  
                <asp:TemplateField HeaderText="">
                <ItemTemplate>                    
                    <a href="#" style=" text-decoration:none; color:Black;" onclick="Leer('<%#Eval("Name").ToString()%>');" )">[Seleccionar]</a>
                    <a href="#" style=" text-decoration:none; color:Black;" onclick="Leer('<%#Eval("Name").ToString()%>');" )">[Seleccionar]</a>
                    <a href="#" style=" text-decoration:none; color:Black;" onclick="Leer('<%#Eval("Name").ToString()%>');" )">[Seleccionar]</a>
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>  
            </asp:GridView>  
        </div>  

    </form>  

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
</body>  
</html>  
