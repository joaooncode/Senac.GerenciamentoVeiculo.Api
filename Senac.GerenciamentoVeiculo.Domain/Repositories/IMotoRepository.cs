using Senac.GerenciamentoVeiculo.Domain.Models.Moto;

namespace Senac.GerenciamentoVeiculo.Domain.Repositories
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAll();
        Task<long> InsertMoto(Moto motto);
        
    }
}
