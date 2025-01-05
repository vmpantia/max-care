using MC.Infrastructure.Models.Entities;

namespace MC.Infrastructure.Databases.Contracts
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> GetMemberAddressesAsync(Guid memberId, CancellationToken cancellationToken = default);
    }
}