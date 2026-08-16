using ReadOrbit.DOMAIN.DomainEntities;

namespace ReadOrbit.APPLICATION.Interfaces
{
    public interface ITest
    {
        Task<IEnumerable<ol_works>> GetAllOlAsync();
        Task<List<ol_works>> GetOlWorksBatchAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<IEnumerable<ol_works>> GetOlPageFromDbAsync(int pageNumber, int pageSize);
    }
}
