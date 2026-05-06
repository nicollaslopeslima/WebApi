using WebApi.Models;

namespace WebApi.Dto.Jogo
{
    public class JogoEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public EmpresaModel Empresa { get; set; }
    }
}
