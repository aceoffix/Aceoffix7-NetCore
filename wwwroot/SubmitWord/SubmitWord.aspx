<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitWord.cs" Inherits="Aceoffix7_Net.SubmitWord.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            var saveUrl = "/SubmitWord/SaveData";
            aceoffixctrl.SaveDataPage = saveUrl;
            aceoffixctrl.WebSave();
            alert("save result:\r\n"+aceoffixctrl.CustomSaveResult);
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="color: Red; font-size: 14px;">Please enter information such as company name, employee name, and department, then click the save button on the toolbar.</span><br />
        <span style="color: Red; font-size: 14px;">Please enter the company name:</span><input id="companyName" name="companyName"
            type="text" /><br />
    </div>
    <div style="width: auto; height: 900px;">
          <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>
