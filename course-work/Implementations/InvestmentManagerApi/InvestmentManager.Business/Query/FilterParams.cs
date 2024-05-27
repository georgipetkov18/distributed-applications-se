namespace InvestmentManagerApi.Business.Query
{
    public class FilterParams
    {
        public int Page { get; set; } = 1;
        public string? Filter { get; set; }
        public bool SkipPaging { get; set; } = false;
    }
}
