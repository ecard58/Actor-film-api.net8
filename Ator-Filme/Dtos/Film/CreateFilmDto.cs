using Ator_Filme.Dtos.Link;

namespace Ator_Filme.Dtos.Film
{
    public class CreateFilmDto
    {
        public string Title { get; set; }
        public List<int> ActorsId { get; set; }
    }
}
