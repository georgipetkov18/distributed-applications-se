using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Investment;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Shared.Attributes;
using InvestmentManagerApi.Shared.Utils;
using InvestmentManagerClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    [AppAuthorize]
    public class InvestmentsController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160/investments";
        private readonly string _walletsUrl = "https://localhost:7160/wallets";
        private static GetWalletsResponse? walletsResponse;
        private static Guid etfId;
        private readonly ILogger<EtfsController> _logger;

        public InvestmentsController(ILogger<EtfsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Make()
        {
            if (walletsResponse == null || etfId == Guid.Empty)
            {
                return Redirect("/");
            }

            return View(walletsResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Make(MakeInvestmentModel model)
        {
            walletsResponse = await RequestManager.GetAsync<GetWalletsResponse>($"{_walletsUrl}/get/user/{SessionManager.User.Id}", true);
            etfId = model.EtfId;
            return RedirectToAction("Make");
        }

        [HttpPost]
        public async Task<IActionResult> Finalize(MakeInvestmentModel model)
        {
            var request = new CreateUpdateInvestmentRequest
            {
                EtfId = etfId,
                WalletId = model.WalletId,
                Quantity = model.Amount
            };
            await RequestManager.PostAsync<CreateUpdateInvestmentRequest, InvestmentResponseShort>($"{_baseUri}/add", request, true);
            walletsResponse = null;
            etfId = Guid.Empty;
            // TODO: Create my investments page and redicet to it
            return Ok();
        }
    }
}
