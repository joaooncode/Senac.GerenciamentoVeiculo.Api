using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculo.Domain.Services;



// Controller, define os endpoints, recebe as requisições e chama as services

namespace Senac.GerenciamentoVeiculo.Api.Controllers
{

    [ApiController]
    [Route("carro")]
    public class CarroController : Controller
    {

        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var carrosResponse = _carroService.GetAll();

            return Ok(carrosResponse);
        }
    }
}
