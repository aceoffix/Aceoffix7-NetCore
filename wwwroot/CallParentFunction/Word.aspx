<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.CallParentFunction.Word" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            function increaseCount(value) {
                CallParentFunc({
                    funcName: 'updateCount',
                    paramJson: value,
                    success: function (strRet) {
                        alert("Now the value of Count in the parent window is: " + strRet);
                    },
                    error: function (strRet) {
                        if (strRet.indexOf('parentlost') > -1) {
                            alert('error: The parent page has been closed, redirected, or refreshed, causing the parent page function to fail to be called!');
                        } else {
                            console.error(strRet);
                        }
                    }
                });
            }

            function increaseCountAndClose(value) {
                CallParentFunc({
                    funcName: 'updateCount',
                    paramJson: value,
                    success: function (strRet) {
                        alert("Now the value of Count in the parent window is: " + strRet);
                        aceoffixctrl.CloseWindow();
                    },
                    error: function (strRet) {
                        if (strRet.indexOf('parentlost') > -1) {
                            alert('error: The parent page has been closed, redirected, or refreshed, causing the parent page function to fail to be called!');
                        } else {
                            console.error(strRet);
                        }
                    }
                });
            }

            function OnAceoffixCtrlInit() {
                aceoffixctrl.CustomToolbar = false;
            }
        </script>

        <input type="button" value="Increase the value of Count in the parent window by 1" onclick="increaseCount(1);" />
        <input type="button" value="Increase the value of Count in the parent window by 5 and close the window" onclick="increaseCountAndClose(5);" /><br />
        <div style=" width:auto; height:900px;">
            <%=aceCtrl.GetHtml()%> 
        </div>
    </form>
</body>
</html>

