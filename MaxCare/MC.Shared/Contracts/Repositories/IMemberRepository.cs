using MC.Shared.Models.Entities;
using System.Linq.Expressions;

namespace MC.Shared.Contracts.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<IEnumerable<Member>> GetMembersAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Member>> GetMembersAsync(Expression<Func<Member, bool>> expression, CancellationToken cancellationToken = default);
        Task<Member?> GetMemberByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}