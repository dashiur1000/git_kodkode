using System;
namespace Thetiger;
class Fleet
{
    static List<string> ids = new List<string>();
    static List<int> speeds = new List<int>();
    static List<double> headings = new List<double>();

    static void AddTrack(string id, int speed, double heading)
    {
        ids.Add(id);
        speeds.Add(speed);
        headings.Add(heading);
    }
}