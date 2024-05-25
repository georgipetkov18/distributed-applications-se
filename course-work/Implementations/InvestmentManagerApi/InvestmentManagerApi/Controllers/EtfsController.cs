using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class EtfsController : ControllerBase
    {
        private readonly IEtfService _etfService;

        public EtfsController(IEtfService etfService)
        {
            this._etfService = etfService;
        }

        [AllowAnonymous]
        [HttpGet("page/{page?}")]
        public async Task<IActionResult> Get(int page = 1)
        {
            return this.Ok(await this._etfService.GetEtfsAsync(page));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._etfService.GetEtfAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateEtfRequest model)
        {
            return this.Ok(await this._etfService.CreateEtfAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateUpdateEtfRequest model)
        {
            var updatedEntity = await this._etfService.UpdateEtfAsync(id, model);
            return this.Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._etfService.DeleteEtfAsync(id);
            return this.Ok();
        }
    }
}
