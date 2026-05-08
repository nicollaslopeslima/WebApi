using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Jogo;
using WebApi.Models;
using WebApi.Services.Jogo;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoInterface _jogoInterface;
        public JogoController(
            IJogoInterface jogoInterface)
        {
            _jogoInterface = jogoInterface;
        }

        [HttpGet("ListarJogos")]
        public async Task<ActionResult<ResponseModel<List<JogoModel>>>> ListarJogos()
        {
            var jogos = await _jogoInterface.ListarJogos();
            return Ok(jogos);
        }

        [HttpGet("BuscarJogoPorId/{idJogo}")]
        public async Task<ActionResult<ResponseModel<JogoModel>>> BuscarJogoPorId(int idJogo    )
        {
            var jogo = await _jogoInterface.BuscarJogoPorId(idJogo);
            return Ok(jogo);
        }

        [HttpGet("BuscarJogoPorIdEmpresa/{idEmpresa}")]
        public async Task<ActionResult<ResponseModel<JogoModel>>> BuscarJogoPorIdEmpresa(int idEmpresa)
        {
            var jogo = await _jogoInterface.BuscarJogoPorIdEmpresa(idEmpresa);
            return Ok(jogo);
        }

        [HttpPost("CriarJogo")]
        public async Task<ActionResult<ResponseModel<List<JogoModel>>>> CriarJogo(JogoCriacaoDto jogoCriacaoDto)
        {
            var jogos = await _jogoInterface.CriarJogo(jogoCriacaoDto);
            return Ok(jogos);
        }

        [HttpPut("EditarJogo")]
        public async Task<ActionResult<ResponseModel<List<JogoModel>>>> EditarJogo(JogoEdicaoDto jogoEdicaoDto)
        {
            var jogos = await _jogoInterface.EditarJogo(jogoEdicaoDto);
            return Ok(jogos);
        }

        [HttpDelete("ExcluirJogo")]
        public async Task<ActionResult<ResponseModel<List<JogoModel>>>> ExcluirJogo(int idJogo)
        {
            var jogos = await _jogoInterface.ExcluirJogo(idJogo);
            return Ok(jogos);
        }
    }
}
