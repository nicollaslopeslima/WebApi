using WebApi.Models;

namespace WebApi.Services.Empresa
{
    public interface IEmpresaInterface
    {
        Task<ResponseModel<List<EmpresaModel>>> ListarEmpresas();
        Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorId(int idEmpresa);
        Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorIdJogo(int idJogo);
    }
}
