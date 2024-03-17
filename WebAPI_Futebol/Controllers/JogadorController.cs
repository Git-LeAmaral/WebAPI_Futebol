using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Futebol.Models;
using WebAPI_Futebol.Service.JogadorService;

namespace WebAPI_Futebol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        // Criando uma Injeção de dependencia para acessar a IJogadorInterface para conseguir acesso a todos métodos 
        private readonly IJogadorInterface _jogadorInterface;
        public JogadorController(IJogadorInterface jogadorInterface)
        {
            _jogadorInterface = jogadorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<JogadoresModel>>>> GetJogadores()
        {
            return Ok(await _jogadorInterface.GetJogadores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<JogadoresModel>>> GetJogadorById(int id)
        {
            ServiceResponse<JogadoresModel> serviceResponse = await _jogadorInterface.GetJogadorById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<JogadoresModel>>>> CreateJogador(JogadoresModel novoJogador)
        {
            return Ok(await _jogadorInterface.CreateJogador(novoJogador));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<JogadoresModel>>>> UpdateJogador(JogadoresModel atualizadoJogador)
        {
            ServiceResponse<List<JogadoresModel>> serviceResponse = await _jogadorInterface.UpdateJogador(atualizadoJogador);
            return Ok(serviceResponse);
        }

        [HttpPut("inativaJogador")]
        public async Task<ActionResult<ServiceResponse<List<JogadoresModel>>>> InativaJogador(int id)
        {
            ServiceResponse<List<JogadoresModel>> serviceResponse = await _jogadorInterface.InativaJogador(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<JogadoresModel>>>> DeleteJogador(int id)
        {
            ServiceResponse<List<JogadoresModel>> serviceResponse = await _jogadorInterface.DeleteJogador(id);

            return Ok(serviceResponse);
        }
    }
}
