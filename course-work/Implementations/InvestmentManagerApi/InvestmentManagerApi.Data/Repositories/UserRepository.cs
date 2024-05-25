using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string passwordHashed, bool isActive = true) 
            => await this.DbSet.FirstOrDefaultAsync(u => u.Email == email && u.Password == passwordHashed);
    }
}
