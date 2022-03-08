using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace ChangeCalculator
{
    internal class Currency
    {
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public string Code { get; private set; }
        public IReadOnlyList<Denomination> Denominations { get; private set; }

        public Currency(string name, string symbol, string currencyCode, List<Denomination> denominations)
        {
            Name = name;
            Symbol = symbol;
            Code = currencyCode;
            Denominations = denominations.OrderByDescending((d)=>d.Value).ToList().AsReadOnly();
        }
    }
}
