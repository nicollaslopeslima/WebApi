using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Jogo;
using WebApi.Models;

namespace WebApi.Services.Jogo
{
    public class JogoService : IJogoInterface
    {
        private readonly AppDbContext _context;

        public JogoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<JogoModel>> BuscarJogoPorId(int idJogo)
        {
            ResponseModel<JogoModel> resposta = new ResponseModel<JogoModel>();
            try
            {
                var jogo = await _context.Jogos
                    .FirstOrDefaultAsync(jogoBanco => jogoBanco.Id == idJogo);

                if (jogo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = jogo;
                resposta.Mensagem = "Jogo localizado com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<JogoModel>> BuscarJogoPorIdEmpresa(int idEmpresa)
        {
            //ResponseModel<JogoModel> resposta = new ResponseModel<JogoModel>();
            //try
            //{
            //   var

            //    if (livro == null)
            //    {
            //        resposta.Mensagem = "Nenhum registro localizado.";
            //        return resposta;
            //    }

            //    resposta.Dados = livro.Empresa;
            //    resposta.Mensagem = "Empresa localizada com sucesso.";
            //    return resposta;
            //}
            //catch (Exception ex)
            //{

            //    resposta.Mensagem = ex.Message;
            //    resposta.Status = false;
            //    return resposta;
            //}
        }

        public Task<ResponseModel<List<JogoModel>>> CriarJogo(JogoCriacaoDto JogoCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<JogoModel>>> EditarJogo(JogoEdicaoDto JogoEdicaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<JogoModel>>> ExcluirJogo(int idJogo)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<JogoModel>>> ListarJogos()
        {
            throw new NotImplementedException();
        }
    }
}
