using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Inventry_Control_System
{
    public partial class Items : Form
    {
        private SqlCon Con = new SqlCon();

        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            Discount.SelectedIndex = 0;
            button1.Enabled = false;

            SqlCommand SELECTCAT = new SqlCommand("SELECT CatName FROM Catagory", Connection);
            try
            {
                Connection.Open();
                SqlDataReader sd = SELECTCAT.ExecuteReader();
                while (sd.Read())
                {
                    Cat.Items.Add(sd["CatName"].ToString());
                }
                Connection.Close();
            }
            catch
            {
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {           
            SalesPrice.BackColor = System.Drawing.Color.White;
            if (SalesPrice.Text != string.Empty)
            {
                try
                {
                    Convert.ToDecimal(SalesPrice.Text);
                    Profit.Text = Convert.ToString(Convert.ToDecimal(SalesPrice.Text) - Convert.ToDecimal(StockPrice.Text) - Convert.ToDecimal(SalesPrice.Text)*Convert.ToDecimal(Discount.SelectedItem)/100);
                    if (Convert.ToDecimal(Profit.Text) < 0)
                        Profit.BackColor = System.Drawing.Color.Red;
                    else
                        Profit.BackColor = System.Drawing.Color.Green;

                }
                catch
                {
                    SalesPrice.Text = "";
                }
            }
        }

       

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            UnitsInStock.BackColor = System.Drawing.Color.White;
            if (UnitsInStock.Text != string.Empty)
            {
                try
                {
                    Convert.ToInt32(UnitsInStock.Text);
                }
                catch
                {
                    UnitsInStock.Text = "";
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            ROL.BackColor = System.Drawing.Color.White;
            if (ROL.Text != string.Empty)
            {
                try
                {
                    Convert.ToInt32(ROL.Text);
                }
                catch
                {
                    ROL.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                if (ItemNo2.SelectedItem.ToString() == ItemNo.Text.ToString())
                    ItemNo2.SelectedItem = ItemNo.Text.ToString();
                else
                    ItemNo2.SelectedIndex = -1;
            }
            catch { }
                        
            try
            {
                SqlCommand SELECTITEM = new SqlCommand("SELECT COUNT(ItemNo) FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                SELECTITEM.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                Connection.Open();
                if (SELECTITEM.ExecuteScalar().ToString() == "1")
                {
                    button4.Text = "Update";
                    button1.Enabled = true;

                    SqlCommand SELECTDES = new SqlCommand("SELECT Descriptions FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTDES.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Des.Text = SELECTDES.ExecuteScalar().ToString();

                    SqlCommand SELECTUNITS = new SqlCommand("SELECT Units FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTUNITS.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Units.Text = SELECTUNITS.ExecuteScalar().ToString();

                    SqlCommand SELECTCAT = new SqlCommand("SELECT Catagory FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTCAT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Cat.SelectedItem = SELECTCAT.ExecuteScalar().ToString();
                    //-*********************************************************************************
                    SqlCommand SELECTSUBCAT = new SqlCommand("SELECT SubCatagory FROM ItemList WHERE ItemNo=@ItemNo",Connection);
                    SELECTSUBCAT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    SubCat.SelectedItem = SELECTSUBCAT.ExecuteScalar().ToString();

                    SqlCommand SELECTSTOCKPRICE = new SqlCommand("SELECT StockPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTSTOCKPRICE.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    StockPrice.Text = SELECTSTOCKPRICE.ExecuteScalar().ToString();

                    SqlCommand SELECTSALESPRICE = new SqlCommand("SELECT SalesPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTSALESPRICE.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    SalesPrice.Text = SELECTSALESPRICE.ExecuteScalar().ToString();

                    SqlCommand SELECTDISCOUNT = new SqlCommand("SELECT Discount FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTDISCOUNT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Discount.Text = SELECTDISCOUNT.ExecuteScalar().ToString();

                    SqlCommand SELECTUNITSINSTOCK = new SqlCommand("SELECT UnitsInStock FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTUNITSINSTOCK.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    UnitsInStock.Text = SELECTUNITSINSTOCK.ExecuteScalar().ToString();

                    SqlCommand SELECTROL = new SqlCommand("SELECT ROL FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTROL.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    ROL.Text = SELECTROL.ExecuteScalar().ToString();
                    
                }
                else
                {
                    button4.Text = "Save";
                    button1.Enabled = false;

                    Des.Text = "";
                    Units.Text = "";
                    StockPrice.Text = "";
                    SalesPrice.Text = "";
                    Discount.SelectedIndex = 0;
                    UnitsInStock.Text = "";
                    ROL.Text = "";
                }
            }
            catch
            {
            }
        }

        private void Cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            SubCat.Items.Clear();
            //ItemNo.Text = "";
            //ItemNo2.Items.Clear();
            try
            {

                SqlCommand SELECTCATDES = new SqlCommand("SELECT Descriptions FROM Catagory WHERE CatName=@CatName", Connection);
                SELECTCATDES.Parameters.AddWithValue("@CatName", Cat.SelectedItem.ToString());
                Connection.Open();
                CatDes.Text = SELECTCATDES.ExecuteScalar().ToString();

                SqlCommand SELECTSUBCAT = new SqlCommand("SELECT SubCatagory FROM SubCatagory WHERE Catagory=@Catagory", Connection);
                SELECTSUBCAT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                
                SqlDataReader ff = SELECTSUBCAT.ExecuteReader();
                
                while (ff.Read())
                {
                    SubCat.Items.Add(ff["SubCatagory"].ToString());
                }
                Connection.Close();
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                Suppliers.Items.Clear();
                //ItemNo.Text = "";

                SqlCommand SELECTSUBCATDES = new SqlCommand("SELECT Descriptions FROM SubCatagory WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELECTSUBCATDES.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELECTSUBCATDES.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());

                SqlCommand SELECTSUP1 = new SqlCommand("SELECT Supplier1 FROM SubCatagory WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELECTSUP1.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELECTSUP1.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());

                SqlCommand SELECTSUP2 = new SqlCommand("SELECT Supplier2 FROM SubCatagory WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELECTSUP2.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELECTSUP2.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());

                SqlCommand SELECTSUP3 = new SqlCommand("SELECT Supplier3 FROM SubCatagory WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELECTSUP3.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELECTSUP3.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());

                Connection.Open();

                SqlCommand SELECTUNIT = new SqlCommand("SELECT Units FROM SubCatagory WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELECTUNIT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELECTUNIT.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());
                Un.Text = SELECTUNIT.ExecuteScalar().ToString();

                SqlCommand SELITNO = new SqlCommand("SELECT ItemNo FROM ItemList WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELITNO.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELITNO.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());
                SqlDataReader aa = SELITNO.ExecuteReader();
                ItemNo2.Items.Clear();
                while (aa.Read())
                {
                    ItemNo2.Items.Add(aa["ItemNo"].ToString());
                }
                aa.Close();

                if (SELECTSUP1.ExecuteScalar().ToString() != " ")
                    Suppliers.Items.Add(SELECTSUP1.ExecuteScalar().ToString());
                if (SELECTSUP2.ExecuteScalar().ToString() != " ")
                    Suppliers.Items.Add(SELECTSUP2.ExecuteScalar().ToString());
                if (SELECTSUP3.ExecuteScalar().ToString() != " ")
                    Suppliers.Items.Add(SELECTSUP3.ExecuteScalar().ToString());

                SubCatDes.Text = SELECTSUBCATDES.ExecuteScalar().ToString();

                Connection.Close();
            }
            catch
            {
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            StockPrice.BackColor = System.Drawing.Color.White;
            if (StockPrice.Text != string.Empty)
            {
                try
                {
                    Convert.ToDecimal(StockPrice.Text);
                }
                catch
                {
                    StockPrice.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            if (Cat.SelectedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please Select a Catagory";
                Cat.Focus();
            }
            else if (SubCat.SelectedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please Select Sub Catagory ";
                SubCat.Focus();
            }
            else if (ItemNo.Text.ToString().Trim(' ') == "")
            {
                toolStripStatusLabel1.Text = "Please Enter Item No";
                ItemNo.Text = "";
                ItemNo.Focus();
            }
            else if (Units.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter Units";
                Units.Text = "";
                Units.Focus();
            }
            else if (StockPrice.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter Stock Price";
                StockPrice.Text = "";
                StockPrice.Focus();
            }
            else if (SalesPrice.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter Sales Price";
                SalesPrice.Text = "";
                SalesPrice.Focus();
            }
            else if (UnitsInStock.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter how many Units have in Stock";
                UnitsInStock.Text = "";
                UnitsInStock.Focus();
            }
            else if (ROL.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter ReOrder Level";
                ROL.Text = "";
                ROL.Focus();
            }
            else if (Convert.ToDecimal(Profit.Text) < 0)
                {
                    MessageBox.Show("Your Stock price larger than Sales Price"+Environment.NewLine+"Enter Correct Value or Change the Discount Rate","Data Entry Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                    SalesPrice.Focus();
                }
            else
            {
                
                try
                {
                    Connection.Open();
                    if (button4.Text.ToString() == "Save")
                    {
                        SqlCommand INSERT = new SqlCommand("INSERT INTO ItemList(ItemNo,Descriptions,Units,Catagory,SubCatagory,StockPrice,SalesPrice,Discount,UnitsInStock,ROL) VALUES(@ItemNo,@Descriptions,@Units,@Catagory,@SubCatagory,@StockPrice,@SalesPrice,@Discount,@UnitsInStock,@ROL)", Connection);
                        INSERT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                        INSERT.Parameters.AddWithValue("@Descriptions", Des.Text.ToString());
                        INSERT.Parameters.AddWithValue("@Units", Units.Text.ToString());
                        INSERT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        INSERT.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());
                        INSERT.Parameters.AddWithValue("@StockPrice", Convert.ToDecimal(StockPrice.Text));
                        INSERT.Parameters.AddWithValue("@SalesPrice", Convert.ToDecimal(SalesPrice.Text));
                        INSERT.Parameters.AddWithValue("@Discount", Convert.ToInt16(Discount.Text));
                        INSERT.Parameters.AddWithValue("@UnitsInStock", Convert.ToInt64(UnitsInStock.Text));
                        INSERT.Parameters.AddWithValue("@ROL", Convert.ToInt32(ROL.Text));


                        if (INSERT.ExecuteNonQuery() == 1)
                        {
                            toolStripStatusLabel1.Text = "Sucessfully Saved";
                            ItemNo2.Items.Add(ItemNo.Text.ToString());
                            ItemNo.Text = "";
                            Des.Text = "";
                            Units.Text = "";
                            StockPrice.Clear();
                            SalesPrice.Text = "";
                            Discount.Text = "";
                            UnitsInStock.Text = "";
                            ROL.Text = "";
                            Profit.Text = "0.0";
                            ItemNo.Focus();
                        }
                        else
                            toolStripStatusLabel1.Text = "Error Item Not Saved";
                    }
                    else
                    {
                        SqlCommand UPDES = new SqlCommand("UPDATE ItemList SET Descriptions=@Descriptions WHERE ItemNo=@ItemNo", Connection);
                        UPDES.Parameters.AddWithValue("@Descriptions", Des.Text.ToString());
                        UPDES.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPUNIT = new SqlCommand("UPDATE ItemList SET Units=@Units WHERE ItemNo=@ItemNo", Connection);
                        UPUNIT.Parameters.AddWithValue("@Units", Units.Text.ToString());
                        UPUNIT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPCAT = new SqlCommand("UPDATE ItemList SET Catagory=@Catagory WHERE ItemNo=@ItemNo", Connection);
                        UPCAT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        UPCAT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPSUBCAT = new SqlCommand("UPDATE ItemList SET SubCatagory=@SubCatagory WHERE ItemNo=@ItemNo", Connection);
                        UPSUBCAT.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());
                        UPSUBCAT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPSTOCKPRICE = new SqlCommand("UPDATE ItemList SET StockPrice=@StockPrice WHERE ItemNo=@ItemNo", Connection);
                        UPSTOCKPRICE.Parameters.AddWithValue("@StockPrice", Convert.ToDecimal(StockPrice.Text));
                        UPSTOCKPRICE.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPSALESPRICE = new SqlCommand("UPDATE ItemList SET SalesPrice=@SalesPrice WHERE ItemNo=@ItemNo",Connection);
                        UPSALESPRICE.Parameters.AddWithValue("@SalesPrice", Convert.ToDecimal(SalesPrice.Text));
                        UPSALESPRICE.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPDISCOUNT = new SqlCommand("UPDATE ItemList SET Discount=@Discount WHERE ItemNo=@ItemNo", Connection);
                        UPDISCOUNT.Parameters.AddWithValue("@Discount", Convert.ToInt16(Discount.Text));
                        UPDISCOUNT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPUNITSINSTOCK = new SqlCommand("UPDATE ItemList SET UnitsInStock=@UnitsInStock WHERE ItemNo=@ItemNo", Connection);
                        UPUNITSINSTOCK.Parameters.AddWithValue("@UnitsInStock", Convert.ToInt64(UnitsInStock.Text));
                        UPUNITSINSTOCK.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        SqlCommand UPROL = new SqlCommand("UPDATE ItemList SET ROL=@ROL WHERE ItemNo=@ItemNo", Connection);
                        UPROL.Parameters.AddWithValue("@ROL", Convert.ToInt32(ROL.Text));
                        UPROL.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                        int a, b, c, d, ei, f, g, h, i;
                        a = UPDES.ExecuteNonQuery();
                        b = UPUNIT.ExecuteNonQuery();
                        c = UPSTOCKPRICE.ExecuteNonQuery();
                        d = UPSALESPRICE.ExecuteNonQuery();
                        ei = UPDISCOUNT.ExecuteNonQuery();
                        f = UPUNITSINSTOCK.ExecuteNonQuery();
                        g = UPROL.ExecuteNonQuery();
                        h = UPCAT.ExecuteNonQuery();
                        i = UPSUBCAT.ExecuteNonQuery();

                        if ((a == 1) && (b == 1) && (c == 1) && (d == 1) && (ei == 1) && (f == 1) && (g == 1) && (h == 1) && (i == 1))
                        {
                            toolStripStatusLabel1.Text = "Update Sucessfully";
                            ItemNo.Text = "";
                            Des.Text = "";
                            Units.Text = "";
                            StockPrice.Text = "";
                            SalesPrice.Text = "";
                            Discount.SelectedIndex = 0;
                            UnitsInStock.Text = "";
                            ROL.Text = "";
                            Profit.Text = "0.0";
                            Cat.Focus();
                        }
                        else
                            toolStripStatusLabel1.Text = "Error, Item Not Updated";

                    }
                    Connection.Close();
                }
                catch
                {
                }
            }
        }

        private void Units_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemNo.Text = "";
            Des.Text = "";
            Units.Text = "";
            StockPrice.Text = "";
            SalesPrice.Text = "";
            Discount.SelectedIndex = 0;
            UnitsInStock.Text = "";
            ROL.Text = "";
            Cat.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                SqlCommand DEL = new SqlCommand("DELETE FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                DEL.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                Connection.Open();
                int a = DEL.ExecuteNonQuery();
                Connection.Close();
                if (a == 1)
                {
                    toolStripStatusLabel1.Text = "Successfully Deleted";
                    ItemNo.Text = "";
                    Des.Text = "";
                    Units.Text = "";
                    StockPrice.Text = "";
                    SalesPrice.Text = "";
                    Discount.SelectedIndex = 0;
                    UnitsInStock.Text = "";
                    ROL.Text = "";
                    Cat.Focus();
                }
                else
                    toolStripStatusLabel1.Text = "Error, Item Not Deleted";
            }
            catch
            {
            }
        }

        private void Profit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((SalesPrice.Text.ToString().Trim(' ')!="")&&(StockPrice.Text.ToString().Trim(' ')!=""))
                Profit.Text = Convert.ToString(Convert.ToDecimal(SalesPrice.Text) - Convert.ToDecimal(StockPrice.Text) - Convert.ToDecimal(SalesPrice.Text) * Convert.ToDecimal(Discount.SelectedItem) / 100);
            if (Convert.ToDecimal(Profit.Text) < 0)
                Profit.BackColor = System.Drawing.Color.Red;
            else
                Profit.BackColor = System.Drawing.Color.Green;
        }

        private void ItemNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                ItemNo.Text = ItemNo2.SelectedItem.ToString();
            }
            catch
            {
            }
            
            try
            {
                SqlCommand SELECTITEM = new SqlCommand("SELECT COUNT(ItemNo) FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                SELECTITEM.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                Connection.Open();
                if (SELECTITEM.ExecuteScalar().ToString() == "1")
                {
                    button4.Text = "Update";
                    button1.Enabled = true;

                    SqlCommand SELECTDES = new SqlCommand("SELECT Descriptions FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTDES.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    Des.Text = SELECTDES.ExecuteScalar().ToString();

                    SqlCommand SELECTUNITS = new SqlCommand("SELECT Units FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTUNITS.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    Units.Text = SELECTUNITS.ExecuteScalar().ToString();

                    SqlCommand SELECTCAT = new SqlCommand("SELECT Catagory FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTCAT.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    Cat.SelectedItem = SELECTCAT.ExecuteScalar().ToString();

                    SqlCommand SELECTSUBCAT = new SqlCommand("SELECT SubCatagory FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTSUBCAT.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    SubCat.SelectedItem = SELECTSUBCAT.ExecuteScalar().ToString();

                    SqlCommand SELECTSTOCKPRICE = new SqlCommand("SELECT StockPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTSTOCKPRICE.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    StockPrice.Text = SELECTSTOCKPRICE.ExecuteScalar().ToString();

                    SqlCommand SELECTSALESPRICE = new SqlCommand("SELECT SalesPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTSALESPRICE.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    SalesPrice.Text = SELECTSALESPRICE.ExecuteScalar().ToString();

                    SqlCommand SELECTDISCOUNT = new SqlCommand("SELECT Discount FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTDISCOUNT.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    Discount.Text = SELECTDISCOUNT.ExecuteScalar().ToString();

                    SqlCommand SELECTUNITSINSTOCK = new SqlCommand("SELECT UnitsInStock FROM ItemList WHERE ItemNo=@ItemNo",Connection);
                    SELECTUNITSINSTOCK.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    UnitsInStock.Text = SELECTUNITSINSTOCK.ExecuteScalar().ToString();

                    SqlCommand SELECTROL = new SqlCommand("SELECT ROL FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTROL.Parameters.AddWithValue("@ItemNo", ItemNo2.SelectedItem.ToString());
                    ROL.Text = SELECTROL.ExecuteScalar().ToString();

                }
                else
                {
                    button4.Text = "Save";
                    button1.Enabled = false;

                    Des.Text = "";
                    Units.Text = "";
                    StockPrice.Text = "";
                    SalesPrice.Text = "";
                    Discount.SelectedIndex = 0;
                    UnitsInStock.Text = "";
                    ROL.Text = "";
                }
            }
            catch
            {
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }

        void Items_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            DataEntry ll = new DataEntry();
            ll.ShowDataEntry();
        }
    }
}