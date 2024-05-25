using InvestmentManagerApi.Business.Interfaces;
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

        [HttpGet("page/{page?}")]
        public async Task<IActionResult> Get(int page = 1)
        {
            return this.Ok(await this._walletService.GetWalletsAsync(page));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return this.Ok(await this._walletService.GetWalletAsync(id));
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
