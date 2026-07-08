using System;
namespace day3.p2;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
}
public interface ILendingStore
{
    void RecordLending(Book book, string borrowerName);
    int GetTotalLendings();
}
public class MemoryLendingStore : ILendingStore
{
    private List<string> _records = new List<string>();
    public void RecordLending(Book book, string borrowerName)
    {
        string record = $"ISBN: {book.ISBN} borrowed by {borrowerName}";
        _records.Add(record);
    }
    public int GetTotalLendings()
    {
        return _records.Count;
    }
}
public class LogStore : ILendingStore
{
    private readonly List<string> _logRecords = new List<string>();
    public void RecordLending(Book book, string borrowerName)
    {
        string record = $"ISBN: {book.ISBN} borrowed by {borrowerName}";
        _logRecords.Add(record);
    }
    public int GetTotalLendings()
    {
        return _logRecords.Count;
    }

}
public class FileLendingStore : ILendingStore
{
    private string _filePath;
    public FileLendingStore(string filePath)
    {
        _filePath = filePath;
    }
    public void RecordLending(Book book, string borrowerName)
    {
        string record = $"{DateTime.Now:yyyy-MM-dd HH:mm} - ISBN: {book.ISBN} borrowed by {borrowerName}";
        File.AppendAllText(_filePath, record + Environment.NewLine);
    }
    public int GetTotalLendings()
    {
        if(!File.Exists(_filePath))
            return 0;
        return File.ReadAllLines(_filePath).Length;
    }
}
public class LibraryService
{
    private readonly ILendingStore _store;
    public LibraryService(ILendingStore store)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
    }
    public void LendBook(Book book, string borrowerName)
    {
        Console.WriteLine($"Lending '{book.Title}' to {borrowerName}");
        _store.RecordLending(book, borrowerName);
    }
    public int GetTotalLendings()
    {
        return _store.GetTotalLendings();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book
        {
            Title = "1984",
            Author = "George Orwell",
            ISBN = "978-0451524935"
        };
        Book book2 = new Book
        {
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            ISBN = "978-0547928227"
        };
        Book book3 = new Book
        {
            Title = "Clean Code",
            Author = "Robert Martin",
            ISBN = "978-0132350884"
        };
        ILendingStore memoryStore = new MemoryLendingStore();
        LibraryService library1 = new LibraryService(memoryStore);
        library1.LendBook(book1, "Alice");
        library1.LendBook(book2, "Bob");
        library1.LendBook(book3, "Charlie");
        Console.WriteLine($"Total lendings: {library1.GetTotalLendings()}");


        ILendingStore fileStore = new FileLendingStore("lendings.txt");
        LibraryService library2 = new LibraryService(fileStore);
        library2.LendBook(book3, "Dudi");
        library2.LendBook(book1, "Miri");
        Console.WriteLine($"Total lendings: {library2.GetTotalLendings()}");
        Console.WriteLine("Check the 'lendings.txt' file to see the records!");

        ILendingStore logStore = new LogStore
    }
}