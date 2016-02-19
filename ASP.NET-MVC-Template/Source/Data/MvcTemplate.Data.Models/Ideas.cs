namespace MvcTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using MvcTemplate.Data.Common.Models;

    public class Ideas : BaseModel<int>, IDeletableEntity
    {
        public Ideas()
        {
            this.VotesForIdeas = new HashSet<VotesForIdeas>();
            this.CommentsForIdeas = new HashSet<CommentsForIdeas>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorIP { get; set; }

        public virtual ICollection<VotesForIdeas> VotesForIdeas { get; set; }

        public virtual ICollection<CommentsForIdeas> CommentsForIdeas { get; set; }

    }
}
