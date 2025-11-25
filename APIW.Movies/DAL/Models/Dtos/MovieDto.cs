namespace APIW.Movies.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public string Classification { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        // Opcional: public CategoryDto Category { get; set; }
    }
}