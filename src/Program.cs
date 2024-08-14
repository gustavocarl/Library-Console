using Library_Console.Data;
using Library_Console.Menu;
using Library_Console.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var dbSettings = new DbSettings("Server=localhost; Database=LIBRARY_CONSOLE; " +
        "USER ID=sa; PASSWORD=123456; ENCRYPT=TRUE; TRUSTSERVERCERTIFICATE=TRUE; CONNECTION TIMEOUT=30;");

        var readerRepository = new ReaderRepository(dbSettings);

        Menu.MainMenu();
    }
}