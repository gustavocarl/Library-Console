using Library_Console.Models;
using System.Data.SqlClient;

namespace Library_Console.Repository
{
    public class RentBookRepository
    {
        private readonly SqlConnection _connection;

        public RentBookRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public RentBooks GetAllRentedBooks()
        {
            const string queryAllRentedBooks = "SELECT RB.ID, " +
                "R.DOCUMENT, R.FIRST_NAME, R.LAST_NAME, " +
                "B.TITLE, B.AUTHOR, B.PAGES, B.PUBLISHER, " +
                "B.BOOK_CONDITION, B.BOOK_STATUS, B.LANGUAGE, " +
                "RB.RENTED, RB.RENTAL_DATE, RB.RETURN_DATE, RB.RETURN_STATUS " +
                "FROM RENT_BOOK AS RB " +
                "INNER JOIN READER AS R ON (RB.READER_ID = R.ID) " +
                "INNER JOIN BOOK AS B ON  (RB.BOOK_ID = B.ID) " +
                "WHERE RENTED = 1";

            using var command = new SqlCommand(queryAllRentedBooks, _connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32(0)}");
                    Console.WriteLine($"CPF: {reader.GetString(1)}");
                    Console.WriteLine($"Primeiro nome: {reader.GetString(2)}");
                    Console.WriteLine($"Último nome: {reader.GetString(3)}");
                    Console.WriteLine($"Título: {reader.GetString(4)}");
                    Console.WriteLine($"Autor: {reader.GetString(5)}");
                    Console.WriteLine($"Páginas: {reader.GetInt32(6)}");
                    Console.WriteLine($"Editora: {reader.GetString(7)}");
                    Console.WriteLine($"Condição do livro {reader.GetString(8)}");
                    Console.WriteLine($"Status do livro: {reader.GetBoolean(9)}");
                    Console.WriteLine($"Idioma: {reader.GetString(10)}");
                    Console.WriteLine($"Alugado: {reader.GetBoolean(11)}");
                    Console.WriteLine($"Data do Aluguel: {reader.GetDateTime(12)}");
                    Console.WriteLine($"Data do Retorno: {reader.GetDateTime(13)}");
                    Console.WriteLine($"Status do Retorno: {reader.GetString(14)}");
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

        public RentBooks GetAllOverdueBooks(RentBooks rentBooks)
        {
            const string queryOverdueBooks = "SELECT RB.ID, " +
                "R.DOCUMENT, R.FIRST_NAME, R.LAST_NAME, " +
                "B.TITLE, B.AUTHOR, B.PAGES, B.PUBLISHER, " +
                "B.BOOK_CONDITION, B.BOOK_STATUS, B.LANGUAGE, " +
                "RB.RENTED, RB.RENTAL_DATE, RB.RETURN_DATE, RB.RETURN_STATUS " +
                "FROM RENT_BOOK AS RB " +
                "INNER JOIN READER AS R ON (RB.READER_ID = R.ID) " +
                "INNER JOIN BOOK AS B ON  (RB.BOOK_ID = B.ID) " +
                "WHERE RB.RETURN_DATE < @DATE";

            using var command = new SqlCommand(queryOverdueBooks, _connection);
            try
            {
                command.Parameters.AddWithValue("@DATE", rentBooks.ReturnDate);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32(0)}");
                    Console.WriteLine($"CPF: {reader.GetString(1)}");
                    Console.WriteLine($"Primeiro nome: {reader.GetString(2)}");
                    Console.WriteLine($"Último nome: {reader.GetString(3)}");
                    Console.WriteLine($"Título: {reader.GetString(4)}");
                    Console.WriteLine($"Autor: {reader.GetString(5)}");
                    Console.WriteLine($"Páginas: {reader.GetInt32(6)}");
                    Console.WriteLine($"Editora: {reader.GetString(7)}");
                    Console.WriteLine($"Condição do livro {reader.GetString(8)}");
                    Console.WriteLine($"Status do livro: {reader.GetBoolean(9)}");
                    Console.WriteLine($"Idioma: {reader.GetString(10)}");
                    Console.WriteLine($"Alugado: {reader.GetBoolean(11)}");
                    Console.WriteLine($"Data do Aluguel: {reader.GetDateTime(12)}");
                    Console.WriteLine($"Data do Retorno: {reader.GetDateTime(13)}");
                    Console.WriteLine($"Status do Retorno: {reader.GetString(14)}");
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

        public RentBooks GetABookRentedByTitle(Books book)
        {
            const string queryRentedBookByTitle = "SELECT RB.ID, " +
                "R.DOCUMENT, R.FIRST_NAME, R.LAST_NAME, " +
                "B.TITLE, B.AUTHOR, B.PAGES, B.PUBLISHER, B.BOOK_CONDITION, B.BOOK_STATUS, B.LANGUAGE, " +
                "RB.RENTED, RB.RENTAL_DATE, RB.RETURN_DATE, RB.RETURN_STATUS " +
                "FROM RENT_BOOK AS RB " +
                "INNER JOIN READER AS R ON (RB.READER_ID = R.ID) " +
                "INNER JOIN BOOK AS B ON  (RB.BOOK_ID = B.ID) " +
                "WHERE B.TITLE = @TITLE AND " +
                "B.AUTHOR = @AUTHOR";

            using var command = new SqlCommand(queryRentedBookByTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader.GetInt32(0)}");
                    Console.WriteLine($"CPF: {reader.GetString(1)}");
                    Console.WriteLine($"Primeiro nome: {reader.GetString(2)}");
                    Console.WriteLine($"Último nome: {reader.GetString(3)}");
                    Console.WriteLine($"Título: {reader.GetString(4)}");
                    Console.WriteLine($"Autor: {reader.GetString(5)}");
                    Console.WriteLine($"Páginas: {reader.GetInt32(6)}");
                    Console.WriteLine($"Editora: {reader.GetString(7)}");
                    Console.WriteLine($"Condição do livro {reader.GetString(8)}");
                    Console.WriteLine($"Status do livro: {reader.GetBoolean(9)}");
                    Console.WriteLine($"Idioma: {reader.GetString(10)}");
                    Console.WriteLine($"Alugado: {reader.GetBoolean(11)}");
                    Console.WriteLine($"Data do Aluguel: {reader.GetDateTime(12)}");
                    Console.WriteLine($"Data do Retorno: {reader.GetDateTime(13)}");
                    Console.WriteLine($"Status do Retorno: {reader.GetString(14)}");
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

        public bool GetRentedBook(Books book)
        {
            var bookIsRented = false;
            const string queryRentedBook = "SELECT RB.ID, " +
                "RB.BOOK_ID, RB.RENTED, B.ID, B.TITLE, " +
                "B.AUTHOR FROM RENT_BOOK AS RB " +
                "INNER JOIN BOOK AS B " +
                "ON (RB.BOOK_ID = B.ID) " +
                "WHERE B.TITLE = @TITLE AND B.AUTHOR = @AUTHOR AND RENTED = 1";

            using var command = new SqlCommand(queryRentedBook, _connection);
            command.Parameters.AddWithValue("@TITLE", book.Title);
            command.Parameters.AddWithValue("@AUTHOR", book.Author);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                bookIsRented = true;
            }

            reader.Close();

            return bookIsRented;
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

        public bool GetExistingBookTitle(string title)
        {
            bool bookTitleExist = false;

            const string queryBookTitle = "SELECT TITLE FROM BOOK " +
                "WHERE TITLE = @TITLE";

            var command = new SqlCommand(queryBookTitle, _connection);
            command.Parameters.AddWithValue("@TITLE", title);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                bookTitleExist = true;
            }

            reader.Close();

            return bookTitleExist;
        }

        public bool GetExistingBookAuthor(string author)
        {
            bool bookAuthorExist = false;

            const string queryBookTitle = "SELECT AUTHOR FROM BOOK " +
                "WHERE AUTHOR = @AUTHOR";

            var command = new SqlCommand(queryBookTitle, _connection);
            command.Parameters.AddWithValue("@AUTHOR", author);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                bookAuthorExist = true;
            }

            reader.Close();

            return bookAuthorExist;
        }

        public RentBooks SaveRentBook(Readers reader, Books book, RentBooks rentBook)
        {
            const string createRentBook = "INSERT INTO RENT_BOOK ( " +
                "READER_ID, BOOK_ID, RENTED, RENTAL_DATE, " +
                "RETURN_DATE, RETURN_STATUS, CREATEDAT, UPDATEDAT " +
                ") VALUES ( " +
                "@READER_ID, @BOOK_ID, @RENTED, @RENTAL_DATE," +
                "@RETURN_DATE, @RETURN_STATUS, @CREATEDAT, @UPDATEDAT ) ";

            var readerRepository = new ReaderRepository(_connection);
            int readerId = readerRepository.GetReaderId(reader);

            var bookRepository = new BookRepository(_connection);
            int bookId = bookRepository.GetBookId(book);

            using var command = new SqlCommand(createRentBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@READER_ID", readerId);
                command.Parameters.AddWithValue("@BOOK_ID", bookId);
                command.Parameters.AddWithValue("@RENTED", rentBook.Rented);
                command.Parameters.AddWithValue("@RENTAL_DATE", rentBook.RentalDate);
                command.Parameters.AddWithValue("@RETURN_DATE", rentBook.ReturnDate);
                command.Parameters.AddWithValue("@RETURN_STATUS", rentBook.ReturnStatus);
                command.Parameters.AddWithValue("@CREATEDAT", rentBook.CreatedAt);
                command.Parameters.AddWithValue("@UPDATEDAT", rentBook.UpdatedAt);

                command.ExecuteNonQuery();
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public RentBooks ReturnRentedBook(Readers reader, Books book, RentBooks rentBook)
        {
            var readerRepository = new ReaderRepository(_connection); ;
            int readerId = readerRepository.GetReaderId(reader);

            var bookRepository = new BookRepository(_connection);
            int bookId = bookRepository.GetBookId(book);

            const string updateRentedBook = "UPDATE RENT_BOOK " +
                "SET RENTED = @RENTED, " +
                "RETURN_STATUS = @RETURN_STATUS," +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE READER_ID = @READER_ID " +
                "AND BOOK_ID = @BOOK_ID ";

            using var command = new SqlCommand(updateRentedBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@RENTED", rentBook.Rented);
                command.Parameters.AddWithValue("@RETURN_STATUS", rentBook.ReturnStatus);
                command.Parameters.AddWithValue("@UPDATEDAT", rentBook.UpdatedAt);
                command.Parameters.AddWithValue("@READER_ID", readerId);
                command.Parameters.AddWithValue("@BOOK_ID", bookId);

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