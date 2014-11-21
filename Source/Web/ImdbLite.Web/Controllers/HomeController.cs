using ImdbLite.Data.Common.Repository;
using ImdbLite.Data.Models.Actor;
using ImdbLite.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbLite.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IImdbLiteData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            //var user = this.CurrentUser.UserName;

            return View();
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