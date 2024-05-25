using Azure;
using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using InvestmentManagerApi.Shared;
using InvestmentManagerApi.Shared.Exceptions;

namespace InvestmentManagerApi.Business
{
    public class EtfService : IEtfService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EtfService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<GetEtfsResponse> GetEtfsAsync(FilterParams parameters)
        {
            var response = new GetEtfsResponse() { Etfs = new() };
            var etfs = await _unitOfWork.Etfs
                .GetAllAsync(
                    skipCount: (parameters.Page - 1) * Constants.DEFAULT_PAGE_SIZE,
                    takeCount: Constants.DEFAULT_PAGE_SIZE,
                    filter: parameters.Filter
                );

            foreach (var etf in etfs)
            {
                response.Etfs.Add(EtfResponse.FromEntity(etf));
            }

            return response;
        }

        public async Task<EtfResponse> GetEtfAsync(Guid id)
        {
            var etf = await _unitOfWork.Etfs.GetByIdAsync(id) ?? throw new NotFoundException();
            return EtfResponse.FromEntity(etf);
        }

        public async Task<EtfResponse> CreateEtfAsync(CreateUpdateEtfRequest request)
        {
            var etfEntity = new Etf
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SingleValue = request.SingleValue,
                Type = request.Type,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            this._unitOfWork.Etfs.Insert(etfEntity);
            await _unitOfWork.SaveChangesAsync();

            return EtfResponse.FromEntity(etfEntity);
        }

        public async Task<EtfResponse> UpdateEtfAsync(Guid id, CreateUpdateEtfRequest request)
        {
            if (!await this._unitOfWork.Etfs.ExistsAsync(id))
            {
                throw new NotFoundException();
            }
            var etfEntity = new Etf
            {
                Id = id,
                Name = request.Name,
                SingleValue = request.SingleValue,
                Type = request.Type,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            };

            await this._unitOfWork.Etfs.UpdateAsync(etfEntity);
            await this._unitOfWork.SaveChangesAsync();

            return EtfResponse.FromEntity(etfEntity);
        }

        public async Task DeleteEtfAsync(Guid id)
        {
            var etf = await _unitOfWork.Etfs.GetByIdAsync(id) ?? throw new NotFoundException();
            _unitOfWork.Etfs.Delete(etf);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
