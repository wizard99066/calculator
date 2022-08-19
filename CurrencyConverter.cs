using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class CurrencyConverter
    {
        List<ExchangeRate> ExchangeRates;

        public CurrencyConverter(List<ExchangeRate> exchangeRates)
        {
            ExchangeRates = exchangeRates;
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
