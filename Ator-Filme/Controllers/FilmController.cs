using Ator_Filme.Dtos.Film;
using Ator_Filme.Models;
using Ator_Filme.Services.FilmService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ator_Filme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmInterface _filmInterface;

        public FilmController(IFilmInterface filmInterface)
        {
            _filmInterface = filmInterface;
        }

        [HttpPost("CreateFilm")]
        public async Task<ActionResult<ResponseModel<List<FilmModel>>>> CreateFilm(CreateFilmDto createFilmDto)
        {
            var films = await _filmInterface.CreateFilm(createFilmDto);
            return Ok(films);
        }
    }

}
