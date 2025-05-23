﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.FileMakerSingle.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <title>Generate File</title>
    <!--js must be referenced-->
    <script type="text/javascript" src="../aceoffix.js"></script>
    <script type="text/javascript">
        function GenerateFile() {
            document.getElementById("Button1").disabled = true;

            var saveFileUrl = "/FileMakerSingle/SaveMaker";
            var openFileUrl = "/FileMakerSingle/FileMakerSingle";
            filemakerctrl.SaveFilePage = saveFileUrl;

            filemakerctrl.CallFileMaker({
                url: openFileUrl,
                success: function (res) {   //res: Obtain the save result set by fs.CustomSaveResult on the server side
                    console.log(res);
                    console.log("completed successfully.");
                    setProgress(100);
                },
                progress: function (pos) {
                    console.log("running " + pos + "%");
                    setProgress(pos);
                },
                error: function (msg) {
                    console.log("error occurred: " + msg);
                }
            });
        }

        function setProgress(percent) {
            var progressBar = document.getElementById("progressBar");
            progressBar.style.width = percent + '%';
            progressBar.innerText = percent + '%';
        }
    </script>
    <style type="text/css">
        #progressBarContainer {
            width: 500px;
            background-color: #e0e0e0;
            border-radius: 5px;
            padding: 3px;
            margin: 10px auto;
        }

        #progressBar {
            height: 20px;
            width: 0%;
            background-color: #76b900;
            border-radius: 5px;
            text-align: center;
            line-height: 20px; /* Center the text vertically */
            color: white;
        }
    </style>
</head>
<body style="text-align: center;">
   <div style="text-align: center;">
        <h3 style="margin:20px;">Demonstration: Effect of Dynamically Filling Data into a Word Template to Generate  File</h3>
		<div style="width:650px;margin: 0 auto; font-size:14px;">
			<p style="text-align: left;">
				Demonstration Content:<br/>
				&nbsp;&nbsp;&nbsp;&nbsp;This example demonstrates calling the FileMaker object on the client side to dynamically generate a Word file and automatically save it  on the server without opening the file online, simulating the effect of directly filling data into a Word template file on the server side.
			</p>
			<p style="text-align: left;">
				Instructions:<br/>
				&nbsp;&nbsp;&nbsp;&nbsp;1. Click the "GenerateFile" button to execute the program that dynamically fills data into the certificate template "template.docx" .<br/>
				&nbsp;&nbsp;&nbsp;&nbsp;2. After generation is complete, you will find the generated file "certificate.pdf" in the "FileMakerSingle/doc" directory.
			</p>
		</div>	
        <input id="Button1" type="button" value="GenerateFile" onclick="GenerateFile()"/>
		<div id="progressBarContainer">
		  <div id="progressBar"></div>
		</div>
    </div>
</body>
</html>


