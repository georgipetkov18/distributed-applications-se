namespace InvestmentManagerApi.Business.Responses.Currency
{
    public class CurrencyResponse
    {
        required public Guid Id { get; set; }
        required public string Code { get; set; }
        required public string Name { get; set; }
        required public decimal ToEuroRate { get; set; }

        public static CurrencyResponse FromEntity(Data.Entities.Currency currency)
        {
            return new CurrencyResponse
            {
                Id = currency.Id,
                Code = currency.Code,
                Name = currency.Name,
                ToEuroRate = currency.ToEuroRate,
            };
        }
    }
}
