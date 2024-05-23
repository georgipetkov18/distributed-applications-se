using InvestmentManagerApi.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this._currencyService.GetCurrenciesAsync());
        }
    }
}
