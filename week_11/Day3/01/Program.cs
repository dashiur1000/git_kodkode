using System;
namespace Demo;
class Day3
{
    static void TryDouble(int n) { n = n * 2; }
    static void AddOne(List<int> xn) { xn.Add(1); }

    static void Main()
    {
        int x = 10;
        TryDouble(x);
        Console.WriteLine(x);

        List<int> list = new List<int>();
        AddOne(list);
        AddOne(list);
        Console.WriteLine(list.Count);
    }
}