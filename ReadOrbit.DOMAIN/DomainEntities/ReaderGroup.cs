using ReadOrbit.DOMAIN.DomainEntities.Group;

namespace ReadOrbit.DOMAIN.DomainEntities.Reader
{
    public class ReaderGroup
    {
        public string ReaderId { get; set; }
        public Reader Reader { get; set; }
        public string GroupId { get; set; }
        public Groups Group { get; set; }
    }
}
