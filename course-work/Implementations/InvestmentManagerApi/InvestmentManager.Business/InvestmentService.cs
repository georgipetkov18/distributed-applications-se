using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Currency;
using InvestmentManagerApi.Business.Responses.Investment;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared.Exceptions;

namespace InvestmentManagerApi.Business
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvestmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<InvestmentResponseShort> CreateInvestmentAsync(CreateUpdateInvestmentRequest request)
        {
            var investmentEntity = new Investment
            {
                Id = Guid.NewGuid(),
                EtfId = request.EtfId,
                WalletId = request.WalletId,
                Quantity = request.Quantity,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            this._unitOfWork.Investments.Insert(investmentEntity);
            await _unitOfWork.SaveChangesAsync();

            return InvestmentResponseShort.FromEntity(investmentEntity);
        }

        public async Task DeleteInvestmentAsync(Guid id)
        {
            var investment = await _unitOfWork.Investments.GetByIdAsync(id) ?? throw new NotFoundException();
            _unitOfWork.Investments.Delete(investment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<InvestmentResponseDetailed> GetInvestmentAsync(Guid id)
        {
            var investment = await _unitOfWork.Investments.GetByIdAsync(id) ?? throw new NotFoundException();
            return InvestmentResponseDetailed.FromEntity(investment);
        }

        public async Task<GetInvestmentsResponse> GetInvestmentsAsync()
        {
            var response = new GetInvestmentsResponse() { Investments = new() };
            var investments = await _unitOfWork.Investments.GetAllAsync();

            foreach (var investment in investments)
            {
                response.Investments.Add(InvestmentResponseDetailed.FromEntity(investment));
            }

            return response;
        }

        public async Task<InvestmentResponseShort> UpdateInvestmentAsync(Guid id, CreateUpdateInvestmentRequest request)
        {
            if (!await this._unitOfWork.Investments.ExistsAsync(id))
            {
                throw new NotFoundException();
            }
            var investmentEntity = new Investment
            {
                Id = id,
                WalletId = request.WalletId,
                EtfId = request.EtfId,
                Quantity = request.Quantity,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true,
            };

            await this._unitOfWork.Investments.UpdateAsync(investmentEntity);
            await this._unitOfWork.SaveChangesAsync();
            return InvestmentResponseShort.FromEntity(investmentEntity);
        }
    }
}
