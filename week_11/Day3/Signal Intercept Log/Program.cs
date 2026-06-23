using System;
namespace Demo;
enum ClassificationEnum { Friendly, Unidentified, Hostile }
class SignalInterceptLog
{
    static void Main()
    {
        List<string> sourceId = new List<string>();
        List<string> classification = new List<string>();
        List<double?> signalStrength = new List<double?>();

        int menu = 1;
        while (menu == 1)
        {
            Console.WriteLine("Welcome to the IDF's secret program...");
            Console.WriteLine("To create a message enter............1");
            Console.WriteLine("To update power and calibrate enter..2");
            Console.WriteLine("To view all message data enter.......3");
            Console.WriteLine("To exit enter........................4");
            Console.Write("Please enter your choice: ");
            string choiceStr = Console.ReadLine();
            if (choiceStr == "1")
            {
                RecordNewBroadcast(sourceId, classification, signalStrength);
                Console.WriteLine("Create!");
            }
            else if (choiceStr == "2")
            {
                UpdatingSignalStrength(sourceId, signalStrength);
                
            }
            else if (choiceStr == "3")
            {
                GetAll(sourceId, classification, signalStrength);
            }
            else if (choiceStr == "4")
            {
                Console.WriteLine("============\n  Goodbye!\n============");
                menu = 0;
            }
            else
            {
                Console.WriteLine("The character string is invalid. Try again.");
            }
        }
    }
    static string RecordNewBroadcast(List<string>sourceId, List<string>classification, List<double?> signalStrength)
    {
        Console.WriteLine("Enter ID");
        string id = Console.ReadLine();

        int checkClassification = 0;
        string savedClassification = "";
        double? validSignal = null;

        while (checkClassification == 0)
        {
            Console.WriteLine("Message type entered (0 or Friendly, 1 or Unidentified, 2 = Hostile): ");
            string ClassificationStr = Console.ReadLine();

            if (Enum.TryParse<ClassificationEnum>(ClassificationStr, true, out ClassificationEnum result))
            {
                savedClassification = result.ToString();
                if (savedClassification == "nunu")
                {
                    checkClassification = 0;
                }

                else
                    checkClassification = 1;
            }
            else
                checkClassification = 0;
            
        }

        int checkSignalStrength = 0;
        while (checkSignalStrength == 0)
        {
            Console.WriteLine("Enter frequency intensity or 'unknown': ");
            string? signalStrengthStr = Console.ReadLine();
            if (double.TryParse(signalStrengthStr, out double signalStrengthDuble))
            {
                if (signalStrengthDuble < 0 | signalStrengthDuble > 300)
                {
                    Console.WriteLine("The number entered is invalid.");
                    checkSignalStrength = 0;
                }
                else
                    validSignal = signalStrengthDuble;
                    checkSignalStrength = 1;
            }
            else if (signalStrengthStr == "unknown")
            {
                signalStrengthStr = null;
                checkSignalStrength = 1;
            }
            else
                checkSignalStrength = 0;
        }
        sourceId.Add(id);
        classification.Add(savedClassification);
        signalStrength.Add(validSignal);
        return "Message added successfully!";

    }
    static string ClassificationByEnum (ClassificationEnum ClassificationWord)
    {
        switch (ClassificationWord)
        {
            case ClassificationEnum.Friendly:
                return "Friendly";
            case ClassificationEnum.Unidentified:
                return "Unidentified";
            case ClassificationEnum.Hostile:
                return "Hostile";
            default:
                return "nunu";
        }
    }
    static void UpdatingSignalStrength(List<string> sourceId, List<double?> signalStrength)
    {
        double? validSignal = null;
        int checkSignalStrength = 0;
        {
        }
        int id = FindById(sourceId);
        if (id >= 0)
        {
            Console.WriteLine("Enter frequency intensity or 'unknown': ");
            string? signalStrengthStr = Console.ReadLine();
            if (double.TryParse(signalStrengthStr, out double signalStrengthDuble))
            {
                if (signalStrengthDuble < 0 | signalStrengthDuble > 300)
                {
                    Console.WriteLine("The number entered is invalid.");
                    checkSignalStrength = 0;
                }
                else
                {
                    validSignal = signalStrengthDuble;
                    checkSignalStrength = 1;
                }
            }
            else if (signalStrengthStr == "unknown")
            {
                validSignal = null;
                checkSignalStrength = 1;
            }
            else
                checkSignalStrength = 1;

        signalStrength[id] = validSignal;
        Console.WriteLine("Update!");
        }
        
        else
        {
            Console.WriteLine("Not found");
        }


    }
    static int FindById(List<string> sourceId)
    {
        Console.WriteLine("enter id: ");
        string idStr = Console.ReadLine();
        for (int index = 0; index < sourceId.Count; index ++)
        {
            if (sourceId[index] == idStr)
                return index;
        }
        return -1;
    }
    static bool GetAll(List<string> sourceId, List<string> classification, List<double?> signalStrength)
    {
        for (int i = 0; i < sourceId.Count; i++)
        {
            if (sourceId[i] == sourceId[i])
            {
                Console.WriteLine($"Signal {i + 1}: [sourceId: {sourceId[i]}, classification: {classification[i]}, signalStrength: {signalStrength[i] ?? 0}]");
                return true;
            }
            Console.WriteLine("The list is empty.");
            return false;
        }
        return false;
       

    }
}