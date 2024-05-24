using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            this._investmentService = investmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this._investmentService.GetInvestmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._investmentService.GetInvestmentAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateInvestmentRequest model)
        {
            return this.Ok(await this._investmentService.CreateInvestmentAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateUpdateInvestmentRequest model)
        {
            var updatedEntity = await this._investmentService.UpdateInvestmentAsync(id, model);
            return this.Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._investmentService.DeleteInvestmentAsync(id);
            return this.Ok();
        }
    }
}
