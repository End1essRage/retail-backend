using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Data.Entities
{
    public class TelegramUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ChatId { get; set; }
        public bool IsAdmin { get; set; }
    }
}