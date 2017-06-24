using System;

namespace Currencies.Domain
{
    public class CurrencyExchange
    {
        public string Name { get; protected set; }
        public string ExchangeCurrencyName { get; protected set; }
        public decimal Value { get; protected set; }
        public string MarketUrl { get; protected set; }
        public string MarketName { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public decimal Change { get; protected set; }

        CurrencyExchange(string name, string exchangeCurrencyName, decimal value, string marketUrl, string marketName)
        {
            Name = name;
            ExchangeCurrencyName = exchangeCurrencyName;
            Value = value;
            MarketUrl = marketUrl;
            MarketName = marketName;
            Change = 0;
            UpdatedAt = DateTime.Now;
        }

        public static CurrencyExchange Instance(string name, string exchangeCurrencyName, decimal value, string marketUrl, string marketName)
            => new CurrencyExchange(name, exchangeCurrencyName, value, marketUrl, marketName);

        public void Update(decimal value)
        {
            if (value - Value != 0)
            {
                Change = value - Value;       
                UpdatedAt = DateTime.Now;
            }
            Value = value;
        }
    }
}
