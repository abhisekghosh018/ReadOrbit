using ReadOrbit.DOMAIN.BaseDomainEntities;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Review :BaseDomainDate
    {
        public string ReviewId { get; set; }
        public string BookId  { get; set; }
        public Book Books { get; set; }
        public string BookReaderId { get; set; }
        public BookReader Readers { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }         

    }
}
