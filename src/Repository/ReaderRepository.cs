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

            using var command = new SqlCommand(createReader, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", reader.Document);
                command.Parameters.AddWithValue("@FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
                command.Parameters.AddWithValue("@STATUS", true);
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

        public Readers UpdateReaderByDocument(string document)
        {
            const string updateReaderByDocument = "UPDATE READER " +
                "SET FIRST_NAME = @FIRST_NAME, " +
                "LAST_NAME = @LAST_NAME, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE DOCUMENT = @DOCUMENT ";

            var reader = new Readers();

            Console.WriteLine("Primeiro nome: ");
            reader.FirstName = Console.ReadLine()!; 

            Console.WriteLine("Último nome: ");
            reader.LastName = Console.ReadLine()!;

            using var command = new SqlCommand(updateReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
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

        public Readers ActivateReaderByDocument(string document)
        {
            const string activateReaderByDocument = "UPDATE READER " +
                "SET STATUS = 1 " +
                "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(activateReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@DOCUMENT", document);

                command.ExecuteNonQuery();
                return null!;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers InactivateReaderByDocument(string document)
        {

            const string inactivateReaderByDocument = "UPDATE READER " +
                "SET STATUS = 0 " +
                "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(inactivateReaderByDocument, _connection);
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