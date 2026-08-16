namespace ReadOrbit.DOMAIN.DomainEntities
{
    public class ol_works
    {
        //public long TotalCount { get; set; }

        public string? OlKey { get; set; }

        public int Revision { get; set; }

        public DateTime? LastModified { get; set; }

        public string? Title { get; set; }

        public string? Subtitle { get; set; }

        public string? Description { get; set; }

        public DateTime? FirstPublishDate { get; set; }

        public List<int>? Covers { get; set; }

        public List<string>? Subjects { get; set; }

        public List<string>? AuthorKeys { get; set; }
    }
}
