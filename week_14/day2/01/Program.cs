using System;
using System.Text.Json;
namespace demo;

class Report
{
    public int Id { get; set; }
    public string Category { get; set; }
    public int Priority { get; set; }
    public string Zone { get; set; }
    public int SignalStrength { get; set; }
    public string Shift { get; set; }
}
class Program
{
    static void Main()
    {
        string back = File.ReadAllText("../../../reports.json");
        List<Report> reports = JsonSerializer.Deserialize<List<Report>>(back) ?? new();
        var topSignals = reports.Where(r => r.Category == "SIGNAL").OrderByDescending(r => r.Priority).Take(3);
        //foreach(Report report in topSignals)
        //{ Console.WriteLine(report.Id); }
        List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        var summary = reports.Select(r => new { r.Id, r.Priority }).ToList();
        //Console.WriteLine(summary.Count());
        var byZoneThenPriority = reports.OrderBy(r => r.Id).ThenBy(r => r.Priority);
        //foreach (var report in byZoneThenPriority)
        //{
        //    Console.WriteLine($"Id: {report.Id}, Priority: {report.Priority}");
        //}
        Report? firstUrgent = reports.FirstOrDefault(r => r.Priority > 4);
        //if (firstUrgent is null)
        //    Console.WriteLine("none above priority 4");
        //else
        //    Console.WriteLine(firstUrgent.Id);
        int prioritySum = reports.Sum(r => r.Priority);
        //Console.WriteLine(prioritySum);
        bool anyCritical = reports.All(r => r.SignalStrength < 6);
        //Console.WriteLine(anyCritical);
        var zones = reports.Select(r => r.Zone).Distinct();
        //foreach (var zone in zones)
        //{
        //    Console.WriteLine(zone);
        //}
        List<int> ages = new List<int> { 15, 22, 17, 30, 19, 45 };
        var aa = ages.Where(ages => ages >= 18).OrderBy(ages => ages).Select(age => age * 2).ToList();
        //foreach (var age in aa)
        //{
        //    Console.WriteLine(age);
        //}
    }
}