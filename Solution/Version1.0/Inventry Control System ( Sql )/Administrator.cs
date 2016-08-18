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
    public partial class Administrator : Form
    {
        private SqlCon Con = new SqlCon();

        int TO_P_NoOfItems = 0;        
        decimal TO_P_TotalAmount = 0.0M;
        decimal TO_P_Profit = 0.0M;

        string StartDay, EndDay;
        public Administrator()
        {
            InitializeComponent();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {            
            //-------------Sales---------------------------------
            SearchTransactions();
            
            DAY.Text = dateTimePicker1.Text.ToString();
            radioButton1.Checked = true;
            panel1.Enabled = false;
            label10.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button1.Enabled = false;
            textBox1.Visible = false;
    
            //---------------------------------------------------
            
            //---------------Have to Order-----------------------
            panel2.Enabled = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            panel3.Visible = false;
            
            //---------------------------------------------------
            //--------------Stock------------------------------------
            AddCategory(comboBox5);
            button3.Enabled = false;
            //-------------------------------------------------------
            //------------Cashier-------------------------------------
            try
            {
                SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                SqlCommand SELCASHIE = new SqlCommand("SELECT CashierName FROM Cashier", Connection);
                Connection.Open();
                SqlDataReader aaa = SELCASHIE.ExecuteReader();
                while (aaa.Read())
                {
                    listBox2.Items.Add(aaa["CashierName"].ToString());
                }
                aaa.Close();
                aaa.Dispose();
                Connection.Close();
            }
            catch
            {
            }
            //--------------------------------------------------------
        }
       /* void GetSalesReport(string FROM,string TO)
        {
            SqlConnection Connection = new SqlConnection(SQLConnectionstring);
            if ((FROM == TO) && (FROM == DateTime.Now.ToShortDateString()))
            {
                groupBox2.Text = "Sales Report   ------  Today -";
                groupBox3.Text = "Today";
            }
            else if (FROM == TO)
            {
                groupBox2.Text = "Sales Report   ------  " + FROM;
                groupBox3.Text = FROM;
            }
            else
            {
                groupBox2.Text = "Sales Report   ------  From " + FROM + "  To " + TO;
                groupBox3.Text = FROM + "  -  " + TO;
            }

            try
            {
                Connection.Open();
                SqlCommand SELECTNOITEMS = new SqlCommand("SELECT SUM(NoOfItems) FROM Transactions WHERE TraDateTime>'" + FROM + " 00:00:00' AND TraDateTime < '" + TO + " 23:59:59'", Connection);
                TO_NoOfItems.Text = SELECTNOITEMS.ExecuteScalar().ToString();

                SqlCommand COUNTTRANSAC = new SqlCommand("SELECT COUNT(TransactionID) FROM Transactions WHERE TraDateTime>'" + FROM + " 00:00:00' AND TraDateTime < '" + TO + " 23:59:59'", Connection);
                TO_NoOfTra.Text = COUNTTRANSAC.ExecuteScalar().ToString();

                SqlCommand COUNTTOTAMT = new SqlCommand("SELECT SUM(TotalAmount) FROM Transactions WHERE TraDateTime>'" + FROM + " 00:00:00' AND TraDateTime < '" + TO + " 23:59:59'", Connection);
                TO_TotalAmt.Text = COUNTTOTAMT.ExecuteScalar().ToString();

                SqlCommand COUNTPROFIT = new SqlCommand("SELECT SUM(Profit) FROM Transactions WHERE TraDateTime>'" + FROM + " 00:00:00' AND TraDateTime < '" + TO + " 23:59:59'", Connection);
                TO_Profit.Text = COUNTPROFIT.ExecuteScalar().ToString();

                ComboBox sas = new ComboBox();
                SqlCommand SALESREP = new SqlCommand("SELECT  TransactionID FROM Transactions WHERE TraDateTime>'" + FROM + " 00:00:00' AND TraDateTime < '" + TO + " 23:59:59'", Connection);                
                SqlDataReader gh=SALESREP.ExecuteReader();
                while (gh.Read())
                {
                    sas.Items.Add(gh["TransactionID"].ToString());
                }
                gh.Close();
                Transac.Items.Clear();
         
                for (int a = 0; a < sas.Items.Count; a++)
                {
                    sas.SelectedIndex = a;
                    SqlCommand SELTRA = new SqlCommand("SELECT *FROM Transactions WHERE TransactionID=@TransactionID", Connection);
                    SELTRA.Parameters.AddWithValue("@TransactionID", sas.SelectedItem.ToString());
                    SqlDataReader gf = SELTRA.ExecuteReader();
                    while (gf.Read())
                    {
                        string[] pp ={ gf["TotalAmount"].ToString(), gf["Discount"].ToString(), gf["TraDateTime"].ToString(), gf["CashierID"].ToString(), gf["NoOfItems"].ToString() };
                        Transac.Items.Add(gf["TransactionID"].ToString()).SubItems.AddRange(pp);
                    }
                    gf.Close();
                }


                S_Rep.Items.Clear();
                S_Rep.Items.Add(" ");
                for (int a = 0; a < sas.Items.Count; a++)
                {
                    sas.SelectedIndex = a;
                    SqlCommand SEINVODET = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID", Connection);
                    SEINVODET.Parameters.AddWithValue("@TransactionID", sas.SelectedItem.ToString());
                    SqlDataReader gg = SEINVODET.ExecuteReader();
                    while (gg.Read())
                    {
                        string[] dfd={gg["ItemNo"].ToString(),gg["Descriptions"].ToString(),gg["Qty"].ToString(),gg["Units"].ToString(),gg["Catagory"].ToString(),gg["SubCatagory"].ToString(),gg["ItemPrice"].ToString(),gg["Discount"].ToString(),gg["TotalAmt"].ToString()};
                        S_Rep.Items.Add(gg["TransactionID"].ToString()).SubItems.AddRange(dfd);
                        
                    }
                    gg.Close();
                }

                Connection.Close();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Error ";
            }
            
        }*///$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        private void tabPage1_Click(object sender, EventArgs e)
        {
                        
        }
        
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            SearchTransactions();
            if (EDay.Checked == true)
                DAY.Text = dateTimePicker1.Text.ToString();
            else if (EMonth.Checked == true)
            {
                if (dateTimePicker1.Value.Month == 12)
                    DAY.Text = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-01   -   " + Convert.ToInt32(dateTimePicker1.Value.Year + 1) + "-01-01";
                else
                    DAY.Text = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-01   -   " + dateTimePicker1.Value.Year + "-" + Convert.ToString(dateTimePicker1.Value.Month + 1) + "-01";
            }
            else if (EYear.Checked == true)
                DAY.Text = dateTimePicker1.Value.Year.ToString() + "-01-01   -   " + Convert.ToString(dateTimePicker1.Value.Year + 1) + "-01-01";
        }

        private void EDay_CheckedChanged(object sender, EventArgs e)
        {            
            DAY.Text = dateTimePicker1.Text.ToString();
            SearchTransactions();            
        }

        private void EMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Month == 12)
                DAY.Text = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-01   -   " + Convert.ToInt32(dateTimePicker1.Value.Year + 1) + "-01-01";
            else
                DAY.Text = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-01   -   " + dateTimePicker1.Value.Year + "-" + Convert.ToString(dateTimePicker1.Value.Month + 1) + "-01";
            SearchTransactions();
        }

        private void EYear_CheckedChanged(object sender, EventArgs e)
        {            
             DAY.Text  = dateTimePicker1.Value.Year.ToString() + "-01-01   -   " + Convert.ToString(dateTimePicker1.Value.Year + 1) + "-01-01";
             SearchTransactions();
        }
        void SearchbyCatagory(string Cat)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            SqlCommand SELITNO=new SqlCommand("SELECT *FROM InvoiceDetails WHERE Catagory=@Catagory",Connection);
            SELITNO.Parameters.AddWithValue("@Catagory", Cat);
            ComboBox www = new ComboBox();
            www.Items.Clear();
            Transac.Items.Clear();
            S_Rep.Items.Clear();
            Connection.Open();
            SqlDataReader wq = SELITNO.ExecuteReader();
            while (wq.Read())
            {
                string[] uuu ={ wq["ItemNo"].ToString(), wq["Descriptions"].ToString(), wq["Qty"].ToString(), wq["Units"].ToString(), wq["Catagory"].ToString(), wq["SubCatagory"].ToString(), wq["ItemPrice"].ToString(), wq["Discount"].ToString(), wq["TotalAmt"].ToString() };
                S_Rep.Items.Add(wq["TransactionID"].ToString()).SubItems.AddRange(uuu);
                www.Items.Add(wq["TransactionID"].ToString());
            }
            wq.Close();

            for (int x = 0; x < www.Items.Count; x++)
            {
                www.SelectedIndex = x;
                SqlCommand SELTRA = new SqlCommand("SELECT *FROM Transactions WHERE TransactionID=@TransactionID", Connection);
                SELTRA.Parameters.AddWithValue("@TransactionID", www.SelectedItem.ToString());
                SqlDataReader hh = SELTRA.ExecuteReader();
                while (hh.Read())
                {
                    string[] yy={hh["TotalAmount"].ToString(),hh["Discount"].ToString(),hh["TraDateTime"].ToString(),hh["CashierID"].ToString(),hh["NoOfItems"].ToString()};
                    Transac.Items.Add(hh["TransactionID"].ToString()).SubItems.AddRange(yy);
                }
                hh.Close();
            }
            Connection.Close();
        }//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }       
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                SearchTransactions();
                panel1.Enabled = false;
                label5.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false; label10.Visible = false;
                textBox1.Visible = false;
                button1.Enabled = false;
                
            }
            else
            {
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel1.Enabled = true;
                button1.Enabled = true;
                radioButton4.Checked = true;
                label5.Visible = true;
                label5.Text = "Select Catagory";
                comboBox1.Visible = true;
                textBox1.Visible = false;                
                AddCategory(comboBox1);
            }
            else
            {

            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            SearchTransactions(); 

        }
        void SearchTransactions()//************************************************************************************************************************************
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            string space = " ";
            
            if (EDay.Checked == true)
            {
                StartDay = dateTimePicker1.Value.ToShortDateString();
                EndDay = dateTimePicker1.Value.ToShortDateString();
            }
            else if (EMonth.Checked == true)
            {
                StartDay = dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-01";
                if (dateTimePicker1.Value.Month == 12)
                    EndDay = Convert.ToString(Convert.ToInt32(dateTimePicker1.Value.Year) + 1) + "-01-01";
                else
                    EndDay = dateTimePicker1.Value.Year + "-" + Convert.ToString(dateTimePicker1.Value.Month + 1) + "-01";
            }
            else if (EYear.Checked == true)
            {
                StartDay = dateTimePicker1.Value.Year.ToString() + "-01-01";
                EndDay = Convert.ToString(dateTimePicker1.Value.Year + 1) + "-01-01";
            }
            else if (All.Checked == true)
            {
                space = "--";
                StartDay = EndDay = "All";

            }
            //============================================================================================================
            if (radioButton1.Checked == false)
            {
                if (radioButton4.Checked == true)
                {
                    if (comboBox1.SelectedIndex == -1)
                    {
                        toolStripStatusLabel1.Text = "Please Select Catagory";
                        comboBox1.Focus();
                    }
                    else
                    {                        
                        this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox5.Font = new System.Drawing.Font("Calibri", 9F);
                        if ((StartDay == EndDay) && (StartDay == DateTime.Now.ToShortDateString()))
                            groupBox3.Text = "Search Result  [  Catagory -" + comboBox1.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ Today ]";
                        else if (StartDay == EndDay)
                            groupBox3.Text = "Search Result  [  Catagory -" + comboBox1.SelectedItem.ToString() + "  ]" + Environment.NewLine +"[ "+ StartDay.Replace('/', '-') + " ]";
                        else
                            groupBox3.Text = "Search Result  [  Catagory -" + comboBox1.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                        groupBox5.Text = "Transactions Detail   [ Search by Category -" + comboBox1.SelectedItem.ToString()+" ]";
                        groupBox2.Text = "Sales Report [  Search by Category -" + comboBox1.SelectedItem.ToString()+" ]";

                        Connection.Open();
                        SqlCommand SELTRA = new SqlCommand("SELECT TransactionID FROM Transactions" + space + " WHERE TraDateTime>'" + StartDay + " 00:00:00' AND TraDateTime < '" + EndDay + " 23:59:59'", Connection);

                        ComboBox TrID = new ComboBox();
                        Transac.Items.Clear();
                        SqlDataReader ff = SELTRA.ExecuteReader();
                        while (ff.Read())
                        {
                            TrID.Items.Add(ff["TransactionID"].ToString());
                        }
                        ff.Close();
                        ComboBox TY = new ComboBox();
                        S_Rep.Items.Clear();
                        for (int a = 0; a < TrID.Items.Count; a++)
                        {
                            TrID.SelectedIndex = a;
                            SqlCommand SELBYCAT = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID AND Catagory=@Catagory", Connection);
                            SELBYCAT.Parameters.AddWithValue("@Catagory", comboBox1.SelectedItem.ToString());
                            SELBYCAT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            SqlDataReader TraID = SELBYCAT.ExecuteReader();
                            while (TraID.Read())
                            {
                                string[] dd ={ TraID["ItemNo"].ToString(), TraID["Descriptions"].ToString(), TraID["Qty"].ToString(), TraID["Units"].ToString(), TraID["Catagory"].ToString(), TraID["SubCatagory"].ToString(), Round(TraID["ItemPrice"].ToString()), Round(TraID["Discount"].ToString()), Round(TraID["TotalAmt"].ToString()) };
                                S_Rep.Items.Add(TraID["TransactionID"].ToString()).SubItems.AddRange(dd);
                                TO_P_NoOfItems+=Convert.ToInt32(TraID["Qty"]);
                                TO_P_TotalAmount+=Convert.ToDecimal(TraID["TotalAmt"]);
                                TO_P_Profit+=Convert.ToDecimal(TraID["Profit"]);
                            }

                            SqlCommand AT = new SqlCommand("SELECT DISTINCT TransactionID FROM InvoiceDetails WHERE TransactionID=@TransactionID AND Catagory=@Catagory", Connection);
                            AT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            AT.Parameters.AddWithValue("@Catagory", comboBox1.SelectedItem.ToString());
                            TraID.Close();
                            SqlDataReader ui = AT.ExecuteReader();
                            while (ui.Read())
                            {
                                TY.Items.Add(ui["TransactionID"].ToString());
                            }
                            ui.Close();
                        }
                        for (int u = 0; u < TY.Items.Count; u++)
                        {
                            TY.SelectedIndex = u;
                            SqlCommand mm = new SqlCommand("SELECT *FROM Transactions WHERE TransactionID=@TransactionID", Connection);
                            mm.Parameters.AddWithValue("@TransactionID", TY.SelectedItem.ToString());
                            SqlDataReader er = mm.ExecuteReader();
                            while (er.Read())
                            {
                                string[] op ={ Round(er["TotalAmount"].ToString()), Round(er["Discount"].ToString()), er["TraDateTime"].ToString(), er["CashierID"].ToString(), er["NoOfItems"].ToString(), Round(er["Profit"].ToString()) };
                                Transac.Items.Add(er["TransactionID"].ToString()).SubItems.AddRange(op);
                            }
                            er.Close();
                        }
                        TY.Items.Clear();
                        TrID.Items.Clear();
                        Connection.Close();

                        AddToMainPannel(TO_P_NoOfItems.ToString(), Transac.Items.Count.ToString(), TO_P_TotalAmount.ToString(), TO_P_Profit.ToString());
                        TO_P_Profit = 0.0M;
                        TO_P_TotalAmount = 0.0M;
                        TO_P_NoOfItems=0;
                        

                    }

                }
                //===========================================================================================================
                else if (radioButton5.Checked == true)
                {
                    if (comboBox1.SelectedIndex == -1)
                    {
                        toolStripStatusLabel1.Text = "Please Select Catagory";
                        comboBox1.Focus();
                    }
                    else if (comboBox2.SelectedIndex == -1)
                    {
                        toolStripStatusLabel1.Text = "Please Select a Sub Category";
                        comboBox2.Focus();
                    }
                    else
                    {
                        this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox5.Font = new System.Drawing.Font("Calibri", 9F);
                        if ((StartDay == EndDay) && (StartDay == DateTime.Now.ToShortDateString()))
                            groupBox3.Text = "Search Result  [  Cat. -" + comboBox1.SelectedItem.ToString() +"] [ SubCat. -"+comboBox2.SelectedItem.ToString()+ "  ]" + Environment.NewLine + "[ Today ]";
                        else if (StartDay == EndDay)
                            groupBox3.Text = "Search Result  [  Cat. -" + comboBox1.SelectedItem.ToString() + "] [ SubCat. -" + comboBox2.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ " + StartDay.Replace('/', '-') + " ]";
                        else
                            groupBox3.Text = "Search Result  [  Cat. -" + comboBox1.SelectedItem.ToString() + "] [ SubCat. -" + comboBox2.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                        groupBox5.Text = "Transactions Detail   [ Search by Cat. -" + comboBox1.SelectedItem.ToString() + "] [ SubCat. -" + comboBox2.SelectedItem.ToString() + " ]";
                        groupBox2.Text = "Sales Report "+Environment.NewLine+"[  Search by Cat. -" + comboBox1.SelectedItem.ToString() + "] [ SubCat. -" + comboBox2.SelectedItem.ToString() + " ]";


                        Connection.Open();
                        SqlCommand SELTRA = new SqlCommand("SELECT TransactionID FROM Transactions " + space + "WHERE TraDateTime>'" + StartDay + " 00:00:00' AND TraDateTime < '" + EndDay + " 23:59:59'", Connection);

                        ComboBox TrID = new ComboBox();
                        Transac.Items.Clear();
                        SqlDataReader ff = SELTRA.ExecuteReader();
                        while (ff.Read())
                        {
                            TrID.Items.Add(ff["TransactionID"].ToString());
                        }
                        ff.Close();
                        ComboBox TY = new ComboBox();
                        S_Rep.Items.Clear();
                        for (int a = 0; a < TrID.Items.Count; a++)
                        {
                            TrID.SelectedIndex = a;
                            SqlCommand SELBYCAT = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID AND Catagory=@Catagory AND SubCatagory=@SubCatagory",Connection);
                            SELBYCAT.Parameters.AddWithValue("@SubCatagory", comboBox2.SelectedItem.ToString());
                            SELBYCAT.Parameters.AddWithValue("@Catagory", comboBox1.SelectedItem.ToString());
                            SELBYCAT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            SqlDataReader TraID = SELBYCAT.ExecuteReader();
                            while (TraID.Read())
                            {
                                string[] dd ={ TraID["ItemNo"].ToString(), TraID["Descriptions"].ToString(), TraID["Qty"].ToString(), TraID["Units"].ToString(), TraID["Catagory"].ToString(), TraID["SubCatagory"].ToString(), Round(TraID["ItemPrice"].ToString()), Round(TraID["Discount"].ToString()), Round(TraID["TotalAmt"].ToString()) };
                                S_Rep.Items.Add(TraID["TransactionID"].ToString()).SubItems.AddRange(dd);
                                TO_P_NoOfItems+=Convert.ToInt32(TraID["Qty"]);
                                TO_P_TotalAmount+=Convert.ToDecimal(TraID["TotalAmt"]);
                                TO_P_Profit+=Convert.ToDecimal(TraID["Profit"]);
                            }

                            SqlCommand AT = new SqlCommand("SELECT DISTINCT TransactionID FROM InvoiceDetails WHERE TransactionID=@TransactionID AND Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                            AT.Parameters.AddWithValue("@SubCatagory", comboBox2.SelectedItem.ToString());
                            AT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            AT.Parameters.AddWithValue("@Catagory", comboBox1.SelectedItem.ToString());
                            TraID.Close();
                            SqlDataReader ui = AT.ExecuteReader();
                            while (ui.Read())
                            {
                                TY.Items.Add(ui["TransactionID"].ToString());
                            }
                            ui.Close();
                        }
                        for (int u = 0; u < TY.Items.Count; u++)
                        {
                            TY.SelectedIndex = u;
                            SqlCommand mm = new SqlCommand("SELECT *FROM Transactions WHERE TransactionID=@TransactionID", Connection);
                            mm.Parameters.AddWithValue("@TransactionID", TY.SelectedItem.ToString());
                            SqlDataReader er = mm.ExecuteReader();
                            while (er.Read())
                            {
                                string[] op ={ Round(er["TotalAmount"].ToString()), Round(er["Discount"].ToString()), er["TraDateTime"].ToString(), er["CashierID"].ToString(), er["NoOfItems"].ToString(), Round(er["Profit"].ToString()) };
                                Transac.Items.Add(er["TransactionID"].ToString()).SubItems.AddRange(op);
                            }
                            er.Close();
                        }
                        TY.Items.Clear();
                        TrID.Items.Clear();
                        Connection.Close();

                        AddToMainPannel(TO_P_NoOfItems.ToString(), Transac.Items.Count.ToString(), TO_P_TotalAmount.ToString(), TO_P_Profit.ToString());
                        TO_P_Profit = 0.0M;
                        TO_P_TotalAmount = 0.0M;                        
                        TO_P_NoOfItems = 0;
                    }

                }
                //=====================================================================================================================================================
                else if (radioButton6.Checked == true)
                {
                    if (textBox1.Text.ToString().Trim() == "")
                    {
                        toolStripStatusLabel1.Text = "Please Enter Transaction ID";
                        textBox1.Focus();
                    }
                    else
                    {
                        this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox5.Font = new System.Drawing.Font("Calibri", 9F);
                        if ((StartDay == EndDay) && (StartDay == DateTime.Now.ToShortDateString()))
                            groupBox3.Text = "Search Result  [  Transaction ID - " + textBox1.Text.ToString() + "  ]" + Environment.NewLine + "[ Today ]";
                        else if (StartDay == EndDay)
                            groupBox3.Text = "Search Result  [  Transaction ID - " + textBox1.Text.ToString() + "  ]" + Environment.NewLine + "[ " + StartDay.Replace('/', '-') + " ]";
                        else
                            groupBox3.Text = "Search Result  [  Transaction ID - " + textBox1.Text.ToString() + "  ]" + Environment.NewLine + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                        groupBox5.Text = "Transactions Detail   [ Search by Transaction ID - " + textBox1.Text.ToString() + " ]";
                        groupBox2.Text = "Sales Report "+Environment.NewLine+"[  Search by Transaction ID - " + textBox1.Text.ToString() + " ]";



                        Connection.Open();
                        SqlCommand SELTRA = new SqlCommand("SELECT *FROM Transactions WHERE TransactionID=@TransactionID " + space + "AND TraDateTime>'" + StartDay + " 00:00:00 ' AND TraDateTime < '" + EndDay + " 23:59:59'", Connection);
                        SELTRA.Parameters.AddWithValue("@TransactionID", textBox1.Text.ToString());
                        ComboBox TrID = new ComboBox();
                        Transac.Items.Clear();
                        SqlDataReader ff = SELTRA.ExecuteReader();
                        while (ff.Read())
                        {
                            string[] eee ={ Round(ff["TotalAmount"].ToString()), Round(ff["Discount"].ToString()), ff["TraDateTime"].ToString(), ff["CashierID"].ToString(), ff["NoOfItems"].ToString(), Round(ff["Profit"].ToString()) };
                            Transac.Items.Add(ff["TransactionID"].ToString()).SubItems.AddRange(eee);
                            TrID.Items.Add(ff["TransactionID"].ToString());

                        }
                        ff.Close();

                        S_Rep.Items.Clear();
                        for (int a = 0; a < TrID.Items.Count; a++)
                        {
                            TrID.SelectedIndex = a;
                            SqlCommand SELBYCAT = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID", Connection);
                            SELBYCAT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            SqlDataReader TraID = SELBYCAT.ExecuteReader();
                            while (TraID.Read())
                            {
                                string[] dd ={ TraID["ItemNo"].ToString(), TraID["Descriptions"].ToString(), TraID["Qty"].ToString(), TraID["Units"].ToString(), TraID["Catagory"].ToString(), TraID["SubCatagory"].ToString(), Round(TraID["ItemPrice"].ToString()), Round(TraID["Discount"].ToString()), Round(TraID["TotalAmt"].ToString()) };
                                S_Rep.Items.Add(TraID["TransactionID"].ToString()).SubItems.AddRange(dd);
                                TO_P_NoOfItems += Convert.ToInt32(TraID["Qty"]);
                                TO_P_Profit += Convert.ToDecimal(TraID["Profit"]);
                                TO_P_TotalAmount += Convert.ToDecimal(TraID["TotalAmt"]);
                            }
                            TraID.Close();

                        }
                        Connection.Close();

                        AddToMainPannel(TO_P_NoOfItems.ToString(), Transac.Items.Count.ToString(), TO_P_TotalAmount.ToString(), TO_P_Profit.ToString());
                        TO_P_Profit = 0.0M;
                        TO_P_TotalAmount = 0.0M;                        
                        TO_P_NoOfItems = 0;

                    }
                }
                //=====================================================================================================================================================
                else if (radioButton7.Checked == true)
                {
                    if (comboBox1.SelectedIndex == -1)
                    {
                        toolStripStatusLabel1.Text = "Please Select Cashier ID";
                        textBox1.Focus();
                    }
                    else
                    {
                        this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox5.Font = new System.Drawing.Font("Calibri", 9F);
                        if ((StartDay == EndDay) && (StartDay == DateTime.Now.ToShortDateString()))
                            groupBox3.Text = "Search Result  [  Transaction ID - " + comboBox1.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ Today ]";
                        else if (StartDay == EndDay)
                            groupBox3.Text = "Search Result  [  Transaction ID - " + comboBox1.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ " + StartDay.Replace('/', '-') + " ]";
                        else
                            groupBox3.Text = "Search Result  [  Transaction ID - " + comboBox1.SelectedItem.ToString() + "  ]" + Environment.NewLine + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                        groupBox5.Text = "Transactions Detail   [ Search by Transaction ID - " + comboBox1.SelectedItem.ToString() + " ]";
                        groupBox2.Text = "Sales Report " + Environment.NewLine + "[  Search by Transaction ID - " + comboBox1.SelectedItem.ToString() + " ]";



                        Connection.Open();
                        SqlCommand SELTRA = new SqlCommand("SELECT *FROM Transactions WHERE CashierID=@CashierID " + space + "AND TraDateTime>'" + StartDay + " 00:00:00 ' AND TraDateTime < '" + EndDay + " 23:59:59'", Connection);
                        SELTRA.Parameters.AddWithValue("@CashierID", comboBox1.SelectedItem.ToString());
                        ComboBox TrID = new ComboBox();
                        Transac.Items.Clear();
                        SqlDataReader ff = SELTRA.ExecuteReader();
                        while (ff.Read())
                        {
                            string[] eee ={ Round(ff["TotalAmount"].ToString()), Round(ff["Discount"].ToString()), ff["TraDateTime"].ToString(), ff["CashierID"].ToString(), ff["NoOfItems"].ToString(), Round(ff["Profit"].ToString()) };
                            Transac.Items.Add(ff["TransactionID"].ToString()).SubItems.AddRange(eee);
                            TrID.Items.Add(ff["TransactionID"].ToString());
                        }
                        ff.Close();

                        S_Rep.Items.Clear();
                        for (int a = 0; a < TrID.Items.Count; a++)
                        {
                            TrID.SelectedIndex = a;
                            SqlCommand SELBYCAT = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID", Connection);
                            SELBYCAT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            SqlDataReader TraID = SELBYCAT.ExecuteReader();
                            while (TraID.Read())
                            {
                                string[] dd ={ TraID["ItemNo"].ToString(), TraID["Descriptions"].ToString(), TraID["Qty"].ToString(), TraID["Units"].ToString(), TraID["Catagory"].ToString(), TraID["SubCatagory"].ToString(), Round(TraID["ItemPrice"].ToString()), Round(TraID["Discount"].ToString()), Round(TraID["TotalAmt"].ToString()) };
                                S_Rep.Items.Add(TraID["TransactionID"].ToString()).SubItems.AddRange(dd);
                                TO_P_NoOfItems += Convert.ToInt32(TraID["Qty"]);
                                TO_P_TotalAmount += Convert.ToDecimal(TraID["TotalAmt"]);
                                TO_P_Profit += Convert.ToDecimal(TraID["Profit"]);
                            }
                            TraID.Close();

                        }
                        Connection.Close();

                        AddToMainPannel(TO_P_NoOfItems.ToString(), Transac.Items.Count.ToString(), TO_P_TotalAmount.ToString(), TO_P_Profit.ToString());
                        TO_P_Profit = 0.0M;
                        TO_P_TotalAmount = 0.0M;                        
                        TO_P_NoOfItems = 0;

                    }
                }
                //=====================================================================================================================================================
                else if (radioButton8.Checked == true)
                {
                    if (textBox1.Text.ToString().Trim() == "")
                    {
                        toolStripStatusLabel1.Text = "Please Enter ItemNo";
                        textBox1.Focus();
                    }
                    else
                    {
                        this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F);
                        this.groupBox5.Font = new System.Drawing.Font("Calibri", 9F);
                        if ((StartDay == EndDay) && (StartDay == DateTime.Now.ToShortDateString()))
                            groupBox3.Text = "Search Result  [  ItemNo - " + textBox1.Text.ToString() + "  ]" + Environment.NewLine + "[ Today ]";
                        else if (StartDay == EndDay)
                            groupBox3.Text = "Search Result  [  ItemNo - " + textBox1.Text.ToString() + "  ]" + Environment.NewLine + "[ " + StartDay.Replace('/', '-') + " ]";
                        else
                            groupBox3.Text = "Search Result  [  ItemNo - " + textBox1.Text.ToString() + "  ]" + Environment.NewLine + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                        groupBox5.Text = "Transactions Detail   [ Search by ItemNo - " + textBox1.Text.ToString() + " ]";
                        groupBox2.Text = "Sales Report " + Environment.NewLine + "[  Search by  - " + textBox1.Text.ToString() + " ]";



                        Connection.Open();
                        SqlCommand SELTRA = new SqlCommand("SELECT TransactionID FROM Transactions" + space + " WHERE TraDateTime>'" + StartDay + " 00:00:00' AND TraDateTime < '" + EndDay + " 23:59:59'", Connection);

                        ComboBox TrID = new ComboBox();
                        Transac.Items.Clear();
                        SqlDataReader ff = SELTRA.ExecuteReader();
                        while (ff.Read())
                        {
                            TrID.Items.Add(ff["TransactionID"].ToString());
                        }
                        ff.Close();
                        ComboBox TY = new ComboBox();
                        S_Rep.Items.Clear();
                        for (int a = 0; a < TrID.Items.Count; a++)
                        {
                            TrID.SelectedIndex = a;
                            SqlCommand SELBYCAT = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID AND ItemNo=@ItemNo", Connection);
                            SELBYCAT.Parameters.AddWithValue("@ItemNo", textBox1.Text.ToString());
                            SELBYCAT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            SqlDataReader TraID = SELBYCAT.ExecuteReader();
                            while (TraID.Read())
                            {
                                string[] dd ={ TraID["ItemNo"].ToString(), TraID["Descriptions"].ToString(), TraID["Qty"].ToString(), TraID["Units"].ToString(), TraID["Catagory"].ToString(), TraID["SubCatagory"].ToString(), Round(TraID["ItemPrice"].ToString()), Round(TraID["Discount"].ToString()), Round(TraID["TotalAmt"].ToString()) };
                                S_Rep.Items.Add(TraID["TransactionID"].ToString()).SubItems.AddRange(dd);
                                TO_P_NoOfItems += Convert.ToInt32(TraID["Qty"]);
                                TO_P_Profit += Convert.ToDecimal(TraID["Profit"]);
                                TO_P_TotalAmount += Convert.ToDecimal(TraID["TotalAmt"]);
                            }

                            SqlCommand AT = new SqlCommand("SELECT DISTINCT TransactionID FROM InvoiceDetails WHERE TransactionID=@TransactionID AND ItemNo=@ItemNo", Connection);
                            AT.Parameters.AddWithValue("@TransactionID", TrID.SelectedItem.ToString());
                            AT.Parameters.AddWithValue("@ItemNo", textBox1.Text.ToString());
                            TraID.Close();
                            SqlDataReader ui = AT.ExecuteReader();
                            while (ui.Read())
                            {
                                TY.Items.Add(ui["TransactionID"].ToString());
                            }
                            ui.Close();
                        }
                        for (int u = 0; u < TY.Items.Count; u++)
                        {
                            TY.SelectedIndex = u;
                            SqlCommand mm = new SqlCommand("SELECT *FROM Transactions WHERE TransactionID=@TransactionID", Connection);
                            mm.Parameters.AddWithValue("@TransactionID", TY.SelectedItem.ToString());
                            SqlDataReader er = mm.ExecuteReader();
                            while (er.Read())
                            {
                                string[] op ={ Round(er["TotalAmount"].ToString()), Round(er["Discount"].ToString()), er["TraDateTime"].ToString(), er["CashierID"].ToString(), er["NoOfItems"].ToString(), Round(er["Profit"].ToString()) };
                                Transac.Items.Add(er["TransactionID"].ToString()).SubItems.AddRange(op);
                            }
                            er.Close();
                        }
                        TY.Items.Clear();
                        TrID.Items.Clear();
                        Connection.Close();

                        AddToMainPannel(TO_P_NoOfItems.ToString(), Transac.Items.Count.ToString(), TO_P_TotalAmount.ToString(), TO_P_Profit.ToString());
                        TO_P_Profit = 0.0M;
                        TO_P_TotalAmount = 0.0M;
                        TO_P_NoOfItems = 0;

                    }
                }
            }
            //=====================================================================================================================================================
            else
            {
                this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F);
                this.groupBox2.Font = new System.Drawing.Font("Calibri", 9F);
                this.groupBox5.Font = new System.Drawing.Font("Calibri", 9F);
                if ((StartDay == EndDay) && (StartDay == DateTime.Now.ToShortDateString()))
                {
                    groupBox3.Text = "Sales Summery" + Environment.NewLine + "[ Today ]";
                    groupBox5.Text = "Transactions Detail  [ Today ]";
                    groupBox2.Text = "Sales Report  [ Today ]";
                }
                else if (StartDay == EndDay)
                {
                    groupBox3.Text = "Sales Summery" + Environment.NewLine + "[ " + StartDay.Replace('/', '-') + " ]";
                    groupBox5.Text = "Transactions Detail  [ " + StartDay.Replace('/', '-') + " ]";
                    groupBox2.Text = "Sales Report  [ "+ StartDay.Replace('/', '-') + " ]";
                }
                else
                {
                    groupBox3.Text = "Sales Summery" + Environment.NewLine + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                    groupBox5.Text = "Transactions Detail  " + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                    groupBox2.Text = "Sales Report  " + "[ FROM  -" + StartDay.Replace('/', '-') + "  TO  -" + EndDay.Replace('/', '-') + " ]";
                }
          
                Transac.Items.Clear();
                S_Rep.Items.Clear();
                SqlCommand SEL = new SqlCommand("SELECT *FROM Transactions" + space + " WHERE TraDateTime>'" + StartDay + " 00:00:00' AND TraDateTime < '" + EndDay + " 23:59:59'", Connection);
                Connection.Open();
                ComboBox kk = new ComboBox();
                SqlDataReader io = SEL.ExecuteReader();
                while (io.Read())
                {
                    string[] hj ={ Round(io["TotalAmount"].ToString()), Round(io["Discount"].ToString()), io["TraDateTime"].ToString(), io["CashierID"].ToString(), io["NoOfItems"].ToString(), Round(io["Profit"].ToString()) };
                    Transac.Items.Add(io["TransactionID"].ToString()).SubItems.AddRange(hj);
                    kk.Items.Add(io["TransactionID"].ToString());
                }
                io.Close();

                for (int y = 0; y < kk.Items.Count; y++)
                {
                    kk.SelectedIndex = y;
                    SqlCommand uu = new SqlCommand("SELECT *FROM InvoiceDetails WHERE TransactionID=@TransactionID", Connection);
                    uu.Parameters.AddWithValue("@TransactionID", kk.SelectedItem.ToString());
                    SqlDataReader rt = uu.ExecuteReader();
                    while (rt.Read())
                    {
                        string[] qw ={ rt["ItemNo"].ToString(), rt["Descriptions"].ToString(), rt["Qty"].ToString(), rt["Units"].ToString(), rt["Catagory"].ToString(), rt["SubCatagory"].ToString(), Round(rt["ItemPrice"].ToString()), Round(rt["Discount"].ToString()), Round(rt["TotalAmt"].ToString()), Round(rt["Profit"].ToString()) };
                        S_Rep.Items.Add(rt["TransactionID"].ToString()).SubItems.AddRange(qw);
                        TO_P_NoOfItems += Convert.ToInt32(rt["Qty"]);
                        TO_P_Profit += Convert.ToDecimal(rt["Profit"]);
                        TO_P_TotalAmount += Convert.ToDecimal(rt["TotalAmt"]);
                    }
                    rt.Close();
                }
                kk.Items.Clear();
                Connection.Close();

                AddToMainPannel(TO_P_NoOfItems.ToString(), Transac.Items.Count.ToString(), TO_P_TotalAmount.ToString(), TO_P_Profit.ToString());
                TO_P_Profit = 0.0M;
                TO_P_TotalAmount = 0.0M;
                TO_P_NoOfItems = 0;
            }
        }//*********************************************************************************************************************************************************************************************************************************************************************************************************************
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {            
            DAY.Text = "All";
            SearchTransactions();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = "Select Category";
            textBox1.Visible = false;
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            label10.Visible = false;                      
            AddCategory(comboBox1);
            comboBox1.Focus();
            
        }

        void AddCategory(ComboBox hh)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                SqlCommand SELCAT = new SqlCommand("SELECT CatName FROM Catagory", Connection);
                Connection.Open();
                SqlDataReader kk = SELCAT.ExecuteReader();
                hh.Items.Clear();
                while (kk.Read())
                {
                    hh.Items.Add(kk["CatName"].ToString());
                }
                kk.Close();
                Connection.Close();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Error";
            }         
        }
        void AddSubCategory(string category,ComboBox dd)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                SqlCommand SELSUBCAT = new SqlCommand("SELECT SubCatagory FROM SubCatagory WHERE Catagory='"+category+"';", Connection);
                Connection.Open();
                SqlDataReader pp = SELSUBCAT.ExecuteReader();
                dd.Items.Clear();
                while (pp.Read())
                {
                    dd.Items.Add(pp["SubCatagory"].ToString());
                }
                pp.Close();
                Connection.Close();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Error";
            }          
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label10.Visible = true;
            comboBox2.Visible = true;
            label10.Text = "Select Sub Catagory";
            comboBox2.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = false;            
            AddCategory(comboBox1);
            comboBox1.Focus();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            label10.Visible = false;
            label5.Text = "Enter Transaction ID";
            textBox1.Visible = true;            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            label5.Text = "Enter Cashier ID";
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            textBox1.Visible = false;
            label10.Visible = false;            

            
            try
            {
                SqlCommand SELCASHIER = new SqlCommand("SELECT CashierID FROM Cashier", Connection);
                comboBox1.Items.Clear();
                Connection.Open();
                SqlDataReader dd = SELCASHIER.ExecuteReader();
                while (dd.Read())
                {
                    comboBox1.Items.Add(dd["CashierID"].ToString());
                }
                dd.Close();
                Connection.Close();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label5.Text = "Enter ItemNo";
            textBox1.Text = "";
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            label10.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            if (radioButton7.Checked == true)
            {               
                try
                {
                    Connection.Open();
                    SqlCommand SELCASHNAME = new SqlCommand("SELECT CashierName FROM Cashier WHERE CashierID='" + comboBox1.SelectedItem.ToString() + "'", Connection);
                    label10.Visible = true;
                    string name = SELCASHNAME.ExecuteScalar().ToString();
                    label10.Text = name.Remove(name.IndexOf(" ")) + Environment.NewLine + name.Substring(name.IndexOf(" ")).TrimStart();
                    Connection.Close();
                }
                catch
                {                    
                    toolStripStatusLabel1.Text = "Error";
                }
            }
            else
            {
                AddSubCategory(comboBox1.SelectedItem.ToString(),comboBox2);
            }
        }
                

        private void Transac_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        void AddToMainPannel(string NoOfItem, string NoOfTran, string TotAmt, string profit)
        {
            TO_NoOfItems.Text = NoOfItem;
            TO_NoOfTra.Text = NoOfTran;
            TO_TotalAmt.Text =Convert.ToString(Math.Round(Convert.ToDecimal(TotAmt),2));
            TO_Profit.Text = Convert.ToString(Math.Round(Convert.ToDecimal(profit), 2));
        }
        string Round(string d)
        {
            return Convert.ToString(Math.Round(Convert.ToDecimal(d), 2));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form hh = new DataEntry();
            hh.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            FullScreen dd = new FullScreen();
            dd.Show(S_Rep,groupBox2.Text.ToString(),1);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FullScreen hh = new FullScreen();
            hh.Show(Transac, groupBox5.Text.ToString(), 2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Transac.GridLines = true;
                S_Rep.GridLines = true;
               
            }
            else
            {
                Transac.GridLines = false;
                S_Rep.GridLines = false;                
            }            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            panel3.Visible = false;

            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            try
            {
                SqlCommand SELALL = new SqlCommand("SELECT I.*,S.Supplier1,S.Supplier2,S.Supplier3 FROM ItemList I,SubCatagory S WHERE I.Catagory=S.Catagory AND I.SubCatagory=S.SubCatagory AND I.UnitsInStock < I.ROL", Connection);
                Connection.Open();
                SqlDataReader dd = SELALL.ExecuteReader();
                while (dd.Read())
                {
                    string[] ee ={ dd["Descriptions"].ToString(), dd["Catagory"].ToString(), dd["SubCatagory"].ToString(), dd["UnitsInStock"].ToString(), dd["ROL"].ToString(), dd["Supplier1"].ToString(), dd["Supplier2"].ToString(), dd["Supplier3"].ToString() };
                    listView1.Items.Add(dd["ItemNo"].ToString()).SubItems.AddRange(ee);
                }
                dd.Close();
                dd.Dispose();
                Connection.Close();
            }
            catch(SqlException d)
            {
                MessageBox.Show(d.Message);
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            AddCategory(comboBox3);
            label12.Visible = false;
            comboBox4.Visible = false;
            label11.Visible = true;
            comboBox3.Visible = true;
            listView1.Items.Clear();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            AddCategory(comboBox3);
            comboBox4.Visible = false;
            label12.Visible = false;
            listView1.Items.Clear();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
            label12.Visible = true;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            AddCategory(comboBox3);
            panel3.Visible = false;
            listView1.Items.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                try
                {
                    SqlCommand SEL = new SqlCommand("select S.Supplier1,S.Supplier2,S.Supplier3,I.ItemNo,I.Descriptions,I.SubCatagory,I.Catagory,I.UnitsInStock,I.ROL FROM SubCatagory S,ItemList I WHERE I.UnitsInStock < I.ROL AND I.Catagory=@Catagory AND S.Catagory=@Catagory AND I.SubCatagory=S.SubCatagory", Connection);
                    SEL.Parameters.AddWithValue("@Catagory", comboBox3.SelectedItem.ToString());
                    Connection.Open();
                    listView1.Items.Clear();
                    SqlDataReader dd = SEL.ExecuteReader();
                    while (dd.Read())
                    {
                        string[] ee ={ dd["Descriptions"].ToString(), dd["Catagory"].ToString(), dd["SubCatagory"].ToString(), dd["UnitsInStock"].ToString(), dd["ROL"].ToString(), dd["Supplier1"].ToString(), dd["Supplier2"].ToString(), dd["Supplier3"].ToString() };
                        listView1.Items.Add(dd["ItemNo"].ToString()).SubItems.AddRange(ee);
                    }
                    dd.Close();
                    dd.Dispose();
                    Connection.Close();
                }
                catch(SqlException k)
                {
                    MessageBox.Show(k.Message, "sdf");
                    toolStripStatusLabel1.Text = "Error";
                }
            }
            if (radioButton11.Checked)
            {
                AddSubCategory(comboBox3.SelectedItem.ToString(), comboBox4);
               
            }
            if (radioButton12.Checked)
            {
                panel3.Visible = true;
                SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                try
                {
                    SqlCommand SELSUPDETAIL = new SqlCommand("SELECT *FROM Suppliers WHERE Company=@Company", Connection);
                    SELSUPDETAIL.Parameters.AddWithValue("@Company", comboBox3.SelectedItem.ToString());
                    Connection.Open();
                    SqlDataReader gg = SELSUPDETAIL.ExecuteReader();
                    while (gg.Read())
                    {
                        label33.Text = gg["Names"].ToString();
                        label34.Text = gg["OfficeAddress"].ToString();
                        label35.Text = gg["ResidentialAddress"].ToString();
                        label36.Text = gg["TPOffice"].ToString();
                        label37.Text = gg["TPResidential"].ToString();
                        label38.Text = gg["TPMobile"].ToString();
                        label39.Text = gg["Fax"].ToString();
                        label40.Text = gg["Email"].ToString();
                        label41.Text = gg["Web"].ToString();
                    }
                    gg.Close();

                    listView1.Items.Clear();
                    SqlCommand SELBYSUP = new SqlCommand("SELECT I.ItemNo,I.Descriptions,I.Units,I.Catagory,I.SubCatagory,I.UnitsInStock,I.ROL,S.Supplier1,S.Supplier2,S.Supplier3 FROM ItemList I,SubCatagory S WHERE I.UnitsInStock < I.ROL AND I.Catagory=S.Catagory AND I.SUbCatagory=S.SubCatagory AND (S.Supplier1=@Supplier OR S.Supplier2=@Supplier OR S.Supplier3=@Supplier)", Connection);
                    SELBYSUP.Parameters.AddWithValue("@Supplier", comboBox3.SelectedItem.ToString());
                    SqlDataReader dd = SELBYSUP.ExecuteReader();
                    while (dd.Read())
                    {
                        string[] ee ={ dd["Descriptions"].ToString(), dd["Catagory"].ToString(), dd["SubCatagory"].ToString(), dd["UnitsInStock"].ToString(), dd["ROL"].ToString(), dd["Supplier1"].ToString(), dd["Supplier2"].ToString(), dd["Supplier3"].ToString() };
                        listView1.Items.Add(dd["ItemNo"].ToString()).SubItems.AddRange(ee);
                    }
                    dd.Close();

                    Connection.Close();
                }
                catch(SqlException h)
                {
                    MessageBox.Show(h.Message);
                    toolStripStatusLabel1.Text = "Error";
                }
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            comboBox4.Visible = false;
            label12.Visible = false;
            label11.Text = "Select Supplier";
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            try
            {
                SqlCommand SELSUP = new SqlCommand("SELECT Company FROM Suppliers", Connection);
                Connection.Open();
                SqlDataReader hh = SELSUP.ExecuteReader();
                comboBox3.Items.Clear();
                while (hh.Read())
                {
                    comboBox3.Items.Add(hh["Company"].ToString());
                }
                hh.Close();
                hh.Dispose();
                Connection.Close();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());
            try
            {
                SqlCommand SELS = new SqlCommand("select S.Supplier1,S.Supplier2,S.Supplier3,I.ItemNo,I.Descriptions,I.SubCatagory,I.Catagory,I.UnitsInStock,I.ROL FROM SubCatagory S,ItemList I WHERE I.UnitsInStock < I.ROL AND I.Catagory=@Catagory AND S.Catagory=@Catagory AND I.SubCatagory=@SubCatagory AND S.SubCatagory=@SubCatagory", Connection);
                SELS.Parameters.AddWithValue("@Catagory", comboBox3.SelectedItem.ToString());
                SELS.Parameters.AddWithValue("@SubCatagory", comboBox4.SelectedItem.ToString());
                Connection.Open();
                listView1.Items.Clear();
                SqlDataReader dd = SELS.ExecuteReader();
                while (dd.Read())
                {
                    string[] ee ={ dd["Descriptions"].ToString(), dd["Catagory"].ToString(), dd["SubCatagory"].ToString(), dd["UnitsInStock"].ToString(), dd["ROL"].ToString(), dd["Supplier1"].ToString(), dd["Supplier2"].ToString(), dd["Supplier3"].ToString() };
                    listView1.Items.Add(dd["ItemNo"].ToString()).SubItems.AddRange(ee);
                }
                dd.Close();
                dd.Dispose();
                Connection.Close();
            }
            catch (SqlException k)
            {
                MessageBox.Show(k.Message, "sdf");
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddSubCategory(comboBox5.SelectedItem.ToString(), comboBox6);
            S_Des.Text = "";
            S_Disco.Text = "";
            S_ROL.Text = "";
            S_SaPrice.Text = "";
            S_StPrice.Text = "";
            S_UnitInST.Text = "";
            S_Units.Text = "";
            listBox1.Items.Clear();
            //ITNO.Text = "";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                S_Des.Text = "";
                S_Disco.Text = "";
                S_ROL.Text = "";
                S_SaPrice.Text = "";
                S_StPrice.Text = "";
                S_UnitInST.Text = "";
                S_Units.Text = "";
                SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                SqlCommand SELITE = new SqlCommand("SELECT ItemNo FROM ItemList WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                SELITE.Parameters.AddWithValue("@Catagory", comboBox5.SelectedItem.ToString());
                SELITE.Parameters.AddWithValue("@SubCatagory", comboBox6.SelectedItem.ToString());
                listBox1.Items.Clear();
                Connection.Open();
                SqlDataReader ss = SELITE.ExecuteReader();
                while (ss.Read())
                {
                    listBox1.Items.Add(ss["ItemNo"].ToString());
                }
                ss.Close();
                ss.Dispose();
                Connection.Close();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                ITNO.Text = listBox1.SelectedItem.ToString();
        }

        private void ITNO_TextChanged(object sender, EventArgs e)
        {
            if (ITNO.Text.Trim() != "")
            {
                
                SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                SqlCommand SELITLIST = new SqlCommand("SELECT I.*,S.Units UN FROM ItemList I,SubCatagory S WHERE I.ItemNo=@ItemNo AND I.SubCatagory=S.SubCatagory AND I.Catagory=S.Catagory", Connection);
                SELITLIST.Parameters.AddWithValue("@ItemNo", ITNO.Text);
                Connection.Open();
                SqlDataReader dd = SELITLIST.ExecuteReader();
                if (dd.HasRows)
                {
                    
                    while (dd.Read())
                    {
                        comboBox5.SelectedItem = dd["Catagory"].ToString();
                        comboBox6.SelectedItem = dd["SubCatagory"].ToString();
                        S_Des.Text = dd["Descriptions"].ToString();
                        S_SaPrice.Text = Round(dd["SalesPrice"].ToString());
                        S_StPrice.Text = Round(dd["StockPrice"].ToString());
                        S_UnitInST.Text = dd["UnitsInStock"].ToString();
                        S_Disco.Text = dd["Discount"].ToString() + " %";
                        S_ROL.Text = dd["ROL"].ToString();
                        S_Units.Text = dd["Units"].ToString()+" "+dd["UN"].ToString();
                    }
                    dd.Close();
                    dd.Dispose();
                    Connection.Close();
                    listBox1.SelectedItem = ITNO.Text;
                }
                else
                {
                    S_Des.Text = "";
                    S_Disco.Text = "";
                    S_ROL.Text = "";
                    S_SaPrice.Text = "";
                    S_StPrice.Text = "";
                    S_UnitInST.Text = "";
                    S_Units.Text = "";
                }
            }
            
        }

        private void ADDUnits_TextChanged(object sender, EventArgs e)
        {
            if (ADDUnits.Text != string.Empty)
            {
                try
                {
                    Convert.ToDecimal(ADDUnits.Text);
                }
                catch
                {
                    ADDUnits.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                SqlCommand SELUNITS = new SqlCommand("SELECT UnitsInStock FROM ItemList WHERE ItemNo=@Itemno", Connection);
                SELUNITS.Parameters.AddWithValue("@ItemNo", ITNO.Text);
                Connection.Open();
                decimal sss = Convert.ToDecimal(SELUNITS.ExecuteScalar());
                sss += Convert.ToDecimal(ADDUnits.Text);
                SqlCommand UPUNIST = new SqlCommand("UPDATE ItemList SET UnitsInStock=@UnitsInStock WHERE ItemNo=@Itemno", Connection);
                UPUNIST.Parameters.AddWithValue("@ItemNo", ITNO.Text);
                UPUNIST.Parameters.AddWithValue("@UnitsInStock", (int)(sss));
                int a = UPUNIST.ExecuteNonQuery();
                if (a != 0)
                {
                    toolStripStatusLabel1.Text = "Successfully Added";
                    ADDUnits.Text = "";
                    S_UnitInST.Text = sss.ToString();
                }
                else
                    toolStripStatusLabel1.Text = "Error Not Added";

                Connection.Close();
            }
            catch(SqlException s)
            {
                MessageBox.Show(s.Message);
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void S_Des_TextChanged(object sender, EventArgs e)
        {
            if (S_Des.Text.Trim() != "")
                button3.Enabled = true;
            else
                button3.Enabled = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                button4.Text = "Update";
                try
                {
                    SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                    SqlCommand SELCASHI = new SqlCommand("SELECT *FROM Cashier WHERE CashierName=@CashierName", Connection);
                    SELCASHI.Parameters.AddWithValue("@CashierName", listBox2.SelectedItem.ToString());
                    Connection.Open();
                    SqlDataReader re = SELCASHI.ExecuteReader();
                    while (re.Read())
                    {
                        CA_ID.Text = re["CashierID"].ToString();
                        CA_Name.Text = re["CashierName"].ToString();
                        CA_Address.Text = re["Address"].ToString();
                        CA_NIC.Text = re["NIC"].ToString();
                        CA_BirthDate.Text = re["BirthDate"].ToString();
                        CA_Gender.SelectedItem = re["Gender"].ToString();
                        CA_TP.Text = re["TelePhone"].ToString();
                        CA_Email.Text = re["Email"].ToString();
                        groupBox11.Text = re["CashierName"].ToString() + " 's Profile";
                    }
                    re.Close();
                    re.Dispose();
                    Connection.Close();
                }
                catch
                {
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Text = "Enter";
            CA_Address.Text = "";
            CA_BirthDate.Text = "";
            CA_Email.Text = "";
            CA_Gender.SelectedIndex = -1;
            CA_ID.Text = "";
            CA_Name.Text = "";
            CA_NIC.Text = ""; 
            CA_TP.Text = "";
            groupBox11.Text = "New";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CA_ID.Text.Trim() == "")
            {
                toolStripStatusLabel1.Text = "Enter Cashier ID";
                CA_ID.Focus();
            }
            else if (CA_Name.Text.Trim()=="")
            {
                toolStripStatusLabel1.Text = "Enter Name";
                CA_Name.Focus();
            }
            else if (CA_NIC.Text.Trim()=="")
            {
                toolStripStatusLabel1.Text = "Enter National Identity Card Number";
                CA_NIC.Focus();
            }
            else if (CA_Gender.SelectedIndex==-1)
            {
                toolStripStatusLabel1.Text = "Enter Gender";
                CA_Gender.Focus();
            }
            else if (CA_BirthDate.Text == DateTime.Now.ToLongDateString())
            {
                toolStripStatusLabel1.Text = "Enter BirthDate Date";
                CA_BirthDate.Focus();
            }
            else
            {
                if (button4.Text == "Enter")
                {
                    SqlConnection Connection = new SqlConnection(Con.ConnectionString());
                    try
                    {
                        SqlCommand INSERT = new SqlCommand("INSERT INTO Cashier VALUES(@CashierID,@CashierName,@Address,@NIC,@BirthDate,@Gender,@Telephone,@Email)", Connection);
                        INSERT.Parameters.AddWithValue("@CashierID", CA_ID.Text);
                        INSERT.Parameters.AddWithValue("@CashierName", CA_Name.Text);
                        INSERT.Parameters.AddWithValue("@Address", CA_Address.Text);
                        INSERT.Parameters.AddWithValue("@NIC", CA_NIC.Text);
                        INSERT.Parameters.AddWithValue("@BirthDate", CA_BirthDate.Text);
                        INSERT.Parameters.AddWithValue("@Gender", CA_Gender.Text);
                        INSERT.Parameters.AddWithValue("@Telephone", CA_TP.Text);
                        INSERT.Parameters.AddWithValue("@Email", CA_Email.Text);
                        Connection.Open();
                        int aa = INSERT.ExecuteNonQuery();
                        if (aa == 1)
                        {
                            toolStripStatusLabel1.Text = "Successfully Inserted";
                            button4.Text = "Enter";
                            CA_Address.Text = "";
                            CA_BirthDate.Text = "";
                            CA_Email.Text = "";
                            CA_Gender.SelectedIndex = -1;
                            CA_ID.Text = "";
                            CA_Name.Text = "";
                            CA_NIC.Text = "";
                            CA_TP.Text = "";
                            listBox2.SelectedIndex = -1;
                            listBox2.Focus();
                        }
                        else
                            toolStripStatusLabel1.Text = "Error Not Saved";
                        Connection.Close();
                    }
                    catch
                    {
                        toolStripStatusLabel1.Text = "Error";
                    }
                }
                else
                {

                }
            }
        }
        
    }
}