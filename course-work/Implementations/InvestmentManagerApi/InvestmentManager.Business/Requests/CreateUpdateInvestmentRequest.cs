namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateInvestmentRequest
    {
        required public Guid WalletId { get; set; }
        required public Guid EtfId { get; set; }
        required public decimal Quantity { get; set; }

    }
}
