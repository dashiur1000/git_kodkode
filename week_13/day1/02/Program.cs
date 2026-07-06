using System;
namespace day1.p2;
//class ThreatScorer
//{
//    public int Score(double speed, string kind)
//    {
//        switch (kind)
//        {
//            case "air": return (int)(speed * 2);
//            case "sea": return (int)(speed * 1);
//            default: return 0;
//        }
//    }
//}
abstract class Track
{
    public double Speed { get; init; }
    public abstract int Score();
}
class Aircraft : Track
{
    public override int Score() => (int)(Speed * 2);
}
class Vessel : Track
{
    public override int Score() => (int)(Speed * 1);
}
class ThreatScorer
{
    public int Score(Track t) => t.Score();
}

