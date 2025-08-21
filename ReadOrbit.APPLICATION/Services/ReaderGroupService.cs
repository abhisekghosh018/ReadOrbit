using ReadOrbit.APPLICATION.DTOs.ReaderGroupDTOs;
using ReadOrbit.APPLICATION.Interfaces;
using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Services
{
    public class ReaderGroupService
    {
        private readonly IReaderGroupRepository _readerGroupRepository;

        public ReaderGroupService(IReaderGroupRepository readerGroupRepository)
        {
            _readerGroupRepository = readerGroupRepository;
        }

        public async Task<IEnumerable<GetReaderGroupDTO>> GetAllReaderGroupsAsync()
        {
            var readerGroups = await _readerGroupRepository.GetAllReaderGroupsAsync();

            if (readerGroups.Any())
            {
                var readerGroupDetails = readerGroups.Select(rg => new GetReaderGroupDTO
                {
                    GroupName = rg.Group.Name,
                    ReaderName = rg.BookReader.UserName,
                    Books = rg.Book.Select(book => new BookDTO
                    {
                        BookName = book.Title,
                        AuthorName = book.Author.Name,
                        GenreName = book.Genre.Name,
                        ImageUrl = book.ImageUrl
                    }).ToList()

                }).ToList();

                return readerGroupDetails;
            } 
            else
            {
                return Enumerable.Empty<GetReaderGroupDTO>();
            }
        }

        public async Task<GetReaderGroupDTO> GetAllReaderGroupsByIdAsync(string id)
        {
            var readerGroup = await _readerGroupRepository.GetReaderGroupByIdAsync(id);

            if (readerGroup == null)
            {
                return null;
            }
            
            var readerGroupDetails = new GetReaderGroupDTO
            {
                GroupName = readerGroup.Group.Name,
                ReaderName = readerGroup.BookReader.UserName,
                Books = readerGroup.Book.Select(book => new BookDTO
                {
                    BookName = book.Title,
                    AuthorName = book.Author.Name,
                    GenreName = book.Genre.Name,
                    ImageUrl = book.ImageUrl
                }).ToList()
            };

            return readerGroupDetails;
        }

        public async Task<int> CreateReaderGroupAsync(CreateReaderGroupDTO createReaderGroupDTO)
        {
            if (createReaderGroupDTO == null)
            {
                return 0;
            }
            var readerGroup = new ReaderGroup
            {
                GroupId = createReaderGroupDTO.GroupId,
                BookReaderId = createReaderGroupDTO.BookReaderId,               
            };
            return await _readerGroupRepository.CreateReaderGroupAsync(readerGroup);
        }
    }
}
