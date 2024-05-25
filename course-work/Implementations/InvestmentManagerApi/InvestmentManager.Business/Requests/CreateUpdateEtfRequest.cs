using InvestmentManagerApi.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateEtfRequest
    {
        [MaxLength(127)]
        required public string Name { get; set; }
        required public decimal SingleValue { get; set; }
        required public EtfType Type { get; set; }
    }
}
