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

namespace FrontOfHouseApp
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        MySQLClient sqlClient = new MySQLClient("host","database","user","pass",3306,5);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
                {
                
                    string myConnection = "datasource=10.100.129.130;port=3306;username=Conrad;password=Conrad2015";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = new MySqlCommand(" select * from demo.table ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                
                    MessageBox.Show("Connected");
                //myDataAdapter.Fill(ds);
                //dataGridView.DataSource = ds.Tables[0];
                //dataGridView.Refresh();
                    //myConn.Close();
                

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
        }

        private void button1A_Click(object sender, EventArgs e)
        {
            sqlClient.Update("","","");
        }
    }
}


/*
            button1.ForeColor = Color.White;
            button1.BackColor = System.Drawing.Color.Crimson;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer2_Tick);
            timer1.Interval = 1000;
            timer1.Start();
            */
            
        
/*
        private void timer2_Tick(object sender, EventArgs e)
        {
            counter--;

            if (counter <= 6 && counter > 0)
            {
                button1.ForeColor = Color.Black;
                button1.BackColor = System.Drawing.Color.Gold;
            }

            if (counter == 0)
            {
                button1.BackColor = System.Drawing.Color.DodgerBlue;
                timer1.Stop();
                counter = 10;
            }
         * */

/*
            try
            {
                string connetionString = null;
            SqlConnection cnn ;
            connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show ("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            }
            */

/*
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
            sql = "Your SQL Statement Here , like Select * from product";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
            */