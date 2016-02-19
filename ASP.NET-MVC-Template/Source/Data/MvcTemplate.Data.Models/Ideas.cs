﻿namespace MvcTemplate.Data.Models
{
    using System;
    using MvcTemplate.Data.Common.Models;

    public class Ideas : BaseModel<int>, IDeletableEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorIP { get; set; }

        // public virtual JokeCategory Category { get; set; }
    }
}
