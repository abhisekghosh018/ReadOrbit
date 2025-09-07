using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.GroupDtos
{
    public class UpdateGroupDTO
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
