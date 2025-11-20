using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models.Dtos
{
    public class CategoryCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El número máximo de carácteres es de 100.")]

        public String Name { get; set; }
    }
}
