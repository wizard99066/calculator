using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class ExchangeRate
    {
        public Currencies FirstCurrency;
        public Currencies SecondCurrency;
        public float Value;
        public int CurrencyCount = 1;

        public ExchangeRate (Currencies firstCurrency, Currencies secondCurrency)
        {
            FirstCurrency=firstCurrency;
            SecondCurrency=secondCurrency;
        }
        public ExchangeRate(Currencies firstCurrency, Currencies secondCurrency, float value) :this (firstCurrency,secondCurrency)
        {
            Value=value;
        }
        public override string ToString()
        {
            return $"{string.Format("{0:f2}", CurrencyCount)} {FirstCurrency} = {string.Format("{0:f2}", Value)} {SecondCurrency}";
        }
        public void SetValue(float value)
        {
            Value = value;
        }
        public void SetCurrencyCount(int currencyCount)
        {
            CurrencyCount = currencyCount;
        }
    }
}
