using RestDotNetUdemy.Hypermedia.Abstract;

namespace RestDotNetUdemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = [];
    }
}