namespace InvestmentManagerApi.Business.Responses.Etf.Type
{
    public class GetTypesResponse
    {
        public Dictionary<int, string> Types { get; set; }
        public GetTypesResponse()
        {
            this.Types = new Dictionary<int, string>();
        }
    }
}
