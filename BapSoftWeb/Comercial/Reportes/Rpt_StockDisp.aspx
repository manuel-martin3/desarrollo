<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_StockDisp.aspx.cs" Inherits="Comercial_Reportes_Rpt_StockDisp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="518px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1143px" EnableTheming="True">
            <LocalReport ReportPath="Comercial\Reportes\Rpt_Stock.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DsStock" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
