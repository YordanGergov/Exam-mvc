namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly ICategoriesService jokeCategories;
        private readonly IideasService ideass;

        public HomeController(
            IJokesService jokes,
            ICategoriesService jokeCategories,
            IideasService ideass)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
            this.ideass = ideass;
        }

        public ActionResult Index()
        {
            var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);
            var ideass =
                this.Cache.Get(
                    "ideass",
                    () => this.ideass.GetAll().To<IdeasViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories,
                Ideass = ideass
            };

            return this.View(viewModel);
        }
    }
}
