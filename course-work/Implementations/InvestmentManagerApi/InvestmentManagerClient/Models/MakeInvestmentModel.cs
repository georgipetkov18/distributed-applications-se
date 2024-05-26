namespace InvestmentManagerClient.Models
{
    public class MakeInvestmentModel
    {
        public Guid EtfId { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
    }
}
