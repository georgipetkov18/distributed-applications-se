namespace InvestmentManagerApi.Business.Responses.Wallet
{
    public class GetWalletsResponse : PagedResponse
    {
        public List<WalletResponseDetailed> Wallets { get; set; }

    }
}
