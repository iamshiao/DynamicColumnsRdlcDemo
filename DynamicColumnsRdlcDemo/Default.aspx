<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicColumnsRdlcDemo.Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dynamic Columns RDLC Demo</title>
</head>
<body>
    <h2>Dynamic Columns RDLC Demo</h2>
    <form id="form1" runat="server">
        <div>
            <rsweb:ReportViewer ID="ReportViewer_main" runat="server" Height="500px" Width="1280px"></rsweb:ReportViewer>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
