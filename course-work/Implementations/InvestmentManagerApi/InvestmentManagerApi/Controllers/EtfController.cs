using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._etfService.GetEtfAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateEtfRequest model)
        {
            await this._etfService.CreateEtfAsync(model);
            return this.Ok();
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
