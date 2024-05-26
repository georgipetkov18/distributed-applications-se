namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateWalletRequest
    {
        required public Guid UserId { get; set; }
        required public Guid CurrencyId { get; set; }
        required public decimal Balance {  get; set; }
    }
}
