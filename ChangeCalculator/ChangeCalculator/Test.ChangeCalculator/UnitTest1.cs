using Xunit;
using ChangeCalculator;
using System.Collections.Generic;

namespace Test_ChangeCalculator
{
    public class CalculatorTests
    {
        [Fact]
        public void Test1()
        {
            var fifty = new Denomination("£50", 50m);
            var twenty = new Denomination("£20", 20m);
            var tenner = new Denomination("£10", 10m);
            var fiver = new Denomination("£5", 5m);
            var two = new Denomination("£2", 2m);
            var one = new Denomination("£1", 1m);
            var fiftyP = new Denomination("50p", 0.5m);
            var twentyP = new Denomination("20p", 0.2m);
            var tenP = new Denomination("10p", 0.1m);
            var fiveP = new Denomination("5p", 0.05m);
            var twoP = new Denomination("2p", 0.02m);
            var oneP = new Denomination("1p", 0.01m);

            var currencyGDP = new Currency("Pounds", "£", "GBP", new List<Denomination>() {
                fifty,
                twenty,
                tenner,
                fiver,
                two,
                one,
                fiftyP,
                twentyP,
                tenP,
                fiveP,
                twoP,
                oneP
            });
            var calculator = new Calculator(new List<Currency> { currencyGDP });



            var change = calculator.GetChange(5.50m, 20m, "GBP");

            Assert.Equal(1, change[tenner]);
            Assert.Equal(2, change[two]);
            Assert.Equal(1, change[fiftyP]);
        }

        [Fact]
        public void Test2()
        {
            var fifty = new Denomination("£50", 50m);
            var twenty = new Denomination("£20", 20m);
            var tenner = new Denomination("£10", 10m);
            var fiver = new Denomination("£5", 5m);
            var two = new Denomination("£2", 2m);
            var one = new Denomination("£1", 1m);
            var fiftyP = new Denomination("50p", 0.5m);
            var twentyP = new Denomination("20p", 0.2m);
            var tenP = new Denomination("10p", 0.1m);
            var fiveP = new Denomination("5p", 0.05m);
            var twoP = new Denomination("2p", 0.02m);
            var oneP = new Denomination("1p", 0.01m);

            var currencyGDP = new Currency("Pounds", "£", "GBP", new List<Denomination>() {
                fifty,
                twenty,
                tenner,
                fiver,
                two,
                one,
                fiftyP,
                twentyP,
                tenP,
                fiveP,
                twoP,
                oneP
            });
            var calculator = new Calculator(new List<Currency> { currencyGDP });



            var change = calculator.GetChange(2.25m, 30m, "GBP");

            Assert.Equal(1, change[twenty]);
            Assert.Equal(1, change[fiver]);
            Assert.Equal(1, change[two]);
            Assert.Equal(1, change[fiftyP]);
            Assert.Equal(1, change[twentyP]);
            Assert.Equal(1, change[fiveP]);
        }
    }
}