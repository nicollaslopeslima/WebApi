using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services.Empresa
{
    public class EmpresaService : IEmpresaInterface
    {
        private readonly AppDbContext _context;
        public EmpresaService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorId(int idEmpresa)
        {
            ResponseModel<EmpresaModel> resposta = new ResponseModel<EmpresaModel>();
            try
            {
                var empresa = await _context.Empresas.FirstOrDefaultAsync(empresaBanco => empresaBanco.Id == idEmpresa);

                if (empresa == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = empresa;
                resposta.Mensagem = "Empresa localizada com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorIdJogo(int idJogo)
        {
            ResponseModel<EmpresaModel> resposta = new ResponseModel<EmpresaModel>();
            try
            {
                var livro = await _context.Jogos
                    .Include(j => j.Empresa)
                    .FirstOrDefaultAsync(jogoBanco => jogoBanco.Id == idJogo);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;    
                }

                resposta.Dados = livro.Empresa;
                resposta.Mensagem = "Empresa localizada com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<EmpresaModel>>> ListarEmpresas()
        {
            ResponseModel<List<EmpresaModel>> resposta = new ResponseModel<List<EmpresaModel>>();
            try
            {
                var empresas = await _context.Empresas.ToListAsync();

                resposta.Dados = empresas;
                resposta.Mensagem = "Empresas listadas com sucesso.";

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
