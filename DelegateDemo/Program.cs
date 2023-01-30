// See https://aka.ms/new-console-template for more information


using Bookstore;

namespace BookTestClient;

/// <summary>
/// BookDB 类封装一个书店数据库，它维护一个书籍数据库。它公开 ProcessPaperbackBooks 方法，该方法在数据库中查找所有平装书，并对每本平装书调用一个委托。使用的 delegate 类型名为 ProcessBookDelegate。Test 类使用该类打印平装书的书名和平均价格。
///委托的使用促进了书店数据库和客户代码之间功能的良好分隔。客户代码不知道书籍的存储方式和书店代码查找平装书的方式。书店代码也不知道找到平装书后将对平装书执行什么处理。
/// </summary>
internal class Program
{
    public static void Main(string[] args)
    {
        BookDB bookDB = new BookDB();

        // Initialize the database with some books:
        AddBooks(bookDB);

        // Print all the titles of paperbacks:
        Console.WriteLine("Paperback Book Titles:");

        // Create a new delegate object associated with the static
        // method Test.PrintTitle:
        bookDB.ProcessPaperbackBooks(PrintTitle);

        // Get the average price of a paperback by using
        // a PriceTotaller object:
        PriceTotaller totaller = new PriceTotaller();

        // Create a new delegate object associated with the nonstatic
        // method AddBookToTotal on the object totaller:
        bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);

        Console.WriteLine("Average Paperback Book Price: ${0:#.##}",
            totaller.AveragePrice());
    }
    static void PrintTitle(Book b)
    {
        Console.WriteLine($"   {b.Title}");
    }
    static void AddBooks(BookDB bookDB)
    {
        bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
        bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
        bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
        bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
    }
}

