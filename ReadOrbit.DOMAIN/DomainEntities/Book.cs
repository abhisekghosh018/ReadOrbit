namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<BookReader> BookReaders { get; set; } = new List<BookReader>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
