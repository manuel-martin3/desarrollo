<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Comercial_Listados_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
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

    <script type="text/javascript">
        function Leer(par) {
            var
            color = '#A80024',
            Texcolor = '#ffffff';
            document.getElementById("txtTabla").value = par;
            document.getElementById("txtTabla").style.color = Texcolor;
            document.getElementById("txtTabla").style.background = color;
            document.getElementById("Divtxtmsg").style.color = Texcolor;
            document.getElementById("Divtxtmsg").style.background = color;
            document.getElementById("Divtxtmsg").style.height = '50px';
        }

    </script>
     <script type='text/javascript'>
         function obtenerOrg() {
             var Button1 = document.getElementById("<%= Button1.ClientID %>");
                document.getElementById("<%= HdF2.ClientID %>").value = document.getElementById("txtTabla").value;
                Button1.click();
            }
     </script>
    

</head>
<body>
    <form id="form1" runat="server">
<table style= " width:1125px;">
     <tr>
     <td>
        <table style=" width:100%;">
            <tr>
                <td style = " text-align:center;"> 
                    <asp:Label ID="Label4" runat="server" Text="LISTA DE EMPRESAS REGISTRADAS" CssClass = 'titulo1'></asp:Label>                    
                </td>
            </tr>        
            <tr>
                <td>
                    
                </td>
            </tr>        
        </table>
     </td>     

        <td style=" text-align:right;" class="style1">
            <asp:Image ID="Image2" runat="server" Height="52px" 
                ImageUrl="~/Images/Logo.png" Width="171px" />                
        </td>               
    </tr>
    <tr>
        <td colspan="2" style = "text-align:left;">    
            <hr />
            * Presione <b>[Seleccionar]</b> , para elegir una Empresa con la cual se emitirá el Permiso de Trabajo, luego presione botón <b>Aceptar</b>
            <br />            
            <br />             
        </td>
    </tr>
    <tr>
        <td colspan="2" style = "text-align:left;">    
   <div>
        <asp:GridView ID="GridViewOrg" runat="server" AutoGenerateColumns="True" 
             CssClass="grid sortable {disableSortCols: [0,2]}" 
            onrowcommand="GridViewOrg_RowCommand">
            <Columns>                
                <asp:TemplateField HeaderText="">
                <ItemTemplate>                    
                    <a href="#" style=" text-decoration:none; color:Black;" onclick="Leer('<%#Eval("descrip").ToString()%>');" )">[Seleccionar]</a>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="key" HeaderText="EMPRESA" SortExpression="key" />
                <asp:BoundField DataField="descrip" HeaderText="DOCUMENTO" SortExpression="descrip" />

            </Columns>
        </asp:GridView>
    </div>    
    
        </td>
    </tr>
    <!--
                <ItemTemplate>                    
                    <a href="#" style=" text-decoration:none; color:Black;" onclick="Leer('<%#Eval("sNombre").ToString()%>');" )">[Seleccionar]</a>
                </ItemTemplate>

        -->
    <tr>
        <td colspan=2>
            <hr /><asp:HiddenField ID="HdF2" runat="server" />
        </td>
    </tr>
    <tr>
        <td id="Divtxtmsg" style = "text-align:center;" colspan="2">           
            <input name="txtTabla" type="text" id="txtTabla" value="" style =" text-align:center; font-size:24px; text-transform:uppercase; font-weight:bold; width:100%; border:none;" />                     
            <asp:Label ID="lblErr" runat="server" Visible="False" CssClass='tex1, titulo2'></asp:Label>                  
            <br /><br />
            
            <asp:Button ID="Button1" runat="server" Text="Aceptar" OnClientClick = 'obtenerOrg();' CssClass= 'boton' Visible="True" />             
        </td>
    </tr>

</table>

    </form>
</body>
</html>
