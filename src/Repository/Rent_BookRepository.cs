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

                Console.WriteLine("Lista de livros alugados");
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

        public Rent_Books GetAllOverdueBooks(DateTime date)
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
                command.Parameters.AddWithValue("@DATE", date);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Lista de livros alugados");
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

        public Rent_Books GetABookRentedByTitle(string title)
        {
            const string queryRentedBookByTitle = "SELECT RB.ID, " +
                "R.DOCUMENT, R.FIRST_NAME, R.LAST_NAME, " +
                "B.TITLE, B.AUTHOR, B.PAGES, B.PUBLISHER, B.BOOK_CONDITION, B.BOOK_STATUS, B.LANGUAGE, " +
                "RB.RENTED, RB.RENTAL_DATE, RB.RETURN_DATE, RB.RETURN_STATUS " +
                "FROM RENT_BOOK AS RB " +
                "INNER JOIN READER AS R ON (RB.READER_ID = R.ID) " +
                "INNER JOIN BOOK AS B ON  (RB.BOOK_ID = B.ID) " +
                "WHERE B.TITLE = @TITLE";

            using var command = new SqlCommand(queryRentedBookByTitle, _connection);
            try
            {
                command.Parameters.AddWithValue("@TITLE", title);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Lista de alugueis de {title}");
                
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

        public Rent_Books ReturnRentedBook(string document, string title)
        {
            int readerId = 0, bookId = 0;

            const string queryReaderId = "SELECT ID, DOCUMENT " +
                "FROM READER " +
                "WHERE DOCUMENT = @DOCUMENT";

            using var cmdReaderId = new SqlCommand(queryReaderId, _connection);
            cmdReaderId.Parameters.AddWithValue("@DOCUMENT", document);

            SqlDataReader rdreaderId = cmdReaderId.ExecuteReader();

            if (rdreaderId.HasRows)
            {
                if (rdreaderId.Read())
                {
                    readerId = Convert.ToInt32(rdreaderId.GetInt32(0));
                }
            }

            rdreaderId.Close();

            const string queryBookId = "SELECT ID, TITLE " +
                "FROM BOOK " +
                "WHERE TITLE = @TITLE";

            using var cmdBookId = new SqlCommand(queryBookId, _connection);
            cmdBookId.Parameters.AddWithValue("@TITLE", title);

            SqlDataReader rdBookId = cmdBookId.ExecuteReader();

            if (rdBookId.HasRows)
            {
                if (rdBookId.Read())
                {
                    bookId = Convert.ToInt32(rdBookId.GetInt32(0));
                }
            }

            rdBookId.Close();

            const string updateRentedBook = "UPDATE RENT_BOOK " +
                "SET RENTED = 0, " +
                "RETURN_STATUS = 'Devolvido' " +
                "WHERE READER_ID = @READER_ID " +
                "AND BOOK_ID = @BOOK_ID ";

            using var command = new SqlCommand(updateRentedBook, _connection);
            try
            {
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