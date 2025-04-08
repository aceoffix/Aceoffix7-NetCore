using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using AceoffixNetCore;
using AceoffixNetCore.Word;

namespace Aceoffix7_NetCore.Controllers.WordParagraph
{
    public class WordParagraphController : Controller
    {

        public IActionResult Word()
        {
            AceoffixCtrl aceCtrl = new AceoffixCtrl(Request);

            WordDocumentWriter wd = new WordDocumentWriter();
            DataRegionWriter title = wd.CreateDataRegion("title", DataRegionInsertType.After, "[home]");
            title.Font.Bold = true;
            title.Font.Size = 20;
            title.Font.Name = "Aharoni";
            title.Font.Italic = false;

            WordParagraphFormat titlePara = title.ParagraphFormat;
            titlePara.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            DataRegionWriter body = wd.CreateDataRegion("body", DataRegionInsertType.After, "title");
            body.Font.Bold = false;
            body.Font.Italic = true;
            body.Font.Size = 10;
            body.Font.Name = "Berlin Sans FB Demi";
            body.Font.Color = Color.Red;
            body.Value = "Aceoffix is a flexible and professional web component for Microsoft Office, with the simplified interfaces and powerful functions that make it terrific not only for online editing and saving Office documents, but also importing and exporting data from database to Office documents. Aceoffix supports many Office document formats, such as *.doc, *.docx, *.xls, *.xlsx, *.ppt, *.pptx, *.xml and *.rtf. \n";
            WordParagraphFormat bodyPara = body.ParagraphFormat;
            bodyPara.LineSpacingRule = WdLineSpacing.wdLineSpaceAtLeast;
            bodyPara.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            bodyPara.FirstLineIndent = 21;
            DataRegionWriter body2 = wd.CreateDataRegion("body2",DataRegionInsertType.After, "body");
            body2.Font.Bold = false;
            body2.Font.Size = 12;
            body2.Font.Name = "Arial Rounded MT Bold";
            body2.Value = "Without installing Microsoft Office at the server side, web developers can easily embed and call Microsoft Office in web pages, just like using a Java or .Net control. Aceoffix edits the real Microsoft Office documents online without converting any formats. Intuitive examples with source code are included to speed up your development time.  In general management systems base on Browser/Server architecture, developers have to manage Word/Excel documents by downloading and uploading. With Aceoffix, you can not only online view, edit and save Office documents on web, but also access the contents of them. In addition, Aceoffix has many other powerful functions as well, like read-only control, authority control, editable region control, forced revision mode, generating formal documents and etc.\n";
            WordParagraphFormat bodyPara2 = body2.ParagraphFormat;
            bodyPara2.LineSpacingRule = WdLineSpacing.wdLineSpace1pt5;
            bodyPara2.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            bodyPara2.FirstLineIndent = 21;
            DataRegionWriter body3 = wd.CreateDataRegion("body3", DataRegionInsertType.After, "body2");
            body3.Font.Bold = false;
            body3.Font.Color = Color.Orange;
            body3.Font.Size = 14;
            body3.Font.Name = "Broadway";
            body3.Value = "Aceoffix includes a group of easy-to-use components. They are the object modules that are developed based on commonly used functions of Word/Excel. These components have the complete objects hierarchies. Developer will be able to understand and handle them easily. With simple code, they can accomplish the functions of Microsoft Office that they could hardly achieve before. Developers will be able to create their own business components based on these components as well. Developers do not have to face with the complex interfaces of Microsoft Office COM automation and VBA (Visual Basic for Applications). They will be able to save their time with Aceoffix. We make it easy to call the components of Aceoffix, and we insist on continuing efforts to keep the simplest calling interfaces of Aceoffix.\n";
            WordParagraphFormat bodyPara3 = body3.ParagraphFormat;
            bodyPara3.LineSpacingRule = WdLineSpacing.wdLineSpaceDouble;
            bodyPara3.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            bodyPara3.FirstLineIndent = 21;
            DataRegionWriter body4 = wd.CreateDataRegion("body4",DataRegionInsertType.After, "body3");
            body4.Value = "[image]doc/logo.png[/image]";
            WordParagraphFormat bodyPara4 = body4.ParagraphFormat;
            bodyPara4.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            aceCtrl.SetWriter(wd);
            aceCtrl.WebOpen("doc/test.docx", OpenModeType.docReadOnly, "John Scott");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

    }
}