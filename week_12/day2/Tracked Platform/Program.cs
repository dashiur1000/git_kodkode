using System;
namespace Dudi;
abstract class Platform
{
    private int _trackid;
    private double _heading { get; set; }
    private double _speedknots { get; set; }

    public int TrackId { get => _trackid;
        private set { _trackid = value; } }
    public double SpeedKnots
    {
        get => _speedknots;
        set
        {
            if (value < 0)
                _speedknots = 0;
            else _speedknots = value;
        }
    }
    public double Heading
    {
        get => _heading;
        set
        {
            if (value > 359 || value < 0)
               _heading = 0;
            else
                _heading = value;       
        }
    }
    protected Platform(int TrackId, double Heading, double SpeedKnots)
    {
        _trackid = TrackId;
        _heading = Heading;
        _speedknots = SpeedKnots;
    }
    public override string ToString()
    {
        return $"TrackId {TrackId}, Heading {Heading}, SpeedKnots {SpeedKnots}";
    }
    public abstract bool IsTrackable();
    public abstract string StatusLine();
}
class AirPlatform : Platform
{
    public double AltitudeFeet { get; }
    public AirPlatform(int TrackId, double Heading, double SpeedKnots, double altitudeFeet)
        : base(TrackId, Heading, SpeedKnots) => AltitudeFeet = altitudeFeet;
    public override bool IsTrackable()
    {
        if(AltitudeFeet < 0 || AltitudeFeet > 60000 && SpeedKnots > 0) return true;
        else return false;
    }
    public override string StatusLine()
    {
        return $"{AltitudeFeet}";
    }
}
class SeaPlatform : Platform
{
    public double DepthMeters { get; }
    public SeaPlatform(int TrackId, double Heading, double SpeedKnots, double depthMeters)
        : base(TrackId, Heading, SpeedKnots) => DepthMeters = depthMeters;
    public override bool IsTrackable()
    {
        if (DepthMeters >= 0 && DepthMeters <= 300) return true;
        else return false;
    }
    public override string StatusLine()
    {
        return $"{DepthMeters}";
    }
}
class GroundPlatform : Platform
{
    public string TerrainType { get; }
    public GroundPlatform(int TrackId, double Heading, double SpeedKnots, string terrainType)
        : base(TrackId, Heading, SpeedKnots) => TerrainType = terrainType;
    public override bool IsTrackable()
    {
        if (TerrainType != "tunnel") return true;
        else return false;
    }
    public override string StatusLine()
    {
        return $"{TerrainType}";
    }
}
class test
{
    static void Main()
    {
        List<Platform> PlatformList = new()
        {
            new AirPlatform(1, 33.6, 500, 30000),
            new SeaPlatform(2, 360, 66, 310),
            new GroundPlatform(3, 250, 55, "tunnel"),
            new AirPlatform(4, 66, 15, 600001),
            new SeaPlatform(5, 100, 55, 65),
            new GroundPlatform(6, 55, 66, "bridge")
        };
        for (int i = 0; i < PlatformList.Count; i++)
        { Console.WriteLine($"{PlatformList[i].ToString()} | {PlatformList[i].StatusLine()}, {PlatformList[i].IsTrackable()}"); }
    }
}