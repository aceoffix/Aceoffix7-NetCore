<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.cs" Inherits="Aceoffix7_Net.ExcelTable.Table" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control the Hiding and Showing of the Title Bar, Menu Bar, Custom Toolbar, and Office Toolbar</title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false; // Hide the custom toolbar
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: auto; height: 98vh;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
