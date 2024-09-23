using Library_Console.Models;
using Library_Console.Repository;

namespace Library_Console.Services
{
    public class ReaderService
    {
        private readonly ReaderRepository _readerRepository;

        public ReaderService(ReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        // CREATE, READER, UPDATED, DELETE

        public Readers GetAllReaders()
        {
            _readerRepository.GetAllReaders();
            return null!;
        }

        public Readers GetReaderByDocument()
        {
            Console.WriteLine("Infome o CPF");
            string document = Console.ReadLine()!;

            _readerRepository.GetReadersByDocument(document);
            return null!;
        }

        public Readers SaveReader()
        {
            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!.ToUpper();

            Console.WriteLine("Primeiro Nome: ");
            reader.FirstName = Console.ReadLine()!.ToUpper();

            Console.WriteLine("Último Nome: ");
            reader.LastName = Console.ReadLine()!.ToUpper();

            _readerRepository.SaveReader(reader);

            return null!;
        }

        public Readers UpdatedReader()
        {
            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!.ToUpper();

            Console.WriteLine("Primeiro nome: ");
            reader.FirstName = Console.ReadLine()!.ToUpper();

            Console.WriteLine("Último nome: ");
            reader.LastName = Console.ReadLine()!.ToUpper();

            _readerRepository.UpdateReaderByDocument(reader);

            return null!;
        }

        public Readers InactiveReader()
        {
            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!;

            _readerRepository.InactivateReaderByDocument(reader);
            return null!;
        }

        public Readers ActiveReader()
        {
            var reader = new Readers();

            Console.WriteLine("CPF: ");
            reader.Document = Console.ReadLine()!;

            _readerRepository.ActivateReaderByDocument(reader);
            return null!;
        }
    }
}