<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.BeforeAndAfterSave.Word" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Events Executed Before and After Document Saving</title>
</head>
<body>
    <script type="text/javascript">

        function Save() {
            // Write your code here to be executed before saving
            alert("The file is about to be saved...");
            aceoffixctrl.SaveFilePage = "/BeforeAndAfterSave/SaveFile";
            aceoffixctrl.WebSave();
            // Write your code here to be executed after saving, such as checking the save result aceoffixctrl.CustomSaveResult
            if ("ok" == aceoffixctrl.CustomSaveResult) {
                alert("The file has been saved successfully.");
            } else {
                alert("Save failed!");
            }
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
    <form id="form1" runat="server">
        <div style=" width:auto; height:850px;">
            <%=aceCtrl.GetHtml()%> 
        </div>
    </form>
</body>
</html>
