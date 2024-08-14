using Library_Console.Data;
using System.Data;
using System.Data.SqlClient;

namespace Library_Console.Repository
{
    internal class ReaderRepository
    {
        private readonly DbSettings _dbSettings;

        public ReaderRepository(DbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public void GetAllReaders()
        {
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"SELECT ID, NAME FROM READER";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32(0)}\n" +
                            $"Nome: {reader.GetString(1)}");

                        Console.WriteLine();
                    }
                }
                connection.Close();
            }
        }

        public void GetReaderById(int id)
        {
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"SELECT ID, NAME FROM READER WHERE ID = {id}";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32(0)}\n" +
                            $"Nome: {reader.GetString(1)}");
                    }
                }
            }
        }
    }
}