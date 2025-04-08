<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.TitleText.Word" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demonstration: Modify the Text Content of the  Aceoffix Control Title Bar</title>
    <style>
        html, body
        {
            height: 100%;
        }
      .main
        {
            height: 100%;
        }
    </style>
    <script type="text/javascript">

        function OnAceoffixCtrlInit() {
            // Set the Caption property of aceoffixctrl to display the title bar content
            aceoffixctrl.Caption = "This is controlled by the Caption property of aceoffixctrl and can be set to the title bar content you want to display";
            aceoffixctrl.CustomToolbar = false; // Hide the custom toolbar
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 12px; line-height: 20px; border-bottom: dotted 1px #ccc; border-top: dotted 1px #ccc;
        padding: 5px;">
        Key code: <span style="background-color:Yellow;">aceoffixctrl.Caption = "This is controlled by the Caption property of aceoffixctrl and can be set to the title bar content you want to display";</span>
    </div>
    <div style="height: 900px; width: auto;">
         <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
