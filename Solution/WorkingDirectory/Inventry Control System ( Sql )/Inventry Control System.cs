using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.IO;


namespace Inventry_Control_System
{
    public partial class Inventry_Control_System : Form
    {
        private SqlCon Con = new SqlCon();
        
        decimal TotalAmount = 0;
        decimal Discount = 0.00M;
        int No = 1;
        int NoOfItems = 0;
        decimal Profit = 0.0M;
        
        public Inventry_Control_System()
        {            
            InitializeComponent();
        }
        static int intCurrentChar;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            if (DD_ItemNo.Items.Count==0)
            {
                toolStripStatusLabel1.Text = "Please Add Items";
                Cash.Text = "";
                Balance.Text = "";
                ItemNo.Focus();
            }
            else if (Cash.Text.ToString().Trim() == "")
            {
                toolStripStatusLabel1.Text = "Enter Cash ";
                Cash.Focus();
            }
            
            else
            {
                if (Cash.Text.IndexOf(".") == -1)
                    Cash.Text = Cash.Text.ToString() + ".00";

                int uu = 0;

                Connection.Open();
                for (int a = 0; a < DD_ItemNo.Items.Count; a++)
                {
                    DD_ItemNo.SelectedIndex = a;
                    DD_Description.SelectedIndex = a;
                    DD_Qty.SelectedIndex = a;
                    DD_Units.SelectedIndex = a;
                    DD_Catagory.SelectedIndex = a;
                    DD_SubCatagory.SelectedIndex = a;
                    DD_ItemPrice.SelectedIndex = a;
                    DD_Discount.SelectedIndex = a;
                    DD_TotalAmt.SelectedIndex = a;
                    DD_Profit.SelectedIndex = a;

                    NoOfItems += Convert.ToInt32(DD_Qty.SelectedItem);

                    SqlCommand INSERTINVOICE = new SqlCommand("INSERT INTO InvoiceDetails(TransactionID,ItemNo,Descriptions,Qty,Units,Catagory,SubCatagory,ItemPrice,Discount,TotalAmt,Profit) VALUES(@TransactionID,@ItemNo,@Descriptions,@Qty,@Units,@Catagory,@SubCatagory,@ItemPrice,@Discount,@TotalAmt,@Profit)", Connection);
                    INSERTINVOICE.Parameters.AddWithValue("@TransactionID", BillNo.Text.ToString());
                    INSERTINVOICE.Parameters.AddWithValue("@ItemNo", DD_ItemNo.SelectedItem.ToString().ToUpper());
                    INSERTINVOICE.Parameters.AddWithValue("@Descriptions", DD_Description.SelectedItem.ToString());
                    INSERTINVOICE.Parameters.AddWithValue("@Qty", Convert.ToDecimal(DD_Qty.SelectedItem));
                    INSERTINVOICE.Parameters.AddWithValue("@Units", DD_Units.SelectedItem.ToString());
                    INSERTINVOICE.Parameters.AddWithValue("@Catagory", DD_Catagory.SelectedItem.ToString());
                    INSERTINVOICE.Parameters.AddWithValue("@SubCatagory", DD_SubCatagory.SelectedItem.ToString());
                    INSERTINVOICE.Parameters.AddWithValue("@ItemPrice", Convert.ToDecimal(DD_ItemPrice.SelectedItem));
                    INSERTINVOICE.Parameters.AddWithValue("@Discount", Convert.ToDecimal(DD_Discount.SelectedItem));
                    INSERTINVOICE.Parameters.AddWithValue("@TotalAmt", Convert.ToDecimal(DD_TotalAmt.SelectedItem));
                    INSERTINVOICE.Parameters.AddWithValue("@Profit", Convert.ToDecimal(DD_Profit.SelectedItem));
                    uu += INSERTINVOICE.ExecuteNonQuery();

                    SqlCommand SELUNITINST = new SqlCommand("SELECT UnitsInStock FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELUNITINST.Parameters.AddWithValue("@ItemNo", DD_ItemNo.SelectedItem.ToString());
                    int ww = Convert.ToInt32(SELUNITINST.ExecuteScalar());
                    ww -= Convert.ToInt32(DD_Qty.SelectedItem);
                    SqlCommand UPSTOCK = new SqlCommand("UPDATE ItemList SET UnitsInStock=@UnitsInStock WHERE ItemNo=@ItemNo", Connection);
                    UPSTOCK.Parameters.AddWithValue("@UnitsInStock", ww);
                    UPSTOCK.Parameters.AddWithValue("@ItemNo", DD_ItemNo.SelectedItem.ToString());
                    UPSTOCK.ExecuteScalar();

                    SqlCommand SESTPRICE = new SqlCommand("SELECT StockPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SESTPRICE.Parameters.AddWithValue("@ItemNo", DD_ItemNo.SelectedItem.ToString());
                    Profit += Convert.ToDecimal(Convert.ToDecimal(DD_TotalAmt.SelectedItem) - (Convert.ToDecimal(SESTPRICE.ExecuteScalar()) * Convert.ToDecimal(DD_Qty.SelectedItem)));

                }
                SqlCommand INSERTTRANSAC = new SqlCommand("INSERT INTO Transactions(TransactionID,TotalAmount,Discount,TraDateTime,CashierID,NoOfItems,Profit) VALUES(@TransactionID,@TotalAmount,@Discount,@TraDateTime,@CashierID,@NoOfItems,@Profit)", Connection);
                INSERTTRANSAC.Parameters.AddWithValue("@TransactionID", BillNo.Text.ToString());
                INSERTTRANSAC.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(NetTot.Text));
                INSERTTRANSAC.Parameters.AddWithValue("@Discount", Convert.ToDecimal(Disco.Text));
                INSERTTRANSAC.Parameters.AddWithValue("@TraDateTime", DateTime.Now.ToString());
                INSERTTRANSAC.Parameters.AddWithValue("@CashierID", Cashier.Text.ToString());
                INSERTTRANSAC.Parameters.AddWithValue("@NoOfItems", NoOfItems);
                INSERTTRANSAC.Parameters.AddWithValue("@Profit", Profit);


                if ((INSERTTRANSAC.ExecuteNonQuery() == 1) && (uu == DD_ItemNo.Items.Count))
                {
                    toolStripStatusLabel1.Text = "Transaction Successfully";

                    DD_ItemNo.Items.Clear();
                    DD_Description.Items.Clear();
                    DD_Qty.Items.Clear();
                    DD_Units.Items.Clear();
                    DD_Catagory.Items.Clear();
                    DD_SubCatagory.Items.Clear();
                    DD_ItemPrice.Items.Clear();
                    DD_Discount.Items.Clear();
                    DD_TotalAmt.Items.Clear();
                    DD_Profit.Items.Clear();

                    AddEndText(TotAmt.Text.ToString(), Disco.Text.ToString(), NetTot.Text.ToString(), Cash.Text.ToString(), Balance.Text.ToString(), NoOfItems.ToString());

                    Cash.Text = "";
                    Balance.Text = "";
                    TotAmt.Text = "0.00";
                    Disco.Text = "0.00";
                    NetTot.Text = "0.00";
                    TotalAmount = 0.0M;
                    Discount = 0.0M;
                    Profit = 0.0M;
                    NoOfItems = 0;
                    BillNo.Text = BillNo.Text.ToString().Remove(3) + Convert.ToString(Convert.ToInt64(BillNo.Text.ToString().Substring(3)) + 1);


                    ItemNo.Focus();
                    System.Threading.Thread.Sleep(1000);
                    Bill.Text = "";
                    AddStartText(Cashier.Text.ToString(), BillNo.Text.ToString());

                }
                else
                    toolStripStatusLabel1.Text = "Error Transaction Not Completed";
                Connection.Close();
            }
            
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {            
            Font font = new Font("Calibri", 8);
            int intPrintAreaHeight = printDocument1.DefaultPageSettings.PaperSize.Height - printDocument1.DefaultPageSettings.Margins.Top - printDocument1.DefaultPageSettings.Margins.Bottom;
            int intPrintAreaWidth = printDocument1.DefaultPageSettings.PaperSize.Width - printDocument1.DefaultPageSettings.Margins.Left - printDocument1.DefaultPageSettings.Margins.Right;
            int marginLeft = printDocument1.DefaultPageSettings.Margins.Left;
            int marginTop = printDocument1.DefaultPageSettings.Margins.Top;
            /*
            if (printDocument1.DefaultPageSettings.Landscape)
            {
                int intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }    */        
            int intLineCount = (int)(intPrintAreaHeight / font.Height);
            
            RectangleF rectPrintingArea = new RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight);
                        
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
                   

            int intLinesFilled;
            int intCharsFitted;

            e.Graphics.MeasureString(Bill.Text.Substring(intCurrentChar), font, new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, out intCharsFitted, out intLinesFilled);

            e.Graphics.DrawString(Bill.Text.Substring(intCurrentChar), font, Brushes.Black, rectPrintingArea, fmt);
                        
            intCurrentChar += intCharsFitted;

            if (intCurrentChar < (Bill.Text.Length - 1))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;                
                intCurrentChar = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            
            if (ItemNo.Text.ToString().Trim(' ') == "")
            {
                toolStripStatusLabel1.Text = "Please Enter a ItemNo";
                ItemNo.Text = "";
                ItemNo.Focus();
            }
            else if (Cat.SelectedIndex==-1)
            {
                toolStripStatusLabel1.Text = "Please Enter Correct ItemNo";
                ItemNo.Text = "";
                ItemNo.Focus();
            }
            else if (Qty.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter Quantity";
                Qty.Text = "";
                Qty.Focus();
            }
            else
            {
                
                SqlCommand SELSTO = new SqlCommand("SELECT UnitsInStock FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                SELSTO.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                SqlCommand SELROL = new SqlCommand("SELECT ROL FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                SELROL.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                Connection.Open();
                if (Convert.ToDecimal(SELSTO.ExecuteScalar())==0)
                {
                    Worning.Visible = true;
                    Worning.ForeColor = System.Drawing.Color.Red;
                    Worning.Text = ItemNo.Text + "'s Stock is over";
                    ItemNo.Focus();
                    timer2.Start();
                    timer3.Start();
                }
                else  if (Convert.ToDecimal(SELSTO.ExecuteScalar()) < Convert.ToDecimal(Qty.Text))
                {
                    Worning.Visible = true;
                    Worning.ForeColor = System.Drawing.Color.Red;
                    Worning.Text = "Unable to add " + ItemNo.Text + ",this Item's Stock has only  " + SELSTO.ExecuteScalar().ToString()+" Items";
                    Qty.Focus();
                    timer2.Start();
                    timer3.Start();
                }               
                else
                {
                    if (Convert.ToDecimal(SELSTO.ExecuteScalar()) == Convert.ToDecimal(Qty.Text))
                    {
                        Worning.Visible = true;
                        Worning.ForeColor = System.Drawing.Color.Red;
                        Worning.Text = ItemNo.Text + " 's Stock is become over" + Environment.NewLine + "After this transaction theres no items in Stock";
                        timer2.Start();
                        timer3.Start();
                    }
                    else if ((Convert.ToDecimal(SELSTO.ExecuteScalar()))<(Convert.ToDecimal(SELROL.ExecuteScalar())))
                    {
                        Worning.Visible = true;
                        Worning.ForeColor = System.Drawing.Color.Orange;
                        Worning.Text = ItemNo.Text + " 's Stock become ReOrder Level";
                        timer2.Start();
                        timer3.Start();
                    }


                    TotalAmount += Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text);
                    TotAmt.Text = Round(TotalAmount.ToString());

                    DD_ItemNo.Items.Add(ItemNo.Text.ToString());
                    DD_Description.Items.Add(Des.Text.ToString());
                    DD_Qty.Items.Add(Qty.Text.ToString());
                    DD_Units.Items.Add(Units.Text.ToString() + " " + label10.Text.ToString());
                    DD_Catagory.Items.Add(Cat.SelectedItem.ToString());
                    DD_SubCatagory.Items.Add(SubCat.SelectedItem.ToString());
                    DD_ItemPrice.Items.Add(Price.Text.ToString());

                    

                    decimal Discou = 0.0M;

                    if (WithDisc.Checked == true)
                    {
                        
                        SqlCommand SELEDISCOUNT = new SqlCommand("SELECT Discount FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                        SELEDISCOUNT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                        Discount += Convert.ToDecimal((Convert.ToDecimal(SELEDISCOUNT.ExecuteScalar()) * Convert.ToDecimal(Price.Text)) / 100) * Convert.ToDecimal(Qty.Text);
                        DD_Discount.Items.Add(Convert.ToDecimal((Convert.ToDecimal(SELEDISCOUNT.ExecuteScalar()) * Convert.ToDecimal(Price.Text)) / 100) * Convert.ToDecimal(Qty.Text));
                        Discou = Convert.ToDecimal((Convert.ToDecimal(SELEDISCOUNT.ExecuteScalar()) * Convert.ToDecimal(Price.Text)) / 100) * Convert.ToDecimal(Qty.Text);
                        
                    }
                    else
                        DD_Discount.Items.Add("0.00");

                    SqlCommand SELSTPRI = new SqlCommand("SELECT StockPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELSTPRI.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    DD_Profit.Items.Add(Convert.ToString(Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text) - Discou - Convert.ToDecimal(SELSTPRI.ExecuteScalar()) * Convert.ToDecimal(Qty.Text)));
                    DD_TotalAmt.Items.Add(Convert.ToString(Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text) - Discou));

                    Discou = 0.0M;


                    AddItem(No.ToString(), ItemNo.Text.ToString(), Des.Text.ToString(), Qty.Text.ToString(), Convert.ToString(Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text)));
                    No++;

                    Disco.Text = Round(Discount.ToString());
                    ItemNo.Text = "";
                    ItemNo2.Items.Clear();
                    Des.Text = "";
                    Cat.SelectedIndex = -1;
                    SubCat.SelectedIndex = -1;
                    Units.Text = "";
                    label10.Text = "";
                    Price.Text = "";
                    WithDisc.Checked = false;
                    Qty.Text = "1";
                    NetTot.Text = Round(Convert.ToString(TotalAmount - Discount));
                    ItemNo.Focus();
                }
                Connection.Close();
            }
        }
        
