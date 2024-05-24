namespace InvestmentManagerApi.Business.Responses.Investment
{
    public class InvestmentResponse
    {
        required public Guid Id { get; set; }
        required public Guid WalletId { get; set; }
        required public Guid EtfId { get; set; }
        required public decimal Quantity { get; set; }

        public static InvestmentResponse FromEntity(Data.Entities.Investment investment)
        {
            return new InvestmentResponse
            {
                Id = investment.Id,
                WalletId = investment.WalletId,
                EtfId = investment.EtfId,
                Quantity = investment.Quantity,
            };
        }
    }
}
