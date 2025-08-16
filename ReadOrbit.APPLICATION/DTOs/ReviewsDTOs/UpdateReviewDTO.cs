using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.ReviewsDTOs
{
    public class UpdateReviewDTO
    {
        public string ReviewId { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
    }
}
