using InvestmentManagerApi.Business.Responses.Etf;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IEtfService
    {
        Task<GetEtfsResponse> GetEtfsAsync();
    }
}
