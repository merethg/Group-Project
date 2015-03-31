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
            strFirstName = txtFirstName.Text;
            strLastName = txtLastName.Text;
            strCardNumber = txtCardNumber.Text;
            strCardSecurity = txtCardSecurity.Text;
            strExpirationDate = cmbExpirationMonth.SelectedItem.ToString() + " / " + cmbExpirationYear.SelectedItem.ToString();
            strBillingAddress1 = txtAddress1.Text;
            strBillingAddress2 = txtAddress2.Text;
            strCity = txtCity.Text;
            strPostCode = txtPostalCode.Text;
            strCountry = cmbCountry.SelectedItem.ToString();
            strEmail = txtEmail.Text;

            if (strFirstName == "" || strLastName == "" || strCardNumber == "" || strCardSecurity == "" || strCardType == "" ||
                strExpirationDate == "" || strBillingAddress1 == "" || strCity == "" || strPostCode == "" || strCountry == "" ||
                strEmail == "")
            {
                MessageBox.Show("ERROR");
            }

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
    }
}
