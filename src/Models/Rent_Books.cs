namespace Library_Console.Models
{
    internal class Rent_Books
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public bool Rented { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}