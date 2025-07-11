using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.Moto
{
    public class UpdateMotoRequest
    {

        public string Cor { get; set; }

        public string Placa { get; set; }

        public string TipoCombustivel { get; set; }
    }
}
