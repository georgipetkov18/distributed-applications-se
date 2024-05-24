using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Business.Responses.Wallet;

namespace InvestmentManagerApi.Business.Responses.Investment
{
    public class InvestmentResponseDetailed
    {
        required public Guid Id { get; set; }
        required public WalletResponseShort Wallet { get; set; }
        required public EtfResponse Etf { get; set; }
        required public decimal Quantity { get; set; }

        public static InvestmentResponseDetailed FromEntity(Data.Entities.Investment investment)
        {
            return new InvestmentResponseDetailed
            {
                Id = investment.Id,
                Wallet = WalletResponseShort.FromEntity(investment.Wallet),
                Etf = EtfResponse.FromEntity(investment.Etf),
                Quantity = investment.Quantity,
            };
        }
    }
}
