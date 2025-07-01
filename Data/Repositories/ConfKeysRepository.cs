using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace retail_backend.Data.Repositories
{
    public class ConfKeysRepository
    {
        private readonly AppContext _context;

        public ConfKeysRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateData(string key, string value)
        {
            var data = await _context.Constants.SingleOrDefaultAsync(c => c.Key == key);
            if (data == null)
            {
                _context.Constants.Add(new Entities.ConfKeys() { Key = key, Value = value });
            }
            else
            {
                data.Value = value;
                _context.Constants.Update(data);
            }

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<string> ReadData(string key)
        {
            var data = await _context.Constants.SingleOrDefaultAsync(c => c.Key == key);
            if (data == null)
            {
                throw new ArgumentException();
            }

            return data.Value;
        }
    }
}