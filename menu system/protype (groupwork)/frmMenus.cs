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
        #region (Variables)

        string strTotal;
        double total = 0.00;
        int tablecheck = 0;
        int intTableNumber = 0;
        int orderNumber;
        DataSet ds = new DataSet();
        Random rnd = new Random();
        MySQLClient sqlClient = new MySQLClient("localhost", "demo", "Conrad", "Conrad2015", 3306);
        string conection = "datasource=localhost;port=3306;username=Conrad;password=Conrad2015";

        #endregion

        #region (Initialisers)
        
        public frmMenus()
        {            
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.bg2;

            #region(Button Colour)

            btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnClear.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnRemove.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnStarter.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            btnMain.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            btnDessert.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            btnDrinks.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            button9.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            button10.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            button11.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19"); 
            button12.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");

            #endregion

        }
        
        //Initialises form taking tableNumber from parent form and setting form item settings
        public frmMenus(int tableNumber)
        {
            InitializeComponent();
            intTableNumber = tableNumber;
            this.BackgroundImage = Properties.Resources.bg2;

            #region(Button Colour)

            btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnClear.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnRemove.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnOrder.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnStarter.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnMain.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnDessert.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            btnDrinks.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button9.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button10.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button11.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");
            button12.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5AF19");

            #endregion
        }
        
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Total = £0.00";
            lblTableNumber.Text = "Table: " + intTableNumber.ToString();

            //Calls text rap methods and enitialises custom draw methods
            listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem += lst_MeasureItem;
        }

        #region (Buttons)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //exected if listbox contains items
            if (listBox1.Items.Count >= 1)
            {
                //executed if an item is selected
                if (listBox1.SelectedIndex != -1)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    
                    //calculates price to add to total
                    string cost = listBox1.Items[listBox1.SelectedIndex + 2].ToString();
                    cost = cost.Remove(0, 1);
                    double dblCost = Convert.ToDouble(cost);

                    total = total + dblCost;

                    strTotal = String.Format("{0:C}", total);

                    label1.Text = "Total = " + strTotal;
                }
            }
        }

        //retrieves price of selected item and removes the item and retrieved price
        private void btnRemove_Click(object sender, EventArgs e)
        {           
            double priceToTake = 0.00;
            string foodItem;

            foreach (string item in listBox2.Items)
            {
                if (item == listBox2.SelectedItem)
                {
                    foodItem = listBox2.SelectedItem.ToString();

                    try
                    {
                        string myConnection = conection;
                        MySqlConnection myConn = new MySqlConnection(myConnection);
                        MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                        MySqlCommand comand = new MySqlCommand("select Price from demo.menu_item where Item_Name = '" + foodItem + "' ;", myConn);
                        MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                        myConn.Open();

                        MySqlDataReader reader = comand.ExecuteReader();

                        while (reader.Read())
                        {
                            priceToTake = reader.GetDouble(0);
                        }
                        myConn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                }
            }
                

            listBox2.Items.Remove(listBox2.SelectedItem);

            total = total - priceToTake;
                        
            label1.Text = String.Format("Total = {0:C}", total);


        }

        //adds selected items in order to the database with a unique order ID
        private void btnOrder_Click(object sender, EventArgs e)
        {
            int randomNumber = rnd.Next(0, 100);
            int itemNum;
            int count = 0;

            do
            {
                orderNumber = randomNumber;
                count = 0;

                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    MySqlCommand comand = new MySqlCommand("select Order_ID from demo.order where Order_ID = '" + randomNumber.ToString() + "' ;", myConn);
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

                if (count == 0)
                {
                    sqlClient.Insert("order", "Order_ID, Table_ID, Status", "'" + randomNumber + "','" + intTableNumber.ToString() + "', 'Recieved'");

                    if (listBox2.Items.Count > 0)
                    {
                        itemNum = 1;

                        foreach (string s in listBox2.Items)
                        {
                            sqlClient.Insert("order_item", "Order_ID, Item_Name, Item_Num", "'" + randomNumber + "', '" + s + "', '" + itemNum + "'");
                            itemNum++;
                        }
                        FrmPayment pay = new FrmPayment(strTotal, this, orderNumber);
                        pay.Show();
                    }
                    else
                    {
                        MessageBox.Show("No items");
                    }
                }
                else
                {
                    randomNumber = rnd.Next(0, 999); 
                }
            } while (count > 0);
        }
        
        //Clears Order from the form
        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            label1.Text = "Total = £0.00";
            total = 0.00;
        }

        //alters selected index of listbox one depending on selection
        private void listBox1_Click(object sender, EventArgs e)
        {
            //if the user clicks on the description or price of an order it will 
            //select the order title instead.
            if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 0)
            {

            }
            else
            {
                if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 1)
                {
                    listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 1, true);
                }
                else
                {
                    if (Convert.ToInt32(listBox1.SelectedIndex) % 4 == 2)
                    {
                        listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 2, true);
                    }
                    else
                    {
                        if (listBox1.SelectedItem == " ")
                        {
                            listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex) - 3, true);
                        }
                    }
                }
            }
        }

        #endregion

        #region (food Menu catagories)
        
        //sets buttons to equal all available starter types
        private void btnStarter_Click(object sender, EventArgs e)
        {
            tablecheck = 1;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "Bread / Nibbles";
            button11.Visible = true;
            button11.Text = "Starters";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Starters";
        }
        
        //sets buttons to equal all available mains types
        private void btnMain_Click(object sender, EventArgs e)
        {
            tablecheck = 2;
            button8.Visible = true;
            button8.Text = "Pizza";
            button9.Visible = true;
            button9.Text = "Pasta";
            button10.Visible = true;
            button10.Text = "Meat";
            button11.Visible = true;
            button11.Text = "Sides";
            button12.Visible = true;
            button12.Text = "Salads";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Mains";
        }
        
        //sets buttons to equal all available desserts types
        private void btnDessert_Click(object sender, EventArgs e)
        {
            tablecheck = 3;
            button8.Visible = false;
            button10.Visible = false;
            button12.Visible = false;
            button9.Visible = true;
            button9.Text = "Desserts";
            button11.Visible = true;
            button11.Text = "Sundaes";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Desserts";
        }

        //sets buttons to equal all available starter types
        private void btnDrinks_Click(object sender, EventArgs e)
        {
            tablecheck = 4;
            button9.Visible = false;
            button11.Visible = false;
            button8.Visible = true;
            button8.Text = "Hot Drinks";
            button10.Visible = true;
            button10.Text = "Soft Drinks";
            button12.Visible = true;
            button12.Text = "Alcohol";
            lblFoodGroup.Visible = true;
            lblFoodGroup.Text = "Drinks";
        }

        #endregion

        #region (food sub catagories)

        //retreieves Pizza and Hot Drinks menus from database depending on tablbe check value
        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 2) //Pizza
            {                
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
                        
                        //Sets price to curency 
                        double price = Convert.ToDouble(reader.GetString(6));
                        string dprice = String.Format("{0:C}", price);
                        listBox1.Items.Add(dprice);

                        listBox1.Items.Add(" ");
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //calls text wrap methods refreshing listbox once complete
                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Pizza";
            }

            else if (tablecheck == 4) //Hot Drinks 
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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

                        listBox1.Items.Add(" ");       
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Drinks: Hot Drinks";
            }
        }

        //retrieves Nibbles, Pasta and Desserts menus from database depending on tablbe check value
        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 1)    //Bread / Nibbles
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");        
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();
                
                lblFoodGroup.Text = "Starters: Bread + Nibbles";
            }
            else if (tablecheck == 2)   //Pasta
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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

                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Pasta";
            }
            else if (tablecheck == 3)   //Desserts
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");    
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Desserts";
            }
        }

        //retrieves Meat and Soft Drinks menus from database depending on tablbe check value
        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 2)    //Meat
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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

                        listBox1.Items.Add(" ");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Meat + Fish";
            }
            else if (tablecheck == 4)   //Soft Drinks
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");    
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Drinks: Soft Drinks";
            }
        }

        //retrieves Starters, Sides and Sundaes menus from database depending on tablbe check value
        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 1)    //Starters
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Starters";
            }
            else if (tablecheck == 2) //Sides
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");     
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();
                
                lblFoodGroup.Text = "Mains: Sides";
            }
            else if (tablecheck == 3) //Sundaes
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();
                
                lblFoodGroup.Text = "Dessrts: Gelato Sundaes";
            }
        }

        //retrieves Salads and Alcohol menus from database depending on tablbe check value
        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (tablecheck == 2)    //Salads
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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

                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Mains: Salad";
            }
            else if (tablecheck == 4)   //Alcohol
            {
                try
                {
                    string myConnection = conection;
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
                        
                        listBox1.Items.Add(" ");   
                    }
                    myConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.DrawItem += lst_DrawItem;
                listBox1.Refresh();

                lblFoodGroup.Text = "Drinks: Beer + Cider";
            }
        }

        #endregion
       
        #region (Text Wrap Methods)
        
        //Calculates height of listbox item
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, listBox1.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }
        
        #endregion

        //Closed form when called
        public void closeForm()
        {
            this.Close();
        }
    }
}
