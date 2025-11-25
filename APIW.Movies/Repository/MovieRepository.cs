using APIW.Movies.DAL;
using APIW.Movies.Models;
using APIW.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIW.Movies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _bd;

        public MovieRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _bd.Movies.Include(c => c.Category).OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _bd.Movies.Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> MovieExistsAsync(string name)
        {
            return await _bd.Movies.AnyAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.Now; // Fecha automática
            await _bd.Movies.AddAsync(movie);
            return await Save();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.UpdatedDate = DateTime.Now; // Fecha automática
            _bd.Movies.Update(movie);
            return await Save();
        }

        public async Task<bool> DeleteMovieAsync(Movie movie)
        {
            _bd.Movies.Remove(movie);
            return await Save();
        }

        public async Task<bool> Save()
        {
            return await _bd.SaveChangesAsync() >= 0;
        }
    }
}