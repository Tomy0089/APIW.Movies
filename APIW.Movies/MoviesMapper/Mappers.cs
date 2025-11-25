using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Models;
using APIW.Movies.Models.Dtos;
using AutoMapper;

namespace APIW.Movies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();
        }

    }
}