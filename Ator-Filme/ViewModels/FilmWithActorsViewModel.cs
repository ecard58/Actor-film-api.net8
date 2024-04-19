namespace Ator_Filme.ViewModels
{
    public class FilmWithActorsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> ActorNames { get; set; }
    }
}
