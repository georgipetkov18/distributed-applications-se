namespace InvestmentManagerApi.Business.Responses.Investment
{
    public class GetInvestmentsResponse : PagedResponse
    {
        public List<InvestmentResponseDetailed> Investments { get; set; }

    }
}
