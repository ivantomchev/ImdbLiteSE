
namespace ImdbLite.Web.Controllers
{
    using System.Web.Mvc;

    using ImdbLite.Data.UnitOfWork;

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