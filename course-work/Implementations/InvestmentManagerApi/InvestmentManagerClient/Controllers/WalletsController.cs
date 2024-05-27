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
        private static Guid currentWalletId;

        public WalletsController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var currencies = await RequestManager.GetAsync<GetCurrenciesResponse>($"https://localhost:7160/currencies/get?skipPaging=true", true);
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

        [HttpGet]
        public IActionResult Funds(Guid id)
        {
            currentWalletId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(ChangeBalanceRequest request)
        {
            request.WalletId = currentWalletId;
            _ = await RequestManager.PostAsync<ChangeBalanceRequest, WalletResponseShort>($"{_baseUri}/deposit", request, true);

            return RedirectToAction("Mine");
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(ChangeBalanceRequest request)
        {
            request.WalletId = currentWalletId;
            _ = await RequestManager.PostAsync<ChangeBalanceRequest, WalletResponseShort>($"{_baseUri}/withdraw", request, true);

            return RedirectToAction("Mine");
        }
    }
}
