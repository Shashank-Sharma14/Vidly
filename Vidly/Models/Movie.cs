using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(1,20,ErrorMessage ="it Should be between 1-20")]
        public byte NumberInStock { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime ReleaseDate { get; set; }
        public Gener Gener { get; set; }
        [Required]
        public byte  GenerId { get; set; }

        public byte  NumberAvailable { get; set; }

    }
}