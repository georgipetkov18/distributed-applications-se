﻿namespace InvestmentManagerApi.Data.Entities
{
    public class Investment : BaseEntity
    {
        required public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; }
        required public Guid EtfId { get; set; }
        public Etf Etf { get; set; }
        required public decimal Quantity { get; set; }
    }
}
