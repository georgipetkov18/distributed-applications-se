using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Shared.Attributes;
using InvestmentManagerApi.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    [AppAuthorize]
    public class WalletsController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160/wallets";
        private readonly ILogger<UsersController> _logger;

        public WalletsController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var currencies = await RequestManager.GetAsync<GetCurrenciesResponse>($"https://localhost:7160/currencies/get", true);
            return View(currencies);
        }

        [HttpPost]
        public async Task<IActionResult> New(CreateUpdateWalletRequest request) 
        {
            request.UserId = SessionManager.User.Id;
            var wallets = await RequestManager.PostAsync<CreateUpdateWalletRequest, WalletResponseShort>($"{_baseUri}/add", request, true);
            return RedirectToAction("Mine");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var wallets = await RequestManager.GetAsync<GetWalletsResponse>($"{_baseUri}/get/user/{SessionManager.User.Id}", true);
            return View(wallets);
        }
    }
}
