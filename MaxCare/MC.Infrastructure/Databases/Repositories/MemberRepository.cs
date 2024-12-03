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

        public async Task<IEnumerable<Member>> GetMembersAsync() => 
            await GetAll()
                .Include(tbl => tbl.Group)
                .ToListAsync();

        public async Task<IEnumerable<Member>> GetMembersAsync(Expression<Func<Member, bool>> expression) =>
            await GetByExpression(expression)
                .Include(tbl => tbl.Group)
                .ToListAsync();
    }
}
