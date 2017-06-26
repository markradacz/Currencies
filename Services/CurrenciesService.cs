using Currencies.Domain;
using Currencies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Currencies.Services
{
    public class CurrenciesService : ICurrencies
    {
        ISet<Currency> _currencies;
        MarketService _marketService;

        public CurrenciesService()
        {
            _currencies = Json.Deserialize<HashSet<Currency>>("settings.json");
            _marketService = new MarketService();
        }

        public async Task<CurrencyExchange[]> GetCurrencyData()
        {
            ISet<CurrencyExchange> data = new HashSet<CurrencyExchange>();
            
            foreach (Currency currency in _currencies)
            {
                var result = GetCurrencyValues(currency);
                foreach (CurrencyExchange exchange in await result)
                    data.Add(exchange);
            }
            return data.ToArray();
        }

        public async Task<CurrencyExchange[]> Update(CurrencyExchange[] data)
        {
            for (int i = 0; i< data.Length; i++)
            {
                data[i].Update(
                    await GetCurrencyExchangeValue(data[i].MarketName, data[i].MarketUrl)
                    );
            }
            return data;
        }

        public async Task<CurrencyExchange[]> GetCurrencyValues(Currency currency)
        {
            ISet<CurrencyExchange> data = new HashSet<CurrencyExchange>();

            foreach (string exchangeCurrency in currency.ExchangeCurrencies)
            {
                Market market = _marketService.GetMarketByName(currency.MarketName);
                string url = String.Format(market.Url, currency.Name, exchangeCurrency);
                decimal value = await GetCurrencyExchangeValue(market.Name, url);
                if (value == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\tError: Invalid address: {0}", url);
                    continue;
                }
                CurrencyExchange currencyExchange = CurrencyExchange.Instance(currency.Name, exchangeCurrency, value, url, market.Name);
                currencyExchange.Update(value);
                data.Add(currencyExchange);
            }
            return data.ToArray();
        }

        public async Task<decimal> GetCurrencyExchangeValue(string marketName, string url)
        {
            WebClient webClient = new WebClient();
            string source = await Task.Run(() =>
                webClient.DownloadString(url));
            dynamic json = Json.Deserialize(source);
            return _marketService.GetMarketValue(marketName, json);
        }


    }
}
