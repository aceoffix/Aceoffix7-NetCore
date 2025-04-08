<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelFill2.cs" Inherits="Aceoffix7_Net.ExcelFill2.ExcelFill2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.Caption = "Simply assign values to Excel";
            aceoffixctrl.CustomToolbar = false;
        }
    </script>
</head>
<body>
        <div style="width: auto; height:900px;">
            <%=aceCtrl.GetHtml()%> 
        </div>
</body>
</html>
