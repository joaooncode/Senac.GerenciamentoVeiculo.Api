using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Carro;
using Senac.GerenciamentoVeiculo.Domain.Models;

namespace Senac.GerenciamentoVeiculo.Domain.Services
{
    public interface ICarroService
    {
    Task <IEnumerable<GetAllResponses>> GetAll();
    }
}
