<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendParameters.cs" Inherits="Aceoffix7_Net.SendParameters.SendParameters" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Save() {
            var myObject = {};
            myObject.id = "1";
            var params = new URLSearchParams(myObject);
            var saveUrl = "/SendParameters/SaveFile";
            aceoffixctrl.SaveFilePage = `${saveUrl}?${params.toString()}`;
            aceoffixctrl.WebSave();
            alert(aceoffixctrl.CustomSaveResult);
        }

        function IsFullScreen() {
            aceoffixctrl.FullScreen =
                !aceoffixctrl.FullScreen;
        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.Caption = "Demo: Pass parameters to the save page and update personnel information";
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
            aceoffixctrl.AddCustomToolButton("Full screen", "IsFullScreen", 4);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 14px;">
    <div style="border:1px solid black;">Three ways for Aceoffix to pass values to the save page:<br/>
          <span>1. Pass parameters to the save page by setting the '?' in the URL of the save page:</span><br/>
          <span>2. Pass parameters to the save page through the input hidden field:</span><br/>  
          <span>3. Pass parameters to the save page through Form controls (here, Form controls include controls of types such as input boxes, drop - down boxes, radio buttons, checkboxes, and TextArea):</span><br/>
                
    </div>
        <span style="color: Red;">Update personnel information:</span><br />
        <input id="age" name="age" type="hidden" value="25" />
        <span style="color: Red;">Name:</span><input id="userName" name="userName" type="text" value="John" /><br />
    </div>
    <!--aceoffix control-->
    <div style="width: auto; height: 900px;">
        <%=aceCtrl.GetHtml()%>
    </div>
    </form>
</body>
</html>