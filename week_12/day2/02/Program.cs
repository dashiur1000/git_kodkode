using System;
namespace Demo;
class Track
{
    public int Id { get; }
    public Track(int id) { Id = id; }
    public virtual string Describe()
        => $"Track {Id}";
}
class Aircraft : Track
{
    public double Altitude { get; }
    public Aircraft(int id, double altitude)
        : base(id)
    {
        Altitude = altitude;
    }
    public override string Describe()
    
        => $"Aircraft {Id} at {Altitude} ft";
    
}
class Insta
{
    static void Main()
    {
        Aircraft a = new Aircraft(8, 8800);
        Console.WriteLine(a.Describe());
        Console.WriteLine(a.Id);
    }
    
}