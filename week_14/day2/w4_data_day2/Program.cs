using System;
using System.Text.Json;
using System.Text.RegularExpressions;
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
        Console.Write("(1) ");
        var count = reports.Count();
        Console.WriteLine(count);
        Console.Write("(2) ");
        var ids = reports.Where(cat => cat.Category == "SIGNAL").Select(cat => cat.Id).ToList();
        foreach (int id in ids)
        {
            Console.Write(id);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(3) ");
        var ids3 = reports.Where(cat => cat.Priority >= 4).Select(cat => cat.Id).ToList();
        foreach(int id2 in ids3)
        {
            Console.Write(id2);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(4) ");
        var list4 = reports.Where(shift => shift.Shift == "Night" && shift.Zone == "North").Select(id => id.Id).ToList();
        foreach (int id2 in list4)
        {
            Console.Write(id2);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(5) ");
        var list5 = reports.Where(cat => cat.Category == "COMMS").Select(rep => new {rep.Id, rep.Priority}).ToList();
        foreach (var item in list5)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(6) ");
        var list6 = reports.Where(sin => sin.SignalStrength >= 70 && sin.SignalStrength <= 90).Select(id => id.Id).ToList();
        foreach (int item in list6)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(7) ");
        var list7 = reports.Where(zone => zone.Zone != "West").Select(id => id.Id).ToList();
        foreach (int item in list7)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(8) ");
        var list8 = reports.OrderByDescending(py => py.Priority).Select(id => id.Id).First();
        Console.WriteLine(list8);
        Console.Write("(9) ");
        var list9 = reports.OrderBy(zo => zo.Zone).ThenByDescending(pi => pi.Priority).Select(id => id.Id).ToList();
        foreach (var item in list9)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(10) ");
        var list10 = reports.OrderByDescending(si => si.SignalStrength).Select(id => id.Id).Take(3).ToList();
        foreach (var item in list10)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(11) ");
        var list11 = reports.OrderBy(si => si.SignalStrength).Select(id => id.Id).Take(2).ToList();
        foreach (var item in list11)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(12) ");
        var list12 = reports.OrderByDescending(si => si.SignalStrength).Select(id => id.Id).Skip(5).ToList();
        foreach (var item in list12)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(13) ");
        var list13 = reports.Where(ca => ca.Category == "IMAGERY").OrderBy(si => si.SignalStrength).Select(id => id.Id).ToList();
        foreach (var item in list13)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(14) ");
        var list14 = reports.Where(pi => pi.Priority == 5).Count();
        Console.WriteLine(list14);
        Console.Write("(15) ");
        var list15 = reports.Average(si => si.SignalStrength);
        Console.WriteLine(list15);
        Console.Write("(16) ");
        var l16 = reports.OrderByDescending(si => si.SignalStrength).Select(si => si.SignalStrength).Take(1).ToList();
        foreach(var item in l16)
            Console.WriteLine(item);
        Console.Write("(17) ");
        var l17 = reports.OrderBy(si => si.SignalStrength).Where(ni => ni.Shift == "Night").Select(si => si.SignalStrength).Take(1).ToList();
        foreach( var item in l17)
            Console.WriteLine(item);
        Console.Write("(18) ");
        var l18 = reports.Where(si => si.Category == "SIGNAL").Sum(p => p.Priority);
        Console.WriteLine(l18);
        Console.Write("(19) ");
        var l19 = reports.Where(zo => zo.Zone == "South").Average(p => p.Priority);
        Console.WriteLine(l19);
        Console.Write("(20) ");
        var l20 = reports.Select(z => z.Zone).Distinct().Count();
        Console.WriteLine(l20);
        Console.Write("(21) ");
        var l21 = reports.OrderBy(a => a.Category).Select(c => c.Category).Distinct().ToList();
        foreach (var item in l21)
        {
            Console.Write(item);
            Console.Write(" ");
        }
        Console.WriteLine();
        Console.Write("(22) ");
        var l22 = reports.GroupBy(a => a.Category).Select(g => new {category = g.Key, count = g.Count()}).ToList();
        foreach (var item in l22)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(23) ");
        var l23 = reports.GroupBy(z => z.Zone).Select(g => new {zone = g.Key, averageSignalStrength = Math.Round(g.Average(a => a.SignalStrength), 2) }).ToList();
        foreach (var item in l23)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(24) ");
        var l24 = reports.GroupBy(z => z.Category).Select(g => new { zone = g.Key, averagePriority = Math.Round(g.Average(a => a.Priority), 2) }).ToList();
        foreach (var item in l24)
        {
            Console.Write(item);
            Console.Write(", ");
        }
        Console.WriteLine();
        Console.Write("(25) ");
        var l25 = reports.GroupBy(z => z.Zone).Select(g => new { zone = g.Key, maxSignalStrength = g.Max(a => a.SignalStrength) }).ToList();
        foreach (var item in l24)
        {
            Console.Write(item);
            Console.Write(", ");
        }
    }

}