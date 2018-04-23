using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridView.CustomGrouping.Models;

namespace GridView.CustomGrouping.Controllers {
    [HandleError]
    public class GridViewController : Controller {
        public ActionResult Index() {
            return Grouping();
        }
        public ActionResult Grouping() {
            return View("Grouping", NorthwindDataProvider.GetProducts());
        }
        public ActionResult GroupingPartial() {
            return PartialView("GroupingPartial", NorthwindDataProvider.GetProducts());
        }
    }
}
