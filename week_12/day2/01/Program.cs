using System;
namespace Demo;
class Track
{
    public int Id { get; }
    public double Speed { get; set; }
    public Track(int id, double speed)
    {
        Id = id;
        Speed = speed;
    }
}

class Aircraft : Track
{
    public double Altitude { get; }
    public Aircraft(int id, double speed, double altitude)
        : base(id, speed)
    {
        Altitude = altitude;
    }
}

class Insta
{
    static void Main()
    {
        Aircraft a = new Aircraft(1, 420, 30000);
        Track b = new Track(1, 30);
        Console.WriteLine($"{a.Id} {a.Speed} {a.Altitude}");
        Console.WriteLine($"{b.Id} {b.Speed}");
    }
}