using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IEtfService
    {
        Task<GetEtfsResponse> GetEtfsAsync();
        Task CreateEtfAsync(AddEtfRequest request);
    }
}
