using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Data.Repositories;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IWalletService
    {
        Task<GetWalletsResponse> GetWalletsAsync(FilterParams parameters);
        Task<WalletResponseDetailed> GetWalletAsync(Guid id);
        Task<BooleanResponse> HasSufficiendFunds(Guid id, decimal amount);
        Task<GetWalletsResponse> GetWalletsByUserIdAsync(Guid userId);
        Task<WalletResponseShort> CreateWalletAsync(CreateUpdateWalletRequest request);
        Task<WalletResponseShort> UpdateWalletAsync(Guid id, CreateUpdateWalletRequest request);
        Task DeleteWalletAsync(Guid id);
    }
}
