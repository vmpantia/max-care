using MC.Infrastructure.Databases.Contexts;
using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MC.Infrastructure.Databases.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(MaxCareDbContext maxCareDbContext) : base(maxCareDbContext) { }

        public async Task<IEnumerable<Member>> GetMembersAsync(CancellationToken cancellationToken = default) => 
            await GetAll()
                .Include(tbl => tbl.Group)
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Member>> GetMembersAsync(Expression<Func<Member, bool>> expression, CancellationToken cancellationToken = default) =>
            await GetByExpression(expression)
                .Include(tbl => tbl.Group)
                .ToListAsync(cancellationToken);

        public async Task<Member?> GetMemberByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await GetByExpression(member => member.Id == id)
                .Include(tbl => tbl.Group)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
