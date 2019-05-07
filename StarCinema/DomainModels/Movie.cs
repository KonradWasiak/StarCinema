using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarCinema.DomainModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Directory { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Show> Shows { get; set; }


    }
}