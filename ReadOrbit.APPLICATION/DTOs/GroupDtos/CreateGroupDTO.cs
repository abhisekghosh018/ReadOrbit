using System.ComponentModel.DataAnnotations;

namespace ReadOrbit.APPLICATION.DTOs.GroupDtos
{
    public class CreateGroupDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
