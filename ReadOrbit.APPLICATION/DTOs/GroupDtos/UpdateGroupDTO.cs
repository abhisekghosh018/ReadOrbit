using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.GroupDtos
{
    public class UpdateGroupDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
