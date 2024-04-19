using Ator_Filme.Data;
using Ator_Filme.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ator_Filme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewModelController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ViewModelController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("FilmsWithActors")]
        public async Task<ActionResult<IEnumerable<FilmWithActorsViewModel>>> ListsFilmsWithActors()
        {
            var filmsWithActors = await _context.Films
                .Include(f => f.Actors)
                .Select(f => new FilmWithActorsViewModel
                {
                    Id = f.Id,
                    Title = f.Title,
                    ActorNames = f.Actors.Select(fa => fa.Name).ToList()
                }).ToListAsync();

            return Ok(filmsWithActors);
        }


    }
}
