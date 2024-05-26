using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.Investment;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IInvestmentService
    {
        Task<GetInvestmentsResponse> GetInvestmentsAsync(FilterParams parameters);
        Task<GetInvestmentsResponse> GetUserInvestmentsAsync(Guid userId, FilterParams parameters);
        Task<InvestmentResponseDetailed> GetInvestmentAsync(Guid id);
        Task<InvestmentResponseShort> CreateInvestmentAsync(CreateUpdateInvestmentRequest request);
        Task<InvestmentResponseShort> UpdateInvestmentAsync(Guid id, CreateUpdateInvestmentRequest request);
        Task DeleteInvestmentAsync(Guid id);
    }
}
