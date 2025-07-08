using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Moto;

namespace Senac.GerenciamentoVeiculo.Domain.Services.Moto
{
    public interface IMotoService
    {
        Task<IEnumerable<GetAllResponse>> GetAll();
    }
}
