using WebApi.Dto.Empresa;
using WebApi.Models;

namespace WebApi.Services.Empresa
{
    public interface IEmpresaInterface
    {
        Task<ResponseModel<List<EmpresaModel>>> ListarEmpresas();
        Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorId(int idEmpresa);
        Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorIdJogo(int idJogo);

        Task<ResponseModel<List<EmpresaModel>>> CriarEmpresa(EmpresaCriacaoDto empresaCriacaoDto);
        Task<ResponseModel<List<EmpresaModel>>> EditarEmpresa(EmpresaEdicaoDto empresaEdicaoDto);
        Task<ResponseModel<List<EmpresaModel>>> ExcluirEmpresa(int idEmpresa);
    }
}
