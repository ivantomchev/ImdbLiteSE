namespace ImdbLite.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ImdbLite.Data.UnitOfWork;
    using ImdbLite.Data.Models;
    using ImdbLite.Web.Areas.Administration.Controllers.Base;
    using ImdbLite.Web.Areas.Administration.ViewModels.Characters;
    using ImdbLite.Web.Areas.Administration.ViewModels.CastMembers;
    using ImdbLite.Common.Extensions;

    using DbModel = ImdbLite.Data.Models.Movie;
    using IndexViewModel = ImdbLite.Web.Areas.Administration.ViewModels.Movies.MovieIndexViewModel;
    using InputModel = ImdbLite.Web.Areas.Administration.ViewModels.Movies.MovieInputModel;
    using DeleteViewModel = ImdbLite.Web.Areas.Administration.ViewModels.Movies.MovieDeleteViewModel;
    using UpdateModel = ImdbLite.Web.Areas.Administration.ViewModels.Movies.MovieUpdateModel;

    public class MoviesController : AdminController
    {
        public MoviesController(IImdbLiteData data)
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

            return PartialView("_ReadMoviesPartial", data);
        }

        [HttpPost]
        public ActionResult AddCharacters(IList<CharacterInputModel> dynamicallyAddedCharacters)
        {
            var model = new InputModel();
            if (dynamicallyAddedCharacters != null)
            {
                model.Characters = dynamicallyAddedCharacters;
            };

            return PartialView("_CharactersPartial", model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            var model = base.GetViewModel<DbModel, UpdateModel>(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            model.Celebrities = this.Data.Celebrities.All().ToSelectList(x => x.FullName, x => x.Id);
            model.GenresList = this.Data.Genres.All().ToSelectList(x => x.Name, x => x.Id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateModel model)
        {
            //TODO More appropriate Update Action
            PopulateSelectedGenres(model.Genres, model.selectedGenres);
            PopulateSelectedCastMembers(model.CastMembers, model.selectedDirectors, ParticipationType.Director);
            PopulateSelectedCastMembers(model.CastMembers, model.selectedProducers, ParticipationType.Producer);

            ClearMovieCollections(model.Id);

            var dbModel = base.Update<DbModel, UpdateModel>(model, model.Id);
            if (dbModel != null)
            {
                return RedirectToAction("Index");
            }

            model.Celebrities = this.Data.Celebrities.All().Project().To<SelectListItem>().ToList();
            model.GenresList = this.Data.Genres.All().Project().To<SelectListItem>().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new InputModel();
            model.Celebrities = this.Data.Celebrities.All().Project().To<SelectListItem>().ToList();
            model.GenresList = this.Data.Genres.All().Project().To<SelectListItem>().ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputModel model)
        {
            PopulateSelectedGenres(model.Genres, model.selectedGenres);
            PopulateSelectedCastMembers(model.CastMembers, model.selectedDirectors, ParticipationType.Director);
            PopulateSelectedCastMembers(model.CastMembers, model.selectedProducers, ParticipationType.Producer);

            var dbModel = base.Create<DbModel>(model);
            if (dbModel != null)
            {
                return RedirectToAction("Index");
            }

            model.Celebrities = this.Data.Celebrities.All().Project().To<SelectListItem>().ToList();
            model.GenresList = this.Data.Genres.All().Project().To<SelectListItem>().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult ActualDelete(int? id)
        {
            var model = base.GetViewModel<DbModel, DeleteViewModel>(id);

            return PartialView("_DeleteMoviePartial", model);
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
            return this.Data.Movies.GetById(id) as T;
        }

        protected override IEnumerable GetData<TViewModel>()
        {
            return this.Data.Movies.All().Project().To<TViewModel>();
        }

        private void PopulateSelectedCastMembers(ICollection<CastMemberInputModel> castMembers, int[] selectedCelebrities, ParticipationType participation)
        {
            if (selectedCelebrities != null)
            {
                foreach (var celebrityId in selectedCelebrities)
                {
                    var castMember = new CastMemberInputModel();
                    castMember.CelebrityId = celebrityId;
                    castMember.Participation = participation;

                    castMembers.Add(castMember);
                }
            }
        }

        private void PopulateSelectedGenres(ICollection<Genre> genres, int[] selectedGenres)
        {
            if (selectedGenres != null)
            {
                foreach (var genreId in selectedGenres)
                {
                    var currentGenre = this.Data.Genres.GetById(genreId);

                    genres.Add(currentGenre);
                }
            }
        }

        private void ClearMovieCollections(int movieId)
        {
            var characters = this.Data.Characters.All().Where(x => x.MovieId == movieId);
            var castmembers = this.Data.CastMembers.All().Where(x => x.MovieId == movieId);

            characters.ForEach(this.Data.Characters.ActualDelete);
            castmembers.ForEach(this.Data.CastMembers.ActualDelete);
        }
    }
}