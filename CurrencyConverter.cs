using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class CurrencyConverter
    {
        public List<ExchangeRate> ExchangeRates;

        public CurrencyConverter()
        {
            ExchangeRates = new List<ExchangeRate>(); 
        }
        public void AddExchangeRate(ExchangeRate exchangeRate)
        {
            ExchangeRates.Add(exchangeRate);
        }
        public void AddExchangeRates(ExchangeRate[] exchangeRates)
        {
            ExchangeRates.AddRange(exchangeRates);
        }

        public void TryDeleteExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            ExchangeRates.RemoveAll(r => r.FirstCurrency == firstCurrency && r.SecondCurrency == secondCurrency);
        }
        public ExchangeRate? FindExchangeRate (Currencies firstCurrency, Currencies secondCurrency)
        {
           return ExchangeRates.Find(r => r.FirstCurrency == firstCurrency && r.SecondCurrency == secondCurrency);
        }
        public override string ToString()
        {
           StringBuilder stringBuilder = new StringBuilder();
            foreach (ExchangeRate exchangeRate in ExchangeRates)
            {
                stringBuilder.Append(exchangeRate.ToString()+"\n");

            }
            return stringBuilder.ToString();

        }
        public ExchangeRate? Convert (Currencies CurrcencyFirst, Currencies CurrencySecond, int count)
        {
            ExchangeRate? rate = FindExchangeRate(CurrcencyFirst, CurrencySecond);
                Console.WriteLine(rate);

            if (rate != null)
            {
                var result = (count * rate.Value) / rate.CurrencyCount;
                rate.SetCurrencyCount(count);
                rate.SetValue(result);
            }
            return rate;

        }
    }
}
