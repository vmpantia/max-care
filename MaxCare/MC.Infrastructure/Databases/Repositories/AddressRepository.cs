using MC.Infrastructure.Databases.Contexts;
using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Entities;
using MC.Shared.Models.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace MC.Infrastructure.Databases.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(MaxCareDbContext maxCareDbContext) : base(maxCareDbContext) { }

        public async Task<IEnumerable<Address>> GetMemberAddressesAsync(Guid memberId, CancellationToken cancellationToken = default) =>
            await GetByExpression(contact => contact.ResourceId == memberId &&
                                             contact.ResourceType == ResourceType.Member)
                .ToListAsync(cancellationToken);
    }
}
