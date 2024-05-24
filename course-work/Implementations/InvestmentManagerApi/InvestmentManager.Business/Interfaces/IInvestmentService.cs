using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Investment;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IInvestmentService
    {
        Task<GetInvestmentsResponse> GetInvestmentsAsync();
        Task<InvestmentResponseDetailed> GetInvestmentAsync(Guid id);
        Task<InvestmentResponseShort> CreateInvestmentAsync(CreateUpdateInvestmentRequest request);
        Task<InvestmentResponseShort> UpdateInvestmentAsync(Guid id, CreateUpdateInvestmentRequest request);
        Task DeleteInvestmentAsync(Guid id);
    }
}
