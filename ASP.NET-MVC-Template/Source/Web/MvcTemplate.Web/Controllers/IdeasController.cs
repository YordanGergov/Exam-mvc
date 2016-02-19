namespace ForumSystem.Web.Controllers
{
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using MvcTemplate.Web.ViewModels.Home;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.ViewModels;
    public class IdeasController : Controller
    {
        private readonly IDbRepository<Ideas> ideas;

        public IdeasController(IDbRepository<Ideas> ideas)
        {
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdeasInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var ideas = new Ideas()
            {
                Description = model.Description,
                Title = model.Title
            };

            if (this.User.Identity.IsAuthenticated)
            {
                ideas.AuthorIP = this.User.Identity.GetUserId();
            }

            this.ideas.Add(ideas);
            this.ideas.Save();

            this.TempData["Notification"] = "Thank you for your idea!";
            return this.Redirect("/");
        }
    }
}