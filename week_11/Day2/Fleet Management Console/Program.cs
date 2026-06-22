using System;
using System.Threading.Channels;
namespace Thetiger;
class Fleet
{
     

    static void Main()
    {
        List<string> ids = new List<string>();
        List<int> speeds = new List<int>();
        List<double> headings = new List<double>();
        int choice = 0;


        int menuLoop = 1;
        while (menuLoop == 1)
        {
            Console.Write("choise function 1 to Add-Track, 3 to Find-Id: ");
            string choiseStr = Console.ReadLine();
            if (int.TryParse(choiseStr, out choice))
            {
                if (choice == 1)
                    AddTrack(ids, speeds, headings);
                else if (choice == 3)
                    FindId(ids, speeds, headings);
            }
            else
                menuLoop = 1;
        }

            int exitLoop = 0;
            while (exitLoop == 0)
            {
                Console.Write("Enter 1 or 0 to exit: ");
                string loopStr = Console.ReadLine();
                if (int.TryParse(loopStr, out exitLoop))
                {
                    menuLoop = exitLoop;
                    if (exitLoop == 1)
                    {
                        menuLoop = 1;
                        exitLoop = 1;
                    }
                    else if (exitLoop == 0)
                    {
                        menuLoop = 0;
                        exitLoop = 1;
                    }
                    else
                    {
                        exitLoop = 0;
                    }
                }
            }

        }
      
    
    static void AddTrack(List<string>ids, List<int> speeds, List<double> headings)
    { 
        
        {
            string speedStr = "";
            string headingStr = "";


            Console.Write("Enter ID number: ");
            ids.Add(Console.ReadLine());


            int addLoop = 0;
            while (addLoop == 0)
            {
                Console.Write("Enter speed: ");
                speedStr = Console.ReadLine();
                if (int.TryParse(speedStr, out int speed))
                {
                    speeds.Add(speed);
                    addLoop = 1;
                }
                else
                    addLoop = 0;
            }
            addLoop = 0;
            while (addLoop == 0)
            {
                Console.Write("Enter heading: ");
                headingStr = Console.ReadLine();
                if (double.TryParse(headingStr, out double heading))
                {
                    headings.Add(heading);
                    addLoop = 1;
                }
                else
                    addLoop = 0;
            }
            for (int index = 0; index < speeds.Count; index++)
            {
                Console.Write($"track {index + 1} [id: {ids[index]}, ");
                Console.Write($"speed: {speeds[index]}, ");
                Console.Write($"heading: {headings[index]}]");
                Console.Write($"\n");
            }
            
        }
    }
    static int FindId(List<string>ids, List<int>speeds, List<double>headings)
    {
        int index = 0;
        Console.Write("Enter ID number: ");
        string id = Console.ReadLine();
        for (index = 0; index < speeds.Count; index++)
        {
            if (ids[index] == id)
            {
                Console.WriteLine($"track {index + 1} [id: {ids[index]}, speed: {speeds[index]}, heading: {headings[index]}]");
                return index;

            }
            
        }
        index = -1;
        return index;
    }
    
}