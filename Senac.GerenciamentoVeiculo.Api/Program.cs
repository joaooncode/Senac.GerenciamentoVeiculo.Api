using Senac.GerenciamentoVeiculo.Domain.Repositories;
using Senac.GerenciamentoVeiculo.Domain.Services;
using Senac.GerenciamentoVeiculo.Infra.Data.DatabaseConfiguration;
using Senac.GerenciamentoVeiculo.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IDbConnectionFactory>(x =>
{
    return new DbConnectionFactory("Server=localhost,1433;Database=gerenciamento_veiculo;User Id=sa;Password=Admin123!; TrustServerCertificate=True;");
});



builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
