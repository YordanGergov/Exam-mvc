namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IideasService
    {
        IQueryable<Ideas> GetAll();

        Ideas EnsureIdeas(string name);
    }
}
