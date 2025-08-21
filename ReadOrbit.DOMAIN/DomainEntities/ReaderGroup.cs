namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class ReaderGroup
    {
        public string Id { get; set; }
        public string BookReaderId { get; set; }
        public BookReader BookReader { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }  
    }
}
