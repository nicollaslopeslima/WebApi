namespace WebApi.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public EmpresaModel Empresa { get; set; }
    }
}
