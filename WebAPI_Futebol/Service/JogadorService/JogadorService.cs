using Microsoft.EntityFrameworkCore;
using WebAPI_Futebol.DataContext;
using WebAPI_Futebol.Models;

namespace WebAPI_Futebol.Service.JogadorService;

public class JogadorService : IJogadorInterface
{
    // CONECTANDO O SERVICE COM O BANCO POR MEIO DO DBCONTEXT
    private readonly ApplicationDbContext _context;
    public JogadorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<JogadoresModel>>> CreateJogador(JogadoresModel novoJogador)
    {
        ServiceResponse<List<JogadoresModel>> serviceResponse = new ServiceResponse<List<JogadoresModel>>();

        try
        {
            if (novoJogador == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informar dados do jogador!";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }

            _context.Add(novoJogador);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Jogadores.ToList();

        } catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<JogadoresModel>>> DeleteJogador(int id)
    {
        ServiceResponse<List<JogadoresModel>> serviceResponse = new ServiceResponse<List<JogadoresModel>>();

        try
        {
            JogadoresModel jogador = _context.Jogadores.FirstOrDefault(x => x.Id == id);

            if (jogador == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogador não encontrado!";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }

            _context.Jogadores.Remove(jogador);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Jogadores.ToList();

        }catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<JogadoresModel>> GetJogadorById(int id)
    {
        ServiceResponse<JogadoresModel> serviceResponse = new ServiceResponse<JogadoresModel>();

        try
        {
            JogadoresModel jogador = _context.Jogadores.FirstOrDefault(x => x.Id == id);

            if (jogador == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogador não encontrado!";
                serviceResponse.Sucesso = false;
            }

            serviceResponse.Dados = jogador;
        } catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<JogadoresModel>>> GetJogadores()
    {
        ServiceResponse<List<JogadoresModel>> serviceResponse = new ServiceResponse<List<JogadoresModel>>();

        try
        {
            serviceResponse.Dados = _context.Jogadores.ToList();

            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
            }

        } catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<JogadoresModel>>> InativaJogador(int id)
    {
        ServiceResponse<List<JogadoresModel>> serviceResponse = new ServiceResponse<List<JogadoresModel>>();

        try
        {
            JogadoresModel jogador = _context.Jogadores.FirstOrDefault(x => x.Id == id);

            if (jogador == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogador não encontrado!";
                serviceResponse.Sucesso = false;
            }

            jogador.Ativo = false;
            jogador.DataDeAlteracao = DateTime.Now.ToLocalTime();

            _context.Jogadores.Update(jogador);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Jogadores.ToList();

        }catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<JogadoresModel>>> UpdateJogador(JogadoresModel atualizadoJogador)
    {
        ServiceResponse<List<JogadoresModel>> serviceResponse = new ServiceResponse<List<JogadoresModel>>();

        try
        {
            JogadoresModel jogador = _context.Jogadores.AsNoTracking().FirstOrDefault(x => x.Id == atualizadoJogador.Id);

            if (jogador == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogador não encontrado!";
                serviceResponse.Sucesso = false;
            }

            jogador.DataDeAlteracao = DateTime.Now.ToLocalTime();
            _context.Jogadores.Update(atualizadoJogador);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Jogadores.ToList();

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}
