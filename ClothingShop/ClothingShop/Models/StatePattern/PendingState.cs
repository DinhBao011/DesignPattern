using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.StatePattern
{
    public class PendingState : IOrderState
    {
        public void ApproveOrder(Order order)
        {
            order.Status = 1;
        }
    }
}