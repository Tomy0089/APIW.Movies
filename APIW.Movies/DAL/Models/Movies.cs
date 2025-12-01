using APIW.Movies.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIW.Movies.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Classification { get; set; } 

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}