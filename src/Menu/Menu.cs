using Library_Console.Data;
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
                    ReaderMenu(connection);
                    break;

                case "2":
                    ReaderMenu(connection);
                    break;

                case "3":
                    ReaderMenu(connection);
                    break;

                case "4":
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

            Console.WriteLine("=============================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Livro");
            Console.WriteLine("=============================");
            Console.WriteLine("1 - Cadastrar novo livro");
            Console.WriteLine("2 - Listar novo livro");
            Console.WriteLine("3 - Editar dados do livro");
            Console.WriteLine("4 - Remover dados do livro");
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
                    BookMenu(connection);
                    break;

                case "4":
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