namespace MvcTemplate.Data.Models
{
    using System;
    using MvcTemplate.Data.Common.Models;

    public class VotesForIdeas : BaseModel<int>, IDeletableEntity
    {

        public string IP { get; set; }

        public int VotePoints { get; set; }

        // public virtual JokeCategory Category { get; set; }
    }
}
