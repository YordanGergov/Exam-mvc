namespace MvcTemplate.Data.Models
{
    using System;
    using MvcTemplate.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    public class VotesForIdeas : BaseModel<int>
    {

        public string IP { get; set; }

        public int VotePoints { get; set; }

        public VoteType Type { get; set; }

        public int? IdeasId { get; set; }

        public virtual Ideas Ideas { get; set; }

    }
}
