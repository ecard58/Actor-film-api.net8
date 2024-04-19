using Ator_Filme.Data;
using Ator_Filme.Dtos.Film;
using Ator_Filme.Models;
using Microsoft.EntityFrameworkCore;

namespace Ator_Filme.Services.FilmService
{
    public class FilmService : IFilmInterface
    {
        private readonly AppDbContext _context;

        public FilmService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<FilmModel>>> CreateFilm(CreateFilmDto createFilmDto)
        {
            ResponseModel<List<FilmModel>> resposta = new ResponseModel<List<FilmModel>>();
            try
            {
                var newFilm = new FilmModel()
                {
                    Title = createFilmDto.Title,
                };

                var actorsToAdd = new List<ActorModel>();
                if (createFilmDto.ActorsId != null && createFilmDto.ActorsId.Count > 0)
                {
                    actorsToAdd = await _context.Actors
                        .Where(a => createFilmDto.ActorsId.Contains(a.Id))
                        .ToListAsync();
                }

                newFilm.Actors = actorsToAdd;

                await _context.Films.AddAsync(newFilm);
                await _context.SaveChangesAsync();

                resposta.Data = new List<FilmModel> { newFilm };
                resposta.Message = "Film successfully created.";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<FilmModel>>> DeleteFilm(int filmId)
        {
            ResponseModel<List<FilmModel>> resposta = new ResponseModel<List<FilmModel>>();
            try
            {
                var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);

                if (film == null)
                {
                    resposta.Message = "Film not found.";
                    return resposta;
                }
                _context.Remove(film);
                await _context.SaveChangesAsync();
                resposta.Data = await _context.Films.ToListAsync();

                resposta.Message = "Film successfully removed.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<FilmModel>>> EditFilm(EditFilmDto editFilmDto)
        {
            ResponseModel<List<FilmModel>> resposta = new ResponseModel<List<FilmModel>>();
            try
            {
                var film = await _context.Films.FindAsync(editFilmDto.Id);
                if(film == null)
                {
                    resposta.Message = "Film not found.";
                    resposta.Status= false;
                    return resposta;
                }

                film.Title = editFilmDto.Title;

                var actorsToAdd = new List<ActorModel>();
                if(editFilmDto.ActorsId != null && editFilmDto.ActorsId.Count > 0)
                {
                    actorsToAdd = await _context.Actors
                        .Where(a => editFilmDto.ActorsId.Contains(a.Id))
                        .ToListAsync();
                }

                film.Actors = actorsToAdd;

                await _context.SaveChangesAsync();

                resposta.Status = true;
                resposta.Message = "Film successfully edited.";
                resposta.Data = new List<FilmModel> { film };
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public async Task<ResponseModel<FilmModel>> GetFilmById(int filmId)
        {
            ResponseModel<FilmModel> resposta = new ResponseModel<FilmModel>();
            try
            {
                var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);

                if (film == null)
                {
                    resposta.Message = "Film not found.";
                    return resposta;
                }
                resposta.Data = film;
                resposta.Message = "Film founded.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmModel>>> ListFilms()
        {
            ResponseModel<List<FilmModel>> resposta = new ResponseModel<List<FilmModel>>();
            try
            {
                var films = await _context.Films.ToListAsync();

                resposta.Data = films;
                resposta.Message = "Films collected.";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
