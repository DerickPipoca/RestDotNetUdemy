using RestDotNetUdemy.Hypermedia;
using RestDotNetUdemy.Hypermedia.Abstract;

namespace RestDotNetUdemy.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public List<HyperMediaLink> Links { get; set; } = [];
    }
}