<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.DataTagEdit.Word" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .Word {
            margin: 0;
            padding: 0;
            display: flex;
        }

        #left-container {
            width: 400px;
            display: flex;
            flex-direction: column;
            border-right: 2px solid #ccc;
            padding: 20px;
            overflow: auto;
            font-size: 12px;
            height: 90vh;
        }

        #right-container {
            flex: 1;
            padding: 0px;
            height: 95vh;
        }

        #podiv {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #left-title {
            text-align: center;
            font-size: 16px;
            padding-bottom: 10px;
            margin-bottom: 10px;
            border-bottom: solid 1px #ccc;
        }

        .input-group {
            margin-bottom: 20px;
            display: flex;
            align-items: center;
        }

        input[type="text"] {
            width: 75%;
            padding: 10px;
            margin-top: 5px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 12px;
            outline: none;
        }

        input[type="submit"] {
            width: 80px;
            padding: 10px;
            margin-top: 5px;
            margin-left: 10px;
            box-sizing: border-box;
            border: none;
            border-radius: 5px;
            background-color: #4E6EF2;
            color: white;
            font-size: 12px;
            outline: none;
            cursor: pointer;
        }
        /* Table style */
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        th {
            position: sticky;
            top: 0;
            background-color: #f2f2f2;
            z-index: 1;
        }
        /* Container style */
        .container {
            height: 500px;
            overflow: auto;
            border: solid 1px #ccc;
            scrollbar-width: thin;
            scrollbar-color: #888 #f2f2f2;
        }
            /* Scrollbar style */
            .container::-webkit-scrollbar {
                width: 8px;
            }

            .container::-webkit-scrollbar-track {
                background: #f2f2f2;
            }

            .container::-webkit-scrollbar-thumb {
                background-color: #888;
                border-radius: 4px;
            }

         .container::-webkit-scrollbar-thumb:hover {
            background-color: #555;
          }

        .delete-button {
            padding: 6px 6px;
            border: none;
            border-radius: 5px;
            background-color: #f44336;
            color: white;
            font-size: 12px;
            cursor: pointer;
        }

        .delete-button:hover {
            background-color: #d32f2f;
        }

        .normal-button {
            padding: 6px 6px;
            border: none;
            border-radius: 5px;
            background-color: #4E7EFF;
            color: white;
            font-size: 12px;
            cursor: pointer;
        }

       .normal-button:hover {
            background-color: #4E6EF2;
       }

        .locate-button {
            padding: 6px 6px;
            border: none;
            border-radius: 5px;
            background-color: #0abb87;
            color: white;
            font-size: 12px;
            cursor: pointer;
        }

       .locate-button:hover {
            background-color: #0a9966;
        }
    </style>

    <script type="text/javascript">
        var definedDataTagJson = '';
        var isFromStart = false;
        var lastOpTag = '';


        function Save() {
            var saveUrl = "/DataTagEdit/SaveFile";
            aceoffixctrl.SaveFilePage = saveUrl;
            aceoffixctrl.WebSave();
        }
        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }

        function loadData() {
            var kWord = document.getElementById("inputKey").value;
            searchDataTag(definedDataTagJson, kWord);
            return;
        }

        function searchDataTag(dtDefinedJson, s) {
            var tb1 = document.getElementById("tagTable");
            var rCount = tb1.rows.length;
            for (var i = 1; i < rCount; i++) {
                tb1.deleteRow(1);
            }

            if ('' == dtDefinedJson) dtDefinedJson = '[]';
            let definedDataTagObj = JSON.parse(dtDefinedJson);

            var oTable = document.getElementById("tagTable");
            var tbodyObj = oTable.tBodies[0];
            for (let key in definedDataTagObj) {
                let dtName = definedDataTagObj[key].name;
                if (dtName.toLocaleLowerCase().indexOf(s.toLocaleLowerCase()) > -1) {
                    var oTr = tbodyObj.insertRow();
                    var oTd = oTr.insertCell();
                    oTd.innerHTML = dtName;
                    oTd.title = dtName;
                    oTd = oTr.insertCell();
                    oTd.innerHTML = '<button class="delete-button" onclick="deleteTag(\'' + dtName + '\')">Delete</button> <button class="locate-button" onclick="locateTag(\'' + dtName + '\')" >Loate</button> <button class="normal-button" onclick="addTag(\'' + dtName + '\');">Add</button> ';
                }
            }
        }

        function addTag(tagName) {
            aceoffixctrl.word.SetTextToSelection(tagName);
        }

        function locateTag(tagName) {
            aceoffixctrl.word.SelectionCollapse(0);

            if (isFromStart) {
                if (lastOpTag == tagName) {
                    aceoffixctrl.word.HomeKey(6);
                }

                isFromStart = false;
            }

            if (!aceoffixctrl.word.FindNextText(tagName)) {
                alert('Reached the end of the document');
                isFromStart = true;
            }

            lastOpTag = tagName;
        }

        function deleteTag(tagName) {
            let selectText = aceoffixctrl.word.GetTextFromSelection();
            if (tagName != selectText) {
                alert('Please perform the locate operation for‘' + tagName + '’and then delete it.');
            } else {
                aceoffixctrl.word.SetTextToSelection('');
            }
        }

        function AfterDocumentOpened() {
            definedDataTagJson = aceoffixctrl.word.DataTagsDefinedAsJson;
            loadData();
        }
    </script>
</head>
<body>
    <div class="Word">
        <div id="left-container">
            <div id="left-title">Defined DataTags</div>
            <div class="input-group">
                <span style="font-size: 14px;">Tags to Add:</span><input type="text" id="inputKey" oninput="loadData();" placeholder="Please enter the keyword of the datatag to search">
            </div>
            <div class="container">
                <table id="tagTable">
                    <thead>
                        <tr>
                            <th>DataTag</th>
                            <th style="width: 150px;">Operation</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>
        <!-- Right-side content -->
        <div id="right-container">
            <div id="podiv" style="width: auto; height: 850px;">
                <%=aceCtrl.GetHtml()%>
            </div>
        </div>
    </div>
</body>
</html>
