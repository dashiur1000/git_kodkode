using System;
namespace Demo;

class Track
{
    public int Id;
    public double Speed;

    public Track(int id, double speed)
    {
        Id = id;
        Speed = speed;
        Console.WriteLine("constructor ran");
    }
    public static void Main()
    {
        Track a = new Track(17, 412.5);
        Track b = new Track(8, 95.0);
        Console.WriteLine($"{a.Id} at {a.Speed} kn");
    }
}




