using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared;
using InvestmentManagerApi.Shared.Exceptions;

namespace InvestmentManagerApi.Business
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalletService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<WalletResponseShort> CreateWalletAsync(CreateUpdateWalletRequest request)
        {
            var walletEntity = new Wallet
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CurrencyId = request.CurrencyId,
                Balance = request.Balance,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            this._unitOfWork.Wallets.Insert(walletEntity);
            await _unitOfWork.SaveChangesAsync();

            return WalletResponseShort.FromEntity(walletEntity);
        }

        public async Task DeleteWalletAsync(Guid id)
        {
            var wallet = await _unitOfWork.Wallets.GetByIdAsync(id) ?? throw new NotFoundException();
            _unitOfWork.Wallets.Delete(wallet);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<WalletResponseDetailed> GetWalletAsync(Guid id)
        {
            var wallet = await _unitOfWork.Wallets.GetByIdAsync(id) ?? throw new NotFoundException();
            return WalletResponseDetailed.FromEntity(wallet);
        }

        public async Task<BooleanResponse> HasSufficiendFunds(Guid id, decimal amount)
        {
            return new BooleanResponse
            {
                Statement = await _unitOfWork.Wallets.HasSufficientFunds(id, amount)
            };
        }


        public async Task<GetWalletsResponse> GetWalletsByUserIdAsync(Guid userId)
        {
            var response = new GetWalletsResponse() { Wallets = new() };
            var wallets = await _unitOfWork.Wallets.GetByUserIdAsync(userId);
            
            foreach (var wallet in wallets)
            {
                response.Wallets.Add(WalletResponseDetailed.FromEntity(wallet));
            }

            return response;
        }

        public async Task<GetWalletsResponse> GetWalletsAsync(int page)
        {
            var response = new GetWalletsResponse() { Wallets = new() };
            var wallets = await _unitOfWork.Wallets.GetAllAsync((page - 1) * Constants.DEFAULT_PAGE_SIZE, Constants.DEFAULT_PAGE_SIZE);

            foreach (var wallet in wallets)
            {
                response.Wallets.Add(WalletResponseDetailed.FromEntity(wallet));
            }

            return response;
        }

        public async Task<WalletResponseShort> UpdateWalletAsync(Guid id, CreateUpdateWalletRequest request)
        {
            if (!await this._unitOfWork.Wallets.ExistsAsync(id))
            {
                throw new NotFoundException();
            }
            var walletEntity = new Wallet
            {
                Id = id,
                CurrencyId = request.CurrencyId,
                UserId = request.UserId,
                Balance = request.Balance,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true,
            };

            await this._unitOfWork.Wallets.UpdateAsync(walletEntity);
            await this._unitOfWork.SaveChangesAsync();
            return WalletResponseShort.FromEntity(walletEntity);
        }
    }
}
