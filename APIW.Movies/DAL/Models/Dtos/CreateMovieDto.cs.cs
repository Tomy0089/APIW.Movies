using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.Models.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria")]
        [MaxLength(10, ErrorMessage = "La clasificación no puede exceder 10 caracteres")]
        public string Classification { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}