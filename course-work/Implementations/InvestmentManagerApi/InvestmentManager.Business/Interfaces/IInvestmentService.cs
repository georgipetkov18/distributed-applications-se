using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Investment;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IInvestmentService
    {
        Task<GetInvestmentsResponse> GetInvestmentsAsync();
        Task<InvestmentResponse> GetInvestmentAsync(Guid id);
        Task<InvestmentResponse> CreateInvestmentAsync(CreateUpdateInvestmentRequest request);
        Task<InvestmentResponse> UpdateInvestmentAsync(Guid id, CreateUpdateInvestmentRequest request);
        Task DeleteInvestmentAsync(Guid id);
    }
}
