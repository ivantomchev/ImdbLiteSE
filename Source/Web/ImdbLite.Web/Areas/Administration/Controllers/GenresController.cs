namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ImdbLite.Data.UnitOfWork;
    using ImdbLite.Web.Areas.Administration.Controllers.Base;

    using DbModel = ImdbLite.Data.Models.Genre.Genre;
    using ViewModel = ImdbLite.Web.Areas.Administration.ViewModels.Genres.GenreBaseViewModel;
    using DetailedViewModel = ImdbLite.Web.Areas.Administration.ViewModels.Genres.GenreDetailsViewModel;
    using System;

    public class GenresController : AdminController
    {
        private const string ListToUpdate = "#genres-list";
        private const string UrlToLoad = "/Administration/Genres/ReadData";
        //var url = Url.Action("ReadData", "Genres");
        //var listToUpdate = "#genres-list";


        public GenresController(IImdbLiteData data)
            : base(data)
        {

        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Genres.GetById(id) as T;
        }

        public ActionResult Index()
        {
            var list = this.Data.Genres.All().Project().To<DetailedViewModel>().OrderBy(x => x.Type);

            return View(list);
        }

        public ActionResult ReadData()
        {
            var list = this.Data.Genres.All().Project().To<DetailedViewModel>().OrderBy(x => x.Type);

            return PartialView("_ReadGenresPartial", list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ViewModel();

            return PartialView("_CreateGenrePartial", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ViewModel model)
        {
            var dbModel = base.Create<DbModel>(model);

            if (dbModel != null)
            {
                return base.GridOperation(ListToUpdate, UrlToLoad);
            }

            return PartialView("_CreateGenrePartial", model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = this.GetById<DbModel>(id);
            var model = AutoMapper.Mapper.Map<ViewModel>(dbModel);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            return PartialView("_UpdateGenrePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ViewModel model)
        {
            base.Update<DbModel, ViewModel>(model, model.Id);

            return base.GridOperation(ListToUpdate, UrlToLoad);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = this.GetById<DbModel>(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DeleteItemPartial");
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var dbModel = this.GetById<DbModel>(id);

            dbModel.IsDeleted = true;
            dbModel.ModifiedOn = DateTime.Now;

            base.Delete<DbModel>(dbModel);

            return base.GridOperation(ListToUpdate, UrlToLoad);
        }

        [HttpGet]
        public ActionResult ActualDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = this.GetById<DbModel>(id);
            var model = AutoMapper.Mapper.Map<ViewModel>(dbModel);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DeleteGenrePartial",model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("ActualDelete")]
        public ActionResult ConfirmActualDelete(ViewModel model)
        {
            base.ActualDelete<DbModel>(model.Id);

            return base.GridOperation(ListToUpdate, UrlToLoad);
        }
    }
}