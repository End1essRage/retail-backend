using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Helpers
{
    public static class DataConstants
    {
        public static Dictionary<OrderStatus, string> OrderStatusDict = new Dictionary<OrderStatus, string>(){
            {OrderStatus.New, "OrderStatus_New"},
            {OrderStatus.Accepted, "OrderStatus_Accepted"},
            {OrderStatus.Completed, "OrderStatus_Completed"},
            {OrderStatus.Cancelled, "OrderStatus_Cancelled"},
            {OrderStatus.Closed, "OrderStatus_Closed"},
        };
    }
}