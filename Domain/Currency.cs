using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currencies.Domain
{
    public class Currency
    {
        public string Name { get; set; }
        public string MarketName { get; set; }
        public string[] ExchangeCurrencies { get; set; }

        Currency()
        { }

        Currency(string name, string marketName, string exchangeCurrenciesString)
        {
            Name = name;
            MarketName = marketName;
            ExchangeCurrencies = exchangeCurrenciesString.Replace(" ", "")
                .Split(',');
        }

        public static Currency Instance(string name, string marketName, string exchangeCurrenciesString)
            => new Currency(name, marketName, exchangeCurrenciesString);
    }
}
