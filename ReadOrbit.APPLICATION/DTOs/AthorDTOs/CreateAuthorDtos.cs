using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.AthorDTOs
{
    public class CreateAuthorDtos
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Name cannot exceed 50 characters")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        public string Name { get; set; }
        public string? Country { get; set; }
        public DateOnly? DOB { get; set; }
    }
}
