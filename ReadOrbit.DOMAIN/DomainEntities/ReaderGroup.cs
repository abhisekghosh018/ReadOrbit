namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class ReaderGroup
    {
        public string Id { get; set; }
        public string BookReaderId { get; set; }
        public BookReader BookReader { get; set; }       
        public ICollection<Book> Book { get; set; } = new List<Book>();
        public string GroupId { get; set; }
        public Group Group { get; set; }
    }
}
