using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class AddEditMovieRequest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Max title length is 100 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Directory max  length is 100 characters")]
        public string Directory { get; set; }
        [Required]
        [MaxLength(2000, ErrorMessage = "Description max length is 2000 characters")]
        public string Description { get; set; }
        [Required]
        [Range(1,1000,ErrorMessage ="Duration time must be between 1 and 1000 minutes")]
        public int DurationTime { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Trailer url max length is 1000 characters")]
        public string TrailerUrl { get; set; }
        [Required]
        public bool Is3D { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public IFormFile PosterImage { get; set; }
        [Required]
        public IFormFile BannerImage { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
