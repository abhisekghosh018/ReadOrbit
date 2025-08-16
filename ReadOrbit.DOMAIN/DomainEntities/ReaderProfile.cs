using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class ReaderProfile
    {
        public string Id  { get; set; }
        public string? Bio { get; set; }
        public string? FavoriteGenre { get; set; }
        public string? AvatarUrl { get; set; }    

    }
}
