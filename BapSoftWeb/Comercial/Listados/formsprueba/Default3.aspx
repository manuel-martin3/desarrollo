<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Comercial_Listados_Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Table Test</title>
</head>
<body>
  <form id="Form1" runat="server">
  <div>
    Rows:
    <asp:TextBox ID="txtRows" runat="server" />&nbsp;
    Cols:
    <asp:TextBox ID="txtCols" runat="server" />
    <br /><br />
    <asp:CheckBox ID="chkBorder" runat="server"
         Text="Put Border Around Cells" />
    <br /><br />
    <asp:Button ID="cmdCreate" OnClick="cmdCreate_Click" runat="server" Text="Create"/>
    <br /><br />
    <asp:Table ID="tbl" runat="server" />
  </div>
  </form>
</body>
</html>

