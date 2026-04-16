using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<JogoModel> Jogos { get; set; }
    }
}
