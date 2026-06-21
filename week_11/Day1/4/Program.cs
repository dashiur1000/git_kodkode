using System;
namespace Demo;
class Example4
{
    static void Main()
    {
        Console.Write("Enter speed: ");
        string raw = Console.ReadLine();
        if (double.TryParse(raw, out double speed))
        {
            string band;
            if (speed < 200) band = "slow";
            else if (speed < 600) band = "cruise";
            else band = "fast";
            Console.WriteLine($"Speed {speed} -> {band}");
        }
        else
        {
            Console.WriteLine("That was not a number.");
        }
    }
}