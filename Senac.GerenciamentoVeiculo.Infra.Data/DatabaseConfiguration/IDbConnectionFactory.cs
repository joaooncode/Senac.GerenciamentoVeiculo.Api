using System.Data;

namespace Senac.GerenciamentoVeiculo.Infra.Data.DatabaseConfiguration
{
    public interface IDbConnectionFactory
    {
       IDbConnection CreateConnection();

       

    }
}
