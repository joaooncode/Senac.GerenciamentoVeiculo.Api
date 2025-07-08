using Senac.GerenciamentoVeiculo.Domain.Models;

namespace Senac.GerenciamentoVeiculo.Domain.Repositories
{
    public interface ICarroRepository
    {
        Task DeleteById(long id);
        Task<IEnumerable<Carro>> GetAll();

        Task<Carro> GetById(long id);
        Task<long> Insert(Carro carro);

        Task UpdateById(Carro carro);
    }
}
