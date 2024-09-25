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

        public int GetReaderId(string document)
        {
            int id = 0;
            const string queryReaderId = "SELECT ID, DOCUMENT " +
                " FROM READER " +
                "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(queryReaderId, _connection);
            command.Parameters.AddWithValue("@DOCUMENT", document);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetInt32(0));
                }
            }

            reader.Close();
            return id;
        }

        public bool GetReaderDocument(string document)
        {
            bool documentExist = false;

            const string queryReaderDocument = "SELECT DOCUMENT " +
              "FROM READER " +
              "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(queryReaderDocument, _connection);
            command.Parameters.AddWithValue("@DOCUMENT", document);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
                documentExist = true;

            reader.Close();
            return documentExist;
        }

        public Readers SaveReader(Readers reader)
        {
            const string createReader = "INSERT INTO READER ( " +
                "DOCUMENT, FIRST_NAME, LAST_NAME, " +
                "STATUS, CREATEDAT, UPDATEDAT ) VALUES ( " +
                "@DOCUMENT, @FIRST_NAME, @LAST_NAME, " +
                "@STATUS, @CREATEDAT, @UPDATEDAT )";

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

        public Readers UpdateReaderByDocument(Readers reader)
        {
            const string updateReaderByDocument = "UPDATE READER " +
                "SET FIRST_NAME = @FIRST_NAME, " +
                "LAST_NAME = @LAST_NAME, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE DOCUMENT = @DOCUMENT ";

            using var command = new SqlCommand(updateReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@FIRST_NAME", reader.FirstName);
                command.Parameters.AddWithValue("@LAST_NAME", reader.LastName);
                command.Parameters.AddWithValue("@UPDATEDAT", DateTime.Now);
                command.Parameters.AddWithValue("@DOCUMENT", reader.Document);

                command.ExecuteNonQuery();
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Readers AlterReaderStatusByDocument(Readers reader)
        {
            const string activateReaderByDocument = "UPDATE READER " +
                "SET STATUS = @STATUS," +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE DOCUMENT = @DOCUMENT";

            using var command = new SqlCommand(activateReaderByDocument, _connection);
            try
            {
                command.Parameters.AddWithValue("@STATUS", reader.Status);
                command.Parameters.AddWithValue("@DOCUMENT", reader.Document);
                command.Parameters.AddWithValue("@UPDATEDAT", DateTime.Now);

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