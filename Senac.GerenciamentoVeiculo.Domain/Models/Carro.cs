﻿namespace Senac.GerenciamentoVeiculo.Domain.Models
{
    public class Carro
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public int AnoFabricacao { get; set; }

        public string Placa { get; set; }

        public string Cor { get; set; }

        public TipoCombustivel TipoCombustivel { get; set; }

    }
}
