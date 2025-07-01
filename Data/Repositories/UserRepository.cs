using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;
using retail_backend.Data.Repositories.Abstractions;

namespace retail_backend.Data.Repositories
{
    public class UserRepository : BaseRepository<TelegramUser>, IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserRole> GetUserRoleByName(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
                return UserRole.Client;

            return user.Role;
        }
    }
}