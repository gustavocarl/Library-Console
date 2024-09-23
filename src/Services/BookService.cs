using Library_Console.Models;
using Library_Console.Repository;

namespace Library_Console.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Books GetAllBooks()
        {
            _bookRepository.GetAllBooks();
            return null!;
        }

        public Books GetBookByTitle()
        {
            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            _bookRepository.GetBookByTitle(book);

            return null!;
        }

        public Books GetBookByAuthor()
        {
            var book = new Books();

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine()!;

            _bookRepository.GetBookByAuthor(book);

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

            _bookRepository.SaveBook(book);

            return null!;
        }

        public Books UpdatedBook()
        {
            var book = new Books();

            Console.WriteLine("Título atuaL: ");
            var title = Console.ReadLine()!;

            Console.WriteLine("Novo Título: ");
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

            _bookRepository.UpdateBookByTitle(book, title);

            return null!;
        }

        public Books ActiveBook()
        {
            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            _bookRepository.ActivateBookByTitle(book);

            return null!;
        }

        public Books InactivateBook()
        {
            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            _bookRepository.InactivateBookByTitle(book);

            return null!;
        }

        public Books AlterBookStatus()
        {
            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            _bookRepository.AlterBookStatus(book);

            return null!;
        }

        public Books AlterBookCondition()
        {
            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            Console.WriteLine("Condição: ");
            book.BookCondition = Console.ReadLine()!;

            _bookRepository.AlterBookCondition(book);

            return null!;
        }
    }
}