using InvestmentManagerApi.Business.Responses.Currency;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface ICurrencyService
    {
        Task<GetCurrenciesResponse> GetCurrenciesAsync();
    }
}
