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

        public JokeCategory EnsureCategory(string name)
        {
            var ideas = this.ideass.All().FirstOrDefault(x => x.Title == name);
            if (ideas != null)
            {
                return ideas;
            }

            ideass = new Ideas { Title = title };
            this.ideass.Add(idea);
            this.ideass.Save();
            return ideas;
        }

        public IQueryable<JokeCategory> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }

        IQueryable<Ideas> IideasService.GetAll()
        {
            throw new NotImplementedException();
        }

        public Ideas EnsureIdeas(string name)
        {
            throw new NotImplementedException();
        }
    }
}
