using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Auth;
using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Shared.Utils;
using InvestmentManagerClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    [Route("[action]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160";
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var currencies = await RequestManager.GetAsync<GetCurrenciesResponse>($"{_baseUri}/currencies/get?skipPaging=true");
            return View(currencies);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new CreateUpdateUserRequest
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Age = model.Age,
            };

            await RequestManager.PostAsync<CreateUpdateUserRequest, AuthResponse>($"{_baseUri}/users/add", user, true);
            await this.ExectureLogin(new AuthRequest
            {
                Email = user.Email,
                Password = user.Password
            });

            var investmentRequest = new CreateUpdateWalletRequest
            {
                UserId = SessionManager.User.Id,
                CurrencyId = model.CurrencyId,
                Balance = model.Balance,
            };

            await RequestManager.PostAsync<CreateUpdateWalletRequest, WalletResponseShort>($"{_baseUri}/wallets/add", investmentRequest, true);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            await this.ExectureLogin(request);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            SessionManager.ResetSession();
            return Redirect("/");
        }

        private async Task ExectureLogin(AuthRequest request)
        {
            var responseData = await RequestManager.PostAsync<AuthRequest, AuthResponse>($"{_baseUri}/auth", request, false, "/register");
            SessionManager.SaveToken(responseData.Token, responseData.ExpiresOn);
        }

    }
}
