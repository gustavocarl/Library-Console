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
            const string queryAllBooks = "SELECT " +
                    "ID, TITLE, AUTHOR, PAGES, " +
                    "PUBLISHER, ISBN_10, ISBN_13, " +
                    "LANGUAGE, CREATEDAT, UPDATEDAT " +
                    "FROM BOOK";

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
                    Console.WriteLine($"ISBN 10:     {reader.GetString(5)}");
                    Console.WriteLine($"ISBN 13:     {reader.GetString(6)}");
                    Console.WriteLine($"Idioma:      {reader.GetString(7)}");
                    Console.WriteLine($"Criado:      {reader.GetDateTime(8)}");
                    Console.WriteLine($"Atualizado:  {reader.GetDateTime(9)}");
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
            const string queryBookTitle = "SELECT " +
                "ID, TITLE, AUTHOR, PAGES, " +
                "PUBLISHER, ISBN_10, ISBN_13, " +
                "LANGUAGE, CREATEDAT, UPDATEDAT " +
                "FROM BOOK " +
                "WHERE TITLE = @TITLE";

            using var command = new SqlCommand(queryBookTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID:         {reader.GetInt32(0)}");
                    Console.WriteLine($"Título:     {reader.GetString(1)}");
                    Console.WriteLine($"Autor:      {reader.GetString(2)}");
                    Console.WriteLine($"Páginas:    {reader.GetInt32(3)}");
                    Console.WriteLine($"Editora:    {reader.GetString(4)}");
                    Console.WriteLine($"ISBN 10:    {reader.GetString(5)}");
                    Console.WriteLine($"ISBN 13:    {reader.GetString(6)}");
                    Console.WriteLine($"Idioma:     {reader.GetString(7)}");
                    Console.WriteLine($"Criado:     {reader.GetDateTime(8)}");
                    Console.WriteLine($"Atualizado: {reader.GetDateTime(9)}");
                    Console.WriteLine();
                }

                reader.Close();
                
                return null!;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books GetBookByAuthor(string author)
        {
            const string queryBookByAuthor = "SELECT " +
                "ID, TITLE, AUTHOR, PAGES, " +
                "PUBLISHER, ISBN_10, ISBN_13, " +
                "LANGUAGE, CREATEDAT, UPDATEDAT " +
                "FROM BOOK " +
                "WHERE AUTHOR = @AUTHOR";

            using var command = new SqlCommand(queryBookByAuthor, _connection);
            try
            {
                command.Parameters.AddWithValue("@AUTHOR", author);

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine($"ID: {reader.GetInt32(0)}");
                    Console.WriteLine($"Título: {reader.GetString(1)}");
                    Console.WriteLine($"Autor: {reader.GetString(2)}");
                    Console.WriteLine($"Páginas: {reader.GetInt32(3)}");
                    Console.WriteLine($"Editora: {reader.GetString(4)}");
                    Console.WriteLine($"ISBN 10: {reader.GetString(5)}");
                    Console.WriteLine($"ISBN 13: {reader.GetString(6)}");
                    Console.WriteLine($"Idioma: {reader.GetString(7)}");
                    Console.WriteLine($"Criado: {reader.GetDateTime(8)}");
                    Console.WriteLine($"Atualizado: {reader.GetDateTime(9)}");
                    Console.WriteLine($"");
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
            var book = new Books();

            Console.WriteLine("Titulo: ");
            book.Title = Console.ReadLine()!;

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine()!;

            Console.WriteLine("Páginas: ");
            book.Pages = Console.ReadLine()!;

            Console.WriteLine("Editora: ");
            book.Publisher = Console.ReadLine()!;

            Console.WriteLine("ISBN 10: ");
            book.Isbn10 = Console.ReadLine()!;

            Console.WriteLine("ISBN 13: ");
            book.Isbn13 = Console.ReadLine()!;

            Console.WriteLine("Idioma: ");
            book.Language = Console.ReadLine()!;

            book.CreatedAt = DateTime.Now;

            book.UpdatedAt = DateTime.Now;

            const string createBook = "INSERT INTO BOOK ( " +
                "TITLE, AUTHOR, PAGES, PUBLISHER, ISBN_10, " +
                "ISBN_13, LANGUAGE, CREATEDAT, UPDATEDAT" +
                ") VALUES ( " +
                "@TITLE, @AUTHOR, @PAGES, @PUBLISHER, @ISBN_10, " +
                "@ISBN_13, @LANGUAGE, @CREATEDAT, @UPDATEDAT " +
                ");";

            using var command = new SqlCommand(createBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@ISBN_10", book.Isbn10);
                command.Parameters.AddWithValue("@ISBN_13", book.Isbn13);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
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

        public Books UpdateBookById(int id)
        {
            const string updateBook = "UPDATE BOOK SET " +
                "TITLE = @TITLE, " +
                "AUTHOR = @AUTHOR, " +
                "PAGES = @PAGES, " +
                "PUBLISHER = @PUBLISHER, " +
                "ISBN_10 = @ISBN_10, " +
                "ISBN_13 = @ISBN_13, " +
                "LANGUAGE = @LANGUAGE, " +
                "UPDATEDAT = @UPDATEDAT " +
                "WHERE ID = @ID";

            var book = new Books();

            Console.WriteLine("Titulo: ");
            book.Title = Console.ReadLine()!;

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine()!;

            Console.WriteLine("Páginas: ");
            book.Pages = Console.ReadLine()!;

            Console.WriteLine("Editora: ");
            book.Publisher = Console.ReadLine()!;

            Console.WriteLine("ISBN 10: ");
            book.Isbn10 = Console.ReadLine()!;

            Console.WriteLine("ISBN 13: ");
            book.Isbn13 = Console.ReadLine()!;

            Console.WriteLine("Idioma: ");
            book.Language = Console.ReadLine()!;

            book.UpdatedAt = DateTime.Now;

            using var command = new SqlCommand(updateBook, _connection);
            try
            {
                command.Parameters.AddWithValue("@ID",  id);
                command.Parameters.AddWithValue("@TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@ISBN_10", book.Isbn10);
                command.Parameters.AddWithValue("@ISBN_13", book.Isbn13);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
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

        public Books UpdateBookByTitle(string title)
        {
            const string updateBookByTitle = "UPDATE BOOK SET " +
                "TITLE = @NEW_TITLE, " +
                "AUTHOR = @AUTHOR, " +
                "PAGES = @PAGES, " +
                "PUBLISHER = @PUBLISHER, " +
                "ISBN_10 = @ISBN_10, " +
                "ISBN_13 = @ISBN_13, " +
                "LANGUAGE = @LANGUAGE, " +
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

            Console.WriteLine("ISBN 10: ");
            book.Isbn10 = Console.ReadLine()!;

            Console.WriteLine("ISBN 13: ");
            book.Isbn13 = Console.ReadLine()!;

            Console.WriteLine("Idioma");
            book.Language = Console.ReadLine()!;

            using var command = new SqlCommand(updateBookByTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);
                command.Parameters.AddWithValue("@NEW_TITLE", book.Title);
                command.Parameters.AddWithValue("@AUTHOR", book.Author);
                command.Parameters.AddWithValue("@PAGES", book.Pages);
                command.Parameters.AddWithValue("@PUBLISHER", book.Publisher);
                command.Parameters.AddWithValue("@ISBN_10", book.Isbn10);
                command.Parameters.AddWithValue("@ISBN_13", book.Isbn13);
                command.Parameters.AddWithValue("@LANGUAGE", book.Language);
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



        public Books RemoveBookById(int id)
        {
            try
            {
                const string removeBook = "DELETE FROM BOOK " +
                    "WHERE ID = @ID";

                using var command = new SqlCommand(removeBook, _connection);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books RemoveBookByTitle(string title)
        {
            const string removeBook = "DELETE FROM BOOK " +
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
    }
}