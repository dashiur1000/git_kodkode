using System;
namespace week13.day1.project1;
abstract class Image
{
    public int Id { get; set; }
    public double CloudCover { get; set; }
    public Image(int id, double cloudCover)
    {
        if (cloudCover < 0 || cloudCover > 100) throw new ArgumentException("CloudCover is incorrect.");
        Id = id;
        CloudCover = cloudCover;
    }
    public abstract int score();
}
class ImageFormat
{
    public string ToSsv(Image image)
    {
        string className = image.GetType().Name;
        return $"Image {image.Id}: {image.CloudCover}% cloud {className}";
    }
            
}
class ToFile
{
    public void SaveToFile(ImageFormat imageFormat, string path, Image image)
        => System.IO.File.WriteAllText(path, imageFormat.ToSsv(image));
}
class Sar : Image
{
    public Sar(int id, double cloudCover)
        : base(id, cloudCover)
    {}
    public override int score()
    {
        return 100 - (int)CloudCover;
    }
}
class Eo : Image
{
    public Eo(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 60 - (int)CloudCover;
    }
}
class Ir : Image
{
    public Ir(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 40 - (int)CloudCover;
    }
}
class MULTISPECTRAL : Image
{
    public MULTISPECTRAL(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 20 - (int)CloudCover;
    }
}
class Repository<T>
{
    private readonly List<T> _items = new();
    public void Add(T item) => _items.Add(item);
    public T Get(int i) => _items[i];
    public int Count => _items.Count;
}
class Test
{
    public static void Main()
    {
        var format = new ImageFormat();
        List<Image> list = new List<Image>()
        {
            new Sar(1, 100.0),
            new Eo(2, 90),
            new Ir(3, 99),
            new MULTISPECTRAL(4, 88)
        };
        var repo = new Repository<Image>();
        foreach (var item in list)
        {
            repo.Add(item);
        }
        int total = 0;
        foreach (var item in list)
        {
            Console.WriteLine(format.ToSsv(item));
            total += item.score();
        }
        Console.WriteLine($"total score: {total}");
    }
   
}
