using System;
namespace Two;
class Greeter
{
    static void Main()
    { 
        Console.Write("Enter speed: ");
        string raw = Console.ReadLine();
        double speed = double.Parse(raw);
        Console.WriteLine($"Speed doubled is {speed * 2}");
    }
}