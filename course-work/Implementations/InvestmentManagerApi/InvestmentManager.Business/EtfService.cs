﻿using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Data.Repositories.Interfaces;
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

        public async Task<GetEtfsResponse> GetEtfsAsync()
        {
            var response = new GetEtfsResponse() { Etfs = new() };
            var etfs = await _unitOfWork.Etfs.GetAllAsync();

            foreach (var etf in etfs)
            {
                response.Etfs.Add(new()
                {
                    Id = etf.Id,
                    Name = etf.Name,
                    SingleValue = etf.SingleValue,
                    Type = etf.Type,
                    TypeName = etf.Type.ToString(),
                });
            }

            return response;
        }

        public async Task<EtfResponse> GetEtfAsync(Guid id)
        {
            var etf = await _unitOfWork.Etfs.GetByIdAsync(id) ?? throw new NotFoundException("Etf does not exist");
            return new EtfResponse
            {
                Id = etf.Id,
                Name = etf.Name,
                SingleValue = etf.SingleValue,
                Type = etf.Type,
                TypeName = etf.Type.ToString(),
            };
        }

        public async Task CreateEtfAsync(CreateUpdateEtfRequest request)
        {
            this._unitOfWork.Etfs.Insert(new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SingleValue= request.SingleValue,
                Type = request.Type,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            });
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<EtfResponse> UpdateEtfAsync(Guid id, CreateUpdateEtfRequest request)
        {
            if (!await this._unitOfWork.Etfs.ExistsAsync(id))
            {
                throw new NotFoundException("Etf does not exist");
            }

            this._unitOfWork.Etfs.Update(new()
            {
                Id = id,
                Name = request.Name,
                SingleValue = request.SingleValue,
                Type = request.Type,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsActivated = true
            });

            await this._unitOfWork.SaveChangesAsync();

            return new EtfResponse
            {
                Id = id,
                Name = request.Name,
                SingleValue = request.SingleValue,
                Type = request.Type,
                TypeName = request.Type.ToString(),
            };
        }

        public async Task DeleteEtfAsync(Guid id)
        {
            var etf = await _unitOfWork.Etfs.GetByIdAsync(id) ?? throw new NotFoundException("Etf does not exist");
            _unitOfWork.Etfs.Delete(etf);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
