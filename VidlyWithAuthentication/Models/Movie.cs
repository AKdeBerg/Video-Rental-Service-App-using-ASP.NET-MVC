using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyWithAuthentication.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }


        [Required]
        public DateTime DateAdded { get; set; }


        public Genre Genre { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
    }
}