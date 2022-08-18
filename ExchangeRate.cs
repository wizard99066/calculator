using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class ExchangeRate1
    {
        Currencies _firstCurrency;
        Currencies _secondCurrency;
        float _value;
        int CurrencyCount = 1;

        public ExchangeRate1 (Currencies firstCurrency, Currencies secondCurrency)
        {
            _firstCurrency=firstCurrency;
            _secondCurrency=secondCurrency;
        }
        public ExchangeRate1(Currencies firstCurrency, Currencies secondCurrency, float value) :this (firstCurrency,secondCurrency)
        {
          _value=value;
        }
        public override string ToString()
        {
            string newCurrency = string.Format("{0:f2}", CurrencyCount);
            string newValue = string.Format("{0:f2}", _value);
            string result = $"{newCurrency} {_firstCurrency}={newValue} {_secondCurrency}";
            return result;
        }
        public float Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public int _CurrencyCount
        {
            set { CurrencyCount = value; }
        }
        public Currencies FirstCurrency => _firstCurrency;
        public Currencies SecondCurrency => _secondCurrency;
    }
}
