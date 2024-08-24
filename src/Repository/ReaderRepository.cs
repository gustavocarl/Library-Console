using Library_Console.Data;
using Library_Console.Models;
using System.Data.SqlClient;

namespace Library_Console.Repository
{
    public class ReaderRepository
    {
        private readonly DbSettings _dbSettings;

        public ReaderRepository(DbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public Readers GetAllReaders()
        {
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                connection.Open();

                Console.WriteLine("Conectado");
                return null;
                Console.ReadLine();
            }
        }
    }
}