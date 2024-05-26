namespace InvestmentManagerApi.Business.Responses.Etf
{
    public class GetEtfsResponse : PagedResponse
    {
        public List<EtfResponse> Etfs { get; set; }
    }
}
