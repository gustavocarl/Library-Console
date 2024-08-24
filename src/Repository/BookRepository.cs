using Library_Console.Data;
using Library_Console.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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
                    Console.WriteLine($"ISBN 10:     {reader.GetString(6)}");
                    Console.WriteLine($"Idioma:      {reader.GetString(7)}");
                    Console.WriteLine($"Criado:      {reader.GetDateTime(8)}");
                    Console.WriteLine($"Atualizado:  {reader.GetDateTime(9)}");
                }

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null!;
            }
        }

        public Books GetBookByName()
        {
            return null!;
        }

        public Books GetBookByAuthor()
        {
            return null!;
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

            book.Publisher = Console.ReadLine()!;
            book.Isbn10 = Console.ReadLine()!;
            book.Isbn13 = Console.ReadLine()!;
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
    }
}