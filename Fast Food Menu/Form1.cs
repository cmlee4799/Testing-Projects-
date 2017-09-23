using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_Food_Menu
{
    public partial class Form1 : Form
    {
        const double Price_Coke = 1.75;
        const double Price_Sprite = 1.75;
        const double Price_Orange = 1.75;
        const double Price_Grape = 1.75;
        const double Price_Strawberry = 1.75;
        const double Price_Gingerale = 1.75;
        const double Price_Straw_Shake = 2.75;
        const double Price_Van_Shake = 2.75;
        const double Price_Choc_Shake = 2.75;
        const double Price_Cheer_Shake = 3.75;
        const double Price_Chocvan_Shake = 3.75;
        const double Price_Hamburger = 2.95;
        const double Price_Cheeseburger = 3.55;
        const double Price_BcnBgr = 4.25;
        const double Price_BcnChBgr = 5.15;
        const double Price_GkSal = 5.50;
        const double Price_CknSal = 6.75;
        const double Price_Fish = 3.75;
        const double Price_BLT = 2.95;
        const double Price_HtDogs = 2.50;
        const double Price_ChDogs = 3.50;
        const double Price_ChChzDogs = 4.25;
        const double Price_Fries = 1.50;
        const double Price_SdSal = 2.25;
        const double Price_OnRgs = 2.50;
        const double Price_Soup = 3.00;

        double tax, subtotal, total;

        public Form1()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            iExit = MessageBox.Show("Confirm you want to exit the system", Convert.ToString(Title), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (iExit == DialogResult.Yes)
                Application.Exit();
        }

        private void ResetTextBoxes()
        {
            Action<Control.ControlCollection> boxes = null;

            boxes = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Text = "0";
                    else
                        boxes(control.Controls);
            };

            boxes(Controls);

        }

        private void ResetCheckBoxes()
        {
            Action<Control.ControlCollection> boxes = null;

            boxes = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else
                        boxes(control.Controls);
            };

            boxes(Controls);

        }

        private void EnableTextBoxes()
        {
            Action<Control.ControlCollection> boxes = null;

            boxes = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Enabled = false;
                    else
                        boxes(control.Controls);
            };

            boxes(Controls);

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(textBox1.Text + " " + checkBox1.Text));
            ResetTextBoxes();
            ResetCheckBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            paymentMethod.Items.Add(" ");
            paymentMethod.Items.Add("Cash");
            paymentMethod.Items.Add("Master Card");
            paymentMethod.Items.Add("Visa");
            paymentMethod.Items.Add("Debit");

            EnableTextBoxes();
        }

        private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paymentMethod.Text == "Cash")
            {
                paymentCash.Enabled = true;
                paymentCash.Text = "";
                paymentCash.Focus();
            }

            else
            {
                paymentCash.Enabled = false;
                paymentCash.Text = "0";

            }
        }

        private void Total_Click(object sender, EventArgs e)
        {
            double[] itemPrice = new double[26];
            itemPrice[0] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[1] = Convert.ToDouble(txSprite.Text) * Price_Sprite;
            itemPrice[2] = Convert.ToDouble(txOrange.Text) * Price_Orange;
            itemPrice[3] = Convert.ToDouble(txGrape.Text) * Price_Grape;
            itemPrice[4] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[5] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[6] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[7] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[8] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[9] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[10] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[11] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[12] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[13] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[14] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[15] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[16] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[17] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[18] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[19] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[20] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[21] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[22] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[23] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[24] = Convert.ToDouble(txCoke.Text) * Price_Coke;
            itemPrice[25] = Convert.ToDouble(txCoke.Text) * Price_Coke;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHamburger.Checked == true)
            {
                txHamburger.Enabled = true;
                txHamburger.Text = "";
                txHamburger.Focus();
                
            }

            else
            {
                txHamburger.Enabled = false;
                txHamburger.Text = "0";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCheeseburger.Checked == true)
            {
                txCheeseburger.Enabled = true;
                txCheeseburger.Text = "";
                txCheeseburger.Focus();

            }

            else
            {
                txCheeseburger.Enabled = false;
                txCheeseburger.Text = "0";
            }
        }
    }
}
