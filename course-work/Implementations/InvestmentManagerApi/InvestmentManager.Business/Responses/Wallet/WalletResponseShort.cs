namespace InvestmentManagerApi.Business.Responses.Wallet
{
    public class WalletResponseShort
    {
        required public Guid Id { get; set; }
        required public Guid UserId { get; set; }
        required public Guid CurrencyId { get; set; }

        required public decimal Balance { get; set; }


        public static WalletResponseShort FromEntity(Data.Entities.Wallet wallet, bool detailed = true)
        {
            return new WalletResponseShort
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                CurrencyId = wallet.CurrencyId,
                Balance = wallet.Balance,
            };
        }
    }
}
