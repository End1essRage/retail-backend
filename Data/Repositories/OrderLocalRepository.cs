using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public class OrderLocalRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly AppContext _context;
        public OrderLocalRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetUserOrdersAsync(string userName)
        {
            return await _context.Orders.Where(o => o.ClientUserName == userName).ToListAsync();
        }
    }
}