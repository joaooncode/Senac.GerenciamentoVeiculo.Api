using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.GerenciamentoVeiculo.Domain.Models;

namespace Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.NovaPasta2
{
    public class InsertRequest
    {

        public string Nome { get; set; }

        public string Marca { get; set; }

        public int AnoFabricacao { get; set; }

        public string Placa { get; set; }

        public string Cor { get; set; }

        public string TipoCombustivel { get; set; }

    }
}
