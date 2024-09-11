using Library_Console.Repository;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

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

            string cpf, title, author;

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
            Console.WriteLine("8  - Alterar dados do leitor pelo CPF");
            Console.WriteLine("9  - Alterar dados do livro");
            Console.WriteLine("10 - Ativar leitor pelo CPF");
            Console.WriteLine("11 - Inativar leitor pelo CPF");
            Console.WriteLine("12 - Ativar livro pelo título");
            Console.WriteLine("13 - Inativar livro pelo título");
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
                    readerRepository.SaveReader();
                    AdministrativeMenu(connection);
                    break;

                case "2":
                    bookRepository.SaveBook();
                    AdministrativeMenu(connection);
                    break;

                case "3":
                    readerRepository.GetAllReaders();
                    Console.ReadLine();
                    AdministrativeMenu(connection);
                    break;

                case "4":
                    bookRepository.GetAllBooks();
                    Console.ReadLine();
                    AdministrativeMenu(connection);
                    break;

                case "5":
                    Console.WriteLine("CPF: ");
                    cpf = Console.ReadLine()!;
                    readerRepository.GetReadersByDocument(cpf);
                    AdministrativeMenu(connection);
                    break;

                case "6":
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    bookRepository.GetBookByTitle(title);
                    AdministrativeMenu(connection);
                    break;

                case "7":
                    Console.WriteLine("Autor: ");
                    author = Console.ReadLine()!;
                    bookRepository.GetBookByAuthor(author);
                    AdministrativeMenu(connection);
                    break;

                case "8":
                    Console.WriteLine("CPF: ");
                    cpf = Console.ReadLine()!;
                    readerRepository.UpdateReaderByDocument(cpf);
                    AdministrativeMenu(connection);
                    break;

                case "9":
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    bookRepository.UpdateBookByTitle(title);
                    AdministrativeMenu(connection);
                    break;

                case "10":
                    Console.WriteLine("CPF: ");
                    cpf = Console.ReadLine()!;
                    readerRepository.ActivateReaderByDocument(cpf);
                    AdministrativeMenu(connection);
                    break;

                case "11":
                    Console.WriteLine("CPF: ");
                    cpf = Console.ReadLine()!;
                    readerRepository.InactivateReaderByDocument(cpf);
                    AdministrativeMenu(connection);
                    break;

                case "12":
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    bookRepository.ActivateBookByTitle(title);
                    AdministrativeMenu(connection);
                    break;

                case "13":
                    Console.WriteLine("Título: ");
                    title = Console.ReadLine()!;
                    bookRepository.InactivateBookByTitle(title);
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

            var rentBookRepository = new Rent_BookRepository(connection);

            Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Aluguel");
            Console.WriteLine("==========================================================");
            Console.WriteLine("1 - Cadastrar aluguel de livro");
            Console.WriteLine("2 - Devolução de livro alugado");
            Console.WriteLine("3 - Alterar data do aluguel");
            Console.WriteLine("4 - Listar todos os livros alugados");
            Console.WriteLine("5 - Listar todos os livros alugados com situação em atraso");
            Console.WriteLine("6 - Listar livro alugados pelo título");
            Console.WriteLine("7 - Alterar status do livro");
            Console.WriteLine("8 - Alterar condição do livro");
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
                    RentMenu(connection);
                    break;

                case "3":
                    rentBookRepository.GetAllRentedBooks();
                    RentMenu(connection);
                    break;

                case "4":
                    RentMenu(connection);
                    break;

                case "5":
                    RentMenu(connection);
                    break;

                case "6":
                    RentMenu(connection);
                    break;

                case "7":
                    RentMenu(connection);
                    break;

                case "8":
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