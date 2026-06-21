using System;
namespace SingleTrackConsoleReadout;
class SingleTrack
{
    static void Main()
    {
        int id = 0;
        int speed = 0;
        string? speedCategory = null;
        double heading = 0;
        string? status = null;


        int n = 0;
        while (n == 0)
        { Console.Write("Enter id number: ");
            string strId = Console.ReadLine();

            if (int.TryParse(strId, out id))
            {
                n = 1;
            }
            else
            {
                Console.WriteLine("Illegal character. Enter a number.");
                n = 0;
            }
        }

        int c = 0;
        while (c == 0)
        {
            Console.Write("Enter speed: ");
            string row = Console.ReadLine();

            if (int.TryParse(row, out speed))
            {

                if (speed < 100) speedCategory = "slow";
                else if (speed < 200) speedCategory = "medium";
                else speedCategory = "fast";
                c = 1;
            }
            else
            {
                Console.WriteLine("Illegal character. Enter a number");
                c = 0;
            }
        }


        int b = 0;
        while (b == 0)
        {
            Console.Write("Enter heading: ");
            string strHeading = Console.ReadLine();

            if (double.TryParse(strHeading, out heading))
            {
                if (heading >= 359 & heading <= 0)
                {
                    Console.WriteLine("The range is invalid, between 0 and 359");
                    b = 0;
                }
                else
                    b = 1;
            }
            else
            {
                Console.WriteLine("Illegal character. Enter a number");
                b = 0;
            }
        }


        int f = 0;
        while (f == 0)
        {
            Console.Write("Enter status: ");
            status = Console.ReadLine();
            if (status == "cruising" | status == "turning" | status == "stopped" | status == "accelerating")
                f = 1;
            else
            {
                Console.WriteLine("The status entered is invalid, please enter cruising, stopped, accelerating");
                f = 0;
            }
        }


        Console.WriteLine("=== Track Report ===");
        Console.WriteLine($"Track ID: {id}");
        Console.Write($"speed: {speed}");
        Console.WriteLine($" km/h {speedCategory} ");
        Console.WriteLine($"Heading: {heading} degrees");
        Console.WriteLine($"Status: {status}");
        Console.WriteLine($"Division Demo 1: {heading}/30 = {(int)heading / 30} (int) | {heading / 30} (double)");
        Console.WriteLine($"Division Demo 2: {speed}/60 = {speed / 60} (int) | {(double)speed / 60} (double)");





    }

}