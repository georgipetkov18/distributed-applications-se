using InvestmentManagerApi.Business.Interfaces;
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
        [HttpGet("page/{page?}")]
        public async Task<IActionResult> Get(int page = 1)
        {
            return this.Ok(await this._currencyService.GetCurrenciesAsync(page));
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
