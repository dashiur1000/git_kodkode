namespace week13.day2.project1;

abstract class SatelliteImage
{
    public int Id { get; set; }
    public double CloudCover { get; set; }
    public SatelliteImage(int id, double cloudCover)
    {
        if (cloudCover < 0 || cloudCover > 100) throw new ArgumentException("CloudCover is incorrect.");
        Id = id;
        CloudCover = cloudCover;
    }
    public abstract int score();
}
class ImageFormat
{
    public string ToSsv(SatelliteImage image)
    {
        string className = image.GetType().Name;
        return $"Image {image.Id}: {image.CloudCover}% cloud {className}";
    }

}
class ToFile
{
    public void SaveToFile(ImageFormat imageFormat, string path, SatelliteImage image)
        => System.IO.File.WriteAllText(path, imageFormat.ToSsv(image));
}
class Sar : SatelliteImage, IScore
{
    public Sar(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 100 - (int)CloudCover;
    }
}
class Eo : SatelliteImage
{
    public Eo(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 60 - (int)CloudCover;
    }
}
class Ir : SatelliteImage
{
    public Ir(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 40 - (int)CloudCover;
    }
}
class MULTISPECTRAL : SatelliteImage
{
    public MULTISPECTRAL(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        return 20 - (int)CloudCover;
    }
}
class QuickLookImage : SatelliteImage
{
    public QuickLookImage(int id, double cloudCover)
        : base(id, cloudCover)
    { }
    public override int score()
    {
        throw new InvalidOperationException("quick-look images are not scored");
    }
}

interface IScore
{
    int score();
}
interface IRetask
{
    void Retask();
}
interface ICalibrateThermal
{
    void CalibrateThermal();
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
        List<SatelliteImage> list = new List<SatelliteImage>()
        {
            new Sar(1, 100.0),
            new Eo(2, 100),
            new Ir(3, 99),
            new MULTISPECTRAL(4, 88),
            new QuickLookImage(5, 80)
        };

        var repo = new Repository<SatelliteImage>();
        foreach (var item in list)
        {
            repo.Add(item);
        }
        int total = 0;
        foreach (var item in list)
        {
            try
            {
                {
                    Console.WriteLine(format.ToSsv(item));
                    total += item.score();
                }
            }
            catch
            {
                Console.WriteLine(format.ToSsv(item));
            }
        }
        {
            Console.WriteLine($"total score: {total}");
        }
    }

}

