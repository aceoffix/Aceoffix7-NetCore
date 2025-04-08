<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.cs" Inherits="Aceoffix7_Net.FIleMakerToPDF.Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <title>Convert Word to PDF</title>
    <!--js must be referenced-->
    <script type="text/javascript" src="../aceoffix.js"></script>
    <script type="text/javascript">
        function ConvertFile() {
            document.getElementById("Button1").disabled = true;

            var saveFileUrl = "/FileMakerToPDF/SaveMaker";
            var openFileUrl = "/FileMakerToPDF/FileMakerToPDF";
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
    <h3 style="margin:20px;">Demo: Effect of Dynamically Populating Data into a Word Template to Generate a PDF File</h3>
    <div style="width:650px;margin: 0 auto; font-size:14px;">
        <p style="text-align: left;">
            Demo Content: <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;This example demonstrates the function of calling the FileMaker object to dynamically generate a Word file on the client side and automatically save it as a PDF on the server without opening the file online, simulating the effect of directly populating data into a Word template on the server side to generate a PDF file.
        </p>
        <p style="text-align: left;">
            Operation Instructions: <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;1. Click the "Generate PDF File" button to generate a PDF - formatted honor certificate file. <br/>
            &nbsp;&nbsp;&nbsp;&nbsp;2. After generation is completed, you can see the generated PDF file: certificate.pdf in the "FileMakerToPDF/doc" directory.
        </p>
    </div>
    <input id="Button1" type="button" value="Generate PDF File" onclick="ConvertFile()"/>
    <div id="progressBarContainer">
        <div id="progressBar"></div>
    </div>
</div>
</body>
</html>


