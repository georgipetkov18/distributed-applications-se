using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Currency;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface ICurrencyService
    {
        Task<GetCurrenciesResponse> GetCurrenciesAsync(FilterParams parameters);
        Task<CurrencyResponse> GetCurrencyAsync(Guid id);
        Task<CurrencyResponse> CreateCurrencyAsync(CreateUpdateCurrencyRequest request);
        Task<CurrencyResponse> UpdateCurrencyAsync(Guid id, CreateUpdateCurrencyRequest request);
        Task DeleteCurrencyAsync(Guid id);
    }
}
