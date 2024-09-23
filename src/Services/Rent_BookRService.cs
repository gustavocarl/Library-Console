using Library_Console.Repository;

namespace Library_Console.Services
{
    public class Rent_BookRService
    {
        private readonly Rent_BookRepository _rent_BookRepository;

        public Rent_BookRService(Rent_BookRepository rent_BookRepository)
        {
            _rent_BookRepository = rent_BookRepository;
        }
    }
}