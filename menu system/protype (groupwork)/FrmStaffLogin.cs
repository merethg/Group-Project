using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySQLClass;

namespace protype__groupwork_
{
    public partial class FrmStaffLogin : Form
    {
        #region(Variables)

        string strTableNumber;
        string strPassword;
        string conection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
        MySQLClient sqlClient = new MySQLClient("localhost", "demo", "Conrad", "Conrad2015", 3306);

        #endregion

        #region(Constructors)

        public FrmStaffLogin()
        {
            InitializeComponent();
        }

        //Sets table number
        public FrmStaffLogin(int tableNumber)
        {
            InitializeComponent();
            strTableNumber = tableNumber.ToString();
        }

        #endregion

        //Password check and table status alteration in database
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            strPassword = txtPassword.Text;
            int count = 0;

            try
            {
                string myConnection = conection;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.staff where Password = 'conrad2015' ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    count += 1;
                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Updated table status
            if (count == 1)
            {
                sqlClient.Update("table", "Table_Status = 'Available'", "Table_ID = '" + strTableNumber + "'");
                this.Close();
            }
            else
            {
                MessageBox.Show("Unable to update table status: Invalid Password");
            }            
        }
    }
}
