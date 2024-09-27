using Library_Console.Data;
using Library_Console.Menu;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var dbSettings = new DbSettings("Server=localhost; Database=LIBRARY_CONSOLE; " +
        "USER ID=YourUserID; PASSWORD=YourPassword; ENCRYPT=TRUE; TRUSTSERVERCERTIFICATE=TRUE; CONNECTION TIMEOUT=30;");

        using var connection = new SqlConnection(dbSettings.ConnectionString);

        connection.Open();

        Menu.MainMenu(connection);
    }
}