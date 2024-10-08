using Library_Console.Models;
using Library_Console.Repository;

namespace Library_Console.Services
{
    public class RentBookService
    {
        private readonly RentBookRepository _rentBookRepository;

        public RentBookService(RentBookRepository rentBookRepository)
        {
            _rentBookRepository = rentBookRepository;
        }

        public RentBooks GetAllRentedBooks()
        {
            Console.WriteLine("Lista de livros alugados");

            _rentBookRepository.GetAllRentedBooks();

            Console.WriteLine("Lista de livros alugados consultada com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            Console.ReadLine();

            return null!;
        }

        public RentBooks GetAllOverdueBooks()
        {
            Console.WriteLine("Lista de livros com aluguel em atraso");

            var rentBook = new RentBooks();

            rentBook.ReturnDate = DateTime.Now;

            _rentBookRepository.GetAllOverdueBooks(rentBook);

            Console.WriteLine("Lista de livros com aluguel em atraso consultada com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return rentBook!;
        }

        public RentBooks GetABookRentedByTitle()
        {
            var book = new Books();

            Console.WriteLine("Título: ");
            book.Title = Console.ReadLine()!;

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine()!;

            _rentBookRepository.GetABookRentedByTitle(book);

            Console.WriteLine("Lista de livros alugados consultada com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return null!;
        }

        public RentBooks SaveRentBook()
        {
            var reader = new Readers();
            var book = new Books();
            var rentBook = new RentBooks();

            do
            {
                Console.WriteLine("Informe o CPF do leitor: ");
                reader.Document = Console.ReadLine()!;
            } while (!_rentBookRepository.GetReaderDocument(reader.Document));

            do
            {
                do
                {
                    Console.WriteLine("Informe o Título do livro: ");
                    book.Title = Console.ReadLine()!;
                } while (!_rentBookRepository.GetExistingBookTitle(book.Title));

                do
                {
                    Console.WriteLine("Informe o Autor do livro: ");
                    book.Author = Console.ReadLine()!;
                } while (!_rentBookRepository.GetExistingBookAuthor(book.Author));

                if (_rentBookRepository.GetRentedBook(book))
                    Console.WriteLine("Livro já está alugado");
            } while (_rentBookRepository.GetRentedBook(book));

            rentBook.Rented = true;

            rentBook.RentalDate = DateTime.Now;

            rentBook.ReturnDate = DateTime.Now.AddMonths(1);

            rentBook.ReturnStatus = "ALUGADO";

            rentBook.CreatedAt = DateTime.Now;

            rentBook.UpdatedAt = DateTime.Now;

            _rentBookRepository.SaveRentBook(reader, book, rentBook);

            return rentBook!;
        }

        public RentBooks ReturnRentedBook()
        {
            int index;
            var reader = new Readers();
            var book = new Books();
            var rentedBook = new RentBooks();

            Console.WriteLine("Informe o CPF do leitor: ");
            reader.Document = Console.ReadLine()!;

            var bookList = _rentBookRepository.GetAllRentedBooksByReader(reader);

            for (var i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {bookList[i].Title} - {bookList[i].Author}");
            }

            do
            {
                Console.WriteLine("Escolha o livro a ser devolvido");
                index = Convert.ToInt32(Console.ReadLine()!);
            } while (index < 1 || index > bookList.Count);

            rentedBook.Rented = false;

            rentedBook.ReturnStatus = "DEVOLVIDO";

            rentedBook.UpdatedAt = DateTime.Now;

            _rentBookRepository.ReturnRentedBook(reader, bookList[index - 1].Id, rentedBook);

            return rentedBook!;
        }
    }
}