using System.Text.Json.Serialization;

namespace Ator_Filme.Models
{
    public class ActorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<FilmModel> Films { get; set; }

    }
}
