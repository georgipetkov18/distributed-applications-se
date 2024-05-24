using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Etf;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IEtfService
    {
        Task<GetEtfsResponse> GetEtfsAsync();
        Task<EtfResponse> GetEtfAsync(Guid id);
        Task<EtfResponse> CreateEtfAsync(CreateUpdateEtfRequest request);
        Task<EtfResponse> UpdateEtfAsync(Guid id, CreateUpdateEtfRequest request);
        Task DeleteEtfAsync(Guid id);
    }
}
