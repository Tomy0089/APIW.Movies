using APIW.Movies.Models;

namespace APIW.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(int id);
        Task<bool> MovieExistsAsync(string name);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(Movie movie);
        Task<bool> Save();
    }
}