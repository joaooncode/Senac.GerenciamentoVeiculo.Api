using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.Moto;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Moto;

namespace Senac.GerenciamentoVeiculo.Domain.Services.Motos
{
    public interface IMotoService
    {
        Task<IEnumerable<GetAllResponse>> GetAll();
        Task<InsertMotoResponse> InsertMoto(InsertMotoRequest insertMotoRequest);
    }
}
