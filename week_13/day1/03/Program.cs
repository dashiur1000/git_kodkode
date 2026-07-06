using System;
using System.Diagnostics;
namespace week13.day2;

abstract class Track
{
    public double Speed { get; init; }
    public abstract int Score();
}
class Aircraft : Track
{
    public override int Score() => (int)(Speed * 2);
}
class Vessel : Track
{
    public override int Score() => (int)(Speed * 1);
}
class ThreatScorer
{
    public int Score(Track t) => t.Score();
}
class Repository<T>
{
    private readonly List<T> _items = new();
    public void Add(T item) => _items.Add(item);
    public T Get(int i) => _items[i];
    public int Count => _items.Count;
    public override string ToString()
    {
        for (int i = 0; i < _items.Count(); i++)
        {
            Console.WriteLine("{_items[i]}");
        }
        return _items.Count.ToString();
    }

}

class Check
{
    public static void Main()
    {
        var repo = new Repository<Track>();
        repo.Add(new Aircraft { Speed = 400 });
        Track t = repo.Get(0);
        Console.WriteLine(repo);
    }
}