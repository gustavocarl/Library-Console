namespace Library_Console.Models
{
    public class Books
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Pages { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string Isbn10 { get; set; } = string.Empty;

        public string Isbn13 { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}