using System;
namespace Dudi;
class Track
{
    private double _heading;

    public int Id { get; }
    public double Speed { get; set; }
    public double Heading
    {
        get => _heading;
        set
        {
            if (value < 0 | value > 359)
                _heading = 0;
            else
                _heading = value;
        }
    }
    public Track(int id, double speed, double heading)
    {
        Id = id;
        Speed = speed;
        Heading = heading;
    }
    public override string ToString()
        => $"Track {Id}: {Speed} kn, heading {Heading}";
}
class Toto
{
    static void Main()
    {
        Track t = new Track(17, 412.5, 270);
        Console.WriteLine(t);
        t.Heading = 999;
        Console.WriteLine(t);
    }
}
