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
        private static string filter = string.Empty;
        private readonly ILogger<InvestmentsController> _logger;

        public InvestmentsController(ILogger<InvestmentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Make()
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
            return RedirectToAction("Mine");
        }

        [HttpGet]
        public async Task<IActionResult> Mine(int page = 1)
        {
            var url = $"{_baseUri}/get/user/{SessionManager.User.Id}?page={page}";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                url += $"&filter={filter}";
            }
            var myInvestments = await RequestManager.GetAsync<GetInvestmentsResponse>(url, true);
            myInvestments.CurrentPage = page;
            return View(myInvestments);
        }

        [HttpPost]
        public IActionResult Filter(FilterModel model)
        {
            filter = model.Filter ?? string.Empty;
            return RedirectToAction("Mine");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await RequestManager.DeleteAsync($"{_baseUri}/delete/{id}", true);
            return RedirectToAction("Mine");
        }
    }
}
