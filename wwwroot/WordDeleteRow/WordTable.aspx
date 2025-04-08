<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordTable.cs" Inherits="Aceoffix7_Net.WordDeleteRow.WordTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove the Row Containing a Specific Cell in a Word Table</title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false; // Hide the custom toolbar
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="color:Red">The row containing the cell at coordinates (2,1) in the table has been deleted. Please check the original template document at the path <%=filePath%>.</div>
    <div style="width:auto; height:900px;">
       <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>