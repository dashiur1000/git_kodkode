using System;
namespace Demo;
class Trump
{
    static List<string> tracks = new List<string>();
    static List<double> speeds = new List<double>();
    static void Main()
    {
        AddTrack("32", 305.2);
        AddTrack("770", 110.1);
        AddTrack("15", 99.9);
        Console.WriteLine(AverageSpeed());
        List<string> fast = FastTracks(20.0);
        Console.WriteLine($"{fast.Count} fast tracks");
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


        static List<string> FastTracks(double threshold)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < tracks.Count; i++)
        {
            if (speeds[i] > threshold)
                result.Add(tracks[i]);
        }
        return result;
    }
    
}