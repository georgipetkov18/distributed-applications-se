﻿using InvestmentManagerApi.Shared.Enums;

namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateEtfRequest
    {
        required public string Name { get; set; }
        required public decimal SingleValue { get; set; }
        required public EtfType Type { get; set; }
    }
}