<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveReturnValue.cs" Inherits="Aceoffix7_Net.SaveReturnValue.SaveReturnValue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            var saveUrl = "/SaveReturnValue/SaveFile";
            aceoffixctrl.SaveFilePage = saveUrl;
            aceoffixctrl.WebSave();
            // The value returned by aceoffixctrl.CustomSaveResult is defined by the background code fs.CustomSaveResult = "OK"; in the save page.
            alert("Saved successfully. The return value is: " + aceoffixctrl.CustomSaveResult);
        }


        function OnAceoffixCtrlInit() {
            aceoffixctrl.Caption = "Demo: Return value of saving";
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:small; color:Red;">
        <asp:Label ID="Label4" runat="server" Text="Key code: Right-click and select 'View source file' to see the js function 'Save()':"></asp:Label>
        <br />aceoffixctrl.WebSave(); // Perform the save operation
        <br/>aceoffixctrl.CustomSaveResult // Get the return value defined by the background code fs.CustomSaveResult = "OK"; in the save page SaveFile.cs
        <br />
    </div>
    <div style=" width:auto; height:900px;">
        <%=aceCtrl.GetHtml()%>
    </div>
    </form>
</body>
</html>
