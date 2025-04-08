<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelFill6.cs" Inherits="Aceoffix7_Net.DefinedNameTable.ExcelFill6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false;
        }
    </script>
</head>
<body>
The display effect when data is not dynamically filled.
		<div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
</body>
</html>

