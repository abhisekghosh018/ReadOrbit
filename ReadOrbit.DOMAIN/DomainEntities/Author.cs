using ReadOrbit.DOMAIN.BaseDomainEntities;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public DateOnly? DOB { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
