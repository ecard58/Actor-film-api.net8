using Ator_Filme.Dtos.Link;

namespace Ator_Filme.Dtos.Film
{
    public class EditFilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> ActorsId { get; set; }
    }
}
