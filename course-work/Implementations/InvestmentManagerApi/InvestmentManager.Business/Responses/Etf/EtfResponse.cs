using InvestmentManagerApi.Shared.Enums;

namespace InvestmentManagerApi.Business.Responses.Etf
{
    public class EtfResponse
    {
        public required Guid Id { get; set; }
        required public string Name { get; set; }
        required public decimal SingleValue { get; set; }
        required public EtfType Type { get; set; }
        required public string TypeName { get; set; }

        public static EtfResponse FromEntity(Data.Entities.Etf etf)
        {
            return new EtfResponse
            {
                Id = etf.Id,
                Name = etf.Name,
                SingleValue = etf.SingleValue,
                Type = etf.Type,
                TypeName = etf.Type.ToString(),
            };
        }
    }
}
