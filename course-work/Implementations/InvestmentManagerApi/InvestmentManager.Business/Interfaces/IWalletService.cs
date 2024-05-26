using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Data.Repositories;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IWalletService
    {
        Task<GetWalletsResponse> GetWalletsAsync(int page);
        Task<WalletResponseDetailed> GetWalletAsync(Guid id);
        Task<BooleanResponse> HasSufficiendFunds(Guid id, decimal amount);
        Task<GetWalletsResponse> GetWalletsByUserIdAsync(Guid userId);
        Task<WalletResponseShort> CreateWalletAsync(CreateUpdateWalletRequest request);
        Task<WalletResponseShort> UpdateWalletAsync(Guid id, CreateUpdateWalletRequest request);
        Task DeleteWalletAsync(Guid id);
    }
}
