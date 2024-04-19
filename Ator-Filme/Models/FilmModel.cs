using System.Text.Json.Serialization;

namespace Ator_Filme.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public ICollection<ActorModel> Actors { get; set; }
    }
}
