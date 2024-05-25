using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateCurrencyRequest
    {
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        required public string Code { get; set; }

        [MaxLength(50)]
        required public string Name { get; set; }
        required public decimal ToEuroRate { get; set; }
    }
}
