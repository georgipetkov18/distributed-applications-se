using InvestmentManagerApi.Shared.Enums;

namespace InvestmentManagerApi.Business.Models
{
    public class EtfViewModel
    {
        required public string Name { get; set; }
        required public decimal SingleValue { get; set; }
        required public EtfType Type { get; set; }
        required public string TypeName { get; set; }
    }
}
