using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.NovaPasta2;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Carro;
using Senac.GerenciamentoVeiculo.Domain.Models;
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

        public async Task DeleteById(long id)

        {
            var carro = await _carroRepository.GetById(id);

            if (carro == null)
            {
                throw new Exception($"Nenhum carro encontrado com o id: {id}");
            }
            ;

            await _carroRepository.DeleteById(id);
        }

        public async Task<IEnumerable<GetAllResponses>> GetAll()
        {
            var carros = await _carroRepository.GetAll();


            var carrosResponses = carros
                .Select(c => new GetAllResponses { Nome = c.Nome, Id = c.Id });

            return carrosResponses;
        }

        public async Task<GetByIdResponses?> GetById(long id)
        {
            var carro = await _carroRepository.GetById(id);

            if (carro == null)
            {
                throw new Exception($"Nenhum carro encontrado com o id: {id}");
            }
            ;

            return new GetByIdResponses { Nome = carro.Nome, Id = carro.Id, Ano = carro.AnoFabricacao, Cor = carro.Cor, Marca = carro.Marca, TipoCombustivel = carro.TipoCombustivel.ToString(), Placa = carro.Placa };
        }

        public async Task<InsertResponse> Insert(InsertRequest insertRequest)
        {

            bool isTipoCombustivelValido = Enum.TryParse(insertRequest.TipoCombustivel, ignoreCase: true, out TipoCombustivel tipoCombustivel);

            if (!isTipoCombustivelValido)
            {
                throw new Exception($"Tipo de combustível inválido: {insertRequest.TipoCombustivel}");
            }

            try
            {
                var carro = new Carro
                {
                    Nome = insertRequest.Nome,
                    Cor = insertRequest.Cor,
                    Marca = insertRequest.Marca,
                    AnoFabricacao = insertRequest.AnoFabricacao,
                    Placa = insertRequest.Placa,
                    TipoCombustivel = tipoCombustivel
                };

                long idResponse = await _carroRepository.Insert(carro);

                var response = new InsertResponse
                {
                    Id = idResponse,
                };
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception($"Falha ao tentar criar Carro {ex}");
            }
            
        }

        public async Task UpdateById(long id, UpdateRequest updateRequest)
        {
            bool isTipoCombustivelValido = Enum.TryParse(updateRequest.TipoCombustivel, ignoreCase: true, out TipoCombustivel tipoCombustivel);

            if (!isTipoCombustivelValido)
            {
                throw new Exception($"Tipo de combustível inválido: {updateRequest.TipoCombustivel}");
            }

            try
            {
                var carro = await _carroRepository.GetById(id);

                if (carro == null) {

                    throw new Exception($"Não foi encontrado um carro com o Id: {id}");
                }

                carro.Placa = updateRequest.Placa;
                carro.Cor = updateRequest.Cor;
                carro.TipoCombustivel = tipoCombustivel;


                await _carroRepository.UpdateById(carro);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
