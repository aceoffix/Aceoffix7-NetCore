<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.AfterDocOpened.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function AfterDocumentOpened() {
            // When the file is opened, assign a text value to the current cursor position in Word
           // aceoffixctrl.word.SetTextToSelection("The file has been opened.");
            alert("Hello");
        }
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false; // Hide the custom toolbar
        }
    </script>
    <form id="form1" runat="server">
        <div style=" width:auto; height:98vh;">
            <%=aceCtrl.GetHtml()%> 
        </div>
    </form>
</body>
</html>