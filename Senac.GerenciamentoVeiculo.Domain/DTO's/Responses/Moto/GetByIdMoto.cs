namespace Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Moto
{
    public class GetByIdMoto
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Cor { get; set; }

        public string Placa { get; set; }

        public int AnoFabricacao { get; set; }

        public string TipoCombustivel { get; set; }
    }
}
