using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf.Type;
using InvestmentManagerApi.Shared.Enums;
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
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterParams parameters)
        {
            return this.Ok(await this._etfService.GetEtfsAsync(parameters));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._etfService.GetEtfAsync(id));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Types()
        {
            var response = new GetTypesResponse();

            foreach (var value in Enum.GetNames(typeof(EtfType)))
            {
                if (Enum.TryParse(value, out EtfType parsed))
                {
                    response.Types.Add((int)parsed, value);
                }
            }

            return Ok(response);
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
