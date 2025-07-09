using Dapper;
using Senac.GerenciamentoVeiculo.Domain.Models.Moto;
using Senac.GerenciamentoVeiculo.Domain.Repositories;
using Senac.GerenciamentoVeiculo.Infra.Data.DatabaseConfiguration;

namespace Senac.GerenciamentoVeiculo.Infra.Data.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        
        private readonly IDbConnectionFactory _connectionFactory;

        public MotoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<IEnumerable<Moto>> GetAll()
        {
            return await _connectionFactory.CreateConnection()
                .QueryAsync<Moto>(@"SELECT nome FROM moto ORDER BY nome");
        }

        public async Task<long> InsertMoto(Moto moto)
        {
            return await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync<long>(@"INSERT INTO moto (nome, marca, placa, cor, anoFabricacao, tipoCombustivelId) OUTPUT INSERTED.Id VALUES (@Nome, @Marca, @Placa, @Cor, @AnoFabricacao, @TipoCombustivel)", moto);
        }
    }
}
