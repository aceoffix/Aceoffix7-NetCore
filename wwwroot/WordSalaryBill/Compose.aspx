<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compose.cs" Inherits="Aceoffix7_Net.WordSalaryBill.Compose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SimpleWord</title>
</head>
<body>
    <script type="text/javascript">s
        function SaveAs() {
            aceoffixctrl.ShowDialog(3);
        }
        function PrintSet() {
            aceoffixctrl.ShowDialog(5);
        }
        function PrintFile() {
            aceoffixctrl.ShowDialog(4);
        }
        function Close() {
            aceoffixctrl.CloseWindow();
        }
        function IsFullScreen() {
            aceoffixctrl.FullScreen =
                !aceoffixctrl.FullScreen;
        }
        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("SaveAs", "SaveAs", 5);
            aceoffixctrl.AddCustomToolButton("PrintSet", "PrintSet", 8);
            aceoffixctrl.AddCustomToolButton("Print", "PrintFile", 6);
            aceoffixctrl.AddCustomToolButton("FullScreen", "IsFullScreen", 4);  
            aceoffixctrl.AddCustomToolButton("Close", "Close", 9);
        }
    </script>
	<div style="width:auto;height:98vh;">
           <%=aceCtrl.GetHtml() %>
    </div>
</body>
</html>
