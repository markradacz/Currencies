using Currencies.Domain;
using Currencies.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Currencies.Services
{
    class MarketService : IMarkets
    {
        ISet<Market> _markets;

        public MarketService()
        {
            _markets = new HashSet<Market>
            {
                Market.Instance("BitBay", "https://bitbay.net/API/Public/{0}{1}/ticker.json"),
                Market.Instance("BitTrex", "https://bittrex.com/api/v1.1/public/getmarketsummary?market={0}-{1}"),
                Market.Instance("CryptoCompare", "https://cryptocompare.com/api/data/coinsnapshot/?fsym={0}&tsym={1}")
            };
            
        }

        public Market GetMarketByName(string name)
            => _markets.Where(m => m.Name.ToLower() == name.ToLower()).FirstOrDefault();

        public decimal GetMarketValue(string name, dynamic json)
        {
            decimal value = 0;
            switch(name.ToLower())
            {
                case "bittrex":
                    value = (decimal)json.result[0].High;
                    break;
                case "bitbay":
                    value = (decimal)json.average;
                    break;
                case "cryptocompare":
                    value = (decimal)json.Data.AggregatedData.PRICE;
                    break;
                default:
                    break;
            }
            return value;
        }
    }
}
