using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.ReaderGroupDTOs
{
    public class CreateReaderGroupDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage ="Reader name is required")]
        public string BookReaderId { get; set; }
        [Required(ErrorMessage = "Group name is required")]
        public string GroupId { get; set; }
        
    }
}
