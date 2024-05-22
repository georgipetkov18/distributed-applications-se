﻿namespace InvestmentManagerApi.Data.Entities
{
    public class Wallet : BaseEntity
    {
        required public Guid UserId { get; set; }
        required public User User { get; set; }

        required public Guid CurrencyId { get; set; }
        required public Currency Currency { get; set; }

        required public IEnumerable<Investment> Investments { get; set; }

        public Wallet()
        {
            this.Investments = new List<Investment>();
        }
    }
}
