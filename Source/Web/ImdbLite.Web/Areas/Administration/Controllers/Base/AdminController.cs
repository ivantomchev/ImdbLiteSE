﻿namespace ImdbLite.Web.Areas.Administration.Controllers.Base
{
    using System.Data.Entity;
    using System.IO;
    using System.Web.Mvc;
    using System.Web;
    using System.Collections;

    using AutoMapper;

    using ImdbLite.Data.UnitOfWork;
    using ImdbLite.Web.Controllers;


    public abstract class AdminController : BaseController
    {

        // [Authorize(Roles = "Admin")]
        public AdminController(IImdbLiteData data)
            : base(data)
        {
        }

        protected abstract T GetById<T>(object id) where T : class;

        protected abstract IEnumerable GetData<TViewModel>() where TViewModel : class;

        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        protected virtual TModel Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                Mapper.Map<TViewModel, TModel>(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);

                return dbModel;
            }
            return null;
        }

        protected virtual void Delete<TModel>(object model)
            where TModel : class
        {
            this.ChangeEntityStateAndSave(model, EntityState.Modified);
        }

        protected virtual void ActualDelete<T>(object id)
            where T : class
        {
            var dbModel = this.GetById<T>(id);
            this.ChangeEntityStateAndSave(dbModel, EntityState.Deleted);
        }

        protected virtual TViewModel GetViewModel<TModel, TViewModel>(object id)
            where TModel : class
            where TViewModel : class
        {
            if (id == null)
            {
                return null;
            }

            var dbModel = this.GetById<TModel>(id);

            if (dbModel == null)
            {
                return null;
            }

            var model = Mapper.Map<TViewModel>(dbModel);

            return model;
        }

        protected void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }

        protected JsonResult GridOperation()
        {
            return Json(new { success = true });
        }
    }
}