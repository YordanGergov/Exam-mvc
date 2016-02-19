namespace MvcTemplate.Data.Models
{

    using MvcTemplate.Data.Common.Models;
    using System;

    public class CommentsForIdeas : BaseModel<int>, IDeletableEntity
    {
        public string Content { get; set; }

        public string IP { get; set; }

        public string Email { get; set; }

    }
}
