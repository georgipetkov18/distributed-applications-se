using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Shared.Utils;
using InvestmentManagerClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    public class EtfsController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160/etfs";
        private readonly ILogger<EtfsController> _logger;
        private static string filter = string.Empty;

        public EtfsController(ILogger<EtfsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            GetEtfsResponse responseData = await RequestManager.GetAsync<GetEtfsResponse>($"{_baseUri}/get?page={page}&filter={filter}");
            responseData.CurrentPage = page;
            return View(responseData);
        }

        [HttpPost]
        public IActionResult Filter(FilterModel model)
        {
            filter = model.Filter ?? string.Empty;
            return RedirectToAction("Index");
        }
    }
}
