<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitExcel.cs" Inherits="Aceoffix7_Net.SubmitExcel.SubmitExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function SaveData() {
            aceoffixctrl.SaveDataPage = "/SubmitExcel/SaveData";
            aceoffixctrl.WebSave();
            alert("save result:\r\n" + aceoffixctrl.CustomSaveResult);
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.Caption = "Excel spreadsheet used as an input form.";
            // Create custom toolbar
            aceoffixctrl.AddCustomToolButton("Save", "SaveData()", 1);
            aceoffixctrl.AddCustomToolButton("-", "", 0);
            aceoffixctrl.AddCustomToolButton("Print", "ShowPrintDlg()", 6);
            aceoffixctrl.AddCustomToolButton("-", "", 0);
            aceoffixctrl.AddCustomToolButton("Full-screen Switch", "SwitchFullScreen()", 4);
        }
        function ShowPrintDlg() {
            aceoffixctrl.ShowDialog(4); //Print dialog box
        }
        function SwitchFullScreen() {
            aceoffixctrl.FullScreen = !aceoffixctrl.FullScreen;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: auto; height: 98vh;">
          <%=aceCtrl.GetHtml()%> 
    </div>
    </form>
</body>
</html>

