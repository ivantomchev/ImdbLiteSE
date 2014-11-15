namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models.Actor;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ImdbLite.Web.Areas.Administration.ViewModels.Actors;

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
            var data = this.actors.All().Project().To<ActorViewModel>();

            return View(data);
        }
    }
}