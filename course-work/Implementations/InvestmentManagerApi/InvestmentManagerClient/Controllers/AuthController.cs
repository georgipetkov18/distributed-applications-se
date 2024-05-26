using Azure.Core;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Auth;
using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Business.Responses.Investment;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Shared.Utils;
using InvestmentManagerClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace InvestmentManagerClient.Controllers
{
    [Route("[action]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160";
        private readonly ILogger<EtfsController> _logger;

        public AuthController(ILogger<EtfsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var currencies = await RequestManager.GetAsync<GetCurrenciesResponse>($"{_baseUri}/currencies/get");
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
        public async Task<IActionResult> Login()
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
