using MC.Shared.Models.Entities;

namespace MC.Shared.Contracts.Repositories
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetMemberContactsAsync(Guid memberId, CancellationToken cancellationToken = default);
    }
}