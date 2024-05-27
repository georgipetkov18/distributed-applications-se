using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Business.Responses.Etf.Type;
using InvestmentManagerApi.Shared;
using InvestmentManagerApi.Shared.Attributes;
using InvestmentManagerApi.Shared.Utils;
using InvestmentManagerClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var url = $"{_baseUri}/get?page={page}";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                url += $"&filter={filter}";
            }
            GetEtfsResponse responseData = await RequestManager.GetAsync<GetEtfsResponse>(url);
            responseData.CurrentPage = page;
            return View(responseData);
        }

        [HttpPost]
        public IActionResult Filter(FilterModel model)
        {
            filter = model.Filter ?? string.Empty;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AppAuthorize]
        public async Task<IActionResult> Delete(Guid etfId)
        {
            await RequestManager.DeleteAsync($"{_baseUri}/delete/{etfId}", true);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var responseData = await RequestManager.GetAsync<GetTypesResponse>($"{_baseUri}/types");
            return View(responseData);
        }

        [HttpPost]
        [AppAuthorize]
        public async Task<IActionResult> New(CreateUpdateEtfRequest request)
        {
            await RequestManager.PostAsync<CreateUpdateEtfRequest, EtfResponse>($"{_baseUri}/add/", request, true);
            return RedirectToAction("Index");
        }
    }
}
