namespace Library_Console.Models
{
    public class Reader
    {
        public int Id { get; set; }

        public string? Document { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}