using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.NovaPasta2;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses.Carro;
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
        public async Task <IActionResult> GetAll()
        {

            var carrosResponse = await _carroService.GetAll();

            return Ok(carrosResponse);
        }


        [HttpGet("{id}")]



        public async Task<IActionResult> GetById(long id)
        {

            try
            {
                var carroIdResponse = await _carroService.GetById(id);
                return Ok(carroIdResponse);
            }
            catch (Exception ex)
            {
                var response = new ErroResponse
                {
                    Mensagem = $"Nenhum carro encontrado com o Id {id}",
                    StatusCode = "404"

                };
                return NotFound(response);
            }

       
        }

        [HttpPost]

        public async Task<IActionResult> Insert([FromBody] InsertRequest insertRequest)
        {
            var insertResponse = await _carroService.Insert(insertRequest);

            return Ok(insertResponse);
        }

    }
}
