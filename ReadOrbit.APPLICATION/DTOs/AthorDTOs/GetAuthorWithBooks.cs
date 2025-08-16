using ReadOrbit.APPLICATION.DTOs.BookDTOs;
using ReadOrbit.APPLICATION.DTOs.GenreDTOs;

namespace ReadOrbit.APPLICATION.DTOs.AthorDTOs
{
    public class GetAuthorWithBooks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public DateOnly? DOB { get; set; }
        public List<GetBookDTOForAuthor> Books { get; set; }
       
    }

    public class GetBookDTOForAuthor
    {      
        public string Title { get; set; }
        public int PublishedYear { get; set; }      
        public GetGenreDtoForAuthor Genre { get; set; }
        public List<BookReviewsForAuthor> Reviews { get; set; }
    }
    public class GetGenreDtoForAuthor
    {
        public string Name { get; set; }
    }
    public class BookReviewsForAuthor
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
