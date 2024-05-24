namespace InvestmentManagerApi.Business.Responses.Wallet
{
    public class WalletResponse
    {
        required public Guid Id { get; set; }
        required public Guid UserId { get; set; }
        required public Guid CurrencyId { get; set; }

        public static WalletResponse FromEntity(Data.Entities.Wallet wallet)
        {
            return new WalletResponse
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                CurrencyId = wallet.CurrencyId,
            };
        }

    }
}
