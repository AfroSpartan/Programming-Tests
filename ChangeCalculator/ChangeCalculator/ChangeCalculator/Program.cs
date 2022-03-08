// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using ChangeCalculator;

[assembly: InternalsVisibleToAttribute("Test_ChangeCalculator")]

// This could have really been loaded from a file or something
var Currencies = new List<Currency>();
var currencyGDP = new Currency("Pounds", "£", "GBP",new List<Denomination>() {
                new Denomination("£50", 50m),
                new Denomination("£20", 20m),
                new Denomination("£10", 10m),
                new Denomination("£5", 5m),
                new Denomination("£2", 2m),
                new Denomination("£1", 1m),
                new Denomination("50p", 0.5m),
                new Denomination("20p", 0.2m),
                new Denomination("10p", 0.1m),
                new Denomination("5p", 0.05m),
                new Denomination("2p", 0.02m),
                new Denomination("1p", 0.01m),
            });

Currencies.Add(currencyGDP);

// We should really sanitise these
Console.WriteLine("Please enter the price:");
var price = decimal.Parse(Console.ReadLine());

Console.WriteLine("Please enter the payment:");
var payment = decimal.Parse(Console.ReadLine());

Console.WriteLine("Please enter the currency code (eg. GBP):");
var currencyCode = Console.ReadLine().ToUpper();

var calculator = new Calculator(Currencies);

var change = calculator.GetChange(price, payment, currencyCode);

Console.Clear();

Console.WriteLine("Your change is:");
Console.WriteLine();
foreach (var denomination in change)
{
    Console.WriteLine($"{denomination.Key.Name} x {denomination.Value}");
}