using Senac.GerenciamentoVeiculo.Domain.Repositories;
using Senac.GerenciamentoVeiculo.Domain.Services;
using Senac.GerenciamentoVeiculo.Domain.Services.Moto;
using Senac.GerenciamentoVeiculo.Infra.Data.DatabaseConfiguration;
using Senac.GerenciamentoVeiculo.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IDbConnectionFactory>(x =>
{
    return new DbConnectionFactory("Server=(localdb)\\MSSQLLocalDB; Database=gerenciamento_veiculo; Trusted_Connection=True");
});



builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();

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
