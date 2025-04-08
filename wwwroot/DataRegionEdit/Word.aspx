<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.cs" Inherits="Aceoffix7_Net.DataRegionEdit.Word" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .Word {
            margin: 0;
            padding: 0;
            display: flex;
        }
        #left-container {
            width: 360px;
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
        #podiv{
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
        }
        #left-title{
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
            width: 70%;
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

       
        .container {
            height: 300px;
            overflow: auto;
            border: solid 1px #ccc;
            scrollbar-width: thin;
            scrollbar-color: #888 #f2f2f2;
        }

      
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
        // Some commonly used methods in the control are called here, such as saving, printing, and so on.
        function OnAceoffixCtrlInit() {
            aceoffixctrl.AddCustomToolButton("Save", "Save", 1);
        }
        function Save() {
            var saveUrl = "/DataRegionEdit/SaveFile";
            aceoffixctrl.SaveFilePage = saveUrl;
            aceoffixctrl.WebSave();
        }

        function loadData() {
            var kWord1 = document.getElementById("inputKey1").value;
            var kWord2 = document.getElementById("inputKey2").value;

            var definedDataRegionJson = aceoffixctrl.word.DataRegionsDefinedAsJson;
            var dataRegionJson = aceoffixctrl.word.DataRegionsAsJson;
            searchDataRegion(definedDataRegionJson, dataRegionJson, kWord1);
            searchDataRegion2(dataRegionJson, kWord2);
        }


        function searchDataRegion(drDefinedJson, drJson, s){
            var tb1 = document.getElementById("bkmkTable");
            var rCount = tb1.rows.length;
            for (var i = 1; i < rCount; i++) {
                tb1.deleteRow(1);
            }

            if ('' == drDefinedJson) drDefinedJson = '[]';
            let definedDataRegionObj = JSON.parse(drDefinedJson);
            let dataRegionsJson = drJson;
            if ('' == dataRegionsJson) dataRegionsJson = '[]';
            let dataRegionsObj = JSON.parse(dataRegionsJson);

            var oTable = document.getElementById("bkmkTable");
            var tbodyObj = oTable.tBodies[0];
            for (let key in definedDataRegionObj) {
                let drName = definedDataRegionObj[key].name;
                let drCaption = definedDataRegionObj[key].caption;
                //alert("DataReion:"+drName+";value:"+drValue);

                let bFind = false;
                for (let k in dataRegionsObj) {
                    if (dataRegionsObj[k].name == drName) {
                        bFind = true;
                        break;
                    }
                }

                if (bFind) continue;

                if (drName.toLocaleLowerCase().indexOf(s.toLocaleLowerCase()) > -1) {
                    var oTr = tbodyObj.insertRow();
                    var oTd = oTr.insertCell();
                    oTd.innerHTML = drName;
                    oTd = oTr.insertCell();
                    oTd.innerHTML = drCaption;
                    oTd = oTr.insertCell();
                    oTd.innerHTML = '<button class="normal-button" onclick="addDataRegion(\'' + drName + '\',\'' + drCaption + '\');loadData();">Add</button>';
                }
            }
        }


        function searchDataRegion2(drJson, s) {
            var tb1 = document.getElementById("bkmkTable2");
            var rCount = tb1.rows.length;
            for (var i = 1; i < rCount; i++) {
                tb1.deleteRow(1);
            }

            let dataRegionsJson = drJson;
            if ('' == dataRegionsJson) dataRegionsJson = '[]';
            let dataRegionsObj = JSON.parse(dataRegionsJson);
            var oTable = document.getElementById("bkmkTable2");
            var tbodyObj = oTable.tBodies[0];
            for (let key in dataRegionsObj) {
                let drName = dataRegionsObj[key].name;

                if (drName.toLocaleLowerCase().indexOf(s.toLocaleLowerCase()) > -1) {
                    var oTr = tbodyObj.insertRow();
                    var oTd = oTr.insertCell();
                    oTd.innerHTML = drName;
                    oTd = oTr.insertCell();
                    oTd.innerHTML = '<button class="delete-button" onclick="deleteDataRegion(\'' + drName + '\');loadData();">Delete</button> <button class="locate-button" onclick="locateDataRegion(\'' + drName + '\');">Locate</button>';
                }
            }

        }

        function locateDataRegion(drName) {
            aceoffixctrl.word.LocateDataRegion(drName);
        }

        function deleteDataRegion(drName){
            aceoffixctrl.word.DeleteDataRegion(drName);
        }

        function addDataRegion(drName, drValue) {
            aceoffixctrl.word.AddDataRegion(drName, drValue);
        }


        function AfterDocumentOpened() {
            loadData();
        }
    </script>
</head>
<body>
<div class="Word">
	<div id="left-container">
    <div id="left-title">Define DataRegion</div>
    <div class="input-group">
        <span style="font-size: 14px;">To be Added:</span><input type="text" id="inputKey1" oninput="loadData();" placeholder="a keyword for the data area to search">
    </div>
    <div class="container">
        <table id="bkmkTable">
            <thead>
            <tr>
                <th>DataRegion</th>
                <th>Show Text</th>
                <th>Operation</th>
            </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <div class="input-group" style="margin-top: 20px">
        <span style="font-size: 14px;">Added:</span><input type="text" id="inputKey2" oninput="loadData();" placeholder=" a keyword for the data area to search">
    </div>
    <div class="container">
        <table id="bkmkTable2">
            <thead>
            <tr>
                <th>DataRegion</th>
                <th>Operation</th>
            </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
	</div>

	<div id="right-container">
        <div id="podiv" style="width:auto;height:98vh;">
            <%=aceCtrl.GetHtml()%> 
        </div>
	</div>
</div>
</body>
</html>
