using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.BookDTOs
{
    public class UpdateBookDTO
    {
        public string Id { get; set; } 
        public string? Title { get; set; }
        public int? PublishedYear { get; set; }
        public string AuthorId { get; set; }
        public int? GenreId { get; set; }
    }
}