        private void Inventry_Control_System_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.DayOfWeek.ToString();
            timer1.Start();
            Worning.Visible = false;

            TotAmt.Text = "0.00";
            Disco.Text = "0.00";
            NetTot.Text = "0.00";
            
            
            try
            {
                Connection.Open();

                SqlCommand SELECTCAT = new SqlCommand("SELECT DISTINCT Catagory FROM ItemList", Connection);
                SqlDataReader dd = SELECTCAT.ExecuteReader();
                while (dd.Read())
                {
                    Cat.Items.Add(dd["Catagory"].ToString());
                }
                dd.Close();
                SqlCommand SELECTTRAID = new SqlCommand("SELECT MAX(TransactionID) FROM Transactions", Connection);

                if (SELECTTRAID.ExecuteScalar().ToString() == "") BillNo.Text = "HUD100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUD999999999") BillNo.Text = "HUE100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUE999999999") BillNo.Text = "HUG100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUG999999999") BillNo.Text = "HUH100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUH999999999") BillNo.Text = "HUI100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUI999999999") BillNo.Text = "HUJ100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUJ999999999") BillNo.Text = "HUK100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUK999999999") BillNo.Text = "HUL100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUL999999999") BillNo.Text = "HUM100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUM999999999") BillNo.Text = "HUN100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUN999999999") BillNo.Text = "HUP100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUP999999999") BillNo.Text = "HUQ100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUQ999999999") BillNo.Text = "HUR100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUR999999999") BillNo.Text = "HUS100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUS999999999") BillNo.Text = "HUT100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUT999999999") BillNo.Text = "HUV100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUV999999999") BillNo.Text = "HUW100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUW999999999") BillNo.Text = "HUX100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUX999999999") BillNo.Text = "HUY100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUY999999999") BillNo.Text = "HUZ100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUZ999999999") BillNo.Text = "HUA100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUA999999999") BillNo.Text = "HUB100000001";
                else if (SELECTTRAID.ExecuteScalar().ToString() == "HUB999999999") BillNo.Text = "HUC100000001";
                else
                    BillNo.Text = SELECTTRAID.ExecuteScalar().ToString().Remove(3) + Convert.ToString(Convert.ToInt64(SELECTTRAID.ExecuteScalar().ToString().Substring(3)) + 1);

                Connection.Close();
            }
            catch
            {
               
                toolStripStatusLabel1.Text = "Error";
            }

            AddStartText(Cashier.Text.ToString(),BillNo.Text.ToString());
        }
        public void EnterCashier(string Cashierid)
        {
            Cashier.Text = Cashierid;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.AddSeconds(1).ToLongTimeString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            
            try
            {
                SubCat.Items.Clear();

                Connection.Open();
                SqlCommand SELECTSUBCAT = new SqlCommand("SELECT DISTINCT SubCatagory FROM ItemList WHERE Catagory=@Catagory", Connection);
                SELECTSUBCAT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SqlDataReader dd = SELECTSUBCAT.ExecuteReader();
                while (dd.Read())
                {
                    SubCat.Items.Add(dd["SubCatagory"].ToString());
                }
                Connection.Close();
            }
            catch
            {
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            
            try
            {
                Connection.Open();

                SqlCommand DS = new SqlCommand("SELECT COUNT(ItemNo) FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                DS.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                if (DS.ExecuteScalar().ToString() != "1")
                {
                    ItemNo2.Items.Clear(); 
                    Des.Text = "";
                    Cat.SelectedIndex = -1;
                    SubCat.Items.Clear();
                    Units.Text = "";
                    Price.Text = "";
                    Qty.Text = "1";
                    WithDisc.Checked = false;
                }
                else
                {

                    SqlCommand SELECTDES = new SqlCommand("SELECT Descriptions FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTDES.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Des.Text = SELECTDES.ExecuteScalar().ToString();

                    SqlCommand SELECTCAT = new SqlCommand("SELECT Catagory FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTCAT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Cat.SelectedItem = SELECTCAT.ExecuteScalar().ToString();

                    SqlCommand SELECTSUBCAT = new SqlCommand("SELECT SubCatagory FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTSUBCAT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    SubCat.SelectedItem = SELECTSUBCAT.ExecuteScalar().ToString();

                    SqlCommand SELECTUNITS1 = new SqlCommand("SELECT Units FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTUNITS1.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    SqlCommand SELECTUNITS2 = new SqlCommand("SELECT Units FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                    SELECTUNITS2.Parameters.AddWithValue("@SubCatagory", SELECTSUBCAT.ExecuteScalar().ToString());
                    SELECTUNITS2.Parameters.AddWithValue("@Catagory", SELECTCAT.ExecuteScalar().ToString());
                    SELECTUNITS2.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    Units.Text = SELECTUNITS1.ExecuteScalar().ToString();
                    label10.Text = SELECTUNITS2.ExecuteScalar().ToString();

                    SqlCommand SELECTPRICE = new SqlCommand("SELECT SalesPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELECTPRICE.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                    string aa = SELECTPRICE.ExecuteScalar().ToString();
                    Price.Text = Round(aa.ToString());
                    Connection.Close();
                }
            }
            catch
            {
            }
        }
        string Round(string d)
        {
            return Convert.ToString(Math.Round(Convert.ToDecimal(d), 2));
        }
        private void Qty_TextChanged(object sender, EventArgs e)
        {
            
            Qty.BackColor = System.Drawing.Color.White;
            if (Qty.Text != string.Empty)
            {
                try
                {
                    Convert.ToDecimal(Qty.Text);
                }
                catch
                {
                    Qty.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            if (ItemNo.Text.ToString().Trim() == "")
            {
                Cash.Focus();
            }
            else if (Cat.SelectedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please Enter Correct ItemNo";
                ItemNo.Text = "";
                ItemNo.Focus();
            }
            else if (Qty.Text.ToString().Trim() == "")
            {
                toolStripStatusLabel1.Text = "Please Enter Quantity";
                Qty.Text = "";
                Qty.Focus();
            }
            else
            {
                Connection.Open();
                SqlCommand SELSTO = new SqlCommand("SELECT UnitsInStock FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                SELSTO.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                SqlCommand SELROL = new SqlCommand("SELECT ROL FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                SELROL.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
               
                if (Convert.ToDecimal(SELSTO.ExecuteScalar()) == 0)
                {
                    Worning.Visible = true;
                    Worning.ForeColor = System.Drawing.Color.Red;
                    Worning.Text = ItemNo.Text + "'s Stock is over";
                    ItemNo.Focus();
                    timer2.Start();
                    timer3.Start();
                }
                else  if (Convert.ToDecimal(SELSTO.ExecuteScalar()) < Convert.ToDecimal(Qty.Text))
                {
                    Worning.Visible = true;
                    Worning.ForeColor = System.Drawing.Color.Red;
                    Worning.Text = "Unable to add " + ItemNo.Text + ",this Item's Stock has only  " + SELSTO.ExecuteScalar().ToString()+" Items";
                    Qty.Focus();
                    timer2.Start();
                    timer3.Start();
                }               
                else
                {
                    if (Convert.ToDecimal(SELSTO.ExecuteScalar()) == Convert.ToDecimal(Qty.Text))
                    {
                        Worning.Visible = true;
                        Worning.ForeColor = System.Drawing.Color.Red;
                        Worning.Text = ItemNo.Text + " 's Stock is become over" + Environment.NewLine + "After this transaction theres no items in Stock";
                        timer2.Start();
                        timer3.Start();
                    }
                    else if ((Convert.ToDecimal(SELSTO.ExecuteScalar())) < (Convert.ToDecimal(SELROL.ExecuteScalar())))
                    {
                        Worning.Visible = true;
                        Worning.ForeColor = System.Drawing.Color.Orange;
                        Worning.Text = ItemNo.Text + " 's Stock become ReOrder Level";
                        timer2.Start();
                        timer3.Start();
                    }


                    TotalAmount += Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text);
                    TotAmt.Text = Round(TotalAmount.ToString());

                    DD_ItemNo.Items.Add(ItemNo.Text.ToString());
                    DD_Description.Items.Add(Des.Text.ToString());
                    DD_Qty.Items.Add(Qty.Text.ToString());
                    DD_Units.Items.Add(Units.Text.ToString() + " " + label10.Text.ToString());
                    DD_Catagory.Items.Add(Cat.SelectedItem.ToString());
                    DD_SubCatagory.Items.Add(SubCat.SelectedItem.ToString());
                    DD_ItemPrice.Items.Add(Price.Text.ToString());

                    

                    decimal Discou = 0.0M;

                    if (WithDisc.Checked == true)
                    {

                        SqlCommand SELEDISCOUNT = new SqlCommand("SELECT Discount FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                        SELEDISCOUNT.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());
                        Discount += Convert.ToDecimal((Convert.ToDecimal(SELEDISCOUNT.ExecuteScalar()) * Convert.ToDecimal(Price.Text)) / 100) * Convert.ToDecimal(Qty.Text);
                        DD_Discount.Items.Add(Convert.ToDecimal((Convert.ToDecimal(SELEDISCOUNT.ExecuteScalar()) * Convert.ToDecimal(Price.Text)) / 100) * Convert.ToDecimal(Qty.Text));
                        Discou = Convert.ToDecimal((Convert.ToDecimal(SELEDISCOUNT.ExecuteScalar()) * Convert.ToDecimal(Price.Text)) / 100) * Convert.ToDecimal(Qty.Text);
                        
                    }
                    else
                        DD_Discount.Items.Add("0.00");

                    DD_TotalAmt.Items.Add(Convert.ToString(Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text) - Discou));



                    SqlCommand SELSTPRI = new SqlCommand("SELECT StockPrice FROM ItemList WHERE ItemNo=@ItemNo", Connection);
                    SELSTPRI.Parameters.AddWithValue("@ItemNo", ItemNo.Text.ToString());

                    DD_Profit.Items.Add(Convert.ToString(Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text) - Discou - Convert.ToDecimal(SELSTPRI.ExecuteScalar()) * Convert.ToDecimal(Qty.Text)));
 

                    AddItem(No.ToString(), ItemNo.Text.ToString(), Des.Text.ToString(), Qty.Text.ToString(), Convert.ToString(Convert.ToDecimal(Price.Text) * Convert.ToDecimal(Qty.Text)));

                    Discou = 0.0M;
                    Disco.Text = Round(Discount.ToString());
                    ItemNo.Text = "";
                    ItemNo2.Items.Clear();
                    Des.Text = "";
                    Cat.SelectedIndex = -1;
                    SubCat.SelectedIndex = -1;
                    Units.Text = "";
                    label10.Text = "";
                    Price.Text = "";
                    WithDisc.Checked = false;
                    Qty.Text = "1";
                    NetTot.Text = Round(Convert.ToString(TotalAmount - Discount));
                    Cash.Focus();
                }
                Connection.Close();
            }
        }

        private void Cash_TextChanged(object sender, EventArgs e)
        {
            Cash.BackColor = System.Drawing.Color.White;
            if (Cash.Text != string.Empty)
            {
                try
                {
                    Balance.Text = Convert.ToString(Convert.ToDecimal(Cash.Text)-Convert.ToDecimal(NetTot.Text));
                }
                catch
                {
                    Cash.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bill.Text = "";
            No = 0;

            DD_ItemNo.Items.Clear();
            DD_Description.Items.Clear();
            DD_Qty.Items.Clear();
            DD_Units.Items.Clear();
            DD_Catagory.Items.Clear();
            DD_SubCatagory.Items.Clear();
            DD_ItemPrice.Items.Clear();
            DD_Discount.Items.Clear();
            DD_TotalAmt.Items.Clear();
            DD_Profit.Items.Clear();

            AddStartText(Cashier.Text.ToString(), BillNo.Text.ToString());
            ItemNo.Text = "";
            Des.Text = "";
            Cat.SelectedIndex = -1;
            SubCat.SelectedIndex = -1;
            Units.Text = "";
            label10.Text = "";
            Price.Text = "";
            WithDisc.Checked = false;
            Qty.Text = "1";
            TotAmt.Text = "0.00";
            TotalAmount = 0.0M;
            Disco.Text = "0.00";
            Discount = 0.0M;
            NetTot.Text = "0.00";
            Cash.Text = "";
            Balance.Text = "";
            ItemNo.Focus();
        }

        private void SubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                ItemNo2.Items.Clear();

                SqlCommand SELECTITEM = new SqlCommand("SELECT ItemNo FROM ItemList WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELECTITEM.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                SELECTITEM.Parameters.AddWithValue("@SubCatagory", SubCat.SelectedItem.ToString());
                Connection.Open();
                SqlDataReader dd = SELECTITEM.ExecuteReader();
                
                while (dd.Read())
                {
                    ItemNo2.Items.Add(dd["ItemNo"].ToString());
                }
                Connection.Close();
            }
            catch
            {
            }
        }

        private void ItemNo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemNo.Text = ItemNo2.SelectedItem.ToString();
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Date.Text = DateTime.Now.DayOfWeek.ToString();
        }
        void AddStartText(string cashierNo,string BillNo)
        {
                        
            Bill.Text += Environment.NewLine + Environment.NewLine + Environment.NewLine;
            Bill.Text += "                                        Unileaver Marketing";            
            Bill.Text +=Environment.NewLine+ "                                                     WEL COME"+Environment.NewLine+Environment.NewLine;
            Bill.Text += "  Date              -    " + DateTime.Now.ToShortDateString()+"               Cashier -   "+cashierNo+Environment.NewLine;
            Bill.Text += "  Start Time  -    " + DateTime.Now.Hour + ":"; if (DateTime.Now.Minute < 10) Bill.Text += "0"; Bill.Text += +DateTime.Now.Minute + " Hrs" + Environment.NewLine + "  Bill No   -   " + BillNo + Environment.NewLine + "   -------------------------------------------------------------------------------";            
            Bill.Text +=Environment.NewLine+ "     No   ItemNo       Description                   Qty              Price";
            Bill.Text += Environment.NewLine + "   -------------------------------------------------------------------------------"+Environment.NewLine;
        }
        void AddEndText(string TotalAmt,string Discount,string NetTotal,string Cash,string Balance,string NoITMSold)
        {            
            Bill.Text += "   -------------------------------------------------------------------------------"+Environment.NewLine;
            Bill.Text += "  End Time    -    " + DateTime.Now.Hour + ":"; if (DateTime.Now.Minute < 10) Bill.Text += "0"; Bill.Text += +DateTime.Now.Minute + " Hrs" + Environment.NewLine;
            Bill.Text += "  No Item(s) Sold   -    "+NoITMSold+Environment.NewLine;
            Bill.Text += "                                                       Total Amount   -   ";

            if (TotalAmt.Length == 4)
                Bill.Text += "               ";
            else if (TotalAmt.Length == 5)
                Bill.Text += "            ";
            else if (TotalAmt.Length == 6)
                Bill.Text += "         ";
            else if (TotalAmt.Length == 7)
                Bill.Text += "      ";
            else if (TotalAmt.Length == 8)
                Bill.Text += "  ";
            else if (TotalAmt.Length == 9)
                Bill.Text += "";
            
            Bill.Text += TotalAmt + Environment.NewLine;
            Bill.Text += "                                                       Discount              -   ";

            if (Discount.Length == 4)
                Bill.Text += "               ";
            else if (Discount.Length == 5)
                Bill.Text += "            ";
            else if (Discount.Length == 6)
                Bill.Text += "         ";
            else if (Discount.Length == 7)
                Bill.Text += "      ";
            else if (Discount.Length == 8)
                Bill.Text += "  ";
            else if (Discount.Length == 9)
                Bill.Text += "";

            Bill.Text+=Discount+Environment.NewLine;            
            Bill.Text += "                                                       Net Total              -   ";
            
            if (NetTotal.Length == 4)
                Bill.Text += "               ";
            else if (NetTotal.Length == 5)
                Bill.Text += "            ";
            else if (NetTotal.Length == 6)
                Bill.Text += "         ";
            else if (NetTotal.Length == 7)
                Bill.Text += "      ";
            else if (NetTotal.Length == 8)
                Bill.Text += "  ";
            else if (NetTotal.Length == 9)
                Bill.Text += "";

            Bill.Text+=NetTotal+Environment.NewLine;
            Bill.Text += "                                                       Cash                        -   ";

            if (Cash.Length == 4)
                Bill.Text += "               ";
            else if (Cash.Length == 5)
                Bill.Text += "            ";
            else if (Cash.Length == 6)
                Bill.Text += "         ";
            else if (Cash.Length == 7)
                Bill.Text += "      ";
            else if (Cash.Length == 8)
                Bill.Text += "  ";
            else if (Cash.Length == 9)
                Bill.Text += "";

            Bill.Text += Cash + Environment.NewLine;
            Bill.Text += "                                                       Balance                 -   ";

            if (Balance.Length == 4)
                Bill.Text += "               ";
            else if (Balance.Length == 5)
                Bill.Text += "            ";
            else if (Balance.Length == 6)
                Bill.Text += "         ";
            else if (Balance.Length == 7)
                Bill.Text += "      ";
            else if (Balance.Length == 8)
                Bill.Text += "  ";
            else if (Balance.Length == 9)
                Bill.Text += "";

            Bill.Text += Balance + Environment.NewLine;
            Bill.Text += "   -------------------------------------------------------------------------------"+Environment.NewLine;
            Bill.Text += "                                                  Thank You" + Environment.NewLine + "                                                 Come Again" + Environment.NewLine;
            Bill.Text += "                                        Unileaver Marketing" + Environment.NewLine;
            Bill.Text += "                                  No 97/B, Elwala,Ukuwela" + Environment.NewLine + "                                                       Matale";
            
        }
        void AddItem(string No, string ItNo, string Description, string Qty, string price)
        {
            string Space1 = "";
            string space2 = "";
            string space3 = "";
            if (ItNo.Length == 1) Space1 = "                       ";
            else if (ItNo.Length == 2) Space1 = "                    ";
            else if (ItNo.Length == 3) Space1 = "                  ";
            else if (ItNo.Length == 4) Space1 = "              ";
            else if (ItNo.Length == 5) Space1 = "           ";
            else if (ItNo.Length == 6) Space1 = "        ";
            else if (ItNo.Length == 7) Space1 = "     ";
            else if (ItNo.Length == 8) Space1 = "  ";
            else if (ItNo.Length == 9) Space1 = " ";
            else if (ItNo.Length == 10) Space1 = " ";
            //-----------------------------------------------------------
            if (Description.Length == 1) space2 = "                                            ";
            else if (Description.Length == 2) space2 = "                                        ";
            else if (Description.Length == 3) space2 = "                                     ";
            else if (Description.Length == 4) space2 = "                                  ";
            else if (Description.Length == 5) space2 = "                               ";
            else if (Description.Length == 6) space2 = "                            ";
            else if (Description.Length == 7) space2 = "                         ";
            else if (Description.Length == 8) space2 = "                     ";
            else if (Description.Length == 9) space2 = "                   ";
            else if (Description.Length == 10) space2 = "                ";
            else if (Description.Length == 11) space2 = "             ";
            else if (Description.Length == 12) space2 = "          ";
            else if (Description.Length == 13) space2 = "        ";
            else if (Description.Length == 14) space2 = "      ";
            else if (Description.Length == 15) space2 = " ";
            else if (Description.Length <= 30) space2 = SubSpace2(Description.Substring(Description.IndexOf(' ')));
            else if (Description.Length <= 45) space2 = SubSpace2(Description.Substring(Description.LastIndexOf(" ")));
            else if (Description.Length <= 60) space2 = SubSpace2(Description.Substring(Description.LastIndexOf(" ")));
            else if (Description.Length <= 75) space2 = SubSpace2(Description.Substring(Description.LastIndexOf(" ")));
            else if (Description.Length <= 90) space2 = SubSpace2(Description.Substring(Description.LastIndexOf(" ")));
            else if (Description.Length <= 105) space2 = SubSpace2(Description.Substring(Description.LastIndexOf(" ")));
            else space2 = SubSpace2("12345678901234");

            if (Qty.Length == 1)
            {
                if (price.Length == 4) space3 = "\t              ";
                else if (price.Length == 5) space3 = "\t           ";
                else if (price.Length == 6) space3 = "\t        ";
                else if (price.Length == 7) space3 = "\t     ";
                else if (price.Length == 8) space3 = "\t  ";
                else if (price.Length == 9) space3 = "\t";
                else if (price.Length == 10) space3 = "   ";

            }
            else if (Qty.Length == 2)
            {
                if (price.Length == 4) space3 = "\t              ";
                else if (price.Length == 5) space3 = "\t           ";
                else if (price.Length == 6) space3 = "\t        ";
                else if (price.Length == 7) space3 = "\t     ";
                else if (price.Length == 8) space3 = "\t  ";
                else if (price.Length == 9) space3 = "\t";
                else if (price.Length == 10) space3 = " ";

            }
            else if (Qty.Length == 3) space3 = "";
            else if (Qty.Length == 4) space3 = "";
            else if (Qty.Length == 5) space3 = "";

            Bill.Text += "     " + No + "   " + ItNo + Space1;

            if (false)
            {

            }
            else
            {
                if (Description.Length <= 15)
                    Bill.Text += Description + space2 + Qty + space3 + price + Environment.NewLine;
                else if (Description.Length <= 30)
                    Bill.Text += Description.Remove(Description.IndexOf(' ')) + Environment.NewLine + "                                        " + Description.Substring(Description.IndexOf(' ')) + space2 + Qty + space3 + price + Environment.NewLine;
                else if (Description.Length <= 45)
                {
                    string a1 = Description.Remove(Description.IndexOf(" "));
                    string a2 = Description.Substring(Description.IndexOf(" "));
                    string a3 = a2.Substring(a2.IndexOf(" ", 1));
                    Bill.Text += a1 + Environment.NewLine + "                                       " + a2.Remove(a2.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a3 + space2 + Qty + space3 + price + Environment.NewLine;
                }
                else if (Description.Length <= 60)
                {
                    string a1 = Description.Remove(Description.IndexOf(" ", 1));
                    string a2 = Description.Substring(Description.IndexOf(" ", 1));
                    string a3 = a2.Substring(a2.IndexOf(" ", 1));
                    string a4 = a3.Substring(a3.IndexOf(" ", 1));
                    Bill.Text += a1 + Environment.NewLine + "                                       " + a2.Remove(a2.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a3.Remove(a3.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a4 + space2 + Qty + space3 + price + Environment.NewLine;
                }
                else if (Description.Length <= 75)
                {
                    string a1 = Description.Remove(Description.IndexOf(" ", 1));
                    string a2 = Description.Substring(Description.IndexOf(" ", 1));
                    string a3 = a2.Substring(a2.IndexOf(" ", 1));
                    string a4 = a3.Substring(a3.IndexOf(" ", 1));
                    string a5 = a4.Substring(a4.IndexOf(" ", 1));
                    Bill.Text += a1 + Environment.NewLine + "                                       " + a2.Remove(a2.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a3.Remove(a3.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a4.Remove(a4.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a5 + space2 + Qty + space3 + price + Environment.NewLine;
                }
                else if (Description.Length <= 90)
                {
                    string a1 = Description.Remove(Description.IndexOf(" ", 1));
                    string a2 = Description.Substring(Description.IndexOf(" ", 1));
                    string a3 = a2.Substring(a2.IndexOf(" ", 1));
                    string a4 = a3.Substring(a3.IndexOf(" ", 1));
                    string a5 = a4.Substring(a4.IndexOf(" ", 1));
                    string a6 = a5.Substring(a5.IndexOf(" ", 1));
                    Bill.Text += a1 + Environment.NewLine + "                                       " + a2.Remove(a2.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a3.Remove(a3.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a4.Remove(a4.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a5.Remove(a5.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a6 + space2 + Qty + space3 + price + Environment.NewLine;
                }
                else if (Description.Length <= 105)
                {
                    string a1 = Description.Remove(Description.IndexOf(" ", 1));
                    string a2 = Description.Substring(Description.IndexOf(" ", 1));
                    string a3 = a2.Substring(a2.IndexOf(" ", 1));
                    string a4 = a3.Substring(a3.IndexOf(" ", 1));
                    string a5 = a4.Substring(a4.IndexOf(" ", 1));
                    string a6 = a5.Substring(a5.IndexOf(" ", 1));
                    string a7 = a6.Substring(a6.IndexOf(" ", 1));
                    Bill.Text += a1 + Environment.NewLine + "                                       " + a2.Remove(a2.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a3.Remove(a3.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a4.Remove(a4.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a5.Remove(a5.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a6.Remove(a6.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a7 + space2 + Qty + space3 + price + Environment.NewLine;
                }
                else
                {
                    string a1 = Description.Remove(Description.IndexOf(" ", 1));
                    string a2 = Description.Substring(Description.IndexOf(" ", 1));
                    string a3 = a2.Substring(a2.IndexOf(" ", 1));
                    string a4 = a3.Substring(a3.IndexOf(" ", 1));
                    string a5 = a4.Substring(a4.IndexOf(" ", 1));
                    string a6 = a5.Substring(a5.IndexOf(" ", 1));
                    string a7 = a6.Substring(a6.IndexOf(" ", 1));
                    string a8 = a7.Substring(a7.IndexOf(" ", 1));
                    Bill.Text += a1 + Environment.NewLine + "                                       " + a2.Remove(a2.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a3.Remove(a3.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a4.Remove(a4.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a5.Remove(a5.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a6.Remove(a6.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a7.Remove(a7.IndexOf(" ", 1)) + Environment.NewLine + "                                       " + a8.Remove(4) + "......................" + space2 + Qty + space3 + price + Environment.NewLine;
                }
            }
            
        }
        
        string SubSpace2(string aa)
        {
            if (aa.Length == 1) return "                                              ";
            else if (aa.Length == 2) return "                                          ";
            else if (aa.Length == 3) return "                                       ";
            else if (aa.Length == 4) return "                                    ";
            else if (aa.Length == 5) return "                                 ";
            else if (aa.Length == 6) return "                              ";
            else if (aa.Length == 7) return "                           ";
            else if (aa.Length == 8) return "                       ";
            else if (aa.Length == 9) return "                     ";
            else if (aa.Length == 10) return "                  ";
            else if (aa.Length == 11) return "               ";
            else if (aa.Length == 12) return "            ";
            else if (aa.Length == 13) return "          ";
            else if (aa.Length == 14) return "        ";
            else if (aa.Length == 15) return "   ";
            else return "";
            //else if (aa.Length <= 30) space2 = SubSpace2(Description.Substring(Description.IndexOf(' ')));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog1 = new PageSetupDialog();
            
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.PageSettings = printDocument1.DefaultPageSettings;
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Worning.Visible == true)
                Worning.Visible = false;
            else
                Worning.Visible = true;
        }

        private void WithDisc_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Des_TextChanged(object sender, EventArgs e)
        {

        }

        private void Units_TextChanged(object sender, EventArgs e)
        {

        }

        private void Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void Date_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Worning.Visible = false;
            timer3.Stop();
            timer2.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }
        private void Inventry_Control_System_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Main gg = new Main();
            gg.ChangeA(1);
            gg.ShowMain();
        }

        private void Bill_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}