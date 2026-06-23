using System;
namespace Demo;
enum ClassificationEnum { Friendly, Unidentified, Hostile }
class SignalInterceptLog
{
    static void Main()
    {
        List<string> sourceId = new List<string>();
        List<string> classification = new List<string>();
        List<double> signalStrength = new List<double>();

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

            }
            else if (choiceStr == "2")
            {

            }
            else if (choiceStr == "3")
            {

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
    static string RecordNewBroadcast(List<string>sourceId, List<string>classification, List<double> signalStrength)
    {
        Console.WriteLine("Enter ID");
        string id = Console.ReadLine();

        int checkClassification = 0;
        while (checkClassification == 0)
        {
            Console.WriteLine("Message type entered");
            string ClassificationStr = Console.ReadLine();
            string classification = ClassificationByEnum(ClassificationStr);
            if (classification == "nunu")
            {
                checkClassification = 0;
            }
            else
            {
                checkClassification = 1;
            }
        }

        int checkSignalStrength = 0;
        while (checkSignalStrength == 0) ;

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
}