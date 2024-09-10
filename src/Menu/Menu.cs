using Library_Console.Repository;
using System.Data.SqlClient;

namespace Library_Console.Menu
{
    public class Menu
    {
        // Menu Administrativo => Leitor, Livro
        // Menu Aluguéis => Pesquisar o leitor e livro

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
            
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Administrativo");
            Console.WriteLine("===============================");
            Console.WriteLine("1  - Cadastrar novo leitor");
            Console.WriteLine("2  - Cadastrar novo livro");
            Console.WriteLine("3  - Listar todos leitores");
            Console.WriteLine("4  - Listar todos livros");
            Console.WriteLine("5  - Listar leitor pelo CPF");
            Console.WriteLine("6  - Listar livro pelo título");
            Console.WriteLine("7  - Listar livros pelo autor");
            Console.WriteLine("8  - Alterar dados do leitor");
            Console.WriteLine("9  - Alterar dados do livro");
            Console.WriteLine("10 - Inativar leitor pelo CPF");
            Console.WriteLine("11 - Inativar livro pelo título");
            Console.WriteLine("===============================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("===============================");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;
            }
        }

        public static void RentMenu(SqlConnection connection)
        {
            var rentBookRepository = new Rent_BookRepository(connection);

            Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("Sistema de Biblioteca");
            Console.WriteLine("Menu de Aluguel");
            Console.WriteLine("==========================================================");
            Console.WriteLine("1 - Cadastrar novo aluguel");
            Console.WriteLine("2 - Alterar data do aluguel");
            Console.WriteLine("3 - Listar todos os livros alugados");
            Console.WriteLine("4 - Listar todos os livros alugados com situação em atraso");
            Console.WriteLine("5 - Listar livro alugados pelo título");
            Console.WriteLine("6 - Alterar status do livro");
            Console.WriteLine("7 - Alterar condição do livro");
            Console.WriteLine("==========================================================");
            Console.WriteLine("0 - Retornar ao menu anterior");
            Console.WriteLine("==========================================================");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "0":
                    MainMenu(connection);
                    break;
            }
        }
    }
}