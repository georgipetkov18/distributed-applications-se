using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._currencyService.GetCurrencyAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateCurrencyRequest model)
        {
            return this.Ok(await this._currencyService.CreateCurrencyAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateUpdateCurrencyRequest model)
        {
            var updatedEntity = await this._currencyService.UpdateCurrencyAsync(id, model);
            return this.Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._currencyService.DeleteCurrencyAsync(id);
            return this.Ok();
        }
    }
}
