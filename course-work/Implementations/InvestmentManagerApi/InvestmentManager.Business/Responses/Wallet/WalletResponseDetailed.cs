using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Business.Responses.User;

namespace InvestmentManagerApi.Business.Responses.Wallet
{
    public class WalletResponseDetailed
    {
        required public Guid Id { get; set; }
        public UserResponse User { get; set; }
        public CurrencyResponse Currency { get; set; }
        required public decimal Balance { get; set; }


        public static WalletResponseDetailed FromEntity(Data.Entities.Wallet wallet)
        {
            return new WalletResponseDetailed
            {
                Id = wallet.Id,
                User = UserResponse.FromEntity(wallet.User),
                Currency = CurrencyResponse.FromEntity(wallet.Currency),
                Balance = wallet.Balance,
            };
        }

    }
}
