using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Data.SQLxml;

namespace KitchAppv2
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();

        public int counter = 5;

        public string orderBackup = "",
            tableNumBackup = "",
            orderNumBackup = "";

        public Form1()
        {
            InitializeComponent();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;

            if (counter == 0)
            {
                counter = 5;
            }
            
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (this.label16.Text == "EMPTY")
            {
                //MySQL to string information used in this attempt can be found here: http://www.c-sharpcorner.com/Blogs/11462/display-data-from-database-to-label.aspx

                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                MySqlDataReader reader = comand.ExecuteReader();

                if (this.label13.Text == "EMPTY")
                {
                    if (this.label10.Text == "EMPTY")
                    {
                        if (this.label7.Text == "EMPTY")
                        {
                            if (this.label4.Text == "EMPTY")
                            {
                                if (this.label1.Text == "EMPTY")
                                {
                                    reader.Read();
                                    this.label1.Text = reader["OrderItem"].ToString; //food order

                                    reader.Read();
                                    this.label2.Text = reader["TableNum"].ToString; //table number

                                    reader.Read();
                                    this.label3.Text = reader["OrderNum"].ToString; //order number
                                }
                                reader.Read();
                                this.label4.Text = reader["OrderItem"].ToString; //food order

                                reader.Read();
                                this.label5.Text = reader["TableNum"].ToString; //table number

                                reader.Read();
                                this.label6.Text = reader["OrderNum"].ToString; //order number
                                
                            }
                            reader.Read();
                            this.label7.Text = reader["OrderItem"].ToString; //food order

                            reader.Read();
                            this.label8.Text = reader["TableNum"].ToString; //table number

                            reader.Read();
                            this.label9.Text = reader["OrderNum"].ToString; //order number
                        }
                        reader.Read();
                        this.label10.Text = reader["OrderItem"].ToString; //food order

                        reader.Read();
                        this.label11.Text = reader["TableNum"].ToString; //table number

                        reader.Read();
                        this.label12.Text = reader["OrderNum"].ToString; //order number
                    }
                    reader.Read();
                    this.label13.Text = reader["OrderItem"].ToString; //food order

                    reader.Read();
                    this.label14.Text = reader["TableNum"].ToString; //table number

                    reader.Read();
                    this.label15.Text = reader["OrderNum"].ToString; //order number
                }
                reader.Read();
                this.label16.Text = reader["OrderItem"].ToString; //food order

                reader.Read();
                this.label17.Text = reader["TableNum"].ToString; //table number

                reader.Read();
                this.label3.Text = reader["OrderNum"].ToString; //order number
                myConn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            myConn.Delete("names", "name=''");
            */
            this.label1.Text = this.label4.Text;
            this.label2.Text = this.label5.Text;
            this.label3.Text = this.label6.Text;

            this.label4.Text = this.label7.Text;
            this.label5.Text = this.label8.Text;
            this.label6.Text = this.label9.Text;

            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            myConn.Delete("names", "name='John Smith'");
            */
            this.label1.Text = this.label4.Text;
            this.label2.Text = this.label5.Text;
            this.label3.Text = this.label6.Text;

            this.label4.Text = this.label7.Text;
            this.label5.Text = this.label8.Text;
            this.label6.Text = this.label9.Text;

            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            orderBackup = this.label1.Text;
            tableNumBackup = this.label2.Text;
            orderNumBackup = this.label3.Text;

            this.label1.Text = this.label4.Text;
            this.label2.Text = this.label5.Text;
            this.label3.Text = this.label6.Text;

            this.label4.Text = orderBackup;
            this.label5.Text = tableNumBackup;
            this.label6.Text = orderNumBackup;
        }

        private void button5_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label4.Text = this.label7.Text;
            this.label5.Text = this.label8.Text;
            this.label6.Text = this.label9.Text;

            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button6_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label4.Text = this.label7.Text;
            this.label5.Text = this.label8.Text;
            this.label6.Text = this.label9.Text;

            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            orderBackup = this.label4.Text;
            tableNumBackup = this.label5.Text;
            orderNumBackup = this.label6.Text;

            this.label4.Text = this.label1.Text;
            this.label5.Text = this.label2.Text;
            this.label6.Text = this.label3.Text;

            this.label1.Text = orderBackup;
            this.label2.Text = tableNumBackup;
            this.label3.Text = orderNumBackup;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            orderBackup = this.label4.Text;
            tableNumBackup = this.label5.Text;
            orderNumBackup = this.label6.Text;

            this.label4.Text = this.label7.Text;
            this.label5.Text = this.label8.Text;
            this.label6.Text = this.label9.Text;

            this.label7.Text = orderBackup;
            this.label8.Text = tableNumBackup;
            this.label9.Text = orderNumBackup;
        }

        private void button9_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button10_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            orderBackup = this.label7.Text;
            tableNumBackup = this.label8.Text;
            orderNumBackup = this.label9.Text;

            this.label7.Text = this.label4.Text;
            this.label8.Text = this.label5.Text;
            this.label9.Text = this.label6.Text;

            this.label4.Text = orderBackup;
            this.label5.Text = tableNumBackup;
            this.label6.Text = orderNumBackup;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            orderBackup = this.label7.Text;
            tableNumBackup = this.label8.Text;
            orderNumBackup = this.label9.Text;

            this.label7.Text = this.label10.Text;
            this.label8.Text = this.label11.Text;
            this.label9.Text = this.label12.Text;

            this.label10.Text = orderBackup;
            this.label11.Text = tableNumBackup;
            this.label12.Text = orderNumBackup;
        }

        private void button13_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button14_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            orderBackup = this.label10.Text;
            tableNumBackup = this.label11.Text;
            orderNumBackup = this.label12.Text;

            this.label10.Text = this.label7.Text;
            this.label11.Text = this.label8.Text;
            this.label12.Text = this.label9.Text;

            this.label7.Text = orderBackup;
            this.label8.Text = tableNumBackup;
            this.label9.Text = orderNumBackup;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            orderBackup = this.label10.Text;
            tableNumBackup = this.label11.Text;
            orderNumBackup = this.label12.Text;

            this.label10.Text = this.label13.Text;
            this.label11.Text = this.label14.Text;
            this.label12.Text = this.label15.Text;

            this.label13.Text = orderBackup;
            this.label14.Text = tableNumBackup;
            this.label15.Text = orderNumBackup;
        }

        private void button17_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button18_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            orderBackup = this.label13.Text;
            tableNumBackup = this.label14.Text;
            orderNumBackup = this.label15.Text;

            this.label13.Text = this.label10.Text;
            this.label14.Text = this.label11.Text;
            this.label15.Text = this.label12.Text;

            this.label10.Text = orderBackup;
            this.label11.Text = tableNumBackup;
            this.label12.Text = orderNumBackup;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            orderBackup = this.label13.Text;
            tableNumBackup = this.label14.Text;
            orderNumBackup = this.label15.Text;

            this.label13.Text = this.label16.Text;
            this.label14.Text = this.label17.Text;
            this.label15.Text = this.label18.Text;

            this.label16.Text = orderBackup;
            this.label17.Text = tableNumBackup;
            this.label18.Text = orderNumBackup;
        }

        private void button21_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button22_Click(object sender, EventArgs e)
        {/*
            try
            {
                string myConnection = "datasource=86.14.93.33;port=3306;username=Conrad;password=Conrad2015";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand comand = new MySqlCommand("select * from demo.table ;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();

                MySqlDataReader reader = comand.ExecuteReader();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            myConn.Delete("names", "name='John Smith'");
            */
            this.label16.Text = "EMPTY";
            this.label17.Text = "EMPTY";
            this.label18.Text = "EMPTY";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            orderBackup = this.label16.Text;
            tableNumBackup = this.label17.Text;
            orderNumBackup = this.label18.Text;

            this.label16.Text = this.label13.Text;
            this.label17.Text = this.label14.Text;
            this.label18.Text = this.label15.Text;

            this.label13.Text = orderBackup;
            this.label14.Text = tableNumBackup;
            this.label15.Text = orderNumBackup;
        }
    }
}
