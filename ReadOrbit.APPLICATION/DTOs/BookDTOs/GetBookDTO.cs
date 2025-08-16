using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.BookDTOs
{
    public class GetBookDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }
}
