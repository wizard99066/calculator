namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Currencies first = Currencies.USD;
            Currencies second = Currencies.EUR;
            var exchange = new ExchangeRate(first, second, 0.9f);
            List<ExchangeRate> ExchangeRate = new List<ExchangeRate>
            {
                exchange,
            };
            var CurrencyConverter = new CurrencyConverter(ExchangeRate);
            var arr = new ExchangeRate[2] { new ExchangeRate(Currencies.NZD, Currencies.JPY, 3), new ExchangeRate(Currencies.CAD, Currencies.GBP, 3) };
            CurrencyConverter.AddExchangeRates(arr);
            var convert = CurrencyConverter.Convert(Currencies.CAD, Currencies.GBP, 4);
            Console.WriteLine(CurrencyConverter.ToString());
            Console.ReadKey();
        }
    }
}