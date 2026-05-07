using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Empresa;
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

        public async Task<ResponseModel<List<JogoModel>>> BuscarJogoPorIdEmpresa(int idEmpresa)
        {
            ResponseModel<List<JogoModel>> resposta = new ResponseModel<List<JogoModel>>();
            try
            {
                var jogo = await _context.Jogos
                    .Include(e => e.Empresa)
                    .Where(jogoBanco => jogoBanco.Empresa.Id == idEmpresa)
                    .ToListAsync();

                if (jogo == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = jogo;
                resposta.Mensagem = "Jogos localizados com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<JogoModel>>> CriarJogo(JogoCriacaoDto JogoCriacaoDto)
        {
            ResponseModel<List<JogoModel>> resposta = new ResponseModel<List<JogoModel>>();
            try
            {
                var empresa = await _context.Empresas
                    .FirstOrDefaultAsync(empresa => empresa.Id == JogoCriacaoDto.Empresa.Id);

                if (empresa == null) 
                {
                    resposta.Mensagem = "Empresa não localizada.";
                    return resposta;
                }

                var jogo= new JogoModel
                {
                    Titulo = JogoCriacaoDto.Titulo,
                    Empresa = empresa
                };

                _context.Add(jogo);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Jogos.Include(e => e.Empresa).ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<JogoModel>>> EditarJogo(JogoEdicaoDto JogoEdicaoDto)
        {
            ResponseModel<List<JogoModel>> resposta = new ResponseModel<List<JogoModel>>();
            try
            {
                var jogo = await _context.Jogos
                    .Include(e => e.Empresa)
                    .FirstOrDefaultAsync(jogoBanco => jogoBanco.Id == JogoEdicaoDto.Id);

                var empresa = await _context.Empresas
                    .FirstOrDefaultAsync(empresaBanco => empresaBanco.Id == JogoEdicaoDto.Empresa.Id);

                if (empresa == null)
                {
                    resposta.Mensagem = "Empresa não localizada.";
                    return resposta;
                }

                if (jogo == null)
                {
                    resposta.Mensagem = "Jogo não localizado.";
                    return resposta;
                }

                jogo.Titulo = JogoEdicaoDto.Titulo;
                jogo.Empresa = empresa;

                _context.Update(jogo);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Jogos.ToListAsync();
                resposta.Mensagem = "Jogo editado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<JogoModel>>> ExcluirJogo(int idJogo)
        {
            ResponseModel<List<JogoModel>> resposta = new ResponseModel<List<JogoModel>>();
            try
            {
                var jogo = _context.Jogos
                    .FirstOrDefault(jogoBanco => jogoBanco.Id == idJogo);

                if (jogo == null)
                {
                    resposta.Mensagem = "Nenhum jogo localizada.";
                    return resposta;
                }
                _context.Jogos.Remove(jogo);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Jogos.ToListAsync();
                resposta.Mensagem = "Jogo excluído com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;

            }
        }

        public async Task<ResponseModel<List<JogoModel>>> ListarJogos()
        {
            ResponseModel<List<JogoModel>> resposta = new ResponseModel<List<JogoModel>>();
            try
            {
                var jogos = await _context.Jogos.ToListAsync();

                resposta.Dados = jogos;
                resposta.Mensagem = "Jogos listados com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
