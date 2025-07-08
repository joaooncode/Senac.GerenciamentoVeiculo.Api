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

        public async Task DeleteById(long id)
        {
            await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync(
                    @"
                     DELETE FROM Carro WHERE id = @Id
                    "
                , new { Id = id });
        }

        public Task UpdateById(Carro carro)
        {
            throw new NotImplementedException();
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

        public async Task<long> Insert(Carro carro)
        {
            return await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync<long>(

                    @"
                        INSERT INTO carro
                        (
                            nome, 
                            marca, 
                            placa, 
                            cor,    
                            anoFabricacao, 
                            tipoCombustivelId
                        )
                        OUTPUT INSERTED.Id
                        VALUES
                        (
                            @Nome, 
                            @Marca, 
                            @Placa, 
                            @Cor, 
                            @AnoFabricacao, 
                            @TipoCombustivel
                        )"
                , carro);
        }

       async Task<Carro> ICarroRepository.GetById(long id)
        {
            return await _connectionFactory.CreateConnection()
                 .QueryFirstOrDefaultAsync<Carro>(
                     @"select c.Id,
	                        c.Nome,
	                        c.Marca,
	                        c.Cor,
	                        c.AnoFabricacao,
	                        c.Placa,
	                        t.Id  AS TipoCombustivel
		                        from Carro c
		                            inner join
			                            TipoCombustivel t on t.Id = c.TipoCombustivelId
			                                where c.Id = @Id", new { Id = id }
                     );
        }


       async Task ICarroRepository.UpdateById(Carro carro)
        {
             await _connectionFactory.CreateConnection()
                .QueryFirstOrDefaultAsync<Carro>(
                 @"
                    UPDATE Carro SET
                                    Placa = @Placa, 
                                    Cor = @Cor,
                                    TipoCombustivelId = @TipoCombustivel 
                                        WHERE Id = @Id
                    ", new
                 {
                     Placa = carro.Placa,
                     Cor = carro.Cor,
                     TipoCombustivel = (int)carro.TipoCombustivel,
                     Id = carro.Id
                 });
        }
    }
}
