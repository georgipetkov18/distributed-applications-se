using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Wallet;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IWalletService
    {
        Task<GetWalletsResponse> GetWalletsAsync();
        Task<WalletResponseDetailed> GetWalletAsync(Guid id);
        Task<WalletResponseShort> CreateWalletAsync(CreateUpdateWalletRequest request);
        Task<WalletResponseShort> UpdateWalletAsync(Guid id, CreateUpdateWalletRequest request);
        Task DeleteWalletAsync(Guid id);
    }
}
