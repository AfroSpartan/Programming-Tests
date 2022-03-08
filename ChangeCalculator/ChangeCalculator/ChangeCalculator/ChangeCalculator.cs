using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator
{
    internal class Calculator
    {
        List<Currency> _currencies;

        public Calculator(List<Currency> currencies)
        {
            _currencies = currencies;
        }

        public Dictionary<Denomination, int> GetChange(decimal price, decimal payment, string currencyCode)
        {
            var change = new Dictionary<Denomination, int>();
            var currency = _currencies.Where((c) => c.Code == currencyCode).FirstOrDefault(); // Should have some better safeguards
            decimal remainder = payment - price;


            foreach (var denomination in currency.Denominations)
            {
                if (denomination.Value > remainder)
                {
                    continue;
                }

                int numDenominations = (int)Math.Floor(remainder / denomination.Value);

                change.Add(denomination, numDenominations);
                remainder = remainder % denomination.Value;
            }

            return change;
        }
    }
}