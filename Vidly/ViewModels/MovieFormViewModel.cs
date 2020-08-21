using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
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
            GenerId = movie.GenerId;
        }
        public IEnumerable<Gener> Geners { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(1, 20, ErrorMessage = "it Should be between 1-20")]
        [Required]
        public byte? NumberInStock { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        public byte? GenerId { get; set; }
        public string Titel {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}