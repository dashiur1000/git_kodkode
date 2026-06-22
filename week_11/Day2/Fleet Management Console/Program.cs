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

        int exitLoop = 0;
        while (exitLoop == 0)
        {
            int menuLoop = 1;
            while (menuLoop == 1)
            {
                Console.Write("choise function\n1 to Add-Track\n2 to Remove-By-Id\n3 to Find-Id\n4 to list-All-Tracks\n5 to Filter-Tracks\n6 to Summarize\n0 to exit\nenter: ");
                string choiseStr = Console.ReadLine();
                if (int.TryParse(choiseStr, out choice))
                {
                    if (choice == 1)
                        AddTrack(ids, speeds, headings);
                    else if (choice == 2)
                        RemoveById(ids, speeds, headings);
                    else if (choice == 3)
                        FindId(ids, speeds, headings);
                    else if (choice == 4)
                    {
                        listAllTracks(ids, speeds, headings);
                    }
                    else if (choice == 5)
                    {
                        Console.Write("enter 1 for filter the speed or 2 for filter the heading: ");
                        string choiceFilter = Console.ReadLine();
                        if (int.TryParse(choiceFilter, out choice))
                        {
                            if (choice == 1)
                                FilterTracks(speeds);
                            else if (choice == 2)
                                FilterTracks(headings);
                            else
                                menuLoop = 1;
                        }

                    }
                    else if (choice == 6)
                        Summarize(ids, speeds, headings);


                    else if (choice == 0)
                    {
                        menuLoop = 0;
                        exitLoop = 1;
                    }
                }
                else
                    menuLoop = 1;
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
    static void RemoveById(List<string> ids, List<int> speeds, List<double> headings)
    {
        int idIndex = FindId(ids, speeds, headings);
        if (idIndex >= 0)
        {
            ids.RemoveAt(idIndex);
            speeds.RemoveAt(idIndex);
            headings.RemoveAt(idIndex);
        }
        else
            Console.WriteLine("No ID to delete");
    }
    static List<string> listAllTracks(List<string> ids, List<int> speeds, List<double> heading)
    {
        List<string> allList = new List<string>();
        for (int index = 0; index < speeds.Count; index++)
        {
            allList.Add($"track {index + 1}: [id: {ids[index]}, speed: {speeds[index]}, heading: {heading[index]}]");
        }
        for (int index = 0; index < allList.Count; index++)
        {
            Console.WriteLine($"{allList[index]}");
        }
        return allList;
    }
    static List<int> FilterTracks(List<int> speeds)
    {
        Console.Write("Enter minimum speed to filter: ");
        int minSpeed = int.Parse(Console.ReadLine());

        List<int> filteredList = new List<int>();

        foreach (int speed in speeds)
        {
            if (speed >= minSpeed)
            {
                filteredList.Add(speed);
            }    
        }
        
        for (int index = 0; index < filteredList.Count; index++)
        {
            Console.Write($"{filteredList[index]}, ");
        }
        Console.Write("\n");
        return filteredList;
    }



    static List<double> FilterTracks(List<double> headings)
    {
        Console.Write("Enter minimum heading to filter: ");
        double minHeadings = double.Parse(Console.ReadLine());

        List<double> filteredList = new List<double>();

        foreach (double heading in headings)
        {
            if (heading >= minHeadings)
            {
                filteredList.Add(heading);
            }
        }

        for (int index = 0; index < filteredList.Count; index++)
        {
            Console.Write($"{filteredList[index]}, ");
        }
        Console.Write("\n");
        return filteredList;
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


    static List<string> Summarize(List<string> ids, List<int> speeds, List<double> headings)
    {
        int counterInt = 0;
        List<string> summarize = new List<string>();
        counterInt = speeds.Count;
        string counter = counterInt.ToString();
        summarize.Add(counter);

        int sumSpeed = 0;
        for (int index = 0; index < speeds.Count; index++)
        {
            sumSpeed = sumSpeed + speeds[index];
        }
        int AveSpeed = sumSpeed / speeds.Count();
        string Ave = AveSpeed.ToString();
        summarize.Add(Ave);


        int fastestTrack = 0;
        for (int index = 0; index < speeds.Count; index++)
        {
            if (speeds[index] > fastestTrack)
            {
                fastestTrack = speeds[index];
            }
        }
        string fastes = fastestTrack.ToString();
        summarize.Add(fastes);


        Console.WriteLine($"count: {summarize[0]}, average speed: {summarize[1]}, fastest track: {summarize[2]}");
        return summarize;

    }


}