using RestDotNetUdemy.Data.Converter.Contract;
using RestDotNetUdemy.Data.VO;
using RestDotNetUdemy.Models;

namespace RestDotNetUdemy.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin != null)
            {
                return new Book()
                {
                    Id = origin.Id,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title,
                    Author = origin.Author
                };
            }
            return null!;
        }

        public BookVO Parse(Book origin)
        {
            if (origin != null)
            {
                return new BookVO()
                {
                    Id = origin.Id,
                    LaunchDate = origin.LaunchDate,
                    Price = origin.Price,
                    Title = origin.Title,
                    Author = origin.Author
                };
            }
            return null!;
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin != null)
            {
                return origin.Select(e => Parse(e) ?? new BookVO()).ToList();
            }
            return null!;
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin != null)
            {
                return origin.Select(e => Parse(e) ?? new Book()).ToList();
            }
            return null!;
        }
    }
}