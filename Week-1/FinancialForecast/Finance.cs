using System;

Console.Write("Enter initial amount: ");
double initialAmount = double.Parse(Console.ReadLine());

Console.Write("Enter annual growth rate (in %): ");
double growthRate = double.Parse(Console.ReadLine());

Console.Write("Enter number of years to forecast: ");
int years = int.Parse(Console.ReadLine());

double futureValue = CalculateFutureValue(initialAmount, growthRate, years);
Console.WriteLine($"\nFuture Value after {years} years: {futureValue:F2}");

// Recursive function to calculate future value
double CalculateFutureValue(double amount, double rate, int years)
{
    if (years == 0)
        return amount;

    return CalculateFutureValue(amount * (1 + rate / 100), rate, years - 1);
}
