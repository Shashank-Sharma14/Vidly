using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(1, 20, ErrorMessage = "it Should be between 1-20")]
        public byte NumberInStock { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public DateTime ReleaseDate { get; set; }
        [Required]
        public byte GenerId { get; set; }
        public GenerDto Gener { get; set; }
    }
}