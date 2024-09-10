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
        public Rent_Books GetRentedBooksById()
        {
            return null!;
        }

        public Rent_Books GetRentedBooksByUserDocument(string document)
        {
            return null!;
        }

        public Rent_Books GetRentedBooksByBookName(string bookName)
        {
            return null!;
        }

        public Rent_Books SaveRentedBook()
        {
            return null!;
        }

        public Rent_Books UpdateRentedBookById()
        {
            return null!;
        }

        public Rent_Books UpdateRentedBookByUserDocument()
        {
            return null!;
        }

        public Rent_Books UpdateRentedBookByBookName()
        {
            return null!;
        }

        public Rent_Books RemoveRentedBookById()
        {
            return null!;
        }

        public Rent_Books RemoveRentedBookByUserDocument()
        {
            return null!;
        }

        public Rent_Books RemoveRentedBookByBookName()
        {
            return null!;
        }
    }
}