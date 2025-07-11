using Microsoft.AspNetCore.Mvc;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Requests.Moto;
using Senac.GerenciamentoVeiculo.Domain.DTO_s.Responses;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotoById(long id)
        {
            try
            {
                var moto = await _motoService.GetMotoById(id);
                return Ok(moto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> InsertMoto([FromBody] InsertMotoRequest insertMotoRequest)
        {
            var moto = await _motoService.InsertMoto(insertMotoRequest);
            return Ok(moto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByIdMoto([FromRoute] long id, [FromBody] UpdateMotoRequest updateRequest)
        {
            try
            {
                await _motoService.UpdateByIdMoto(id, updateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                var errorResponse = new ErroResponse
                {
                    Mensagem = ex.Message,
                    StatusCode = "500"
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdMoto([FromRoute] long id) 
        {
            try
            {
                await _motoService.DeleteByIdMoto(id);
                return Ok();
            }
            catch (Exception ex)
            {

                var errorResponse = new ErroResponse
                {
                    Mensagem = ex.Message,
                    StatusCode = "500"
                };

                return BadRequest(errorResponse);
            }

        }


    }
}
