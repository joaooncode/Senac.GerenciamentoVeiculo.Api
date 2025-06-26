using Dapper;
using Senac.GerenciamentoVeiculo.Domain.Models;
using Senac.GerenciamentoVeiculo.Domain.Repositories;
using Senac.GerenciamentoVeiculo.Infra.Data.DatabaseConfiguration;



// Responsavel por conectar ao banco de dados e retornar dados para a service.

namespace Senac.GerenciamentoVeiculo.Infra.Data.Repositories
{
    public class CarroRepository : ICarroRepository
    {

        private readonly IDbConnectionFactory _connectionFactory;

        public CarroRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Carro>> GetAll()
        {
            return await _connectionFactory.CreateConnection()
                .QueryAsync<Carro>(
                @"SELECT id,
                         nome
                    FROM carro
                    ORDER BY nome
                ");
        }
    }
}
