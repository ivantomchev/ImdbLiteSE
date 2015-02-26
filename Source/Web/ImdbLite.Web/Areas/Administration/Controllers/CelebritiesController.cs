namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ImdbLite.Web.Areas.Administration.Controllers.Base;
    using ImdbLite.Data.UnitOfWork;

    using DbModel = ImdbLite.Data.Models.Celebrity;
    using IndexViewModel = ImdbLite.Web.Areas.Administration.ViewModels.Celebrities.CelebrityIndexViewModel;
    using InputModel = ImdbLite.Web.Areas.Administration.ViewModels.Celebrities.CelebrityInputModel;
    using UpdateModel = ImdbLite.Web.Areas.Administration.ViewModels.Celebrities.CelebrityUpdateModel;
    using DeleteViewModel = ImdbLite.Web.Areas.Administration.ViewModels.Celebrities.CelebrityDeleteViewModel;

    public class CelebritiesController : AdminController
    {
        public CelebritiesController(IImdbLiteData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var data = GetData<IndexViewModel>();

            return View(data);
        }

        public ActionResult ReadData()
        {
            var data = GetData<IndexViewModel>();

            return PartialView("_ReadCelebritiesPartial", data);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            var model = base.GetViewModel<DbModel, UpdateModel>(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateModel model)
        {
            var dbModel = base.Update<DbModel, UpdateModel>(model, model.Id);
            if (dbModel != null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var model = new InputModel();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(InputModel model)
        {
            var dbModel = base.Create<DbModel>(model);

            if (dbModel != null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ActualDelete(int? id)
        {
            var model = base.GetViewModel<DbModel, DeleteViewModel>(id);

            return PartialView("_DeleteCelebrityPartial", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ActualDelete(DeleteViewModel model)
        {
            base.ActualDelete<DbModel>(model.Id);

            return base.GridOperation();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Celebrities.GetById(id) as T;
        }

        protected override IEnumerable GetData<TViewModel>()
        {
            return this.Data.Celebrities.All().Project().To<TViewModel>();
        }

    }
}