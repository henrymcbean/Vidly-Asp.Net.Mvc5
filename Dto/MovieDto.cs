using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Asp.Net.Mvc5.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; } 

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
    }
}