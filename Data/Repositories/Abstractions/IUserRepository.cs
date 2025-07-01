using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories.Abstractions
{
    public interface IUserRepository : IAsyncRepository<TelegramUser>
    {
        public Task<UserRole> GetUserRoleByName(string userName);
    }
}