using Library_Console.Models;
using System.Data.SqlClient;

namespace Library_Console.Repository
{
    public class ReaderRepository
    {
        private readonly SqlConnection _connection;

        public ReaderRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public Readers GetAllReaders()
        {
            const string queryAllReaders = "SELECT ID, DOCUMENT, FIRST_NAME, " +
                "LAST_NAME, STATUS, CREATEDAT, UPDATEDAT " +
                "FROM READER";

            using var command = new SqlCommand(queryAllReaders, _connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Lista de Leitores: \n");
                while (reader.Read())
                {
                    Console.WriteLine($"Id:             {reader.GetInt32(0)}");
                    Console.WriteLine($"CPF:            {reader.GetString(1)}");
                    Console.WriteLine($"Primeiro Nome:  {reader.GetString(2)}");
                    Console.WriteLine($"Último Nome:    {reader.GetString(3)}");
                    Console.WriteLine($"Status:         {reader.GetBoolean(4)}");
                    Console.WriteLine($"Criado:         {reader.GetDateTime(5)}");
                    Console.WriteLine($"Atualizado:     {reader.GetDateTime(6)}");
                    Console.WriteLine();
                }

                Console.WriteLine("Pressione ENTER para continuar...");
                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers GetReaderById(int id)
        {
            const string queryReaderById = "SELECT ID, DOCUMENT, FIRST_NAME, " +
                "LAST_NAME, STATUS, CREATEDAT, UPDATEDAT " +
                "FROM READER " +
                "WHERE ID = @ID";

            using var command = new SqlCommand(queryReaderById, _connection);
            try
            {
                command.Parameters.AddWithValue("@ID", id);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                Console.WriteLine($"Id:             {reader.GetInt32(0)}");
                Console.WriteLine($"CPF:            {reader.GetString(1)}");
                Console.WriteLine($"Primeiro Nome:  {reader.GetString(2)}");
                Console.WriteLine($"Último Nome:    {reader.GetString(3)}");
                Console.WriteLine($"Status:         {reader.GetBoolean(4)}");
                Console.WriteLine($"Criado:         {reader.GetDateTime(5)}");
                Console.WriteLine($"Atualizado:     {reader.GetDateTime(6)}");
                Console.WriteLine();

                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers GetReadersByName(string name)
        {
            var queryReaderByName = "SELECT ID, DOCUMENT, FIRST_NAME, " +
                "LAST_NAME, STATUS, CREATEDAT, UPDATEDAT " +
                "FROM READER " +
                "WHERE FIRST_NAME LIKE (@FIRST_NAME)";

            using var command = new SqlCommand(queryReaderByName, _connection);
            try
            {
                command.Parameters.AddWithValue("@FIRST_NAME", $"%{name}%");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id:             {reader.GetInt32(0)}");
                    Console.WriteLine($"CPF:            {reader.GetString(1)}");
                    Console.WriteLine($"Primeiro Nome:  {reader.GetString(2)}");
                    Console.WriteLine($"Último Nome:    {reader.GetString(3)}");
                    Console.WriteLine($"Status:         {reader.GetBoolean(4)}");
                    Console.WriteLine($"Criado:         {reader.GetDateTime(5)}");
                    Console.WriteLine($"Atualizado:     {reader.GetDateTime(6)}");
                    Console.WriteLine();
                }

                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers GetReadersByDocument(string document)
        {
            const string gueryReaderByDocument = "SELECT ID, DOCUMENT,FIRST_NAME, " +
                "LAST_NAME, STATUS, CREATEDAT, UPDATEDAT " +
                "FROM READER " +
                "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(gueryReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", document);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                Console.WriteLine($"Id:             {reader.GetInt32(0)}");
                Console.WriteLine($"CPF:            {reader.GetString(1)}");
                Console.WriteLine($"Primeiro Nome:  {reader.GetString(2)}");
                Console.WriteLine($"Último Nome:    {reader.GetString(3)}");
                Console.WriteLine($"Status:         {reader.GetBoolean(4)}");
                Console.WriteLine($"Criado:         {reader.GetDateTime(5)}");
                Console.WriteLine($"Atualizado:     {reader.GetDateTime(6)}");
                Console.WriteLine();

                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers SaveReader()
        {
            var reader = new Readers();

            const string createReader = "INSERT INTO READER ( " +
                "DOCUMENT, FIRST_NAME, LAST_NAME, " +
                "STATUS, CREATEDAT, UPDATEDAT ) VALUES ( " +
                "@DOCUMENT, @FIRST_NAME, @LAST_NAME, " +
                "@STATUS, @CREATEDAT, @UPDATEDAT )";

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!;

            Console.WriteLine("Primeiro Nome: ");
            reader.FirstName = Console.ReadLine()!;

            Console.WriteLine("Último Nome: ");
            reader.LastName = Console.ReadLine()!;

            Console.WriteLine("Status: ");
            reader.Status = bool.Parse(Console.ReadLine()!);

            using var command = new SqlCommand(createReader, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", reader.Document);
                command.Parameters.AddWithValue("@FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
                command.Parameters.AddWithValue("@STATUS", reader.Status);
                command.Parameters.AddWithValue("@CREATEDAT", DateTime.Now);
                command.Parameters.AddWithValue("@UPDATEDAT", DateTime.Now);

                command.ExecuteScalar();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers UpdateReaderById(int id)
        {
            const string updateReaderById = "UPDATE READER " +
                "SET DOCUMENT = @DOCUMENT, " +
                "FIRST_NAME = @FIRST_NAME, " +
                "LAST_NAME = @LAST_NAME, " +
                "STATUS = @STATUS, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE ID = @ID";

            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!;

            Console.WriteLine("Primeiro nome: ");
            reader.FirstName = Console.ReadLine()!;

            Console.WriteLine("Último nome: ");
            reader.LastName = Console.ReadLine()!;

            Console.WriteLine("Status: ");
            reader.Status = bool.Parse(Console.ReadLine()!);

            using var command = new SqlCommand(updateReaderById, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", reader.Document);
                command.Parameters.AddWithValue("@FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
                command.Parameters.AddWithValue("@STATUS", reader.Status);
                command.Parameters.AddWithValue("@UPDATEDAT", DateTime.Now);
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers UpdateReaderByName(string name)
        {
            const string updateReaderByName = "UPDATE READER " +
                "SET DOCUMENT = @DOCUMENT, " +
                "FIRST_NAME = @NEW_FIRST_NAME, " +
                "LAST_NAME = @LAST_NAME, " +
                "STATUS = @STATUS, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE FIRST_NAME LIKE (@FIRST_NAME)";

            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!;

            Console.WriteLine("Primeiro nome: ");
            reader.FirstName = Console.ReadLine()!;

            Console.WriteLine("Último nome: ");
            reader.LastName = Console.ReadLine()!;

            Console.WriteLine("Status: ");
            reader.Status = bool.Parse(Console.ReadLine()!);

            using var command = new SqlCommand(updateReaderByName, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", reader.Document);
                command.Parameters.AddWithValue("@NEW_FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
                command.Parameters.AddWithValue("@STATUS", reader.Status);
                command.Parameters.AddWithValue("@UPDATEDAT", DateTime.Now);
                command.Parameters.AddWithValue("@FIRST_NAME", "%{name}%");
                
                command.ExecuteNonQuery();
                
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers UpdateReaderByDocument(string document)
        {
            const string updateReaderByDocument = "UPDATE READER " +
                "SET DOCUMENT = @NEW_DOCUMENT, " +
                "FIRST_NAME = @FIRST_NAME, " +
                "LAST_NAME = @LAST_NAME, " +
                "STATUS = @STATUS, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE DOCUMENT = @DOCUMENT ";

            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!;

            Console.WriteLine("Primeiro nome: ");
            reader.FirstName = Console.ReadLine()!;

            Console.WriteLine("Último nome: ");
            reader.LastName = Console.ReadLine()!;

            Console.WriteLine("Status: ");
            reader.Status = bool.Parse(Console.ReadLine()!);

            using var command = new SqlCommand(updateReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@NEW_DOCUMENT", reader.Document);
                command.Parameters.AddWithValue("@FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
                command.Parameters.AddWithValue("@STATUS", reader.Status);
                command.Parameters.AddWithValue("@UPDATEDAT", DateTime.Now);
                command.Parameters.AddWithValue("@DOCUMENT", document);

                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers RemoveReaderById(int id)
        {
            const string removeReaderById = "DELETE FROM READER " +
                "WHERE ID = @ID";

            using var command = new SqlCommand(removeReaderById, _connection);
            try
            {
                command.Parameters.AddWithValue("@ID", id);

                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers RemoveReaderByName(string name)
        {
            const string removeReaderByName = "DELETE FROM READER " +
                "WHERE FIRST_NAME LIKE (@FIRST_NAME)";

            using var command = new SqlCommand(removeReaderByName, _connection);
            try
            {
                command.Parameters.AddWithValue("@FIRST_NAME", $"%{name}%");

                command.ExecuteNonQuery();
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers RemoveReaderByDocument(string document)
        {
            const string removeReaderByDocument = "UPDATE READER SET " +
                "STATUS = 0" +
                "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(removeReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", document);

                command.ExecuteNonQuery();
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }
    }
}