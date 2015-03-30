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

    public partial class frmMenus : Form
    {
        double total = 0.00;
        string strTotal;
        DataSet ds = new DataSet();
        

        int tablecheck = 0;
        
        public frmMenus()
        {            
            InitializeComponent();
        }

        #region customer list

        private void button1_Click(object sender, EventArgs e)
        {
            //add button
            //listBox2.Items.Add(listBox1.SelectedValue);
            listBox2.Items.Add(listBox1.SelectedItem);
            //total = total + Convert.ToDouble(listBox1.Items[listBox1.SelectedIndex+2].ToString());
            string cost = listBox1.Items[listBox1.SelectedIndex + 2].ToString();
            cost = cost.Remove(0, 1);
            double dblCost = Convert.ToDouble(cost);
            
            total = total + dblCost;

            strTotal = String.Format("{0:C}", total);

            label1.Text = "Total = " + strTotal;
            //label1.Text = "Total = £ " + total.ToString("#.##");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double holder = 0.00;
            foreach (string item in listBox1.Items)
            {
                if (item == listBox2.SelectedItem)
                {
                    //select this item in the ListBox.
                    holder = Convert.ToDouble(listBox1.Items[listBox1.FindString(item) + 2]);
                    break;
                }
            } 
            //remove button
            listBox2.Items.Remove(listBox2.SelectedItem);
            total = total - holder;
            if (Convert.ToInt16(listBox2.Items.Count) == 0)
            {
                total = 0.00;
            }
            label1.Text = "Total = £ " + total.ToString("#.##");
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySQLClient sqlClient = new MySQLClient("localhost", "demo", "Conrad", "Conrad2015", 3306);
            //order button 
            foreach (string s in listBox2.Items)
            {
                sqlClient.Insert("order_item", "Order_ID, Item_Name", "'1', '" + s + "'");
            }
        }

#endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            //ignore
            label1.Text = "Total = £0.00";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ignore 
        }

        #region food catagories

        //starter button 
        private void button4_Click(object sender, EventArgs e)
        {
            //sets buttons to equal all available starter types
            tablecheck = 1;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "bread/ nibbles";
            button11.Visible = true;
            button11.Text = "starters";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Starters";
        }

        //main button
        private void button5_Click(object sender, EventArgs e)
        {
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
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Mains";
        }

        //dessert button
        private void button6_Click(object sender, EventArgs e)
        {
            //sets buttons to equal all available desserts types

            tablecheck = 3;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "desserts";
            button11.Visible = true;
            button11.Text = "sundaes";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Desserts";
        }

        //drinks button 
        private void button7_Click(object sender, EventArgs e)
        {
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
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Drinks";
        }
        #endregion

        #region food sub_catagories

        //to change server info such as ip or port change the string below.
        //put the ip after datasorce and the port after port.
        //change the username after username and the password to the server password.
        string conection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";

        //pizza and hot drinks
        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (tablecheck == 2)
            {
                //pizza
                try
                {
                    //this code recieves a list of items, descriptions and prices from the server.
                    //each line of the server table is put into listBox1 in the following order:
                    // meal name 
                    // description 
                    // price 
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Pizza' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        double price = Convert.ToDouble(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add("");                        
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Mains: Pizza";
            }
            
            else if (tablecheck == 4)
            {
                //hot drinks 
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Hot Drinks' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");       
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Drinks: Hot Drinks";
            }
        }

        //nibbles, pasta and desserts
        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (tablecheck == 1)
            {
                //bread/ nibbles
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Bread + Nibbles' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");        
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Starters: Bread + Nibbles";
            }
            else if (tablecheck == 2)
            {
                //pasta
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Pasta' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Mains: Pasta";
            }
            else if (tablecheck == 3)
            {
                //desserts
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Dessert' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");    
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Desserts";
            }
        }

        //meat and soft drinks
        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (tablecheck == 2)
            {
                //meat
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Meat + Fish' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Mains: Meat + Fish";
            }
            else if (tablecheck == 4)
            {
                //soft drinks
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Soft Drinks' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");    
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Drinks: Soft Drinks";
            }
        }

        //starters, sides nad sundaes
        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (tablecheck == 1)
            {
                //starters
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Starters' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                lblFoodGroup.Text = "Starters";
            }
            else if (tablecheck == 2)
            {
                //sides
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Sides' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Mains: Sides";
            }
            else if (tablecheck == 3)
            {
                //sundaes
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Gelato Sundaes' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Dessrts: Gelato Sundaes";
            }
        }

        //salads and alcohol
        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (tablecheck == 2)
            {
                //salads
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Salad' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Mains: Salad";
            }
            else if (tablecheck == 4)
            {
                //alcohol
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    //myDataAdapter.SelectCommand = new MySqlCommand("select Table_ID from demo.table where Table_Status = 'Available' and Seat_Numbers = '" + searchValue.ToString() + "'", myConn);
                    MySqlCommand comand = new MySqlCommand("select * from demo.menu_item where Item_Type = 'Beer + Cider' ;", myConn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                    myConn.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(1));
                        listBox1.Items.Add(reader.GetString(2));
                        decimal price = Convert.ToDecimal(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);
                        listBox1.Items.Add("");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                lblFoodGroup.Text = "Drinks: Beer + Cider";
            }
        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //if the user clicks on the description or price of an order it will 
            //select the order title instead.
            if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 0)
            {
                
            }
            else if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 1)
            {
                listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) -1,true);
            }
            else if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 2)
            {
                listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 2, true);
            }
            else

            if (listBox1.SelectedItem == "")
            {
                listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 3, true);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            label1.Text = "Total = £0.00";
            total = 0.00;
        }
    }
}
