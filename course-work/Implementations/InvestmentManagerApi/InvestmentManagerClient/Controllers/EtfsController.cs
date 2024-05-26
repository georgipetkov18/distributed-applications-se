using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Shared.Utils;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagerClient.Controllers
{
    public class EtfsController : Controller
    {
        private readonly string _baseUri = "https://localhost:7160/etfs";
        private readonly ILogger<EtfsController> _logger;

        public EtfsController(ILogger<EtfsController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            GetEtfsResponse responseData = await RequestManager.GetAsync<GetEtfsResponse>($"{_baseUri}/get");
            return View(responseData);
        }
    }
}
