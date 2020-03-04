using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunchOrder
{
    public partial class Form1 : Form
    {
        double hamburger = 6.95;
        double pizza = 5.95;
        double salad = 4.95;
        double taxRate = 0.075;
        double tax = 0.0;
        double addOn = 0.0;
        double orderTotal = 0.0;
        double addOnPrice = 0.75;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            calculateTotals();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearTotals()
        {
            txtOrderTotal.Text = "";
            txtSubtotal.Text = "";
            txtTax.Text = "";
        }

        private void ClearAddOns()
        {
            chkAddOn1.Checked = false;
            chkAddOn2.Checked = false;
            chkAddOn3.Checked = false;
        }

        private void calculateTotals()
        {
            if (rdoHamburger.Checked)
            {
                orderTotal += hamburger;
                addOnPrice = .75;
            }
            else if (rdoPizza.Checked)
            {
                orderTotal += pizza;
                addOnPrice = .5;
            }
            else
            {
                orderTotal += salad;
                addOnPrice = .25;
            }
            if (chkAddOn1.Checked)
                addOn += addOnPrice;
            if (chkAddOn2.Checked)
                addOn += addOnPrice;
            if (chkAddOn3.Checked)
                addOn += addOnPrice;
            orderTotal += addOn;
            txtSubtotal.Text = orderTotal.ToString("c");
            tax = (orderTotal * taxRate);
            txtTax.Text = tax.ToString("c");
            txtOrderTotal.Text = "$" + (orderTotal + tax).ToString("c");
            addOn = 0;
        }

        

        private void rdoHamburger_CheckedChanged(object sender, EventArgs e)
        {
            ClearTotals();
            ClearAddOns();
            if (rdoHamburger.Checked)
            {
                gbxAddOn.Text = "Add on items ($.75 each)";
                chkAddOn1.Text = "Lettuce, tomato and onions";
                chkAddOn2.Text = "Ketchup, mustard and mayo";
                chkAddOn3.Text = "French fries";
            }

        }

        private void rdoPizza_CheckedChanged(object sender, EventArgs e)
        {

            ClearTotals();
            ClearAddOns();

            if (rdoPizza.Checked)
            {
                gbxAddOn.Text = "Add on items ($.50 each)";
                chkAddOn1.Text = "Pepperoni";
                chkAddOn2.Text = "Sausage";
                chkAddOn3.Text = "Olives";
            }
        }

        private void rdoSalad_CheckedChanged(object sender, EventArgs e)
        {

            ClearTotals();
            ClearAddOns();

            if (rdoSalad.Checked)
            {
                gbxAddOn.Text = "Add on items ($.25 each)";
                chkAddOn1.Text = "Croutons";
                chkAddOn2.Text = "Bacon bits";
                chkAddOn3.Text = "Breadsticks";
            }


        }
    }
}
