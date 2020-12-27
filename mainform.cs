using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodTruck
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //Create new instance of form1
            var f1 = new Form1();
            //Open Form
            /*f1.ShowDialog(); Opens only one instance of that Window*/
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            //Create new instance of form2
            var f2 = new Form2();
            f2.Show();
        }

        private void mainform_Load(object sender, EventArgs e)
        {   
            //Reads Entire File
            string texts = System.IO.File.ReadAllText("foods.csv");
            //Reads Line By Line
            string[] lines = System.IO.File.ReadAllLines("foods.csv");
            foreach (var line in lines) {
               /// MessageBox.Show(line);
                String[] words = line.Split(','); //words[0] = "Burgers"
                string food_name = words[0];
                double price = double.Parse(words[1]); ;
                Image pic = Image.FromFile($"images/{words[2]}");
                int avail = int.Parse(words[3]);
                //Importing List<Food> from different Form 
                Form1.foods.Add(new Food(food_name, price, pic));
                Form1.availables.Add(avail);
            }
            
        }

        //Save Data on Close
        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<string> lines = new List<string>();
            lines.Add("Hello");
            lines.Add("World");
            System.IO.File.WriteAllLines("foods1.csv", lines.ToArray());
        }
    }
}
