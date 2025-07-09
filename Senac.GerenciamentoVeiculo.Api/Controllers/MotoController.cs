using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.Moto;
using Senac.GerenciamentoVeiculo.Domain.Services.Motos;

namespace Senac.GerenciamentoVeiculo.Api.Controllers
{

    [ApiController]
    [Route("moto")]
    public class MotoController : Controller
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var motos = await _motoService.GetAll();

            return Ok(motos);
        }

        [HttpPost]
        public async Task<IActionResult> InsertMoto([FromBody] InsertMotoRequest insertMotoRequest)
        {
            var moto = await _motoService.InsertMoto(insertMotoRequest);
            return Ok(moto);
        }
    }
}
