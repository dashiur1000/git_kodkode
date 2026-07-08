using project.commands;
using project.parser;
using System;
namespace project.batchRunner;
class BatchRunner
{
    private readonly ICommandLogger _logger;
    private readonly CommandParser _parser;
    private int _succeeded;
    private int _failed;
    private int _unparseable;
    public BatchRunner(ICommandLogger logger)
    {
        _logger = logger;
        _parser = new CommandParser();
        _succeeded = 0;
        _failed = 0;
        _unparseable = 0;
    }
    public void Run(List<string> rawLines)
    {
        foreach (var line in rawLines)
        {
            var command = _parser.Parse(line);
            if(command == null)
            {
                _unparseable++;
                Console.WriteLine("line failed to parse");
            }
            else
            {
                bool ex = command.Execute();
                if(ex == false)
                {
                    _failed++;
                }
                else
                {
                    _logger.LogResult(command, ex);
                    _succeeded++;
                }
                
            }
        }
    }
    public RunSummary GetSummary()
    {
        ICommandLogger commandLogger = _logger;
        Console.Write($"Succeeded: {_succeeded} | ");
        Console.Write($"Failed: {_failed} | ");
        Console.Write($"Unparseable: {_unparseable}");
        return new RunSummary(_succeeded, _failed, _unparseable);

    }

}
interface ICommandLogger
{
    void LogResult(Command command, bool success);
}
class RunSummary
{
    public int Succeeded { get; }
    public int Failed { get; }
    public int Unparseable { get; }
    public RunSummary(int succeeded, int failed, int unparseable)
    {
        Succeeded = succeeded;
        Failed = failed;
        Unparseable = unparseable;
    }
}
class ConsoleCommandLogger : ICommandLogger
{
    public void LogResult(Command command, bool success)
    {
        Console.WriteLine($"{command}: {success}");
    }
}
class FileCommandLogger : ICommandLogger
{
    public void LogResult(Command command, bool success)
    {

    }
}