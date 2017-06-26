using Currencies.Domain;
using Currencies.Services;
using System;
using System.Threading.Tasks;

namespace Currencies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Currencies";
            CurrenciesService currenciesService = new CurrenciesService();
            Console.WriteLine("Downloading data...");
            Task.Run(async () =>
            {
                CurrencyExchange[] data = await currenciesService.GetCurrencyData();
                while (true)
                {
                    data = await currenciesService.Update(data);
                    Console.Clear();
                    foreach (CurrencyExchange currencyExchange in data)
                    {
                        Console.ForegroundColor = currencyExchange.Change > 0 ? ConsoleColor.Green : currencyExchange.Change < 0 ? ConsoleColor.Red : ConsoleColor.Gray;
                        Console.WriteLine("{0} -> {1} {2} [{3}, change: {4}, last update: {5}]",
                            currencyExchange.Name, currencyExchange.Value, currencyExchange.ExchangeCurrencyName, currencyExchange.MarketName, currencyExchange.Change, currencyExchange.UpdatedAt);
                    }  
                }
            }).GetAwaiter().GetResult();
        }
    }
}
