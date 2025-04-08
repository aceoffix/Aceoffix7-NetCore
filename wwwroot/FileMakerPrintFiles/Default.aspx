<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.FileMakerPrintFiles.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table {
            border: solid 1px #ccc;
            width: 600px;
            margin: 20px;
        }

        th {
            border-bottom: solid 1px #ccc;
            text-align: left;
            padding: 5px;
        }

        td {
            padding: 5px;
        }
    </style>
    <style type="text/css">
        .progressBarContainer {
            width: 100%;
            background-color: #eee;
            border-radius: 5px;
            padding: 3px;
            box-shadow: 2px 2px 3px 3px #ccc inset;
        }

        .progressBar {
            height: 20px;
            width: 0%;
            background-color: #1A73E8;
            border-radius: 5px;
            text-align: center;
            line-height: 20px; /* Center text vertically */
            color: white;
        }

        #progressDiv {
            width: 400px;
            margin: 10px auto;
            text-align: left;
            font-size: 14px;
            border: solid 1px #1A73E8;
            padding: 10px 20px;
            color: #1A73E8;
        }

        #errorMsg {
            color: red;
        }
    </style>
    <script type="text/javascript" src="../aceoffix.js"></script>
    <script type="text/javascript">
        var checkit = true;
        function selectall() {
            if (checkit) {
                var obj = document.all.check;
                for (var i = 0; i < obj.length; i++) {
                    obj[i].checked = true;
                    checkit = false;
                }
            } else {
                var obj = document.all.check;
                for (var i = 0; i < obj.length; i++) {
                    obj[i].checked = false;
                    checkit = true;
                }

            }

        }

        function PrintFiles() {
            var ids = [];
            var checkboxes = document.getElementsByName('check');

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    ids.push(checkboxes[i].value);
                }
            }

            if (0 == ids.length) {
                alert('Please select at least one document');
                return;
            }

            document.getElementById("Button1").disabled = true;
            ConvertFile(ids, 0);
        }

        function ConvertFile(idArr, index) {
            var myObject = {};
            myObject.id = idArr[index];
            var params = new URLSearchParams(myObject);

            var openFileUrl = "/FileMakerPrintFiles/FileMaker";
            filemakerctrl.SetPrint();//Print
            filemakerctrl.CallFileMaker({
                url: `${openFileUrl}?${params.toString()}`,
                success: function () {
                    console.log("Completed successfully.");
                    setProgress1(100);

                    index++;
                    setProgress2(index, idArr.length);

                    if (index < idArr.length) {
                        ConvertFile(idArr, index);
                    }
                },
                progress: function (pos) {
                    console.log("Running " + pos + "%");
                    setProgress1(pos);
                },
                error: function (msg) {
                    document.getElementById("errorMsg").innerHTML = "An error occurred: <br /> " + msg;
                    console.log("Error occurred: " + msg);
                }
            });
        }

        function setProgress1(percent) {
            var progressBar = document.getElementById("progressBar1");
            progressBar.style.width = percent + '%';
            progressBar.innerText = percent + '%';
        }

        function setProgress2(index, count) {
            var progressBar = document.getElementById("progressBar2");
            progressBar.style.width = Math.round(index / count * 100) + '%';
            progressBar.innerText = index + '/' + count;
        }

    </script>
</head>
<body>
    <div style="margin: 100px" align="center">
        <h3>Demo: Batch Print Files</h3>
        <div style="width: 600px; margin: 0 auto; font-size: 14px;">
            <p style="text-align: left;">
                Demo Content:<br />
                &nbsp;&nbsp;&nbsp;&nbsp;This example demonstrates the effect of batch printing files using Word as an example. After selecting the files, click the "Batch Print File" button.
            </p>
        </div>
        <table id="table1">
            <h3>File List</h3>
            <tr>
                <th>
                    <input name="checkAll" type="checkbox" onclick="selectall()" /></th>
                <th>Serial Number</th>
                <th>Filename</th>
                <th>Action</th>
            </tr>
            <tr>
                <td>
                    <input name="check" type="checkbox" value="1" /></td>
                <td>01</td>
                <td>Aceoffix Product Overview</td>
                <td><a href="javascript:AceBrowser.openWindow('Preview?id=1','width=1150px;height=800px;');">Preview</a></td>
            </tr>
            <tr>
                <td>
                    <input name="check" type="checkbox" value="2" /></td>
                <td>02</td>
                <td>Aceoffix Trial Limits</td>
                <td><a href="javascript:AceBrowser.openWindow('Preview?id=2','width=1150px;height=800px;');">Preview</a></td>
            </tr>
            <tr>
                <td>
                    <input name="check" type="checkbox" value="3" /></td>
                <td>03</td>
                <td>Aceoffix License Policy</td>
                <td><a href="javascript:AceBrowser.openWindow('Preview?id=3','width=1150px;height=800px;');">Preview</a></td>
            </tr>
            <tr>
                <td>
                    <input name="check" type="checkbox" value="4" /></td>
                <td>04</td>
                <td>Introduction to Aceoffix</td>
                <td><a href="javascript:AceBrowser.openWindow('Preview?id=4','width=1150px;height=800px;');">Preview</a></td>
            </tr>
        </table>

        <input type="button" id="Button1" value="Batch Print File" onclick="PrintFiles()" />

        <div id="progressDiv">
            Single File Progress:
		<div class="progressBarContainer">
            <div id="progressBar1" class="progressBar"></div>
        </div>
            Overall Progress:
		<div class="progressBarContainer">
            <div id="progressBar2" class="progressBar"></div>
        </div>
            <div id="errorMsg"></div>
        </div>
    </div>

</body>
</html>
