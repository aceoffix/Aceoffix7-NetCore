<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excel.cs" Inherits="Aceoffix7_Net.DrawExcel.Excel" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            // Hide the custom toolbar
            aceoffixctrl.CustomToolbar = false;
        }
    </script>
</head>
<body>
    <div style="width: auto; height: 850px;">
        <%=aceCtrl.GetHtml()%>
    </div>
</body>
</html>
