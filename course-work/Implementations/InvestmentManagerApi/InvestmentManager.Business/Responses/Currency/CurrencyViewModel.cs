namespace InvestmentManagerApi.Business.Responses.Currency
{
    public class CurrencyViewModel
    {
        required public string Code { get; set; }
        required public string Name { get; set; }
        required public decimal ToEuroRate { get; set; }
    }
}
