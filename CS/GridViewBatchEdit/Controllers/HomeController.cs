using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Models;

namespace GridView.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial() {
            return PartialView("_GridViewPartial", BatchEditRepository.GridData);
        }
    }
}