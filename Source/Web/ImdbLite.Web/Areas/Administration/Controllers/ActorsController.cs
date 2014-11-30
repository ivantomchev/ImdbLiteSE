namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using ImdbLite.Data.Common.Repository;
    using ImdbLite.Data.Models.Actor;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ImdbLite.Web.Areas.Administration.ViewModels.Actors;
    using ImdbLite.Web.Controllers;
    using ImdbLite.Data.UnitOfWork;
    using ImdbLite.Web.Areas.Administration.Controllers.Base;

    using System.Web;
    using System.IO;
    using System.Collections.Generic;
    using ImdbLite.Common;
    using System.Text;
    using System;
    using AutoMapper;
    using System.Data.Entity;
    using System.Collections;
    using System.Linq;


    public class ActorsController : AdminController
    {
        public ActorsController(IImdbLiteData data)
            : base(data)
        {
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Actors.GetById(id) as T;
        }

        // GET: Administration/Actors
        public ActionResult Index()
        {
            var data = this.Data.Actors.All().Project().To<ActorViewModel>();

            return View(data);
        }

        public ActionResult PopulateDropDown()
        {

            return null;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateActorViewModel();

            return PartialView("_CreateActorDialogPartial", model);
        }

        [HttpPost]
        public ActionResult Create(CreateActorViewModel model)
        {
            var dbModel = base.Create<Actor>(model);

            if (dbModel != null)
            {
                var subDirectoryComponents = new string[] { model.FirstName, model.LastName, model.BirthDate.Year.ToString() };
                var subDirectoryName = GenerateSubDirectoryName(subDirectoryComponents);
                var filePath = GenerateFilePath(GlobalConstants.ActorsDirectory, subDirectoryName, Path.GetExtension(model.MainPhotoFile.FileName));

                model.MainPhotoFile.SaveAs(Server.MapPath(filePath));

                dbModel.MainPhotoUrl = filePath;

                base.ChangeEntityStateAndSave(dbModel, EntityState.Added);

                return Json(dbModel,JsonRequestBehavior.AllowGet);
            }

            return PartialView("_CreateActor", model);
        }
    }
}