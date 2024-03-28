using ClothingShop.Models.StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.StatePattern
{
    public class OrderState
    {
        private IOrderState _orderState;

        public OrderState(IOrderState state)
        {
            _orderState = state;
        }
        public void SetState(IOrderState state)
        {
            _orderState = state;
        }
        public void ApproveOrder(Order order)
        {
            _orderState.ApproveOrder(order);
        }
    }
}
