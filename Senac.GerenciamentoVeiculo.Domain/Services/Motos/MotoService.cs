using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.Moto;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Moto;
using Senac.GerenciamentoVeiculo.Domain.Models.Moto;
using Senac.GerenciamentoVeiculo.Domain.Repositories;

namespace Senac.GerenciamentoVeiculo.Domain.Services.Motos
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

        public async Task<InsertMotoResponse> InsertMoto(InsertMotoRequest insertMotoRequest)
        {
            bool isTipoCombustivelValido = Enum.TryParse(insertMotoRequest.TipoCombustivel, ignoreCase: true, out TipoCombustivelMoto tipoCombustivelMoto);


            if (!isTipoCombustivelValido)
            {
                throw new Exception($"Tipo de Combustível inválido: {insertMotoRequest.TipoCombustivel}");
            }

            try
            {
                var moto = new Moto
                {
                    Nome = insertMotoRequest.Nome,
                    Cor = insertMotoRequest.Cor,
                    AnoFabricacao = insertMotoRequest.AnoFabricacao,
                    Placa = insertMotoRequest.Placa,
                    Marca = insertMotoRequest.Marca,
                    TipoCombustivel = tipoCombustivelMoto
                };

                long idResponse = await _motoRepository.InsertMoto(moto);

                var response = new InsertMotoResponse
                {
                    Id = idResponse,
                };

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception($"Falha ao criar moto: {ex}");
            }
        }
    }
}
