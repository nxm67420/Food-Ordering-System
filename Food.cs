using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck
{
    public class Food
    {
        public string name;
        public double price;
        public Image pic;

        public Food(string name, double price, Image pic)
        {
            this.name = name;
            this.price = price;
            this.pic = pic;
        }
        public override string ToString()
        {
            return name;
        }

    }
}
