using ReadOrbit.DOMAIN.BaseDomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class Genre :BaseDomainDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
