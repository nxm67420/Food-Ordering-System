using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck
{
    class OrderItem
    {
        public Food item;
        public int quantity;

        public OrderItem(Food item, int qty) {
            this.item = item;
            quantity = qty;
        }

        public override string ToString()
        {
            return $"{item.name}:{quantity}";
        }
    }
}
