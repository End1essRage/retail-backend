using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Data.Entities
{
    public class Order : BaseEntity
    {
        public int BuyerId { get; set; }
        public TelegramUser Buyer { get; set; }
        public int ManagerId { get; set; }
        public TelegramUser Manager { get; set; }
        public Status Status { get; set; }

        // Хранение позиций в виде JSON
        public List<Position> Positions { get; set; } = new List<Position>();
    }

    public class Position
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }

    public enum Status
    {
        New,
        Informed,
        Processed,
        Closed,
        Canceled
    }
}