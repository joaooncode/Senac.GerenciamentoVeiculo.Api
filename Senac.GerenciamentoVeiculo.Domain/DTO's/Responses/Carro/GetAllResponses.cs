using Senac.GerenciamentoVeiculo.Domain.Models;

namespace Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Carro
{
    public class GetAllResponses
    {
        public string Nome { get; set; }

        public long Id { get; set; }

    }

    public class GetByIdResponses
    { 
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public int Ano { get; set; }

        public string Cor {  get; set; }

        public string TipoCombustivel { get; set; }

        public string Placa { get; set; }
    }

}
