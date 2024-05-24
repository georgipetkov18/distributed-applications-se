using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared.Exceptions;

namespace InvestmentManagerApi.Business
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<CurrencyResponse> CreateCurrencyAsync(CreateUpdateCurrencyRequest request)
        {
            var currencyEntity = new Currency
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                ToEuroRate = request.ToEuroRate,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            this._unitOfWork.Currencies.Insert(currencyEntity);
            await _unitOfWork.SaveChangesAsync();

            return CurrencyResponse.FromEntity(currencyEntity);
        }

        public async Task DeleteCurrencyAsync(Guid id)
        {
            var currency = await _unitOfWork.Currencies.GetByIdAsync(id) ?? throw new NotFoundException();
            _unitOfWork.Currencies.Delete(currency);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetCurrenciesResponse> GetCurrenciesAsync()
        {
            var response = new GetCurrenciesResponse() { Currencies = new() };
            var currencies = await _unitOfWork.Currencies.GetAllAsync();

            foreach (var currency in currencies)
            {
                response.Currencies.Add(new()
                {
                    Id = currency.Id,
                    Code = currency.Code,
                    Name = currency.Name,
                    ToEuroRate = currency.ToEuroRate,
                });
            }

            return response;
        }

        public async Task<CurrencyResponse> GetCurrencyAsync(Guid id)
        {
            var currency = await _unitOfWork.Currencies.GetByIdAsync(id) ?? throw new NotFoundException();
            return new CurrencyResponse
            {
                Id = currency.Id,
                Code = currency.Code,
                Name = currency.Name,
                ToEuroRate = currency.ToEuroRate,
            };
        }

        public async Task<CurrencyResponse> UpdateCurrencyAsync(Guid id, CreateUpdateCurrencyRequest request)
        {
            if (!await this._unitOfWork.Currencies.ExistsAsync(id))
            {
                throw new NotFoundException();
            }
            var currencyEntity = new Currency
            {
                Id = id,
                Code = request.Code,
                Name = request.Name,
                ToEuroRate = request.ToEuroRate,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true,
            };

            await this._unitOfWork.Currencies.UpdateAsync(currencyEntity);
            await this._unitOfWork.SaveChangesAsync();
            return CurrencyResponse.FromEntity(currencyEntity);
        }
    }
}
