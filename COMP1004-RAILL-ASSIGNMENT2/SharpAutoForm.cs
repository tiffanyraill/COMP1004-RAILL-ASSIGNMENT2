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
            additionalOptionsLabel.Text = "";
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
    }
}
