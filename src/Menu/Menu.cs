using Library_Console.Repository;
using Library_Console.Services;
using System.Data.SqlClient;

namespace Library_Console.Menu
{
    public class Menu
    {
        public static void MainMenu(SqlConnection connection)
        {
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu Principal");
            Console.WriteLine("=======================");
            Console.WriteLine("1 - Menu Administrativo");
            Console.WriteLine("2 - Menu de Aluguel");
            Console.WriteLine("=======================");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("=======================");

            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    break;

                case "1":
                    AdministrativeMenu(connection);
                    break;

                case "2":
                    RentMenu(connection);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    MainMenu(connection);
                    break;
            }
        }

        public static void AdministrativeMenu(SqlConnection connection)
        {
            var readerRepository = new ReaderRepository(connection);
            var bookRepository = new BookRepository(connection);
            var readerService = new ReaderService(readerRepository);
            var bookService = new BookService(bookRepository);

            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Administrativo");
            Console.WriteLine("=====================================");
            Console.WriteLine("1  - Cadastrar novo leitor");
            Console.WriteLine("2  - Cadastrar novo livro");
            Console.WriteLine("3  - Listar todos leitores");
            Console.WriteLine("4  - Listar todos livros");
            Console.WriteLine("5  - Listar leitor pelo CPF");
            Console.WriteLine("6  - Listar livro pelo título");
            Console.WriteLine("7  - Listar livros pelo autor");
            Console.WriteLine("7  - Listar livros pelo autor");
            Console.WriteLine("8  - Alterar dados do leitor pelo CPF");
            Console.WriteLine("9  - Alterar dados do livro");
            Console.WriteLine("10 - Alterar status do leitor");
            Console.WriteLine("11 - Altera status do livro");
            Console.WriteLine("=====================================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("=====================================");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;

                case "1":
                    readerService.SaveReader();
                    AdministrativeMenu(connection);
                    break;

                case "2":
                    bookService.SaveBook();
                    AdministrativeMenu(connection);
                    break;

                case "3":
                    readerService.GetAllReaders();
                    Console.ReadLine();
                    AdministrativeMenu(connection);
                    break;

                case "4":
                    bookService.GetAllBooks();
                    Console.ReadLine();
                    AdministrativeMenu(connection);
                    break;

                case "5":
                    readerService.GetReaderByDocument();
                    Console.ReadLine();
                    AdministrativeMenu(connection);
                    break;

                case "6":
                    bookService.GetBookByTitle();
                    AdministrativeMenu(connection);
                    break;

                case "7":
                    bookService.GetBookByAuthor();
                    AdministrativeMenu(connection);
                    break;

                case "8":
                    readerService.UpdatedReader();
                    AdministrativeMenu(connection);
                    break;

                case "9":
                    bookService.UpdatedBook();
                    AdministrativeMenu(connection);
                    break;

                case "10":
                    readerService.AlterReaderStatus();
                    AdministrativeMenu(connection);
                    break;

                case "11":
                    bookService.ActiveBook();
                    AdministrativeMenu(connection);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    AdministrativeMenu(connection);
                    break;
            }
        }

        public static void RentMenu(SqlConnection connection)
        {
            string cpf, title;
            DateTime date;

            var rentBookRepository = new Rent_BookRepository(connection);
            var bookRepository = new BookRepository(connection);
            var bookService = new BookService(bookRepository);

            Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Aluguel");
            Console.WriteLine("==========================================================");
            Console.WriteLine("1 - Cadastrar aluguel de livro");
            Console.WriteLine("2 - Devolução de livro alugado");
            Console.WriteLine("3 - Listar todos os livros alugados");
            Console.WriteLine("4 - Listar todos os livros alugados com situação em atraso");
            Console.WriteLine("5 - Listar livro alugado pelo título");
            Console.WriteLine("6 - Alterar condição do livro");
            Console.WriteLine("==========================================================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("==========================================================");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;

                case "1":
                    Console.WriteLine("CPF: ");
                    cpf = Console.ReadLine()!;
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    rentBookRepository.SaveRentBook(cpf, title);
                    RentMenu(connection);
                    break;

                case "2":
                    Console.WriteLine("CPF: ");
                    cpf = Console.ReadLine()!;
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    rentBookRepository.ReturnRentedBook(cpf, title);
                    RentMenu(connection);
                    break;

                case "3":
                    rentBookRepository.GetAllRentedBooks();
                    Console.ReadLine();
                    RentMenu(connection);
                    break;

                case "4":
                    Console.WriteLine("Data: ");
                    date = Convert.ToDateTime(Console.ReadLine()!).Date;
                    rentBookRepository.GetAllOverdueBooks(date);
                    Console.ReadLine();
                    RentMenu(connection);
                    break;

                case "5":
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    rentBookRepository.GetABookRentedByTitle(title);
                    Console.ReadLine();
                    RentMenu(connection);
                    break;

                case "6":
                    bookService.AlterBookCondition();
                    RentMenu(connection);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    RentMenu(connection);
                    break;
            }
        }
    }
}