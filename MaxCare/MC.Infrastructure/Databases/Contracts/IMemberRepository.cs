using MC.Infrastructure.Models.Entities;
using System.Linq.Expressions;

namespace MC.Infrastructure.Databases.Contracts
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<IEnumerable<Member>> GetMembersAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Member>> GetMembersAsync(Expression<Func<Member, bool>> expression, CancellationToken cancellationToken = default);
        Task<Member?> GetMemberByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}