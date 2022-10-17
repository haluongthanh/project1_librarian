namespace code.Entities
{
    public class Book
    {
        public string? Isbn { get; set; }
        public string? Book_names { get; set; }
        public string? Author { get; set; }
        public string? Publisher_names { get; set; }
        public DateTime Publishing_year { get; set; }
        public int Amount { get; set; }
        public int status { get; set; }
    }
}