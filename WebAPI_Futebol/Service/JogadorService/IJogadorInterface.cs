using WebAPI_Futebol.Models;

namespace WebAPI_Futebol.Service.JogadorService;

public interface IJogadorInterface
{
    Task<ServiceResponse<List<JogadoresModel>>> GetJogadores();
    Task<ServiceResponse<List<JogadoresModel>>> CreateJogador(JogadoresModel novoJogador);
    Task<ServiceResponse<JogadoresModel>> GetJogadorById(int id);
    Task<ServiceResponse<List<JogadoresModel>>> UpdateJogador(JogadoresModel atualizadoJogador);
    Task<ServiceResponse<List<JogadoresModel>>> DeleteJogador(int id);
    Task<ServiceResponse<List<JogadoresModel>>> InativaJogador(int id);
}
