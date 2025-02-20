using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction(1);
        Console.WriteLine(fraction1.GetFractionString());

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}
