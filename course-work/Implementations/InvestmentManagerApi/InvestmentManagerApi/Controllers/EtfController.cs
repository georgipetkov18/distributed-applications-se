using InvestmentManagerApi.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EtfController : ControllerBase
    {
        private readonly IEtfService _etfService;

        public EtfController(IEtfService etfService)
        {
            this._etfService = etfService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this._etfService.GetEtfsAsync());
        }
    }
}
