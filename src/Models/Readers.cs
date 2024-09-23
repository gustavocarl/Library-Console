namespace Library_Console.Models
{
    public class Readers
    {
        public int Id { get; set; }

        public string Document { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}