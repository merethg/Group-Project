using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kitchen_System
{
    public partial class FrmKitchen : Form
    {
        public FrmKitchen()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn); 
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");

                while (reader.Read())
                {
                    lstbData.Items.Add(reader.GetString(0) + "\t" + reader.GetString(1) + "\t" + reader.GetString(2));

                }

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
