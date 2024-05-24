namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateCurrencyRequest
    {
        required public string Code { get; set; }
        required public string Name { get; set; }
        required public decimal ToEuroRate { get; set; }
    }
}
