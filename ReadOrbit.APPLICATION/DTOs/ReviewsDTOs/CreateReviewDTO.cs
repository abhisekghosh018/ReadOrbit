using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.ReviewsDTOs
{
    public class CreateReviewDTO
    {
        public string ReviewId { get; set; }
        public string BookId { get; set; }      
        public string BookReaderId { get; set; }       
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }
}
