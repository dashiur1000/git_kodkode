using System;
namespace One;
class FirstClass
{
    static void Main()
    {
        int id = 17;
        double speed = 412.5;
        double heading = 270.0;
        string status = "active";
        bool isLocked = true;
        Console.WriteLine($"Track {id}: {speed} kn, heading {heading}, status {status}");
        Console.WriteLine($"Radar locked: {isLocked}");
    }
}