using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator
{
    internal class Denomination
    {
        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public Denomination(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
