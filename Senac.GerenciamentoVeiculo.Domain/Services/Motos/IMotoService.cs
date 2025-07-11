using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.Moto;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Moto;

namespace Senac.GerenciamentoVeiculo.Domain.Services.Motos
{
    public interface IMotoService
    {
        Task<IEnumerable<GetAllResponse>> GetAll();
        Task<GetByIdMoto> GetMotoById(long id);

        Task<InsertMotoResponse> InsertMoto(InsertMotoRequest insertMotoRequest);
        Task UpdateByIdMoto(long id, UpdateMotoRequest updateRequest);

        Task DeleteByIdMoto(long id);
    }
}
