using project.batchRunner;
using project.commands;
using System;
namespace project.parser;
public enum Commandso
{
    CREATE_FILE,
    SEND_EMAIL,
    BACKUP
}
class CommandParser
{
    public Command Parse(string rawLine)
    {
        string[] lines = rawLine.Split(" ");
        if(lines.Length == 2 )
        {
            if (Enum.TryParse(lines[0], false, out Commandso command))
            {
                switch (command)
                {
                    case Commandso.CREATE_FILE:
                        return new CreateFileCommand(rawLine, lines[1]);
                    case Commandso.SEND_EMAIL:
                        return new SendEmailCommand(rawLine, lines[1]);
                    case Commandso.BACKUP:
                        return new BackupCommand(rawLine, lines[1]);
                }
            }
        
        }
        return null;
    }
}
