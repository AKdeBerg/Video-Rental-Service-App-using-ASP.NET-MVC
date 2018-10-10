﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyWithAuthentication.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

    }
}