using MC.Shared.Models.Entities;

namespace MC.Shared.Contracts.Repositories
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> GetMemberAddressesAsync(Guid memberId, CancellationToken cancellationToken = default);
    }
}