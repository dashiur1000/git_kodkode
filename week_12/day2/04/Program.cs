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
        Aircraft a = new Aircraft(1, 300, 30000);
        Vessel b = new Vessel(1, 300);

        Track[] allArr = new Track[3];
        allArr[0] = a;
        allArr[1] = b;
        allArr[2] = new Aircraft(1, 2, 3);

        for (int i = 0; i < allArr.Length; i++)
        {
            Console.WriteLine(allArr[i].Describe());
        }

        List<Track> all = new()
        {
            new Aircraft(1, 420, 30000),
            new Vessel(2, 18),
            new Aircraft(3, 315, 41000)
        };
        foreach (Track t in all)
        {
            Console.WriteLine(t.Describe());
        }
    }
}