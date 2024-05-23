using InvestmentManagerApi.Business.Interfaces;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf;
using InvestmentManagerApi.Data.Repositories.Interfaces;

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
                    Name = etf.Name,
                    SingleValue = etf.SingleValue,
                    Type = etf.Type,
                    TypeName = etf.Type.ToString(),
                });
            }

            return response;
        }

        public async Task CreateEtfAsync(AddEtfRequest request)
        {
            _unitOfWork.Etfs.Insert(new()
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
    }
}
