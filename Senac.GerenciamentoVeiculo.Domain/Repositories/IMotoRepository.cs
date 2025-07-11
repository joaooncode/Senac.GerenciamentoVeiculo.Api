using Senac.GerenciamentoVeiculo.Domain.Models.Moto;

namespace Senac.GerenciamentoVeiculo.Domain.Repositories
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAll();

        Task<Moto> GetByIdMoto(long id);

        Task<long> InsertMoto(Moto motto);
        Task UpdateByIdMoto(Moto moto);

        Task DeleteByIdMoto(long id);
    }
}
