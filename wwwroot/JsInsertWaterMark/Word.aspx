<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.JsInsertWaterMark.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Wartermark with JS</title>
</head>
<body>
    <script type="text/javascript">
        // Event handler for when the  Aceoffix control is initialized.
        function OnAceoffixCtrlInit() {
            aceoffixctrl.CustomToolbar = false;
        }

        function AfterDocumentOpened() {
            aceoffixctrl.word.SetWaterMark("Aceoffix");//Watermark Text
        }
    </script>
    <form id="form1" runat="server">
    <div style="width:auto; height: 850px;" >
        <%=aceCtrl.GetHtml()%>
    </div>
    </form>
</body>
</html>
