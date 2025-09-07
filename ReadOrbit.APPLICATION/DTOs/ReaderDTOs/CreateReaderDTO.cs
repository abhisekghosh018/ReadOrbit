using ReadOrbit.DOMAIN.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.ReaderDTOs
{
    public class CreateReaderDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public bool Status { get; set; }
        public bool IsApproved { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public string ProfileId { get; set; }
        
    }
}
