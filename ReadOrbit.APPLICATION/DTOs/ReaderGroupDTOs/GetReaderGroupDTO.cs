namespace ReadOrbit.APPLICATION.DTOs.ReaderGroupDTOs
{
    public class GetReaderGroupDTO
    {
        
        public string ReaderName { get; set; }
        public string GroupName { get; set; }
        public List<BookDTO> Books { get; set; } = new List<BookDTO>();
    }

    public class BookDTO
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public string? ImageUrl { get; set; }


    }
}
