using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.ReaderDTOs
{
    public class UpdateReaderDTO
    {
        public string Id { get; set; }       
        public string Email { get; set; }
        public string? Mobile { get; set; }              
    }
}
