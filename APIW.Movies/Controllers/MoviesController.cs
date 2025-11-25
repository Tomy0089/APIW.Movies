using APIW.Movies.Models;
using APIW.Movies.Models.Dtos;
using APIW.Movies.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIW.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovies()
        {
            var list = await _movieService.GetMoviesAsync();
            var listDto = _mapper.Map<List<MovieDto>>(list);
            return Ok(listDto);
        }

        [HttpGet("{id:int}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovie(int id)
        {
            var item = await _movieService.GetMovieAsync(id);
            if (item == null) return NotFound();

            return Ok(_mapper.Map<MovieDto>(item));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _movieService.MovieExistsAsync(createDto.Name))
            {
                ModelState.AddModelError("", "La película ya existe");
                return BadRequest(ModelState);
            }

            var movie = _mapper.Map<Movie>(createDto);
            if (!await _movieService.CreateMovieAsync(movie))
            {
                ModelState.AddModelError("", $"Error guardando {movie.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetMovie", new { id = movie.Id }, _mapper.Map<MovieDto>(movie));
        }

        
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
        {
            if (movieDto == null || id != movieDto.Id)
            {
                return BadRequest(ModelState);
            }

            // 1. Buscamos la película existente (Queda "trackeada" por EF Core)
            var existingMovie = await _movieService.GetMovieAsync(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            // 2. CORRECCIÓN: En vez de crear uno nuevo, volcamos los datos del DTO sobre el existente
            _mapper.Map(movieDto, existingMovie);

            // Nota: Ya no necesitamos copiar CreatedDate manualmente porque
            // existingMovie ya lo tiene y el mapeo lo respeta.

            // 3. Mandamos a guardar el mismo objeto que ya recuperamos
            if (!await _movieService.UpdateMovieAsync(existingMovie))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro {existingMovie.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            if (movie == null) return NotFound();

            if (!await _movieService.DeleteMovieAsync(movie))
            {
                ModelState.AddModelError("", $"Error eliminando {movie.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}