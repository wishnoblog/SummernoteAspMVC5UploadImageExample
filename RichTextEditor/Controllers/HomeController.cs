using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RichTextEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string UploadImage(HttpPostedFileBase image)
        {
            var file = Request.Files[0];

            var fileName = Path.GetFileName(image.FileName);

            var path = Path.Combine(Server.MapPath("~/MailUpload/"), fileName);
            file.SaveAs(path);
            return $"{Request.Url.Authority}/MailUpload/{fileName}";
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