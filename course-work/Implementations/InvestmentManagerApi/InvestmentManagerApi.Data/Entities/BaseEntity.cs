using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        required public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        required public bool IsActivated { get; set; }
    }
}
