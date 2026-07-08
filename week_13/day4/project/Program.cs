using project.batchRunner;
using System;
namespace project.program;
class Maini
{
    public static void Main()
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo?  projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent;
            string fileName = "commands.txt";
            string FullPath = Path.Combine(projectDir.FullName, fileName);
            List<string> list = new List<string>(File.ReadAllLines(FullPath));
            var logger = new ConsoleCommandLogger();
            var runner = new BatchRunner(logger);
            runner.Run(list);
            var summary = runner.GetSummary();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex}");
        }
    }
}