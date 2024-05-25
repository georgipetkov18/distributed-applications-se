using InvestmentManagerApi.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Data.Entities
{
    public class Etf : BaseEntity
    {
        [MaxLength(127)]
        required public string Name { get; set; }
        required public decimal SingleValue { get; set; }
        required public EtfType Type { get; set; }

        public IEnumerable<Investment> Investments { get; set; }

        public Etf() 
        { 
            this.Investments = new List<Investment>();
        }
    }
}
