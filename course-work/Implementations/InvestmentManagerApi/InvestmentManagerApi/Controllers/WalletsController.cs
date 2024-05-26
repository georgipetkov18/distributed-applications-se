using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WalletManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletsController(IWalletService walletService)
        {
            this._walletService = walletService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery]FilterParams parameters)
        {
            return this.Ok(await this._walletService.GetWalletsAsync(parameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._walletService.GetWalletAsync(id));
        }

        [HttpGet("~/[controller]/Get/User/{id}")]
        public async Task<IActionResult> GetByUser(Guid id)
        {
            return this.Ok(await this._walletService.GetWalletsByUserIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateWalletRequest model)
        {
            return this.Ok(await this._walletService.CreateWalletAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateUpdateWalletRequest model)
        {
            var updatedEntity = await this._walletService.UpdateWalletAsync(id, model);
            return this.Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._walletService.DeleteWalletAsync(id);
            return this.Ok();
        }
    }
}
