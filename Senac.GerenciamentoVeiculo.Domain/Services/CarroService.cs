using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Carro;
using Senac.GerenciamentoVeiculo.Domain.Repositories;




// Service, conecta ao repository e possui regras de negocios


namespace Senac.GerenciamentoVeiculo.Domain.Services
{
    public class CarroService : ICarroService
    {

        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<IEnumerable<GetAllResponses>> GetAll()
        {
           var carros = await _carroRepository.GetAll();


            var carrosResponses = carros.Select(c => new GetAllResponses { Nome = c.Nome });

            return carrosResponses;
        }
    }
}
