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

            Console.WriteLine("Buscar livro pelo título e autor: ");
            do
            {
                Console.WriteLine("Informe o título do livro: ");
                book.Title = Console.ReadLine()!.ToUpper();
            } while (!_bookRepository.GetExistingBookTitle(book.Title));

            do
            {
                Console.WriteLine("Informe o autor do livro: ");
                book.Author = Console.ReadLine()!.ToUpper();
            } while (!_bookRepository.GetExistingBookAuthor(book.Author));

            _bookRepository.GetBookByTitleAndAuthor(book);

            Console.WriteLine("Livro consultado com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return book!;
        }

        public Books GetBookByAuthor()
        {
            var book = new Books();

            do
            {
                Console.WriteLine("Informe o nome do autor: ");
                book.Author = Console.ReadLine()!.ToUpper();
            } while (!_bookRepository.GetExistingBookAuthor(book.Author));

            _bookRepository.GetBookByAuthor(book);

            return book!;
        }

        public Books SaveBook()
        {
            var book = new Books();

            do
            {
                Console.WriteLine("Informe o titulo do livro: ");
                book.Title = Console.ReadLine()!.ToUpper();
            } while ((book.Title.Length < 3 || book.Title.Length > 100));

            do
            {
                Console.WriteLine("Informe o autor do livro: ");
                book.Author = Console.ReadLine()!.ToUpper();
            } while (book.Author.Length < 3 || book.Author.Length > 50);

            do
            {
                Console.WriteLine("Informe a quantidade de páginas do livro: ");
                book.Pages = Convert.ToInt32(Console.ReadLine()!);
            } while (book.Pages <= 0);

            do
            {
                Console.WriteLine("Informe a editora do livro: ");
                book.Publisher = Console.ReadLine()!.ToUpper();
            } while (book.Publisher.Length < 3 || book.Publisher.Length > 100);

            do
            {
                Console.WriteLine("Informe o idioma do livro: ");
                book.Language = Console.ReadLine()!.ToUpper();
            } while (book.Language.Length < 3 || book.Language.Length > 500);

            do
            {
                Console.WriteLine("Informe a condição do livro: ");
                book.Condition = Console.ReadLine()!.ToUpper();
            } while (book.Condition.Length < 3 || book.Condition.Length > 100);

            do
            {
                Console.WriteLine("Informe o ISBN 10 do livro: ");
                book.Isbn10 = Console.ReadLine()!.ToUpper();
            } while (book.Isbn10.Length != 10 && string.IsNullOrWhiteSpace(book.Isbn10));

            do
            {
                Console.WriteLine("Informe o ISBN 13 do livro: ");
                book.Isbn13 = Console.ReadLine()!.ToUpper();
            } while (book.Isbn13.Length != 13 && string.IsNullOrWhiteSpace(book.Isbn10));

            book.CreatedAt = DateTime.Now;

            book.UpdatedAt = DateTime.Now;

            _bookRepository.SaveBook(book);

            return book!;
        }

        public Books UpdatedBook()
        {
            var book = new Books();

            do
            {
                Console.WriteLine("Informe o titulo do livro: ");
                book.Title = Console.ReadLine()!.ToUpper();
            } while ((book.Title.Length < 3 || book.Title.Length > 100) && _bookRepository.GetExistingBookTitle(book.Title));

            do
            {
                Console.WriteLine("Informe o autor do livro: ");
                book.Author = Console.ReadLine()!.ToUpper();
            } while ((book.Author.Length < 3 || book.Author.Length > 50) && _bookRepository.GetExistingBookAuthor(book.Author));

            do
            {
                Console.WriteLine("Informe a quantidade de páginas do livro: ");
                book.Pages = Convert.ToInt32(Console.ReadLine()!);
            } while (book.Pages <= 0);

            do
            {
                Console.WriteLine("Informe a editora do livro: ");
                book.Publisher = Console.ReadLine()!.ToUpper();
            } while (book.Publisher.Length < 3 || book.Publisher.Length > 100);

            do
            {
                Console.WriteLine("Informe a condição do livro: ");
                book.Condition = Console.ReadLine()!.ToUpper();
            } while (book.Condition.Length < 3 || book.Condition.Length > 100);

            book.UpdatedAt = DateTime.Now;

            _bookRepository.UpdateBookByTitle(book);

            return book!;
        }

        public Books ActiveBook()
        {
            var book = new Books();
            char status;

            do
            {
                Console.WriteLine("Informe o titulo do livro: ");
                book.Title = Console.ReadLine()!.ToUpper();
            } while ((book.Title.Length < 3 || book.Title.Length > 100) && _bookRepository.GetExistingBookTitle(book.Title));

            do
            {
                Console.WriteLine("Informe o autor do livro: ");
                book.Author = Console.ReadLine()!.ToUpper();
            } while ((book.Author.Length < 3 || book.Author.Length > 50) && _bookRepository.GetExistingBookAuthor(book.Author));

            do
            {
                Console.WriteLine("Informe o status do livro:\n" +
                    "A - Ativo\n" +
                    "I - Inativo");
                status = Convert.ToChar(Console.ReadLine()!.ToUpper());
            } while (!status.Equals('A') && !status.Equals('I'));

            if (status == 'A')
                book.Status = true;
            else if (status == 'I')
                book.Status = false;

            book.UpdatedAt = DateTime.Now;

            _bookRepository.AlterBookStatus(book);

            return book!;
        }

        public Books AlterBookCondition()
        {
            var book = new Books();

            do
            {
                Console.WriteLine("Informe o titulo do livro: ");
                book.Title = Console.ReadLine()!.ToUpper();
            } while ((book.Title.Length < 3 || book.Title.Length > 100) && _bookRepository.GetExistingBookTitle(book.Title));

            do
            {
                Console.WriteLine("Informe o autor do livro: ");
                book.Author = Console.ReadLine()!.ToUpper();
            } while ((book.Author.Length < 3 || book.Author.Length > 50) && _bookRepository.GetExistingBookAuthor(book.Author));

            do
            {
                Console.WriteLine("Informe a condição do livro: ");
                book.Condition = Console.ReadLine()!.ToUpper();
            } while (book.Condition.Length < 3 || book.Condition.Length > 100);

            book.UpdatedAt = DateTime.Now;

            _bookRepository.AlterBookCondition(book);

            return book!;
        }
    }
}