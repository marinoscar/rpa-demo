using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.crm.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var isAuth = this.Session["isAuth"];
            if (isAuth == null)
                return Redirect("/Account/Index");
            ViewBag.ShowModal = (((new Random()).Next(1,4)) % 2) == 0;
            return View();
        }
    }
}