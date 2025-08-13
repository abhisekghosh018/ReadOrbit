namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Review
    {
        public string ReviewId { get; set; }
        public string BookId  { get; set; }
        public Book Books { get; set; }
        public string BookReaderId { get; set; }
        public BookReader Readers { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
    }
}
