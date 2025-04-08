<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.cs" Inherits="Aceoffix7_Net.SaveAndSearch.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        // Get the value of the third parameter from the parent page's openWindow function
        var param = aceoffixctrl.WindowParams;
        var paramArr = param.split(",");
        var strKey = paramArr[0];
        var id = paramArr[1];

        function Save() {
            var myObject = {};
            myObject.id = id;
            var params = new URLSearchParams(myObject);
            var saveUrl = "/SaveAndSearch/SaveFile";
            aceoffixctrl.SaveFilePage = `${saveUrl}?${params.toString()}`;
            aceoffixctrl.WebSave();
        }

        function SetKeyWord(key, visible) {
            if (key == "null" || "" == key) {
                alert("The keyword is empty.");
                return;
            }
            let falg = true;
            aceoffixctrl.word.HomeKey(6);
            while (falg) {
                if (aceoffixctrl.word.FindNextText(key)) {
                    if (visible) {
                        aceoffixctrl.word.SetHighlightToSelection(7);
                    } else {
                        aceoffixctrl.word.SetHighlightToSelection(0);
                    }
                } else {
                    aceoffixctrl.word.HomeKey(6)
                    break;
                }
            }

        }

        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="Button1" type="button" onclick="SetKeyWord(strKey, true)" value="Highlight Keyword" />
        <input id="Button2" type="button" onclick="SetKeyWord(strKey, false)" value="Remove Highlight" />
        <div style="width: auto; height: 900px;">
            <%=aceCtrl.GetHtml()%>
        </div>
    </form>
</body>
</html>
