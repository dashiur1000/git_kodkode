using System.Text.Json;
namespace demo;
class Report
{
    public int Id { get; set; }
    public string Category { get; set; }
    public int Priority { get; set; }
}
class maini
{
    static void Main()
    {

        //var reports = new List<Report>
        //{
        //    new Report { Id = 1, Category = "SIGNAL", Priority = 3 },
        //    new Report { Id = 2, Category = "IMAGERY", Priority = 5 },
        //};
        //var opts = new JsonSerializerOptions { WriteIndented = true };
        //string json = JsonSerializer.Serialize(reports, opts);
        //File.WriteAllText("../../../reports.json", json);

        string back = File.ReadAllText("reports.json");
        //Console.WriteLine(back);

        List<Report> loaded = JsonSerializer.Deserialize<List<Report>>(back) ?? new(); 
        foreach (Report report in loaded)
        {
            Console.WriteLine(report.Category);
        }
    }
}