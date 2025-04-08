<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataTag.cs" Inherits="Aceoffix7_Net.WordDataTag2.DataTag" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false; // Hide the custom toolbar

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: auto; height: 92vh;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
