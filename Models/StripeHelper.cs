using Stripe;
using System;
using System.Configuration;

public class StripeHelper
{
    static StripeHelper()
    {
        StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["StripeApiKey"];
    }

    public static Charge CreateCharge(decimal amount, string currency, string sourceToken)
    {
        var chargeOptions = new ChargeCreateOptions
        {
            Amount = Convert.ToInt64(amount * 100),  
            Currency = currency,
            Source = sourceToken,
            Description = "Example charge"
        };

        var chargeService = new ChargeService();
        Charge charge = chargeService.Create(chargeOptions);
        return charge;
    }
}