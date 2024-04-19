using Ator_Filme.Dtos.Film;
using Ator_Filme.Models;

namespace Ator_Filme.Services.FilmService
{
    public interface IFilmInterface
    {
        Task<ResponseModel<List<FilmModel>>> ListFilms();
        Task<ResponseModel<FilmModel>> GetFilmById(int filmId);
        Task<ResponseModel<List<FilmModel>>> CreateFilm(CreateFilmDto createFilmDto);
        Task<ResponseModel<List<FilmModel>>> EditFilm(EditFilmDto editFilmDto);
        Task<ResponseModel<List<FilmModel>>> DeleteFilm(int filmId);
    }
}
