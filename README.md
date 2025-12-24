# Aceoffix7-NetCore

**Latest Version：7.3.1.1**

### 1. Introduction

​      The Aceoffix7-NetCore projectproject demonstrates how to use the Aceoffix 7.0 product within the ASP.NET Core. Please note that this project only supports ASP.NET Core and does not cover the ASP.NET Framework. It supports .NET Core 3.1, as well as .NET 5 and later versions.This project showcases nearly 90% of the functions of the Aceoffix product and serves as a demo project.

### 2. Project environmental prerequisites

​      Visual Studio 2019 or later versions.

### 3. Steps for running the project

- Use "git clone" or directly download the project's compressed package to your local machine and then decompress it.

- Download the Aceoffix client program.

  [aceclientsetup_7.x.x.x.exe](https://github.com/aceoffix/aceoffix7-client/releases/)

- Copy the program downloaded in the previous step to the root directory of the current project.

- Open this project using Visual Studio. Then right-click on the project folder, and click "Manage NuGet Packages -> Browse" in sequence. Enter `Acesoft.Aceoffix`,`System.Data.Sqlite`,and `Newtonsoft.Json`in  the search box and install the latest version.

- Run this project and visit the index.html page to see the sample effect.

### 4. Trial license key

- Aceoffix Standard V7.0 is 4ZDGS-FDZDK-WK18-YSJET

- Aceoffix Enterprise V7.0 is QA2JS-8C0PT-IKKJ-VTCC6

- Aceoffix Ultimate V7.0 is 9GRX9-VFFED-6NSN-ACVR1

### 5. How to integrate AceoffixV7 into your web project

- Open this project using Visual Studio. Then right-click on the project folder, and click "Manage NuGet Packages -> Browse" in sequence. Enter `Acesoft.Aceoffix` in the search box and install the latest version.

- Download the Aceoffix client program.

  [aceclientsetup_7.x.x.x.exe](https://github.com/aceoffix/aceoffix7-client/releases/)

- Copy the program downloaded in the previous step to the root directory of your project. Then, in Visual Studio, right - click on the program and change the value of "Properties -> Copy to Output Directory" to "Copy always".

- Add the following code to  your project `Program.cs` file.

  ```C#
  builder.Services.AddAceoffixAcewServer();//Available starting from Aceoffix v7.3.1.1
  ```

- Add the following code to  your project `Program.cs` file.

  ```c#
  //Note: These two lines of code must be placed before app.UseRouting().
  app.UseAceoffixAcewServer();//Available starting from Aceoffix v7.3.1.1
  app.UseMiddleware<AceoffixNetCore.AceServer.ServerHandlerMiddleware>();
  ```

- Aceoffix programming control:

  - Backend Code: In the Aceoffix-calling Controller, add the following (see `Aceoffix7-NetCore/Controllers/SimpleWord/SimpleWordController.cs` for full implementation).
  
    ```c#
    public IActionResult Word()
    {
        AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);
        aceCtrl.WebOpen("doc/test.docx", OpenModeType.docNormalEdit, "Tom");
        ViewBag.aceCtrl = aceCtrl.GetHtml();
        return View();
    }
    ```
  
  - Add a new function called Save in Aceoffix7NetCore/Controllers/SimpleWord/SimpleWordController.cs if your user wants to save document.
  
    ```c#
    FileSaver fs = new FileSaver(Request, Response);
    await fs.LoadAsync();
    string webRootPath = _webHostEnvironment.WebRootPath;
    fs.SaveToFile(webRootPath + "/SimpleWord/doc/" + fs.FileName);
    return   fs.Close();
    ```
  
  - Frontend Code: (See `Aceoffix7-NetCore/Views/SimpleWord/Word.cshtml` for the complete implementation).
  
    ```html
    @{
        Layout = null;
    }
    <!DOCTYPE html>
    <html>
    <head lang="en">
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
        <script type="text/javascript">
            function SaveDoc() {
                var saveUrl = "/SimpleWord/SaveDoc";
                aceoffixctrl.SaveFilePage = saveUrl;
                aceoffixctrl.WebSave();
            }    
            function OnAceoffixCtrlInit() {
                aceoffixctrl.AddCustomToolButton("Save", "SaveDoc()", 1);        
            }
        </script>
        <div style="width:auto;height:900px;">
            @Html.Raw(ViewBag.aceCtrl)
        </div>    
    </body>
    </html>
    ```
  
  - Reference the aceoffix.js file in your current web project's homepage (e.g.  in _Layout.cshtml).
  
    > **【Note】:** The project does not contain an `aceoffix.js` file. This file is provided by the Aceoffix server-side program configured in `Startup.cs`, which encapsulates `aceoffix.js`. By default, it is deployed to the root directory of the current project, so you can reference it directly.
  
  ```javascript
  <script type="text/javascript" src="/aceoffix.js"></script>
  ```
  
  - On the web page that requires file opening, call the `AceBrowser.openWindow` method to open the Controller request that has already been written above. For example, in the sample code：
  
    ```javascript
    <a href="javascript:AceBrowser.openWindow('SimpleWord/Word','width=1150px;height=900px;');">Open Word File</a>
    ```

- When publish the project , follow the prompts to install the Aceoffix V7 client. Once the registration dialog box appears, please enter the license key of Aceoffix V7 to complete the registration.

