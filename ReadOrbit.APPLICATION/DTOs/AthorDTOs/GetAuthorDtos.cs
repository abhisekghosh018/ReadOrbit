namespace ReadOrbit.APPLICATION.DTOs.AthorDTOs
{
    public class GetAuthorDtos
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public DateOnly? DOB { get; set; }
        public string? ImageUrl { get; set; }
    }
}
