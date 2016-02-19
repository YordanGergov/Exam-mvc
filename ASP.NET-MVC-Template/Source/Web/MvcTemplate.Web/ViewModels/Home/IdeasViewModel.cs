namespace MvcTemplate.Web.ViewModels.Home
{
    using AutoMapper;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Web;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class IdeasViewModel : IMapFrom<Ideas>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Joke/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
