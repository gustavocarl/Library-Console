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

        public Books GetBookByTitle(string title)
        {
            const string queryBookTitle = " SELECT ID, TITLE, AUTHOR, " +
                "PAGES PUBLISHER, LANGUAGE, BOOK_CONDITION, " +
                "BOOK_STATUS, ISBN_10, ISBN_13, CREATEDAT, UPDATEDAT " +
                "FROM BOOK " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(queryBookTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);

                SqlDataReader reader = command.ExecuteReader();

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

                reader.Close();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books GetBookByAuthor(string author)
        {
            const string queryBookByAuthor = " SELECT ID, TITLE, AUTHOR, " +
                "PAGES PUBLISHER, LANGUAGE, BOOK_CONDITION, " +
                "BOOK_STATUS, ISBN_10, ISBN_13, CREATEDAT, UPDATEDAT " +
                "FROM BOOK " +
                "WHERE AUTHOR = @AUTHOR";

            using var command = new SqlCommand(queryBookByAuthor, _connection);
            try
            {
                command.Parameters.AddWithValue("@AUTHOR", author);

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

        public Books SaveBook()
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

            var book = new Books();

            Console.WriteLine("Titulo: ");
            book.Title = Console.ReadLine()!;

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine()!;

            Console.WriteLine("Páginas: ");
            book.Pages = Console.ReadLine()!;

            Console.WriteLine("Editora: ");
            book.Publisher = Console.ReadLine()!;

            Console.WriteLine("Idioma: ");
            book.Language = Console.ReadLine()!;

            Console.WriteLine("Condição: ");
            book.BookCondition = Console.ReadLine()!;

            Console.WriteLine("ISBN 10: ");
            book.Isbn10 = Console.ReadLine()!;

            Console.WriteLine("ISBN 13: ");
            book.Isbn13 = Console.ReadLine()!;

            book.CreatedAt = DateTime.Now;

            book.UpdatedAt = DateTime.Now;

            using var command = new SqlCommand(createBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
                command.Parameters.AddWithValue("@BOOK_CONDITION", book.BookCondition);
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

        public Books UpdateBookByTitle(string title)
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

            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine()!;

            Console.WriteLine("Páginas: ");
            book.Pages = Console.ReadLine()!;

            Console.WriteLine("Editora: ");
            book.Publisher = Console.ReadLine()!;

            Console.WriteLine("Condição: ");
            book.BookCondition = Console.ReadLine()!;

            Console.WriteLine("Idioma");
            book.Language = Console.ReadLine()!;

            Console.WriteLine("ISBN 10: ");
            book.Isbn10 = Console.ReadLine()!;

            Console.WriteLine("ISBN 13: ");
            book.Isbn13 = Console.ReadLine()!;

            using var command = new SqlCommand(updateBookByTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);
                command.Parameters.AddWithValue("@NEW_TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
                command.Parameters.AddWithValue("@BOOK_CONDITION", book.BookCondition);
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

        public Books ActivateBookByTitle(string title)
        {
            const string removeBook = "UPDATE BOOK " +
                "SET BOOK_STATUS = 1 " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(removeBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);
                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books InactivateBookByTitle(string title)
        {
            const string removeBook = "UPDATE BOOK " +
                "SET BOOK_STATUS = 0 " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(removeBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);
                command.ExecuteNonQuery();

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books AlterBookStatus(string title)
        {
            const string updateBookStatus = "UPDATE BOOK " +
                "SET BOOK_STATUS = 1 " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(updateBookStatus, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);
                command.ExecuteNonQuery();
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books AlterBookCondition(string title)
        {
            const string updateBookCondition = "UPDATE BOOK " +
                "SET BOOK_CONDITION = @CONDITION " +
                "WHERE TITLE = @TITLE";

            Console.WriteLine("Condição do livro: ");
            string condition = Console.ReadLine()!;
            
            using var command = new SqlCommand(updateBookCondition, _connection);
            try
            {
                command.Parameters.AddWithValue("@CONDITION", condition);
                command.Parameters.AddWithValue("@TITLE", title);

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