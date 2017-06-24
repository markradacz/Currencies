using Currencies.Domain;
using System.Threading.Tasks;

namespace Currencies.Interfaces
{
    public interface ICurrencies
    {
        Task<CurrencyExchange[]> GetCurrencyValues(Currency currency);
        Task<CurrencyExchange[]> Update(CurrencyExchange[] currencyExhange);
        Task<CurrencyExchange[]> GetCurrencyData();
        Task<decimal> GetCurrencyExchangeValue(string name, string url);
    }
}
