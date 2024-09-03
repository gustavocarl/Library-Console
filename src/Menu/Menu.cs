using Library_Console.Data;
using Library_Console.Models;
using Library_Console.Repository;
using System.Data.SqlClient;

namespace Library_Console.Menu
{
    public class Menu
    {
        public static void MainMenu(SqlConnection connection)
        {
            Console.WriteLine("======================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu Principal");
            Console.WriteLine("======================");
            Console.WriteLine("1 - Menu do Leitor");
            Console.WriteLine("2 - Menu de Livro ");
            Console.WriteLine("3 - Aluguel de Livros");
            Console.WriteLine("======================");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("======================");

            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    break;

                case "1":
                    ReaderMenu(connection);
                    break;

                case "2":
                    BookMenu(connection);
                    break;

                case "3":
                    RentMenu(connection);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    MainMenu(connection);
                    break;
            }
        }

        public static void ReaderMenu(SqlConnection connection)
        {
            var readerRepository = new ReaderRepository(connection);

            string document;

            Console.WriteLine("=============================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Leitor");
            Console.WriteLine("=============================");
            Console.WriteLine("1 - Cadastrar novo leitor");
            Console.WriteLine("2 - Listar o leitor");
            Console.WriteLine("3 - Editar dados do leitor");
            Console.WriteLine("4 - Remover dados do leitor");
            Console.WriteLine("=============================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("=============================");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;

                case "1":
                    readerRepository.SaveReader();
                    ReaderMenu(connection);
                    break;

                case "2":
                    readerRepository.GetAllReaders();
                    Console.ReadLine();
                    ReaderMenu(connection);
                    break;

                case "3":
                    Console.WriteLine("CPF");
                    document = Console.ReadLine()!;
                    readerRepository.UpdateReader(document);
                    ReaderMenu(connection);
                    break;

                case "4":
                    Console.WriteLine("CPF");
                    document = Console.ReadLine()!;
                    readerRepository.RemoveReader(document);
                    ReaderMenu(connection);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    ReaderMenu(connection);
                    break;
            }
        }

        public static void BookMenu(SqlConnection connection)
        {
            var bookRepository = new BookRepository(connection);
            string title, author;
            int id;

            Console.WriteLine("=============================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Livro");
            Console.WriteLine("=============================");
            Console.WriteLine("1 - Cadastrar novo livro");
            Console.WriteLine("2 - Listar todos os livro");
            Console.WriteLine("3 - Listar livro por autor");
            Console.WriteLine("4 - Listar livro pelo título");
            Console.WriteLine("5 - Editar livro pelo id");
            Console.WriteLine("6 - Editar livro pelo título");
            Console.WriteLine("7 - Remover livro pelo id");
            Console.WriteLine("8 - Remover livro pelo título");
            Console.WriteLine("=============================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("=============================");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;

                case "1":
                    bookRepository.SaveBook();
                    BookMenu(connection);
                    break;

                case "2":
                    bookRepository.GetAllBooks();
                    Console.ReadLine();
                    BookMenu(connection);
                    break;

                case "3":
                    Console.WriteLine("Autor: ");
                    author = Console.ReadLine()!;
                    bookRepository.GetBookByAuthor(author);
                    BookMenu(connection);
                    break;

                case "4":
                    Console.WriteLine("Título");
                    title = Console.ReadLine()!;
                    bookRepository.GetBookByTitle(title);
                    BookMenu(connection);
                    break;

                case "5":
                    Console.WriteLine("id");
                    id = int.Parse(Console.ReadLine()!);
                    bookRepository.UpdateBookById(id);
                    BookMenu(connection);
                    break;

                case "6":
                    Console.WriteLine("Título");
                    title = Console.ReadLine()!;
                    bookRepository.UpdateBookByTitle(title);
                    BookMenu(connection);
                    break;

                case "7":
                    Console.WriteLine("id");
                    id = int.Parse(Console.ReadLine()!);
                    bookRepository.RemoveBookById(id);
                    BookMenu(connection);
                    break;

                case "8":
                    Console.WriteLine("Título");
                    title = Console.ReadLine()!;
                    bookRepository.RemoveBookByTitle(title);
                    BookMenu(connection);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    BookMenu(connection);
                    break;
            }
        }

        public static void RentMenu(SqlConnection connection)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Aluguel");
            Console.WriteLine("=============================");
            Console.WriteLine("1 - Cadastrar novo aluguel");
            Console.WriteLine("1 - Listar livros alugados");
            Console.WriteLine("2 - Editar dados do aluguel");
            Console.WriteLine("3 - Remover dados do aluguel");
            Console.WriteLine("=============================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("=============================");
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;

                case "1":
                    RentMenu(connection);
                    break;

                case "2":
                    RentMenu(connection);
                    break;

                case "3":
                    RentMenu(connection);
                    break;

                case "4":
                    RentMenu(connection);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    RentMenu(connection);
                    break;
            }
        }
    }
}