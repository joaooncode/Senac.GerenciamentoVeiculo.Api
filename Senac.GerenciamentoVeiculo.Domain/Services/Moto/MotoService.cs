using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Moto;
using Senac.GerenciamentoVeiculo.Domain.Repositories;

namespace Senac.GerenciamentoVeiculo.Domain.Services.Moto
{
    public class MotoService : IMotoService
    {

        private readonly IMotoRepository _motoRepository;

        public MotoService(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        public async Task<IEnumerable<GetAllResponse>> GetAll()
        {
            var motos = await _motoRepository.GetAll();

            var motosResponses = motos.Select(m => new GetAllResponse { Nome = m.Nome });

            return motosResponses;
        }
    }
}
