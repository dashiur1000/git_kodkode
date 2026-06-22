using System;
namespace Demo;
class Two
{
    static List<string> tracks = new List<string>();
    static List<double> speeds = new List<double>();
    static void Main()
    {
        AddTrack("32", 88.8);
        AddTrack("770", 110.1);
        AddTrack("15", 99.9);
        Console.WriteLine(AverageSpeed());
    }
    static void AddTrack(string id, double speed)
    {
        tracks.Add(id);
        speeds.Add(speed);
    }

    static double AverageSpeed()
    {
        if (speeds.Count == 0) return 0.0;
        double sum = 0;
        foreach (double s in speeds) sum += s;
        return sum / speeds.Count;
    }

    
}