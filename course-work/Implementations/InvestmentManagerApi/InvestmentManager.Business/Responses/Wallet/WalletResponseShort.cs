namespace InvestmentManagerApi.Business.Responses.Wallet
{
    public class WalletResponseShort
    {
        required public Guid Id { get; set; }
        required public Guid UserId { get; set; }
        required public Guid CurrencyId { get; set; }
        public string CurrencyCode { get; set; }

        public static WalletResponseShort FromEntity(Data.Entities.Wallet wallet, bool detailed = true)
        {
            return new WalletResponseShort
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                CurrencyId = wallet.CurrencyId,
                CurrencyCode = wallet.Currency.Code
            };
        }
    }
}
