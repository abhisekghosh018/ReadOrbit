using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class BookReader
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public DateTime JoinDate { get; set; }
        public string ProfileId { get; set; }
        public ReaderProfile Profile { get; set; }
    }
}
