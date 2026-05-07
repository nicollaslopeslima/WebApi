using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Empresa;
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

        public async Task<ResponseModel<List<EmpresaModel>>> CriarEmpresa(EmpresaCriacaoDto empresaCriacaoDto)
        {
           ResponseModel<List<EmpresaModel>> resposta = new ResponseModel<List<EmpresaModel>>();
            try
            {
                var empresa = new EmpresaModel()
                {
                    Nome = empresaCriacaoDto.Nome
                };

                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Empresas.ToListAsync();
                resposta.Mensagem = "Empresa criada com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
               resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<EmpresaModel>>> EditarEmpresa(EmpresaEdicaoDto empresaEdicaoDto)
        {
            ResponseModel<List<EmpresaModel>> resposta = new ResponseModel<List<EmpresaModel>>();
            try
            {
                var empresa = _context.Empresas
                    .FirstOrDefault(empresaBanco => empresaBanco.Id == empresaEdicaoDto.Id);

                if (empresa == null)
                {
                    resposta.Mensagem = "Nenhuma empresa localizada.";
                    return resposta;
                }

                empresa.Nome = empresaEdicaoDto.Nome;

                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Empresas.ToListAsync();
                resposta.Mensagem = "Empresa editada com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<EmpresaModel>>> ExcluirEmpresa(int idEmpresa)
        {
           ResponseModel<List<EmpresaModel>> resposta = new ResponseModel<List<EmpresaModel>>();
            try
            {
                var empresa = _context.Empresas
                    .FirstOrDefault(empresaBanco => empresaBanco.Id == idEmpresa);

                if (empresa == null)
                {
                    resposta.Mensagem = "Nenhuma empresa localizada.";
                    return resposta;
                }
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Empresas.ToListAsync();
                resposta.Mensagem = "Empresa excluída com sucesso.";

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
