namespace MvcTemplate.Web.ViewModels.Home
{
    using AutoMapper;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Web;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    public class IdeasViewModel : IMapFrom<Ideas>, IHaveCustomMappings
    {
        public int Title { get; set; }

        public string Descriptions { get; set; }

        public int VotePoints { get; set; }

        public virtual ICollection<VotesForIdeas> VotesForIdeas { get; set; }

        public virtual ICollection<CommentsForIdeas> CommentsForIdeas { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Ideas/{identifier.EncodeId(this.Title)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
        }
    }
}
