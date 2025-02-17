namespace RestDotNetUdemy.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}