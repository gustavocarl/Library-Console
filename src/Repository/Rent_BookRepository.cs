using Library_Console.Models;
using System.Data.SqlClient;

namespace Library_Console.Repository
{
    public class Rent_BookRepository
    {
        private readonly SqlConnection _connection;

        public Rent_BookRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public Rent_Books GetAllRentedBooks()
        {
            return null!;
        }

        public Rent_Books SaveRentBook(string document, string title)
        {
            int readerId = 0, bookId = 0;

            const string queryReaderId = "SELECT ID, DOCUMENT " +
                " FROM READER " +
                "WHERE DOCUMENT = @DOCUMENT";

            const string queryBookId = "SELECT ID, TITLE " +
                "FROM BOOK " +
                "WHERE TITLE = @TITLE";

            const string createRentBook = "INSERT INTO RENT_BOOK ( " +
                "READER_ID, BOOK_ID, RENTED, RENTAL_DATE, " +
                "RETURN_DATE, RETURN_STATUS, CREATEDAT, UPDATEDAT " +
                ") VALUES ( " +
                "@READER_ID, @BOOK_ID, @RENTED, @RENTAL_DATE," +
                "@RETURN_DATE, @RETURN_STATUS, @CREATEDAT, @UPDATEDAT ) ";

            using var cmdQueryReaderId = new SqlCommand(queryReaderId, _connection);
            cmdQueryReaderId.Parameters.AddWithValue("@DOCUMENT", document);

            SqlDataReader rdReaderId = cmdQueryReaderId.ExecuteReader();

            if (rdReaderId.HasRows)
            {
                if (rdReaderId.Read())
                {
                    readerId = Convert.ToInt32(rdReaderId.GetInt32(0));
                }
            }

            rdReaderId.Close();

            using var cmdQueryBookId = new SqlCommand(queryBookId, _connection);
            cmdQueryBookId.Parameters.AddWithValue("@TITLE", title);

            SqlDataReader rdBookId = cmdQueryBookId.ExecuteReader();

            if (rdBookId.HasRows)
            {
                if (rdBookId.Read())
                {
                    bookId = Convert.ToInt32(rdBookId.GetInt32(0));
                }
            }

            rdBookId.Close();

            using var command = new SqlCommand(createRentBook, _connection);
            try
            {
                
                command.Parameters.AddWithValue("@READER_ID", readerId);
                command.Parameters.AddWithValue("@BOOK_ID", bookId);
                command.Parameters.AddWithValue("@RENTED", true);
                command.Parameters.AddWithValue("@RENTAL_DATE", DateTime.Now.Date);
                command.Parameters.AddWithValue("@RETURN_DATE", DateTime.Now.AddMonths(1));
                command.Parameters.AddWithValue("@RETURN_STATUS", "Alugado");
                command.Parameters.AddWithValue("@CREATEDAT", DateTime.Now);
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