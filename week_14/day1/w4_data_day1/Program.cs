using System;
using System.Text.Json;
namespace demo;

class Maini
{
    static void Main()
    {

        //List<Reports> list = new List<Reports>();
        //IValidator validator = new IsBillingNumber();
        //List<Reports> list2 = new List<Reports>();
        //int valid = 0;
        //int invalid = 0;
        //using (var reader = new StreamReader("../../../field_reports_input.txt"))
        //{
        //    try
        //    {
        //        string? line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            try
        //            {
        //                string[] parts = line.Split(" ");
        //                validator.Validate(parts[2]);
        //                var report = new Reports
        //                (int.Parse(parts[0]),
        //                    parts[1],
        //                    int.Parse(parts[2])
        //                );
        //                list2.Add(report);
        //                valid++;
        //            }
        //            catch (CustomeException ex)
        //            {
        //                invalid++;
        //                Console.WriteLine($"Error: {ex.Message}");
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        Console.WriteLine($"valid: {valid}, invalid: {invalid}");
        //        var opts = new JsonSerializerOptions { WriteIndented = true };
        //        string json = JsonSerializer.Serialize(list2, opts);
        //        Console.WriteLine(json);
        //        File.WriteAllText("../../../reports_output.json", json);
        //    }
        //}

        List<Reports> list = new List<Reports>();
        IValidator validator = new IsBillingNumber();
        List<Reports> list2 = new List<Reports>();
        var validator2 = new IsNotEmpty();
        int valid = 0;
        int invalid = 0;
        string debug = File.ReadAllText("../../../w4d1_reports_corrupted.json");
        string baseDir = AppContext.BaseDirectory;
        string filePath = Path.Combine(baseDir, "w4d1_reports.json");
        string dot = File.ReadAllText(filePath);
        Console.WriteLine(dot);
        foreach (var line in dot.Split("/"))
        {
            {
                try
                {
                    string[] parts = line.Split(":");
                    validator2.Validate(parts);
                    validator.Validate(parts[2]);
                    var report = new Reports
                    (int.Parse(parts[0]),
                        parts[1],
                        int.Parse(parts[2])
                    );
                    list2.Add(report);
                    valid++;
                }
                catch (CustomeException ex)
                {
                    invalid++;
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            }
            
            
            {
                Console.WriteLine($"valid: {valid}, invalid: {invalid}");
            }
            
        }



    }
    class Reports
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public Reports(int id, string category, int priority)
        {
            Id = id;
            Category = category;
            Priority = priority;
        }
    }
    interface IValidator
    {
        void Validate(string priorityStr);
    }
    class IsBillingNumber : IValidator
    {
        public void Validate(string priorityStr)
        {
            if (!int.TryParse(priorityStr, out int priority))
            {
                throw new CustomeException("Priority is not a number");
            }
            if (priority < 0)
            {
                throw new CustomeException("Priority is negative");
            }
        }
    }
    class IsNotEmpty 
    {
        public void Validate(string[] arrey)
        {
            if (arrey.Length != 3)
            {
                throw new CustomeException("Invalid line");
            }
        }
    }
    public class CustomeException : Exception
    {
        public CustomeException(string message) : base(message)
        {
        }
    }

