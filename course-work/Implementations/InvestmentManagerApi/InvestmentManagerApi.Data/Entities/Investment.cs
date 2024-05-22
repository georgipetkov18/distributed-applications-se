namespace InvestmentManagerApi.Data.Entities
{
    public class Investment : BaseEntity
    {
        required public Guid WalletId { get; set; }
        required public Wallet Wallet { get; set; }
        required public Guid EtfId { get; set; }
        required public Etf Etf { get; set; }
        required public decimal Quantity { get; set; }
    }
}
