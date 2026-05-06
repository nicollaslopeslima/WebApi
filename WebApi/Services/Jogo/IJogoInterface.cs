using WebApi.Dto.Jogo;
using WebApi.Models;

namespace WebApi.Services.Jogo
{
    public interface IJogoInterface
    {
        Task<ResponseModel<List<JogoModel>>> ListarJogos();
        Task<ResponseModel<JogoModel>> BuscarJogoPorId(int idJogo);
        Task<ResponseModel<JogoModel>> BuscarJogoPorIdEmpresa(int idEmpresa);

        Task<ResponseModel<List<JogoModel>>> CriarJogo(JogoCriacaoDto JogoCriacaoDto);
        Task<ResponseModel<List<JogoModel>>> EditarJogo(JogoEdicaoDto JogoEdicaoDto);
        Task<ResponseModel<List<JogoModel>>> ExcluirJogo(int idJogo);
    }
}
