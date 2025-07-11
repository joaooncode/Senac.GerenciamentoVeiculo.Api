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

        public async Task DeleteByIdMoto(long id)
        {
            await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync<Moto>(@"DELETE  FROM Moto  WHERE @Id = id", new {Id = id});
        }

        public async Task<IEnumerable<Moto>> GetAll()
        {
            return await _connectionFactory.CreateConnection()
                .QueryAsync<Moto>(@"SELECT nome FROM moto ORDER BY nome");
        }

        public async Task<Moto> GetByIdMoto(long id)
        {
            return await _connectionFactory.CreateConnection()
                 .QueryFirstOrDefaultAsync<Moto>(
                    @"select m.Id,
                             m.Nome,
                             m.Marca,
                             m.Placa,
                             m.Cor,
                             m.AnoFabricacao,
                             t.Id AS TipoCombustivel
                                from Moto m
                                       INNER JOIN
                                              TipoCombustivel t on t.Id = m.TipoCombustivelId WHERE m.Id = @Id", new {Id = id});
        }

        public async Task<long> InsertMoto(Moto moto)
        {
            return await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync<long>(@"INSERT INTO moto (nome, marca, placa, cor, anoFabricacao, tipoCombustivelId) OUTPUT INSERTED.Id VALUES (@Nome, @Marca, @Placa, @Cor, @AnoFabricacao, @TipoCombustivel)", moto);
        }

        public async Task UpdateByIdMoto(Moto moto)
        {
            await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync<Moto>(
                    @"UPDATE Moto SET Placa = @Placa, Cor = @Cor, TipoCombustivelId = @TipoCombustivel WHERE Id = @Id",
                    new {Placa = moto.Placa,
                        Cor = moto.Cor,
                        TipoCombustivel = (int)moto.TipoCombustivel,
                        Id = moto.Id
                   
                    }
                );
        }
    }
}
