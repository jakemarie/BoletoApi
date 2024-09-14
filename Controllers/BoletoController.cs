using BoletoApi.Models;
using BoletoApi.Service.BoletoService;
using Microsoft.AspNetCore.Mvc;

namespace BoletoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoInterface _boletoInterface;
        public BoletoController(IBoletoInterface boletoInterface) 
        {
            _boletoInterface = boletoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BoletoModel>>>> GetBoletos() 
        {
            return Ok(await _boletoInterface.GetBoletos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BoletoModel>>> GetBoletoById(int id) 
        {
            ServiceResponse<BoletoModel> serviceResponse = await _boletoInterface.GetBoletoById(id);
            return Ok(serviceResponse);
        }

        [HttpGet("Boletos-data-atual")]
        public async Task<ActionResult<ServiceResponse<List<BoletoModel>>>> GetBoletoDataAtual()
        {
            return Ok(await _boletoInterface.GetBoletoDataAtual());
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<BoletoModel>>>> UpdateBoleto(BoletoModel EditandoBoleto)
        {
            ServiceResponse<List<BoletoModel>> serviceResponse = await _boletoInterface.UpdateBoleto(EditandoBoleto);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<BoletoModel>>>> CreateBoletos(BoletoModel novoBoleto) 
        {
            return Ok(await _boletoInterface.CreateBoletos(novoBoleto));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<BoletoModel>>>> DeleteBoletos(int id)
        {
            ServiceResponse<List<BoletoModel>> serviceResponse = await _boletoInterface.DeleteBoleto(id);
            return Ok(serviceResponse);
        }

    }
}
