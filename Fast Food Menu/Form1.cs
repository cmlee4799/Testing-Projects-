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
        const decimal Price_Coke = 1.75M;
        const decimal Price_Sprite = 1.75M;
        const decimal Price_Orange = 1.75M;
        const decimal Price_Grape = 1.75M;
        const decimal Price_Strawberry = 1.75M;
        const decimal Price_Gingerale = 1.75M;
        const decimal Price_Straw_Shake = 2.75M;
        const decimal Price_Van_Shake = 2.75M;
        const decimal Price_Choc_Shake = 2.75M;
        const decimal Price_Cheer_Shake = 3.75M;
        const decimal Price_Chocvan_Shake = 3.75M;
        const decimal Price_Hamburger = 2.95M;
        const decimal Price_Cheeseburger = 3.55M;
        const decimal Price_BcnBgr = 4.25M;
        const decimal Price_BcnChBgr = 5.15M;
        const decimal Price_GrkSal = 5.50M;
        const decimal Price_CknSal = 6.75M;
        const decimal Price_FishSw = 3.75M;
        const decimal Price_BLT = 2.95M;
        const decimal Price_HotDogs = 2.50M;
        const decimal Price_ChlDogs = 3.50M;
        const decimal Price_ChChzDogs = 4.25M;
        const decimal Price_Fries = 1.50M;
        const decimal Price_SdSal = 2.25M;
        const decimal Price_OnRgs = 2.50M;
        const decimal Price_Soup = 3.00M;

        decimal tax, subtotal, total;
        decimal taxRate = .07M;

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
            decimal[] itemPrice = new decimal[26];
            itemPrice[0] = Convert.ToDecimal(txCoke.Text) * Price_Coke;
            itemPrice[1] = Convert.ToDecimal(txSprite.Text) * Price_Sprite;
            itemPrice[2] = Convert.ToDecimal(txOrange.Text) * Price_Orange;
            itemPrice[3] = Convert.ToDecimal(txGrape.Text) * Price_Grape;
            itemPrice[4] = Convert.ToDecimal(txStrawberry.Text) * Price_Strawberry;
            itemPrice[5] = Convert.ToDecimal(txGinger.Text) * Price_Gingerale;
            itemPrice[6] = Convert.ToDecimal(txStrawShake.Text) * Price_Straw_Shake;
            itemPrice[7] = Convert.ToDecimal(txVanShake.Text) * Price_Van_Shake;
            itemPrice[8] = Convert.ToDecimal(txChocShake.Text) * Price_Choc_Shake;
            itemPrice[9] = Convert.ToDecimal(txCheerShake.Text) * Price_Cheer_Shake;
            itemPrice[10] = Convert.ToDecimal(txChocVanShake.Text) * Price_Chocvan_Shake;
            itemPrice[11] = Convert.ToDecimal(txHamburger.Text) * Price_Hamburger;
            itemPrice[12] = Convert.ToDecimal(txCheeseburger.Text) * Price_Cheeseburger;
            itemPrice[13] = Convert.ToDecimal(txBcnBgr.Text) * Price_BcnBgr;
            itemPrice[14] = Convert.ToDecimal(txBcnChBgr.Text) * Price_BcnChBgr;
            itemPrice[15] = Convert.ToDecimal(txGrkSal.Text) * Price_GrkSal;
            itemPrice[16] = Convert.ToDecimal(txCknSal.Text) * Price_CknSal;
            itemPrice[17] = Convert.ToDecimal(txFishSw.Text) * Price_FishSw;
            itemPrice[18] = Convert.ToDecimal(txBLT.Text) * Price_BLT;
            itemPrice[19] = Convert.ToDecimal(txHotDogs.Text) * Price_HotDogs;
            itemPrice[20] = Convert.ToDecimal(txChlDogs.Text) * Price_ChlDogs;
            itemPrice[21] = Convert.ToDecimal(txChChzDogs.Text) * Price_ChChzDogs;
            itemPrice[22] = Convert.ToDecimal(txFries.Text) * Price_Fries;
            itemPrice[23] = Convert.ToDecimal(txSdSal.Text) * Price_SdSal;
            itemPrice[24] = Convert.ToDecimal(txOnRgs.Text) * Price_OnRgs;
            itemPrice[25] = Convert.ToDecimal(txSoup.Text) * Price_Soup;

            decimal change;
            if (paymentMethod.Text == "Cash")
            {
                subtotal = itemPrice[0] + itemPrice[1] + itemPrice[2] + itemPrice[3]
                    + itemPrice[4] + itemPrice[5] + itemPrice[6] + itemPrice[7]
                    + itemPrice[8] + itemPrice[9] + itemPrice[10] + itemPrice[11]
                    + itemPrice[12] + itemPrice[13] + itemPrice[14] + itemPrice[15]
                    + itemPrice[16] + itemPrice[17] + itemPrice[18] + itemPrice[19]
                    + itemPrice[20] + itemPrice[21] + itemPrice[22] + itemPrice[23]
                    + itemPrice[24] + itemPrice[25];
                
                tax = subtotal * taxRate;
                total = subtotal + tax;
                subtotalTx.Text = Convert.ToString(tax);
                totalTx.Text = Convert.ToString(total);
                change = Convert.ToDecimal(paymentCash.Text) - total;
                changeTx.Text = Convert.ToString(change);

                subtotalTx.Text = string.Format("{0:C}", subtotal);
                taxTx.Text = string.Format("{0:C}", tax);
                totalTx.Text = string.Format("{0:C}", total);
                changeTx.Text = string.Format("{0:C}", change);
            }

            else
            {
                subtotal = itemPrice[0] + itemPrice[1] + itemPrice[2] + itemPrice[3]
                    + itemPrice[4] + itemPrice[5] + itemPrice[6] + itemPrice[7]
                    + itemPrice[8] + itemPrice[9] + itemPrice[10] + itemPrice[11]
                    + itemPrice[12] + itemPrice[13] + itemPrice[14] + itemPrice[15]
                    + itemPrice[16] + itemPrice[17] + itemPrice[18] + itemPrice[19]
                    + itemPrice[20] + itemPrice[21] + itemPrice[22] + itemPrice[23]
                    + itemPrice[24] + itemPrice[25];

                tax = subtotal * taxRate;
                total = subtotal + tax;
                subtotalTx.Text = Convert.ToString(tax);
                totalTx.Text = Convert.ToString(total);
               
                subtotalTx.Text = string.Format("{0:C}", subtotal);
                taxTx.Text = string.Format("{0:C}", tax);
                totalTx.Text = string.Format("{0:C}", total);
                

            }

            
        }

        private void ckBcnBgr_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBcnBgr.Checked == true)
            {
                txBcnBgr.Enabled = true;
                txBcnBgr.Text = "";
                txBcnBgr.Focus();

            }

            else
            {
                txBcnBgr.Enabled = false;
                txBcnBgr.Text = "0";
            }
        }

        private void ckBcnChBgr_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBcnChBgr.Checked == true)
            {
                txBcnChBgr.Enabled = true;
                txBcnChBgr.Text = "";
                txBcnChBgr.Focus();

            }

            else
            {
                txBcnChBgr.Enabled = false;
                txBcnChBgr.Text = "0";
            }
        }

        private void ckGrkSal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGrkSal.Checked == true)
            {
                txGrkSal.Enabled = true;
                txGrkSal.Text = "";
                txGrkSal.Focus();

            }

            else
            {
                txGrkSal.Enabled = false;
                txGrkSal.Text = "0";
            }
        }

        private void ckCknSal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCknSal.Checked == true)
            {
                txCknSal.Enabled = true;
                txCknSal.Text = "";
                txCknSal.Focus();

            }

            else
            {
                txCknSal.Enabled = false;
                txCknSal.Text = "0";
            }
        }

        private void ckFishSw_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFishSw.Checked == true)
            {
                txFishSw.Enabled = true;
                txFishSw.Text = "";
                txFishSw.Focus();

            }

            else
            {
                txFishSw.Enabled = false;
                txFishSw.Text = "0";
            }
        }

        private void ckBLT_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBLT.Checked == true)
            {
                txBLT.Enabled = true;
                txBLT.Text = "";
                txBLT.Focus();

            }

            else
            {
                txBLT.Enabled = false;
                txBLT.Text = "0";
            }
        }

        private void ckHotDogs_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHotDogs.Checked == true)
            {
                txHotDogs.Enabled = true;
                txHotDogs.Text = "";
                txHotDogs.Focus();

            }

            else
            {
                txHotDogs.Enabled = false;
                txHotDogs.Text = "0";
            }
        }

        private void ckChlDogs_CheckedChanged(object sender, EventArgs e)
        {
            if (ckChlDogs.Checked == true)
            {
                txChlDogs.Enabled = true;
                txChlDogs.Text = "";
                txChlDogs.Focus();

            }

            else
            {
                txChlDogs.Enabled = false;
                txChlDogs.Text = "0";
            }
        }

        private void ckChChzDogs_CheckedChanged(object sender, EventArgs e)
        {
            if (ckChChzDogs.Checked == true)
            {
                txChChzDogs.Enabled = true;
                txChChzDogs.Text = "";
                txChChzDogs.Focus();

            }

            else
            {
                txChChzDogs.Enabled = false;
                txChChzDogs.Text = "0";
            }
        }

        private void ckFries_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFries.Checked == true)
            {
                txFries.Enabled = true;
                txFries.Text = "";
                txFries.Focus();

            }

            else
            {
                txFries.Enabled = false;
                txFries.Text = "0";
            }
        }

        private void ckSdSal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSdSal.Checked == true)
            {
                txSdSal.Enabled = true;
                txSdSal.Text = "";
                txSdSal.Focus();

            }

            else
            {
                txSdSal.Enabled = false;
                txSdSal.Text = "0";
            }
        }

        private void ckOnRgs_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOnRgs.Checked == true)
            {
                txOnRgs.Enabled = true;
                txOnRgs.Text = "";
                txOnRgs.Focus();

            }

            else
            {
                txOnRgs.Enabled = false;
                txOnRgs.Text = "0";
            }
        }

        private void ckSoup_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoup.Checked == true)
            {
                txSoup.Enabled = true;
                txSoup.Text = "";
                txSoup.Focus();

            }

            else
            {
                txSoup.Enabled = false;
                txSoup.Text = "0";
            }
        }

        private void ckCoke_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCoke.Checked == true)
            {
                txCoke.Enabled = true;
                txCoke.Text = "";
                txCoke.Focus();

            }

            else
            {
                txCoke.Enabled = false;
                txCoke.Text = "0";
            }
        }

        private void ckSprite_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSprite.Checked == true)
            {
                txSprite.Enabled = true;
                txSprite.Text = "";
                txSprite.Focus();

            }

            else
            {
                txSprite.Enabled = false;
                txSprite.Text = "0";
            }
        }

        private void ckOrange_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOrange.Checked == true)
            {
                txOrange.Enabled = true;
                txOrange.Text = "";
                txOrange.Focus();

            }

            else
            {
                txOrange.Enabled = false;
                txOrange.Text = "0";
            }
        }

        private void ckGrape_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGrape.Checked == true)
            {
                txGrape.Enabled = true;
                txGrape.Text = "";
                txGrape.Focus();

            }

            else
            {
                txGrape.Enabled = false;
                txGrape.Text = "0";
            }
        }

        private void ckStrawberry_CheckedChanged(object sender, EventArgs e)
        {
            if (ckStrawberry.Checked == true)
            {
                txStrawberry.Enabled = true;
                txStrawberry.Text = "";
                txStrawberry.Focus();

            }

            else
            {
                txStrawberry.Enabled = false;
                txStrawberry.Text = "0";
            }
        }

        private void ckGinger_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGinger.Checked == true)
            {
                txGinger.Enabled = true;
                txGinger.Text = "";
                txGinger.Focus();

            }

            else
            {
                txGinger.Enabled = false;
                txGinger.Text = "0";
            }
        }

        private void ckStrawShake_CheckedChanged(object sender, EventArgs e)
        {
            if (ckStrawShake.Checked == true)
            {
                txStrawShake.Enabled = true;
                txStrawShake.Text = "";
                txStrawShake.Focus();

            }

            else
            {
                txStrawShake.Enabled = false;
                txStrawShake.Text = "0";
            }
        }

        private void ckVanShake_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVanShake.Checked == true)
            {
                txVanShake.Enabled = true;
                txVanShake.Text = "";
                txVanShake.Focus();

            }

            else
            {
                txVanShake.Enabled = false;
                txVanShake.Text = "0";
            }
        }

        private void ckChocShake_CheckedChanged(object sender, EventArgs e)
        {
            if (ckChocShake.Checked == true)
            {
                txChocShake.Enabled = true;
                txChocShake.Text = "";
                txChocShake.Focus();

            }

            else
            {
                txChocShake.Enabled = false;
                txChocShake.Text = "0";
            }
        }

        private void ckCheerShake_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCheerShake.Checked == true)
            {
                txCheerShake.Enabled = true;
                txCheerShake.Text = "";
                txCheerShake.Focus();

            }

            else
            {
                txCheerShake.Enabled = false;
                txCheerShake.Text = "0";
            }
        }

        private void ckChocVanShake_CheckedChanged(object sender, EventArgs e)
        {
            if (ckChocVanShake.Checked == true)
            {
                txChocVanShake.Enabled = true;
                txChocVanShake.Text = "";
                txChocVanShake.Focus();

            }

            else
            {
                txChocVanShake.Enabled = false;
                txChocVanShake.Text = "0";
            }
        }

        private void ckHamburger_CheckedChanged(object sender, EventArgs e)
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

        private void ckCheeseburger_CheckedChanged(object sender, EventArgs e)
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
