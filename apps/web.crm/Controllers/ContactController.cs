using crm.client;
using crm.sdk;
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

        public ActionResult Create(object entity)
        {
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult SaveContact(Contact contact)
        {
            var res = new { RequestId = Guid.NewGuid().ToString(), Result = "Success", Action = "Save", Object = contact };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}