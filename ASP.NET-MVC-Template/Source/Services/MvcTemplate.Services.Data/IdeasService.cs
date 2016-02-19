namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class IdeasService : IideasService
    {
        private readonly IDbRepository<Ideas> ideass;

        public IdeasService(IDbRepository<Ideas> ideass)
        {
            this.ideass = ideass;
        }

        public Ideas EnsureIdeas(string title)
        {
            var ideas = this.ideass.All().FirstOrDefault(x => x.Title == title);
            if (ideas != null)
            {
                return ideas;
            }

            ideas = new Ideas { Title = title };
            this.ideass.Add(ideas);
            this.ideass.Save();
            return ideas;
        }

        public IQueryable<Ideas> GetAll()
        {
            return this.ideass.All().OrderBy(x => x.Title);
        }
    }
}
