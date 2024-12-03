using MC.Shared.Models.Entities;
using System.Linq.Expressions;

namespace MC.Shared.Contracts.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<IEnumerable<Member>> GetMembersAsync(Expression<Func<Member, bool>> expression);
    }
}