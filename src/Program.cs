using Library_Console.Data;
using Library_Console.Menu;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var dbSettings = new DbSettings("Server=localhost; Database=LIBRARY_CONSOLE; " +
        "USER ID=sa; PASSWORD=123456; ENCRYPT=TRUE; TRUSTSERVERCERTIFICATE=TRUE; CONNECTION TIMEOUT=30;");

        var connection = new SqlConnection(dbSettings.ConnectionString);

        connection.Open();

        Menu.MainMenu(connection);

    }
}