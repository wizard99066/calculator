/*namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Currencies first = Currencies.USD;
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
}*/


namespace calculator

{
    internal class Program
    {
        static int Inlet()
        {
            string temp = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(temp, out n))
            {
                Console.Write("Неверный ввод!\nВведите число раз: ");
                temp = Console.ReadLine();
            }
            return n;
        }

        
        static void TypeOfCurrencies()
        {
            string[] typeOfCurrencies = Enum.GetNames(typeof(Currencies));
            foreach (string name in typeOfCurrencies)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }

        static Currencies GetTypeOfCurrencies()
        {
            Console.Write("Введите наименование валюты: ");
            string? temp = Console.ReadLine();
            object findCurr;
            while (!Enum.TryParse(typeof(Currencies), temp.ToUpper(), out findCurr))
            {
                Console.Write("Такой валюты нет в данный момент\nВведите еще раз: ");
                temp = Console.ReadLine();
            }

            return (Currencies)findCurr;
        }

        static ExchangeRate[] CreateExchangeRateArray(Currencies userCurrencies)
        {
            ExchangeRate[] exchangeRateArray = new ExchangeRate[8];

            Currencies currencies = new Currencies();

            Random rand = new Random();

            for (int i = 0; i < exchangeRateArray.Length; i++)
            {
                currencies = (Currencies)i;
                double randomCourse = rand.NextDouble() * 5;
                if (currencies == userCurrencies) { randomCourse = 1; }
                float randomCOurse=(float)randomCourse;
                ExchangeRate exchangeRate = new(userCurrencies, currencies, randomCOurse);
                exchangeRateArray[i] = exchangeRate;
            }

            return exchangeRateArray;
        }

        static ExchangeRate CreateExchangeRate()
        {
            Random rand = new Random();
            double randomCourse = rand.NextDouble() * 5;

            Currencies currencies1 = (Currencies)rand.Next(10);
            Currencies currencies2 = (Currencies)rand.Next(10);
            float randomCOurse = (float)randomCourse;

            if (currencies1 == currencies2) randomCOurse = 1;

            ExchangeRate exchangeRate = new ExchangeRate(currencies1, currencies2, randomCOurse);

            return exchangeRate;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Валютный калькулятор");
            CurrencyConverter currencyConverter = new();
            Console.WriteLine("Введите валюту, которую необходимо обменять :");            
            TypeOfCurrencies();
            Currencies curForExchange = GetTypeOfCurrencies();            
            currencyConverter.AddExchangeRates(CreateExchangeRateArray(curForExchange));
            Console.WriteLine("Курс на данный момент: ");
            Console.Write(currencyConverter);
            Console.WriteLine($"Выберите валюту, на которую будем менять  {curForExchange}");
            Currencies curToExchange = GetTypeOfCurrencies();
            ExchangeRate findExchangeRate = currencyConverter.FindExchangeRate(curForExchange, curToExchange);
            Console.WriteLine(findExchangeRate);
            Console.Write("Сумма на обмен: ");
            int count = Inlet();
            Console.Write("Ваш обмен: ");
            ExchangeRate myExchange = currencyConverter.Convert(curForExchange, curToExchange, count);
            Console.Write(myExchange);
            Console.WriteLine();
            //ссылка на скрин работающей программы https://i.postimg.cc/nc8zmbvm/Screenshot-189.png
        }
    }
}


