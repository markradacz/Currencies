namespace Currencies.Interfaces
{
    interface IMarkets
    {
        decimal GetMarketValue(string name, dynamic json);
    }
}
