using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace protype__groupwork_
{
    public partial class FrmPayment : Form
    {
        #region (Variables)
        
        int startYear = DateTime.Now.Year;
        int intOrderNumber;
        string strFirstName;
        string strLastName;
        string strCardType;
        string strCardNumber;
        string strCardSecurity;
        string strExpirationDate;
        string strBillingAddress1;
        string strBillingAddress2;
        string strCity;
        string strPostCode;
        string strCountry;
        string strEmail;
        private frmMenus menu;
        
        #endregion

        #region (Initialisers)
        
        //Default constructor 
        public FrmPayment()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.bg2;
            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnOrder.ForeColor = Color.White;
        }

        //Default constructor setting form item properties 
        public FrmPayment(string total)
        {
            InitializeComponent();
            lblPrice.Text = total;
            this.BackgroundImage = Properties.Resources.bg2;
            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnOrder.ForeColor = Color.White;
        }

        //Default constructor setting form item properties 
        public FrmPayment(string total, frmMenus frmM)
        {
            InitializeComponent();
            lblPrice.Text = total;
            menu = frmM;
            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnOrder.ForeColor = Color.White;
            this.BackgroundImage = Properties.Resources.bg2;
        }

        //Default constructor setting form item properties 
        public FrmPayment(string total, frmMenus frmM, int orderNumber)
        {
            InitializeComponent();
            lblPrice.Text = total;
            menu = frmM;
            intOrderNumber = orderNumber;
            lblOrderID.Text = orderNumber.ToString();
            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnOrder.ForeColor = Color.White;
            this.BackgroundImage = Properties.Resources.bg2;
        }

        #endregion

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            //gets current date
            for (int year = DateTime.Now.Year; year <= startYear + 3; year++)
            {
                cmbExpirationYear.Items.Add(year.ToString());
            }

            cmbCountry.DataSource = GetCountryList();
            cmbCountry.SelectedItem = "United Kingdom";
        }

        //Creates and fills a list of countries
        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                }
            }
            return cultureList;
        }

        #region (Buttons)
        
        //submits payment details
        public void btnOrder_Click(object sender, EventArgs e)
        {
            bool error = false;
            bool valid = false;

            lblExpirationDate.ForeColor = Color.Black;
            lblExpiratonDate.ForeColor = Color.Black;

            //checks expiration validity
            if (cmbExpirationMonth.SelectedIndex == -1 || cmbExpirationYear.SelectedIndex == -1)
            {
                error = true;
            }
            else
            {
                strExpirationDate = cmbExpirationMonth.SelectedItem.ToString() + " / " + cmbExpirationYear.SelectedItem.ToString();
            }

            #region(SET VALUES)

            strFirstName = txtFirstName.Text;
            strLastName = txtLastName.Text;
            strCardNumber = txtCardNumber.Text;
            strCardSecurity = txtCardSecurity.Text;
            strBillingAddress1 = txtAddress1.Text;
            strBillingAddress2 = txtAddress2.Text;
            strCity = txtCity.Text;
            strPostCode = txtPostalCode.Text;
            strCountry = cmbCountry.SelectedItem.ToString();
            strEmail = txtEmail.Text;

            #endregion

            #region(Set Default Colour)
            lblFirstName.ForeColor = Color.Black;
            lblLastName.ForeColor = Color.Black;
            lblCardType.ForeColor = Color.Black;
            lblCardNumber.ForeColor = Color.Black;
            lblSecurityNumber.ForeColor = Color.Black;
            lblBilling1.ForeColor = Color.Black;
            lblCity.ForeColor = Color.Black;
            lblCountry.ForeColor = Color.Black;
            lblPostCode.ForeColor = Color.Black;
            lblEmail.ForeColor = Color.Black;
            #endregion

            #region(Error Checking)

            //Checks email validity
            foreach (char c in strEmail)
            {
                if (c == '@')
                {
                    valid = true;
                }
            }

            //Checks to see all needed fields are filled
            if (strFirstName == "" || strLastName == "" || strCardNumber == "" || strCardSecurity == "" || strCardType == "" ||
                strExpirationDate == "" || strBillingAddress1 == "" || strCity == "" || strPostCode == "" || strCountry == "" ||
                strEmail == "")
            {
                MessageBox.Show("ERROR");
                error = true;
            }
            else
            {
                //Checks to see if card length is valid
                if (strCardNumber.Length != 16)
                {
                    MessageBox.Show("Card Number Too Long");
                    txtCardNumber.Clear();
                    strCardNumber = "";
                    lblCardNumber.ForeColor = Color.Red;
                    error = true;
                }
                else
                {
                    //Checks to see if first name fiels is filled
                    if (strFirstName == "")
                    {
                        MessageBox.Show("Please enter your first name");
                        txtFirstName.Clear();
                        lblFirstName.ForeColor = Color.Red;
                        error = true;
                    }
                    else
                    {
                        //Checks to see if last name field is filled
                        if (strLastName == "")
                        {
                            MessageBox.Show("Please enter your last name");
                            txtLastName.Clear();
                            lblLastName.ForeColor = Color.Red;
                            error = true;
                        }
                        else
                        {
                            //Checks to see is a card type is selected
                            if (radVisa.Checked == false && radMasterCard.Checked == false &&
                                radAmericanExpress.Checked == false && radDiscover.Checked == false &&
                                radDelta.Checked == false)
                            {
                                MessageBox.Show("Please chose a card type");
                                lblCardType.ForeColor = Color.Red;
                                error = true;
                            }
                            else
                            {
                                //Checks to see if billing address is filled
                                if (strBillingAddress1 == "")
                                {
                                    MessageBox.Show("Please enter you address");
                                    lblBilling1.ForeColor = Color.Red;
                                    error = true;
                                }
                                else
                                {
                                    //Checks to see is city ils is filled
                                    if (strCity == "")
                                    {
                                        MessageBox.Show("Please enter your city");
                                        lblCity.ForeColor = Color.Red;
                                        error = true;
                                    }
                                    else
                                    {
                                        //Checks to see if email fiels is filled
                                        if (strEmail == "")
                                        {
                                            MessageBox.Show("Please enter your email address");
                                            lblEmail.ForeColor = Color.Red;
                                            error = true;
                                        }
                                        else
                                        {
                                            //Executed invalid email address is entered
                                            if (!valid)
                                            {
                                                MessageBox.Show("Please enter a valid email address");
                                                lblEmail.ForeColor = Color.Red;
                                                txtEmail.Clear();
                                                error = true;
                                            }
                                            else
                                            {
                                                //Checks to see if both expiration date fields are filled
                                                if (cmbExpirationMonth.SelectedIndex == -1 || cmbExpirationYear.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Please enter a valid expiration date");
                                                    lblExpirationDate.ForeColor = Color.Red;
                                                    lblExpiratonDate.ForeColor = Color.Red;
                                                    error = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region(Test Labels)
            //label1.Text = strFirstName;
            //label2.Text = strLastName;
            //label3.Text = strCardType;
            //label4.Text = strCardNumber;
            //label6.Text = strExpirationDate;
            //label7.Text = strCardSecurity;
            //label8.Text = strBillingAddress1;
            //label9.Text = strBillingAddress2;
            //label10.Text = strCity;
            //label11.Text = strPostCode;
            //label12.Text = strCountry;
            //label13.Text = strEmail;
            #endregion

            //Executed if all payment fields are filled correctly
            if (!error)
            {
                FrmTrackOrder track = new FrmTrackOrder(intOrderNumber);
                track.Show();
                this.Close();
                //this.Hide();
                menu.closeForm(); //calls closeForm method from parent form
            }
        }
        
        #endregion

        #region(SetCardTypes)
       
        //Sets card type string
        private void radVisa_CheckedChanged(object sender, EventArgs e)
        {
            strCardType = "Visa";
        }

        private void radMasterCard_CheckedChanged(object sender, EventArgs e)
        {

            strCardType = "MasterCard";
        }

        private void radAmericanExpress_CheckedChanged(object sender, EventArgs e)
        {

            strCardType = "American Express";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            strCardType = "Delta";
        }

        private void radDiscover_CheckedChanged(object sender, EventArgs e)
        {

            strCardType = "Discover";
        }

        private void picVisa_Click(object sender, EventArgs e)
        {
            strCardType = "Visa";
            radVisa.Checked = true;
        }

        private void picMasterCard_Click(object sender, EventArgs e)
        {
            strCardType = "MasterCard";
            radMasterCard.Checked = true;
        }

        private void picAmericanExpress_Click(object sender, EventArgs e)
        {
            strCardType = "American Express";
            radAmericanExpress.Checked = true;
        }

        private void picDelta_Click(object sender, EventArgs e)
        {
            strCardType = "Delta";
            radDelta.Checked = true;
        }

        private void picDiscover_Click(object sender, EventArgs e)
        {
            strCardType = "Discover";
            radDiscover.Checked = true;
        }
        
        #endregion

        #region (Form Limitations)
        
        //Limits textbox to Digits
        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Linits textbox to Letters and hyphens 
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        //Linits textbox to Letters and hyphens 
        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        //Linits textbox to Digits 
        private void txtCardSecurity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Linits textbox to Letters 
        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        
        #endregion
        
    }
}
