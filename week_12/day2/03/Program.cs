using System;
namespace Demo;
abstract class Track
{
    public int Id { get; }
    public double Speed { get; set; }
    protected Track(int id, double speed)
    {
        Id = id;
        Speed = speed;
    }
    public abstract string Describe();
}
class Aircraft : Track
{
    public double Altitude { get; }
    public Aircraft(int id, double speed, double altitude)
        : base(id, speed) => Altitude = altitude;
    public override string Describe()
        => $"Aircraft {Id} at {Altitude} ft, {Speed} kn";
}
class Vessel : Track
{
    public Vessel(int id, double speed) : base(id, speed) { }
    public override string Describe()
        => $"Vessel {Id}, {Speed} kn";
}
class Insta
{
    static void Main()
    {
        Aircraft b = new Aircraft(1, 20, 300);
        Console.WriteLine(b.Describe());
        Vessel c = new Vessel(1, 20);
        Console.WriteLine(c.Describe());
    }
}