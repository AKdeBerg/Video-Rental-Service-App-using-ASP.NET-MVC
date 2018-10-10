﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyWithAuthentication.Models;

namespace VidlyWithAuthentication.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }

                else
                {
                    return "New Movie";
                }
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}