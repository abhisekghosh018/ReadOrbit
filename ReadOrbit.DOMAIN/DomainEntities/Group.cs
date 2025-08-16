using ReadOrbit.DOMAIN.BaseDomainEntities;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Group : BaseDomainDate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
       
    }
}
