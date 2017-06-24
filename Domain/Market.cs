namespace Currencies.Domain
{
    public class Market
    {
        public string Name { get; protected set; }
        public string Url { get; protected set; }

        Market(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public static Market Instance(string name, string url)
            => new Market(name, url);
    }
}
