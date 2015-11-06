using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using ASPPDFLib;
using TestingASPPDF.Models;

namespace TestingASPPDF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //String content = "<html><body><p>Hello HTML Page</p></body></html>";
           // System.IO.File.WriteAllText(Server.MapPath("NewHTML.html"), content);

            //IPdfManager objPdf = new PdfManager();
            //IPdfDocument objDoc = objPdf.CreateDocument(Missing.Value);
            //objDoc.ImportFromUrl("http://localhost/AspPDF/manual_13/editor%20file.aspx", "scale=0.6; hyperlinks=true; drawbackground=true", Missing.Value, Missing.Value);
            //string path = Server.MapPath("importfromurl.pdf");
            //String strFilename = objDoc.Save(Server.MapPath("NewPDF.pdf"), false);

            //IndexModel.PhoneNumber = "Success! Download your PDF file <A HREF=" + strFilename + ">here</A>";
            //ViewBag.PDFDownload = IndexModel.PhoneNumber;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(IndexViewModel IndexModel)
        {
            string htmlPagePath = Server.MapPath("~/FirstHTML.html");
            System.IO.File.WriteAllText(Server.MapPath("~/FirstHTML.html"), IndexModel.PhoneNumber);

            IPdfManager objPdf = new PdfManager();
            IPdfDocument objDoc = objPdf.CreateDocument(Missing.Value);
            objDoc.ImportFromUrl(htmlPagePath, "scale=0.6; hyperlinks=true; drawbackground=true", Missing.Value, Missing.Value);
            string path = Server.MapPath("importfromurl.pdf");
            String strFilename = objDoc.Save(Server.MapPath("~/FirstHTML.pdf"), false);
            ViewBag.PDFDownload = "Success! Download your PDF file <A HREF=" + strFilename + ">here</A>"; ;
            
            return View();

        }

        [ValidateInput(false)]
        public ActionResult PDFGenration(string HTMLSource)
        {
           // string HTMLSource = "";
           // String content = "<html><body><p>Hello HTML Page</p></body></html>";
            string htmlPagePath = Server.MapPath("~/FirstHTML.html");
            System.IO.File.WriteAllText(Server.MapPath("~/FirstHTML.html"), HTMLSource);

            IPdfManager objPdf = new PdfManager();
            IPdfDocument objDoc = objPdf.CreateDocument(Missing.Value);
            objDoc.ImportFromUrl(htmlPagePath, "scale=0.6; hyperlinks=true; drawbackground=true", Missing.Value, Missing.Value);
            string path = Server.MapPath("importfromurl.pdf");
            String strFilename = objDoc.Save(Server.MapPath("~/FirstHTML.pdf"), false);
            ViewBag.PDFDownload = "Success! Download your PDF file <A HREF=" + strFilename + ">here</A>"; ;
            return Json(new { name = "Hello There" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}