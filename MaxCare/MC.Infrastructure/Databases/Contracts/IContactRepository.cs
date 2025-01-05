using MC.Infrastructure.Models.Entities;

namespace MC.Infrastructure.Databases.Contracts
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetMemberContactsAsync(Guid memberId, CancellationToken cancellationToken = default);
    }
}