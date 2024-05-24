using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Wallet;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IWalletService
    {
        Task<GetWalletsResponse> GetWalletsAsync();
        Task<WalletResponse> GetWalletAsync(Guid id);
        Task<WalletResponse> CreateWalletAsync(CreateUpdateWalletRequest request);
        Task<WalletResponse> UpdateWalletAsync(Guid id, CreateUpdateWalletRequest request);
        Task DeleteWalletAsync(Guid id);
    }
}
