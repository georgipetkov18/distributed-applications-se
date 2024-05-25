using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]FilterParams parameters)
        {
            return this.Ok(await this._currencyService.GetCurrenciesAsync(parameters));
        }


        [AllowAnonymous]
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
