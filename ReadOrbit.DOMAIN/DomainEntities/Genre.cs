using ReadOrbit.DOMAIN.BaseDomainEntities;
using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Genre :BaseDomainDate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
