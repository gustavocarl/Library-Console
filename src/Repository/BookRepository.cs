using Library_Console.Models;
using System.Data.SqlClient;

namespace Library_Console.Repository
{
    public class BookRepository
    {
        private readonly SqlConnection _connection;

        public BookRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public Books GetAllBooks()
        {
            const string queryAllBooks = "SELECT ID, TITLE, AUTHOR, " +
                "PAGES, PUBLISHER, LANGUAGE, BOOK_CONDITION, " +
                "BOOK_STATUS, ISBN_10, ISBN_13, CREATEDAT, UPDATEDAT " +
                "FROM BOOK ";

            using var command = new SqlCommand(queryAllBooks, _connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id:          {reader.GetInt32(0)}");
                    Console.WriteLine($"Título:      {reader.GetString(1)}");
                    Console.WriteLine($"Autor:       {reader.GetString(2)}");
                    Console.WriteLine($"Páginas:     {reader.GetInt32(3)}");
                    Console.WriteLine($"Editora:     {reader.GetString(4)}");
                    Console.WriteLine($"Idioma:      {reader.GetString(5)}");
                    Console.WriteLine($"Condição:    {reader.GetString(6)}");
                    Console.WriteLine($"Status:      {reader.GetBoolean(7)}");
                    Console.WriteLine($"ISBN 10:     {reader.GetString(8)}");
                    Console.WriteLine($"ISBN 13:     {reader.GetString(9)}");
                    Console.WriteLine($"Criado:      {reader.GetDateTime(10)}");
                    Console.WriteLine($"Atualizado:  {reader.GetDateTime(11)}");
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

        public Books GetBookByTitle(Books book)
        {
            const string queryBookTitle = " SELECT ID, TITLE, AUTHOR, " +
                "PAGES, PUBLISHER, LANGUAGE, BOOK_CONDITION, " +
                "BOOK_STATUS, ISBN_10, ISBN_13, CREATEDAT, UPDATEDAT " +
                "FROM BOOK " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(queryBookTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id:          {reader.GetInt32(0)}");
                    Console.WriteLine($"Título:      {reader.GetString(1)}");
                    Console.WriteLine($"Autor:       {reader.GetString(2)}");
                    Console.WriteLine($"Páginas:     {reader.GetInt32(3)}");
                    Console.WriteLine($"Editora:     {reader.GetString(4)}");
                    Console.WriteLine($"Idioma:      {reader.GetString(5)}");
                    Console.WriteLine($"Condição:    {reader.GetString(6)}");
                    Console.WriteLine($"Status:      {reader.GetBoolean(7)}");
                    Console.WriteLine($"ISBN 10:     {reader.GetString(8)}");
                    Console.WriteLine($"ISBN 13:     {reader.GetString(9)}");
                    Console.WriteLine($"Criado:      {reader.GetDateTime(10)}");
                    Console.WriteLine($"Atualizado:  {reader.GetDateTime(11)}");
                    Console.WriteLine();
                }

                Console.ReadLine();
                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books GetBookByAuthor(Books book)
        {
            const string queryBookByAuthor = " SELECT ID, TITLE, AUTHOR, " +
                "PAGES, PUBLISHER, LANGUAGE, BOOK_CONDITION, " +
                "BOOK_STATUS, ISBN_10, ISBN_13, CREATEDAT, UPDATEDAT " +
                "FROM BOOK " +
                "WHERE AUTHOR = @AUTHOR";

            using var command = new SqlCommand(queryBookByAuthor, _connection);
            try
            {
                command.Parameters.AddWithValue("@AUTHOR", book.Author);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id:          {reader.GetInt32(0)}");
                    Console.WriteLine($"Título:      {reader.GetString(1)}");
                    Console.WriteLine($"Autor:       {reader.GetString(2)}");
                    Console.WriteLine($"Páginas:     {reader.GetInt32(3)}");
                    Console.WriteLine($"Editora:     {reader.GetString(4)}");
                    Console.WriteLine($"Idioma:      {reader.GetString(5)}");
                    Console.WriteLine($"Condição:    {reader.GetString(6)}");
                    Console.WriteLine($"Status:      {reader.GetBoolean(7)}");
                    Console.WriteLine($"ISBN 10:     {reader.GetString(8)}");
                    Console.WriteLine($"ISBN 13:     {reader.GetString(9)}");
                    Console.WriteLine($"Criado:      {reader.GetDateTime(10)}");
                    Console.WriteLine($"Atualizado:  {reader.GetDateTime(11)}");
                    Console.WriteLine();
                }

                Console.ReadLine();

                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public int GetBookId(string title)
        {
            int id = 0;

            const string queryBookId = "SELECT ID, TITLE " +
                "FROM BOOK " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(queryBookId, _connection);
            command.Parameters.AddWithValue("@TITLE", title);

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

        public Books SaveBook(Books book)
        {
            const string createBook = "INSERT INTO BOOK ( " +
                "TITLE, AUTHOR, PAGES, " +
                "PUBLISHER, LANGUAGE, BOOK_CONDITION, " +
                "BOOK_STATUS, ISBN_10, ISBN_13, " +
                "CREATEDAT, UPDATEDAT " +
                ") VALUES ( " +
                "@TITLE, @AUTHOR, @PAGES, " +
                "@PUBLISHER, @LANGUAGE, @BOOK_CONDITION, " +
                "@BOOK_STATUS, @ISBN_10, @ISBN_13, " +
                "@CREATEDAT, @UPDATEDAT " +
                ");";

            using var command = new SqlCommand(createBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
                command.Parameters.AddWithValue("@BOOK_CONDITION", book.Condition);
                command.Parameters.AddWithValue("@BOOK_STATUS", true);
                command.Parameters.AddWithValue("@ISBN_10", book.Isbn10);
                command.Parameters.AddWithValue("@ISBN_13", book.Isbn13);
                command.Parameters.AddWithValue("@CREATEDAT", book.CreatedAt);
                command.Parameters.AddWithValue("@UPDATEDAT", book.UpdatedAt);

                command.ExecuteScalar();
                return book!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return book;
            }
        }

        public Books UpdateBookByTitle(Books book, string title)
        {
            const string updateBookByTitle = "UPDATE BOOK SET " +
                "TITLE = @NEW_TITLE, " +
                "AUTHOR = @AUTHOR, " +
                "PAGES = @PAGES, " +
                "PUBLISHER = @PUBLISHER, " +
                "LANGUAGE = @LANGUAGE, " +
                "BOOK_CONDITION = @BOOK_CONDITION, " +
                "ISBN_10 = @ISBN_10, " +
                "ISBN_13 = @ISBN_13, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(updateBookByTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);
                command.Parameters.AddWithValue("@NEW_TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
                command.Parameters.AddWithValue("@BOOK_CONDITION", book.Condition);
                command.Parameters.AddWithValue("@ISBN_10", book.Isbn10);
                command.Parameters.AddWithValue("@ISBN_13", book.Isbn13);
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

        public Books ActivateBookByTitle(Books book)
        {
            const string removeBook = "UPDATE BOOK " +
                "SET BOOK_STATUS = 1 " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(removeBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books InactivateBookByTitle(Books book)
        {
            const string removeBook = "UPDATE BOOK " +
                "SET BOOK_STATUS = 0 " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(removeBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books AlterBookStatus(Books book)
        {
            const string updateBookStatus = "UPDATE BOOK " +
                "SET BOOK_STATUS = 1 " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(updateBookStatus, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.ExecuteNonQuery();
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books AlterBookCondition(Books book)
        {
            const string updateBookCondition = "UPDATE BOOK " +
                "SET BOOK_CONDITION = @CONDITION " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(updateBookCondition, _connection);
            try
            {
                command.Parameters.AddWithValue("@CONDITION", book.Condition);
                command.Parameters.AddWithValue("@TITLE", book.Title);

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