using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Empresa;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaInterface _empresaInterface;
        public EmpresaController(IEmpresaInterface empresaInterface)
        {
            _empresaInterface = empresaInterface;
        }

        [HttpGet("ListarEmpresas")]
        public async Task<ActionResult<ResponseModel<List<EmpresaModel>>>> ListarEmpresas()
        {
            var empresas = await _empresaInterface.ListarEmpresas();
            return Ok(empresas);
        }

        [HttpGet("BuscarEmpresaPorId/{idEmpresa}")]
        public async Task<ActionResult<ResponseModel<EmpresaModel>>> BuscarEmpresaPorId(int idEmpresa)
        {
            var empresa = await _empresaInterface.BuscarEmpresaPorId(idEmpresa);
            return Ok(empresa);
        }
    }
}
