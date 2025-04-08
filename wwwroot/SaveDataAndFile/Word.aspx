<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.SaveDataAndFile.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            var saveUrl = "/SaveDataAndFile/SaveFile";
            var saveDataUrl = "/SaveDataAndFile/SaveData";
            aceoffixctrl.SaveFilePage = saveUrl;
            aceoffixctrl.SaveDataPage = saveDataUrl;
            aceoffixctrl.WebSave();
            // Get the save result and perform the next business logic based on it. The return values of saving data and saving the file are separated by \n.
            let saveResult = aceoffixctrl.CustomSaveResult;
            let saveDataResult = saveResult.split("\n")[0];
            let saveFileResult = saveResult.split("\n")[1];
            alert("Data save result: " + saveDataResult);
            alert("File save result: " + saveFileResult);
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>          
            <span style="color: Red; font-size: 14px;">Please enter the company name:</span><input id="CompanyName" name="CompanyName" type="text" /><br />
        </div>
        <div style="width: auto; height: 800px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
