using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Data.Entities
{
    public class TelegramUser : BaseEntity
    {
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}