using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.ReaderProfileDTOs
{
    public class UpdateReaderProfileDTO
    {
        public string Id { get; set; }
        public string? Bio { get; set; }
        public string? FavoriteGenre { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
