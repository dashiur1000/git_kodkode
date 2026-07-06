using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.IO;
namespace day1;

class TrackAll
{
    public int Id;
    public double Speed;
    public bool IsValid() => Speed >= 0; 
    public string Format() => $"Track {Id}: {Speed} kn"; 
    public void SaveToFile(string path) 
        => System.IO.File.WriteAllText(path, Format());
}


class Track
{
    public int Id { get; }
    public double Speed { get; }
    public Track(int id, double speed)
    {
        if (speed < 0) throw new ArgumentException("speed cannot be negative");
        Id = id; Speed = speed;
    }
    public override string ToString() => $"Track {Id}: {Speed} kn";
}
class TrackFormatter
{
    public string ToCsv(Track t) => $"{t.Id},{t.Speed}";
}
class FileTrackStore
{
    public void Save(Track t, string path) =>
        System.IO.File.WriteAllText(path, t.ToString());
}