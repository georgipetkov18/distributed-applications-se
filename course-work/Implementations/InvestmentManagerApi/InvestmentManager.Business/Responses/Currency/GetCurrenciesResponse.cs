
namespace InvestmentManagerApi.Business.Responses.Currency
{
    public class GetCurrenciesResponse : PagedResponse
    {
        public List<CurrencyResponse> Currencies { get; set; }

    }
}
