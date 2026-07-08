using System;
using System.Net.Mail;
namespace project.commands;
abstract class Command
{
    public string RawLine { get; }
    public string Target { get; }
    protected Command(string rawLine, string target)
    {
        RawLine = rawLine;

        try
        {
            Target = target;
        }
        catch (Exception e) { Console.WriteLine(e); }
            
    }
    public abstract bool Execute();
}
interface IUndoable
{
    void Undo();
}
interface IRetryable
{
    void Retry();
}
class CreateFileCommand: Command, IUndoable
{
    public CreateFileCommand(string rawLine, string fileName) : base(rawLine, fileName)
    {

    }
    public override bool Execute()
    {
        if (this.Target.StartsWith("_") || this.Target[^4] != '.')
            return false;
        Console.WriteLine($"{this.RawLine} File '{this.Target}'");
        return true;
    }
    public void Undo()
    {
        Console.WriteLine($"{this.RawLine} File '{this.Target}' deleted (undo)");
    }
}
class SendEmailCommand : Command
{
    public SendEmailCommand(string rawLine, string emailAddress) : base(rawLine, emailAddress)
    {

    }
    public override bool Execute()
    {
        if (this.Target.EndsWith("@gmail.com"))
        {
            Console.WriteLine($"{this.RawLine} Email sent to '{this.Target}'.");
            return true;
        }
        else
        {
            return false;
        }
    }
}
class BackupCommand : Command, IUndoable, IRetryable
{
    public BackupCommand(string rawLine, string datasetName) : base(rawLine, datasetName)
    {

    }
    public override bool Execute()
    {
        if (this.Target.StartsWith("_"))
            return false;
        Console.WriteLine($"{this.RawLine} Dataset '{this.Target}' backed up");
        return true;
    }
    public void Undo()
    {
        Console.WriteLine($"{this.RawLine} Backup of '{this.Target}' removed (undo)");
    }
    public void Retry()
    {
        Console.WriteLine($"{this.RawLine} Retrying backup of '{this.Target}");
        Execute();
    }
}