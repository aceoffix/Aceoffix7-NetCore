<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.CustomToolButton.Word" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function myTest() {
            alert("The test button has been clicked.");
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Test Button", "myTest", 0);
        }
    </script>
</head>
<body>
    <p>Click the "Test Button" in the custom toolbar to see the effect.</p>
    <div style="width: auto; height: 900px;">
        <%=aceCtrl.GetHtml()%>
    </div>
</body>
</html>
