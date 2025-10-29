using System.ComponentModel.DataAnnotations;

namespace APIW.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] //Este data annotation indica que el campo es clave primaria
        public virtual int Id { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}
