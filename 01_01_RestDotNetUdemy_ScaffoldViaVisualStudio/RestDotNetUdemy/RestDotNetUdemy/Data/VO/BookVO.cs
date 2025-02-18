using RestDotNetUdemy.Hypermedia;
using RestDotNetUdemy.Hypermedia.Abstract;

namespace RestDotNetUdemy.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public DateTime LaunchDate { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public List<HyperMediaLink> Links { get; set; } = [];
    }
}