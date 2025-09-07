namespace ReadOrbit.APPLICATION.DTOs.ReaderProfileDTOs
{
    public class CreateReaderProfileDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Bio { get; set; }
        public string? FavoriteGenre { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
