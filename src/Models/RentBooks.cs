namespace Library_Console.Models
{
    public class RentBooks
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public bool Rented { get; set; }

        public string ReturnStatus { get; set; } = string.Empty;

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}