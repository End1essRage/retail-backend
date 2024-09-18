using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace retail_backend.Data.Entities
{
    public class Order : BaseEntity
    {
        //public int ClientId { get; set; }
        //public virtual TelegramUser Client { get; set; }
        // public int ManagerId { get; set; }
        // public TelegramUser Manager { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string ClientUserName { get; set; }
        public OrderStatus Status { get; set; }
        public string PositionsJson { get; set; }

        [NotMapped]
        public Dictionary<int, int> Positions
        {
            get => string.IsNullOrEmpty(PositionsJson) ? new Dictionary<int, int>() : JsonConvert.DeserializeObject<Dictionary<int, int>>(PositionsJson);
            set => PositionsJson = JsonConvert.SerializeObject(value);
        }

    }

    public enum OrderStatus
    {
        New,
        Accepted,
        Completed,
        Cancelled
    }
}