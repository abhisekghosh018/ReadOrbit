using ReadOrbit.DOMAIN.BaseDomainEntities;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class BookReader : BaseDomainDate
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfileId { get; set; }
        public ReaderProfile Profile { get; set; }       
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
