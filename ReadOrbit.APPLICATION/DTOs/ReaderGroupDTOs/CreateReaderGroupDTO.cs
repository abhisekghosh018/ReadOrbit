using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.ReaderGroupDTOs
{
    public class CreateReaderGroupDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string BookReaderId { get; set; }
        public string GroupId { get; set; }
        
    }
}
