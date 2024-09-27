using CpfCnpjLibrary;
using Library_Console.Models;
using Library_Console.Repository;

namespace Library_Console.Services
{
    public class ReaderService(ReaderRepository readerRepository)
    {
        private readonly ReaderRepository _readerRepository = readerRepository;

        public Readers GetAllReaders()
        {
            Console.WriteLine("Lista de Leitores:");
            var reader = _readerRepository.GetAllReaders();

            Console.WriteLine("Lista de leitores buscada com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return reader!;
        }

        public Readers GetReaderByDocument()
        {
            var reader = new Readers();
            bool documentExist;

            Console.WriteLine("Buscar leitor pelo CPF: ");
            do
            {
                Console.WriteLine("Informe o CPF para buscar leitor: ");
                reader.Document = Console.ReadLine()!.ToUpper();
                documentExist = _readerRepository.GetReaderDocument(reader.Document);
            } while ((!Cpf.Validar(reader.Document)) && (string.IsNullOrWhiteSpace(reader.Document)) && (documentExist));

            _readerRepository.GetReadersByDocument(reader.Document);

            Console.WriteLine("Leitor consultado com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return null!;
        }

        public Readers SaveReader()
        {
            var reader = new Readers();
            bool documentExist;
            Console.WriteLine("Cadastrar novo leitor");

            do
            {
                Console.WriteLine("Informe o CPF para cadastro: ");
                reader.Document = Console.ReadLine()!.ToUpper();
                documentExist = _readerRepository.GetReaderDocument(reader.Document);
            } while ((!Cpf.Validar(reader.Document)) && (string.IsNullOrWhiteSpace(reader.Document)) && (documentExist));

            do
            {
                Console.WriteLine("Informe o Primeiro Nome para cadastro: ");
                reader.FirstName = Console.ReadLine()!.ToUpper();
            } while ((reader.FirstName.Length < 3 || reader.LastName.Length > 50) && string.IsNullOrWhiteSpace(reader.FirstName));

            do
            {
                Console.WriteLine("Informe o Último Nome para cadastro: ");
                reader.LastName = Console.ReadLine()!.ToUpper();
            } while ((reader.LastName.Length < 3 || reader.LastName.Length > 50) && string.IsNullOrWhiteSpace(reader.Document));

            _readerRepository.SaveReader(reader);

            Console.WriteLine("Cadastro do leitor realizado com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return null!;
        }

        public Readers UpdatedReader()
        {
            var reader = new Readers();
            bool documentExist;

            Console.WriteLine("Atualizar leitor existente");
            do
            {
                Console.WriteLine("Informe o CPF para atualização de cadastro: ");
                reader.Document = Console.ReadLine()!;
                documentExist = _readerRepository.GetReaderDocument(reader.Document);
            } while ((!Cpf.Validar(reader.Document)) && (string.IsNullOrWhiteSpace(reader.Document)) && (documentExist));

            do
            {
                Console.WriteLine("Informe o Primeiro Nome para atualização de cadastro: ");
                reader.FirstName = Console.ReadLine()!.ToUpper();
            } while ((reader.FirstName.Length < 3 || reader.LastName.Length > 50) && string.IsNullOrWhiteSpace(reader.FirstName));

            do
            {
                Console.WriteLine("Informe o Último Nome para atualização de cadastro: ");
                reader.LastName = Console.ReadLine()!.ToUpper();
            } while ((reader.LastName.Length < 3 || reader.LastName.Length > 50) && string.IsNullOrWhiteSpace(reader.Document));

            _readerRepository.UpdateReaderByDocument(reader);

            Console.WriteLine("Atualização do cadastro realizada com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return null!;
        }

        public Readers AlterReaderStatus()
        {
            var reader = new Readers();
            bool documentExist;
            char status;

            Console.WriteLine("Alterar Status do leitor");
            do
            {
                Console.WriteLine("Informe o CPF do leitor: ");
                reader.Document = Console.ReadLine()!;
                documentExist = _readerRepository.GetReaderDocument(reader.Document);
            } while ((!Cpf.Validar(reader.Document)) && (string.IsNullOrWhiteSpace(reader.Document)) && (documentExist));

            do
            {
                Console.WriteLine("Informe o status do leitor: \n" +
                    "A - Ativo\n" +
                    "I - Inativo");
                status = Convert.ToChar(Console.ReadLine()!.ToUpper());
            } while (!status.Equals('A') && !status.Equals('I'));

            if (status == 'A')
                reader.Status = true;
            else if (status == 'I')
                reader.Status = false;

            _readerRepository.AlterReaderStatusByDocument(reader);

            Console.WriteLine("Alteração do status do leitor realizado com sucesso...");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();

            return null!;
        }
    }
}