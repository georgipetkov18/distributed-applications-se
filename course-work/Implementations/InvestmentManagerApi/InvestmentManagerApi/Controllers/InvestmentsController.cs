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
    public class InvestmentsController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(IInvestmentService investmentService)
        {
            this._investmentService = investmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterParams parameters)
        {
            return this.Ok(await this._investmentService.GetInvestmentsAsync(parameters));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> Get(Guid userId, [FromQuery] FilterParams parameters)
        {
            return this.Ok(await this._investmentService.GetUserInvestmentsAsync(userId, parameters));
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
