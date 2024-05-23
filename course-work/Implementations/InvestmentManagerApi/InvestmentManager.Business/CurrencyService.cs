using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Data.Repositories.Interfaces;

namespace InvestmentManagerApi.Business
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<GetCurrenciesResponse> GetCurrenciesAsync()
        {
            var response = new GetCurrenciesResponse() { Currencies = new() };
            var currencies = await _unitOfWork.Currencies.GetAllAsync();

            foreach (var currency in currencies)
            {
                response.Currencies.Add(new()
                {
                    Code = currency.Code,
                    Name = currency.Name,
                    ToEuroRate = currency.ToEuroRate,
                });
            }

            return response;
        }
    }
}
