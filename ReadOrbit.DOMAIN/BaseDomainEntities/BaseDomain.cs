using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.DOMAIN.BaseDomainEntities
{
    public abstract class BaseDomain
    {
        public bool? Status { get; set; }
        public bool? IsApproved { get; set; }       
    }

    public abstract class BaseDomainDate: BaseDomain
    {        
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
