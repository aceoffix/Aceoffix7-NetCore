<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excel.cs" Inherits="Aceoffix7_Net.ExcelDisableRight.Excel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Disable Right-Click in Excel</title>
    <script type="text/javascript">
        function OnAceoffixCtrlInit() {
            // Hide the custom toolbar
            aceoffixctrl.CustomToolbar = false; 
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="color:Red">After opening the Excel document, try right-clicking the mouse. You'll find that the right-click function is disabled.</div>
        <div style=" width:auto; height:90vh;">
            <%=aceCtrl.GetHtml()%> 
        </div>
    </form>
</body>
</html>