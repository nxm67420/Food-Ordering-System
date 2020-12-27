using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodTruck.Properties;

namespace FoodTruck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Arrays
        //string[] menus = { "Burger", "Cake", "Hot Dog", "Pizza" };
        //Image[] images = { Resources.burger, Resources.cake, Resources.hotdog, Resources.pizza };
        //double[] prices = { 0.99, 0.5, 1, 9.8 };
        /*Static creates One Instances across all Classes*/
        //BEST
        //static Food[] foods = {
        //    new Food("Burger", 0.99, Resources.burger),
        //    new Food("Cake", 0.5, Resources.cake),
        //    new Food("Hot Dog", 1, Resources.hotdog),
        //    new Food("Pizza", 9.8, Resources.pizza)
        //};
        ////Fives Each Food Item a QTY
        //static List<int> availables = new List<int>() {5, 4, 3, 2};
        //BEST
        public static List<Food> foods = new List<Food>();
        public static List<int> availables = new List<int>();

        //Load ListBox With Menu Items
        private void Form1_Load(object sender, EventArgs e)
        {
            //Uses ToString()
            listBox1.Items.AddRange(foods.ToArray());
            //foreach (var f in foods) {
            //    availables.Add(10);
            //}

            //pictureBox1.Image = Resources.burger;
            /*listBox1.Items.Add("Burger");
            listBox1.Items.Add("Cake");
            listBox1.Items.Add("Hot Dog");
            listBox1.Items.Add("Pizza");*/
        }

        //Show Image on Selected ListBox Index
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            pictureBox1.Image = foods[listBox1.SelectedIndex].pic;
            textBox1.Text = $"{foods[listBox1.SelectedIndex].price:C}";
            comboQty.Text = "1";
            //Prevents ComboBox Stack Up
            comboQty.Items.Clear();
            //Add Range To ComboBox
            for (int i = 1; i <= availables[listBox1.SelectedIndex]; i++) {
                comboQty.Items.Add(i);
            }
            ////Selects images from index within Array[]
            //pictureBox1.Image = images[listBox1.SelectedIndex];
            ////Shows Prices of Menu Items Based off of SelectedIndex
            //textBox1.Text = $"{prices[listBox1.SelectedIndex]:C}";
        }

        //Add To Cart Button
        private void btnAddCart_Click(object sender, EventArgs e)
        {   
            //If ListBox Item is Not Selected
                if(listBox1.SelectedIndex < 0) return;
            //Else
                var qty = int.Parse(comboQty.Text);
                //Create Item Object from foods[] 'reference'
                var oItem1 = new OrderItem(foods[listBox1.SelectedIndex], int.Parse(comboQty.Text));
                //Add Selected Item To Cart (Name + Qty)
                listBox2.Items.Add(oItem1);
                //reduces QTY of Item Selected
                availables[listBox1.SelectedIndex] -= qty;
                //Clears to Avoid Stack Up
                comboQty.Items.Clear();
                //Add Range To ComboBox (Refreshes New QTY)
                for (int i = 1; i <= availables[listBox1.SelectedIndex]; i++)
                {
                    comboQty.Items.Add(i);
                }
                updateTotal();

                //var food_name = foods[listBox1.SelectedIndex].name;
                //var food_price = foods[listBox1.SelectedIndex].price;
                //var qty = txtQty.Text;
        }//End of Add To Cart

        //Update Total
        private void updateTotal() {
            double subtotal = 0;
            //For Each Added Item to ListBox
            foreach (OrderItem o in listBox2.Items)
            {
                var oItem = o;
                //Grabs 'Food item' Object --> Food Class --> Grabs Price * Line 70 (Qty)
                subtotal += oItem.item.price * oItem.quantity;
            }
            labelDisplay.Text = $"subtotal: {subtotal:C}\nTax(8%): {subtotal * 0.08:C}\nTotal: {subtotal * 1.08:C}";
        }

        //Remove From Cart
        private void btnRemoveCart_Click(object sender, EventArgs e)
        {   
            //Create Variable == Cast ListBox2 Item 
            OrderItem oItem = (OrderItem)listBox2.SelectedItem;
            //Remove Created Variable
            listBox2.Items.Remove(oItem);
            updateTotal();
        }

        //Place Order Button
        private void button3_Click(object sender, EventArgs e)
        {   
            MessageBox.Show("Thank You!! Order Has Been Placed");
        }
    }
}
