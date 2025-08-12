using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class ReaderGroup
    {
        public string Id { get; set; }
        public string ReaderId { get; set; }
        public BookReader Reader { get; set; }
        public string GroupId { get; set; }
        public Group Group { get; set; }
    }
}
