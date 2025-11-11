using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models.Dtos
{
    public class CategoryDto

    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El número máximo de carácteres es de 100.")]
           
        public String Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }

}
