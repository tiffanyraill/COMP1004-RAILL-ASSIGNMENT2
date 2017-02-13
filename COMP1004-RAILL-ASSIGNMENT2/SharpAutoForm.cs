///@SharpAutoForm Assignment 2  COMP1004-02-w2017
///@Tiffany Raill
///@200264388
///App Creation Date: 1/30/2017
///@Description: This app determines the total amount due for the purchase of a vehicle based on 
///accessories and options selected and a trade-in value(if any). The price of the car will be set by the user.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_RAILL_ASSIGNMENT2
{
    public partial class SharpAutoForm : Form
    {
        double standardOption = 0.00;
        double stereoSystemCost = 425.76;
        double leatherInteriorCost = 987.41;
        double computerNavigationCost = 1741.23;
        double pearlizedOption = 345.72;
        double customizedOption = 599.99;
        double totalAdditionalCharges;

        public SharpAutoForm()
        {
            InitializeComponent();
        }

        private void SharpAutoForm_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // STEP 1: Create a new form
            AboutForm aboutForm = new AboutForm();
            //STEP 2: Show the about form with ShowDialogue (a modal method that displays the form)
            aboutForm.ShowDialog();
            //the aboutform is not working, reverting to messageBox.
            MessageBox.Show("This program calculates the amount due on a New or Used Vehicle");
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        //exit button- exits application
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // When the Clear Button is clicked, all the Text Boxes and Check Boxes of the form are cleared.
        //The Radio Button in the Exterior Finish Group box is set to Standard as a default. 
        //Have the Trade- in Allowance Text Box default to zero
        private void clearButton_Click(object sender, EventArgs e)
        {
            double tradeInAllowance = 0.00;
            tradeInAllowanceTextBox.Text = tradeInAllowance.ToString("C2");

            basePriceTextBox.Text = "";
            additionalOptionsTextBox.Text = "";
            subtotalTextBox.Text = "";
            salesTaxTextBox.Text = "";
            totalTextBox.Text = "";
            amountDueTextBox.Text = "";

            stereoSystemCheckBox.Checked = false;
            leatherInteriorCheckBox.Checked = false;
            computerNavigationCheckBox.Checked = false;

            standardRadioButton.Checked = true;
            pearlizedRadioButton.Checked = false;
            customizedDetailingRadioButton.Checked = false;
        }

        //exit menu button - exits application
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //clear menu button - calls to "clear button" method and clears form
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearButton.PerformClick();
        }

        private void stereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (stereoSystemCheckBox.Checked == true)
            {
               additionalOptionsTextBox.Text = stereoSystemCost.ToString("C2");
             }
                else if (stereoSystemCheckBox.Checked == false)
                {
                    additionalOptionsTextBox.Text = "";
                }
            }
        
        private void leatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (leatherInteriorCheckBox.Checked == true)
            {
                additionalOptionsTextBox.Text = leatherInteriorCost.ToString("C2");
            }
            else if (leatherInteriorCheckBox.Checked == false)
            {
                additionalOptionsTextBox.Text = "";
            }
        }

        private void computerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (computerNavigationCheckBox.Checked == true)
            {
                additionalOptionsTextBox.Text = computerNavigationCost.ToString("C2");
            }
            else if (computerNavigationCheckBox.Checked == false)
            {
                additionalOptionsTextBox.Text = "";
            }
        }
        
        private void pearlizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            if (pearlizedRadioButton.Checked == true)
            {
                additionalOptionsTextBox.Text = pearlizedOption.ToString("C2");
            }
        }

        //customized detailing option - additional options + 599.99
        private void customizedDetailingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (customizedDetailingRadioButton.Checked == true)
            {
                additionalOptionsTextBox.Text = customizedOption.ToString("C2");
            }
        }

        //if the standard option is chosen, no additional charges- message box displays message
        private void standardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (standardRadioButton.Checked == true)
            {
                additionalOptionsTextBox.Text = standardOption.ToString("C2");
                MessageBox.Show("No Additional Charges for Standard Package");
            }
        }

        private void additionalCharges()
        {
            if (pearlizedRadioButton.Checked == true)
            {
                totalAdditionalCharges += pearlizedOption;
            }
            if (customizedDetailingRadioButton.Checked == true)
            {
                totalAdditionalCharges += customizedOption;
            }
            if (stereoSystemCheckBox.Checked == true)
            {
                totalAdditionalCharges += stereoSystemCost;
            }
            if(computerNavigationCheckBox.Checked == true)
            {
                totalAdditionalCharges += computerNavigationCost;
            }
            if(leatherInteriorCheckBox.Checked == true)
            {
                totalAdditionalCharges += leatherInteriorCost;
            }
            additionalOptionsTextBox.Text = totalAdditionalCharges.ToString("C2");
         }

        //calculate the subtotal of additional charges plus base price
         private void subTotal()
         {
            double basePrice = Convert.ToDouble(basePriceTextBox.Text);
            double totalAdditionalCharges = Convert.ToDouble(additionalOptionsTextBox.Text);
            double subTotal = basePrice + totalAdditionalCharges;

            subtotalTextBox.Text = subTotal.ToString("C2");
         }

        //calculate the sales tax
        private void salesTaxes()
        {
            double taxes = Convert.ToDouble(subtotalTextBox.Text) * .13;
            salesTaxTextBox.Text = taxes.ToString("C2");
        }
         //multiply the subtotal by 1.13 to include taxes in the cost
         private void Total()
         {
            double subTotal = Convert.ToDouble(subtotalTextBox.Text);
            double total = subTotal * 1.13;
           
            totalTextBox.Text = total.ToString("C2");
         }

         private void AmountDue()
         {
             double subTotal = Convert.ToDouble(subtotalTextBox.Text);
             double tradeInAllowance = Convert.ToDouble(tradeInAllowanceTextBox.Text);
             double amountDue = subTotal - tradeInAllowance;

             amountDueTextBox.Text = amountDue.ToString("C2");
          }

          private void calculateButton_Click(object sender, EventArgs e)
          {
             if (subtotalTextBox.Text != "")
            {
                AmountDue();
            }
        }
    }
}

