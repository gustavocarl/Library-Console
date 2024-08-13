namespace Library_Console
{
    public class Menu
    {
        public static void MainMenu()
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
                    ReaderMenu();
                    break;

                case "2":
                    BookMenu();
                    break;

                case "3":
                    RentMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    MainMenu();
                    break;
            }
        }

        public static void ReaderMenu()
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
                    MainMenu();
                    break;

                case "1":
                    ReaderMenu();
                    break;

                case "2":
                    ReaderMenu();
                    break;

                case "3":
                    ReaderMenu();
                    break;

                case "4":
                    ReaderMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    ReaderMenu();
                    break;
            }
        }

        public static void BookMenu()
        {
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
                    MainMenu();
                    break;

                case "1":
                    BookMenu();
                    break;

                case "2":
                    BookMenu();
                    break;

                case "3":
                    BookMenu();
                    break;

                case "4":
                    BookMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    BookMenu();
                    break;
            }
        }

        public static void RentMenu()
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
                    MainMenu();
                    break;
                case "1":
                    RentMenu();
                    break;

                case "2":
                    RentMenu();
                    break;

                case "3":
                    RentMenu();
                    break;

                case "4":
                    RentMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    RentMenu();
                    break;
            }
        }
    }
}