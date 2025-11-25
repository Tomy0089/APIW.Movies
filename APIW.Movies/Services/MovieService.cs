using APIW.Movies.Models;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.Services.IServices;

namespace APIW.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepo;

        public MovieService(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public Task<ICollection<Movie>> GetMoviesAsync() => _movieRepo.GetMoviesAsync();
        public Task<Movie> GetMovieAsync(int id) => _movieRepo.GetMovieAsync(id);
        public Task<bool> MovieExistsAsync(string name) => _movieRepo.MovieExistsAsync(name);
        public Task<bool> CreateMovieAsync(Movie movie) => _movieRepo.CreateMovieAsync(movie);
        public Task<bool> UpdateMovieAsync(Movie movie) => _movieRepo.UpdateMovieAsync(movie);
        public Task<bool> DeleteMovieAsync(Movie movie) => _movieRepo.DeleteMovieAsync(movie);
    }
}