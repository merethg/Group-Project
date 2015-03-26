using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace protype__groupwork_
{

    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();

        int tablecheck = 0;
        
        public Form1()
        {
            
            InitializeComponent();


        }
        #region customer list

        private void button1_Click(object sender, EventArgs e)
        {
            //add button
            //listBox2.Items.Add(listBox1.SelectedValue);
            listBox2.Items.Add(listBox1.SelectedItem);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //remove button
                listBox2.Items.Remove(listBox2.SelectedItem);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //order button 
        }

#endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            //ignore
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ignore 
        }

        #region food catagories

        private void button4_Click(object sender, EventArgs e)
        {
            //starter button 
            //sets buttons to equal all available starter types
            tablecheck = 1;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "bread/ nibbles";
            button11.Visible = true;
            button11.Text = "starters";
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //main button
            //sets buttons to equal all available mains types
            tablecheck = 2;
            button8.Visible = true;
            button8.Text = "pizza";
            button9.Visible = true;
            button9.Text = "pasta";
            button10.Visible = true;
            button10.Text = "meat";
            button11.Visible = true;
            button11.Text = "sides";
            button12.Visible = true;
            button12.Text = "salads";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //dessert button
            //sets buttons to equal all available desserts types

            tablecheck = 3;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "desserts";
            button11.Visible = true;
            button11.Text = "sundaes";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //drinks button 
            //sets buttons to equal all available starter types
            tablecheck = 4;
            button9.Visible = false;
            button11.Visible = false;
            button8.Visible = true;
            button8.Text = "hot drinks";
            button10.Visible = true;
            button10.Text = "soft drinks";
            button12.Visible = true;
            button12.Text = "alcohol";
        }
        #endregion

        #region food info

        private void button8_Click(object sender, EventArgs e)
        {
            if (tablecheck == 2)
            {
                //pizza
                //string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                //MySqlConnection myConn = new MySqlConnection(myConnection);
                //MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                //myDataAdapter.SelectCommand = new MySqlCommand(" select 'Item_Name', 'Description', 'Price' from 'demo.menu_item' where Item_Type = 'Pizza Rustica','Classic Pizza','Calzone','Skinny Pizza' ;", myConn);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                //myConn.Open();
                //myDataAdapter.Fill(ds);
                //listBox1.DataSource = ds;
                //myConn.Close();

                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item", myConn);//"select Item_Name from demo.menu_item where Item_Type = 'Pizza Rustica','Classic Pizza','Calzone','Skinny Pizza' ;", myConn);  ////########
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1)+" \n"+(reader.GetString(2)));
                        listBox1.Items.Add(reader.GetString(6));                        
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
            else if (tablecheck == 4)
            {
                //hot drinks 
                listBox1.DataSource = ds;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tablecheck == 1)
            {
                //bread/ nibbles
                listBox1.DataSource = ds;
            }
            else if (tablecheck == 2)
            {
                //pasta
                listBox1.DataSource = ds;
            }
            else if (tablecheck == 3)
            {
                //desserts
                listBox1.DataSource = ds;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (tablecheck == 2)
            {
                //meat
                listBox1.DataSource = ds;
            }
            else if (tablecheck == 4)
            {
                //soft drinks
                listBox1.DataSource = ds;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (tablecheck == 1)
            {
                //starters
                listBox1.DataSource = ds;
            }
            else if (tablecheck == 2)
            {
                //sides
                listBox1.DataSource = ds;
            }
            else if (tablecheck == 3)
            {
                //sundaes
                listBox1.DataSource = ds;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (tablecheck == 2)
            {
                //salads
                listBox1.DataSource = ds;
            }
            else if (tablecheck == 4)
            {
                //alcohol
                listBox1.DataSource = ds;
            }
        }
        #endregion
    }
}
