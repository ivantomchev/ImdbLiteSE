namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models.Actor;
    using System.Web.Mvc;

    public class ActorsController : Controller
    {
        private readonly IDeletableEntityRepository<Actor> actors;

        public ActorsController(IDeletableEntityRepository<Actor> actors)
        {
            this.actors = actors;
        }

        // GET: Administration/Actors
        public ActionResult Index()
        {
            return View();
        }
    }
}