using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.AthorDTOs
{
    public class CreateAuthorDtos
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Country { get; set; }
        public DateOnly? DOB { get; set; }
    }
}
