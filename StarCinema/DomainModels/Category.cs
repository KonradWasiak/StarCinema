using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarCinema.DomainModels
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}