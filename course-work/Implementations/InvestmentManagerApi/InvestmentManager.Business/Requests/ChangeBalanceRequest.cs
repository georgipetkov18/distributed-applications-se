namespace InvestmentManagerApi.Business.Requests
{
    public class ChangeBalanceRequest
    {
        public Guid WalletId { get; set; }
        required public decimal Amount { get; set; }
    }
}
