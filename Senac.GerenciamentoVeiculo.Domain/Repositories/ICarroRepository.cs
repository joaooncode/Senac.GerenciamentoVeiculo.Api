using Senac.GerenciamentoVeiculo.Domain.Models;

namespace Senac.GerenciamentoVeiculo.Domain.Repositories
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> GetAll();

        Task<Carro> GetById(long id);
    }
}
