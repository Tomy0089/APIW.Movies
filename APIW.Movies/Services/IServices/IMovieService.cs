using APIW.Movies.Models;

namespace APIW.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(int id);
        Task<bool> MovieExistsAsync(string name);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(Movie movie);
    }
}