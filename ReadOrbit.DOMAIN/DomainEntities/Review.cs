using ReadOrbit.DOMAIN.BaseDomainEntities;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Review :BaseDomainDate
    {
        public string ReviewId { get; set; }
        public string BookId  { get; set; }
        public Book Book { get; set; }
        public string BookReaderId { get; set; }
        public BookReader Reader { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }         

    }
}
