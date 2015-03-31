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
        int startYear = DateTime.Now.Year;
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

        public FrmPayment()
        {
            InitializeComponent();
        }

        public FrmPayment(string total)
        {
            InitializeComponent();
            txtInvoiceTotal.Text = total;
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {

            for (int year = DateTime.Now.Year; year <= startYear + 3; year++)
            {
                cmbExpirationYear.Items.Add(year.ToString());
            }

            cmbCountry.DataSource = GetCountryList();
            cmbCountry.SelectedItem = "United Kingdom";
        }

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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            bool error = false;
            bool valid = false;

            lblExpirationDate.ForeColor = Color.Black;
            lblExpiratonDate.ForeColor = Color.Black;

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
            //strExpirationDate = cmbExpirationMonth.SelectedItem.ToString() + " / " + cmbExpirationYear.SelectedItem.ToString();
            strBillingAddress1 = txtAddress1.Text;
            strBillingAddress2 = txtAddress2.Text;
            strCity = txtCity.Text;
            strPostCode = txtPostalCode.Text;
            strCountry = cmbCountry.SelectedItem.ToString();
            strEmail = txtEmail.Text;
            #endregion

            #region(set default colour)
            lblFirstName.ForeColor = Color.Black;
            lblLastName.ForeColor = Color.Black;
            lblCardType.ForeColor = Color.Black;
            lblCardNumber.ForeColor = Color.Black;
            lblSecurityNumber.ForeColor = Color.Black;
            //lblExpirationDate.ForeColor = Color.Black;
            lblBilling1.ForeColor = Color.Black;
            lblCity.ForeColor = Color.Black;
            lblCountry.ForeColor = Color.Black;
            lblPostCode.ForeColor = Color.Black;
            lblEmail.ForeColor = Color.Black;
            #endregion

            #region(Error Checking)

            foreach (char c in strEmail)
            {
                if (c == '@')
                {
                    valid = true;
                }
            }

            if (strFirstName == "" || strLastName == "" || strCardNumber == "" || strCardSecurity == "" || strCardType == "" ||
                strExpirationDate == "" || strBillingAddress1 == "" || strCity == "" || strPostCode == "" || strCountry == "" ||
                strEmail == "")
            {
                MessageBox.Show("ERROR");
                error = true;
            }
            else
            {
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
                    if (strFirstName == "")
                    {
                        MessageBox.Show("Please enter your first name");
                        txtFirstName.Clear();
                        lblFirstName.ForeColor = Color.Red;
                        error = true;
                    }
                    else
                    {
                        if (strLastName == "")
                        {
                            MessageBox.Show("Please enter your first name");
                            txtLastName.Clear();
                            lblLastName.ForeColor = Color.Red;
                            error = true;
                        }
                        else
                        {
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
                                if (strBillingAddress1 == "")
                                {
                                    MessageBox.Show("Please enter you address");
                                    lblBilling1.ForeColor = Color.Red;
                                    error = true;
                                }
                                else
                                {
                                    if (strCity == "")
                                    {
                                        MessageBox.Show("Please enter your city");
                                        lblCity.ForeColor = Color.Red;
                                        error = true;
                                    }
                                    else
                                    {
                                        if (strEmail == "")
                                        {
                                            MessageBox.Show("Please enter your email address");
                                            lblEmail.ForeColor = Color.Red;
                                            error = true;
                                        }
                                        else
                                        {
                                            if (!valid)
                                            {
                                                MessageBox.Show("Please enter a valid email address");
                                                lblEmail.ForeColor = Color.Red;
                                                txtEmail.Clear();
                                                error = true;
                                            }
                                            else
                                            {
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


            if (!error)
            {
                FrmTrackOrder track = new FrmTrackOrder();
                track.Show();
                this.Hide();
            }
        }

        #region(SetCardTypes)
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
        #endregion

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void txtCardSecurity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

       

        
    }
}
