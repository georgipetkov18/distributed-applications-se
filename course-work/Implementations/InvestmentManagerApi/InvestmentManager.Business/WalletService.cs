using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Wallet;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
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

        public async Task<WalletResponse> CreateWalletAsync(CreateUpdateWalletRequest request)
        {
            var walletEntity = new Wallet
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CurrencyId = request.CurrencyId,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            this._unitOfWork.Wallets.Insert(walletEntity);
            await _unitOfWork.SaveChangesAsync();

            return WalletResponse.FromEntity(walletEntity);
        }

        public async Task DeleteWalletAsync(Guid id)
        {
            var wallet = await _unitOfWork.Wallets.GetByIdAsync(id) ?? throw new NotFoundException();
            _unitOfWork.Wallets.Delete(wallet);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<WalletResponse> GetWalletAsync(Guid id)
        {
            var wallet = await _unitOfWork.Wallets.GetByIdAsync(id) ?? throw new NotFoundException();
            return new WalletResponse
            {
                Id = wallet.Id,
                CurrencyId = wallet.CurrencyId,
                UserId = wallet.UserId,
            };
        }

        public async Task<GetWalletsResponse> GetWalletsAsync()
        {
            var response = new GetWalletsResponse() { Wallets = new() };
            var wallets = await _unitOfWork.Wallets.GetAllAsync();

            foreach (var wallet in wallets)
            {
                response.Wallets.Add(new()
                {
                    Id = wallet.Id,
                    UserId = wallet.UserId,
                    CurrencyId = wallet.CurrencyId,
                });
            }

            return response;
        }

        public async Task<WalletResponse> UpdateWalletAsync(Guid id, CreateUpdateWalletRequest request)
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
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true,
            };

            await this._unitOfWork.Wallets.UpdateAsync(walletEntity);
            await this._unitOfWork.SaveChangesAsync();
            return WalletResponse.FromEntity(walletEntity);
        }
    }
}
