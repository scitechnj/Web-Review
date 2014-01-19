using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About(Sucker sucker)
        {
            return Json(new { doesHeSuck = sucker.DoesHeSuck });
        }

    }

    public class Sucker
    {
        public string Text { get; set; }
        public bool DoesHeSuck { get; set; }
        public int[] Arr { get; set; }
        public SuckLevel Level { get; set; }
    }

    public class SuckLevel
    {
        public int Amount { get; set; }
    }
}
