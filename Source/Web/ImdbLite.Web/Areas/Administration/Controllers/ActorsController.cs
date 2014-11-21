namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models.Actor;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ImdbLite.Web.Areas.Administration.ViewModels.Actors;
    using ImdbLite.Web.Controllers;
    using ImdbLite.Data.UnitOfWork;

    public class ActorsController : BaseController
    {
        public ActorsController(IImdbLiteData data)
            :base(data)
        {
        }

        // GET: Administration/Actors
        public ActionResult Index()
        {
            var data = this.Data.Actors.All().Project().To<ActorViewModel>();

            return View(data);
        }
    }
}