using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //Este data annotation indica que el campo es obligatorio
        [Display(Name="Nombre de la categoria")] //personaliza el nombre que se muestra en las vistas
        public string Name { get; set; }

    }
}

