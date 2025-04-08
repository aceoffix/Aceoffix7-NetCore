<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.ExtractImage.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieve Images from a Word Document on Save</title>
    <script type="text/javascript">
        function Save() {
            aceoffixctrl.SaveDataPage = "/ExtractImage/SaveData";
            aceoffixctrl.WebSave();
            var value = aceoffixctrl.CustomSaveResult;
            alert(value);
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save Image", "Save", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div style="width:auto;height:900px;">
          <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
