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
    public partial class SubCatagory : Form
    {
        private SqlCon Con = new SqlCon();
       
        public SubCatagory()
        {
            InitializeComponent();
        }

        private void SubCatagory_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            Sup1.Enabled = false;
            Sup2.Enabled = false;
            Sup3.Enabled = false;
            button3.Enabled = false;

            SqlCommand SELECT = new SqlCommand("SELECT CatName FROM Catagory", Connection);
            try
            {
                Connection.Open();
                SqlDataReader dd = SELECT.ExecuteReader();
                while (dd.Read())
                {
                    Cat.Items.Add(dd["CatName"].ToString());
                }
                Connection.Close();
            }
            catch
            {
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        

        private void Cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            Sup1.Enabled = true;
            Sup2.Enabled = true;
            Sup3.Enabled = true;            
            SubCat.Text = "";
            try
            {
                SqlCommand SELECTSUP1 = new SqlCommand("SELECT Supplier1 FROM Catagory WHERE CatName=@CatName", Connection);
                SELECTSUP1.Parameters.AddWithValue("@CatName", Cat.SelectedItem.ToString());

                SqlCommand SELECTSUP2 = new SqlCommand("SELECT Supplier2 FROM Catagory WHERE CatName=@CatName", Connection);
                SELECTSUP2.Parameters.AddWithValue("@CatName", Cat.SelectedItem.ToString());

                SqlCommand SELECTSUP3 = new SqlCommand("SELECT Supplier3 FROM Catagory WHERE CatName=@CatName", Connection);
                SELECTSUP3.Parameters.AddWithValue("@CatName", Cat.SelectedItem.ToString());


                Connection.Open();
                Sup1.Text = SELECTSUP1.ExecuteScalar().ToString();
                Sup2.Text = SELECTSUP2.ExecuteScalar().ToString();
                Sup3.Text = SELECTSUP3.ExecuteScalar().ToString();
                Connection.Close();
            }
            catch
            {
                //==============================================================
            }
        }

        private void SubCat_TextChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            try
            {
                SqlCommand SELECT = new SqlCommand("SELECT COUNT(SubCatagory) FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                SELECT.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                SELECT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                Connection.Open();
                if (SELECT.ExecuteScalar().ToString() == "1")
                {
                    button1.Text = "Update";
                    button3.Enabled = true;

                    SqlCommand FINDDESC = new SqlCommand("SELECT Descriptions FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                    FINDDESC.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                    FINDDESC.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                    Des.Text = FINDDESC.ExecuteScalar().ToString();

                    SqlCommand FINDSUP1 = new SqlCommand("SELECT Supplier1 FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                    FINDSUP1.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                    FINDSUP1.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                    if (Sup1.Text.ToString() == FINDSUP1.ExecuteScalar().ToString())
                        Sup1.Checked = true;
                    else
                        Sup1.Checked = false;

                    SqlCommand FINDSUP2 = new SqlCommand("SELECT Supplier2 FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                    FINDSUP2.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                    FINDSUP2.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                    if (Sup2.Text.ToString() == FINDSUP2.ExecuteScalar().ToString())
                        Sup2.Checked = true;
                    else
                        Sup2.Checked = false;

                    SqlCommand FINDSUP3 = new SqlCommand("SELECT Supplier3 FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                    FINDSUP3.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                    FINDSUP3.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                    if (Sup3.Text.ToString() == FINDSUP3.ExecuteScalar().ToString())
                        Sup3.Checked = true;
                    else
                        Sup3.Checked = false;

                    SqlCommand FINDUNIT = new SqlCommand("SELECT Units FROM SubCatagory WHERE SubCatagory=@SubCatagory AND Catagory=@Catagory", Connection);
                    FINDUNIT.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                    FINDUNIT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                    unit.Text = FINDUNIT.ExecuteScalar().ToString();

                    
                }
                else
                {
                    button1.Text = "Save";
                    button3.Enabled = false;
                    Des.Text = "";
                    Sup1.Checked = true;
                    Sup2.Checked = true;
                    Sup3.Checked = true;
                    unit.Text = "";
                }
                Connection.Close();
            }
            catch
            {
                //----------------------------------------------------------------
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            if (Cat.SelectedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please Select a Catagory and Enter Sub Catagory for that";
                Cat.Focus();
            }
            else if ((SubCat.Text.ToString().Trim(' ')).ToString() == "")
            {
                toolStripStatusLabel1.Text = "Please Enter Sub Catagory Name";
                SubCat.Text = "";
                SubCat.Focus();
            }
            else if (unit.SelectedIndex == -1)
            {
                toolStripStatusLabel1.Text = "Please Select a Unit for the Sub Catagory";
                unit.Focus();
            }
            else if ((Sup1.Checked==false)&&(Sup2.Checked==false)&&(Sup3.Checked==false))
            {
                toolStripStatusLabel1.Text = "Please Select atleast one Supplier for this Sub Catagory";
                Sup1.Focus();
            }
            else
            {
                try
                {                    
                    if (button1.Text.ToString() == "Save")
                    {
                        SqlCommand INSERT = new SqlCommand("INSERT INTO SubCatagory(Catagory,SubCatagory,Descriptions,Supplier1,Supplier2,Supplier3,Units) VALUES(@Catagory,@SubCatagory,@Descriptions,@Supplier1,@Supplier2,@Supplier3,@Units)", Connection);
                        INSERT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        INSERT.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                        INSERT.Parameters.AddWithValue("@Descriptions", Des.Text.ToString());
                        if (Sup1.Checked == true)
                            INSERT.Parameters.AddWithValue("@Supplier1", Sup1.Text.ToString());
                        else
                            INSERT.Parameters.AddWithValue("@Supplier1", " ");
                        if (Sup2.Checked == true)
                            INSERT.Parameters.AddWithValue("@Supplier2", Sup2.Text.ToString());
                        else
                            INSERT.Parameters.AddWithValue("@Supplier2", " ");
                        if (Sup3.Checked == true)
                            INSERT.Parameters.AddWithValue("@Supplier3", Sup3.Text.ToString());
                        else
                            INSERT.Parameters.AddWithValue("@Supplier3", " ");

                        INSERT.Parameters.AddWithValue("@Units", unit.SelectedItem.ToString());
                        Connection.Open();
                        int a = INSERT.ExecuteNonQuery();
                        Connection.Close();
                        if (a == 1)
                        {
                            toolStripStatusLabel1.Text = "Successfully Saved";
                            SubCat.Text = "";
                            Des.Text = "";
                            Sup1.Checked = true;
                            Sup2.Checked = true;
                            Sup3.Checked = true;
                            unit.SelectedIndex = 0;
                            SubCat.Focus();
                        }
                        else
                        {
                            toolStripStatusLabel1.Text = "Error SubCatagory Not Saved";
                        }
                    }
                    else
                    {
                        SqlCommand UPDES = new SqlCommand("UPDATE SubCatagory SET Descriptions=@Description WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory ", Connection);
                        UPDES.Parameters.AddWithValue("@Description", Des.Text.ToString());
                        UPDES.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        UPDES.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());

                        SqlCommand UPSUP1 = new SqlCommand("UPDATE SubCatagory SET Supplier1=@Supplier1 WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory ", Connection);
                        UPSUP1.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        UPSUP1.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                        if (Sup1.Checked == true)
                            UPSUP1.Parameters.AddWithValue("@Supplier1", Sup1.Text.ToString());
                        else
                            UPSUP1.Parameters.AddWithValue("@Supplier1", " ");

                        SqlCommand UPSUP2 = new SqlCommand("UPDATE SubCatagory SET Supplier2=@Supplier2 WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory ", Connection);
                        UPSUP2.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        UPSUP2.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                        if (Sup2.Checked == true)
                            UPSUP2.Parameters.AddWithValue("@Supplier2", Sup2.Text.ToString());
                        else
                            UPSUP2.Parameters.AddWithValue("@Supplier2", " ");

                        SqlCommand UPSUP3 = new SqlCommand("UPDATE SubCatagory SET Supplier3=@Supplier3 WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory ", Connection);
                        UPSUP3.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        UPSUP3.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                        if (Sup3.Checked == true)
                            UPSUP3.Parameters.AddWithValue("@Supplier3", Sup3.Text.ToString());
                        else
                            UPSUP3.Parameters.AddWithValue("@Supplier3", " ");

                        SqlCommand UPUNIT = new SqlCommand("UPDATE SubCatagory SET Units=@Units WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);
                        UPUNIT.Parameters.AddWithValue("@Units", unit.Text.ToString());
                        UPUNIT.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                        UPUNIT.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());

                        int a, b, c, d, ei;
                        Connection.Open();
                        a = UPDES.ExecuteNonQuery();
                        b = UPSUP1.ExecuteNonQuery();
                        c = UPSUP2.ExecuteNonQuery();
                        d = UPSUP3.ExecuteNonQuery();
                        ei = UPUNIT.ExecuteNonQuery();


                        if ((a == 1) && (b == 1) && (c == 1) && (d == 1) && (ei == 1))
                        {
                            toolStripStatusLabel1.Text = "Successfully Updated";
                            SubCat.Text = "";
                            Des.Text = "";
                            Sup1.Checked = true;
                            Sup2.Checked = true;
                            Sup3.Checked = true;
                            unit.SelectedIndex = 0;
                            SubCat.Focus();
                        }

                    }

                }
                catch (SqlException s)
                {
                    MessageBox.Show(s.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            SqlCommand DELETE = new SqlCommand("DELETE FROM SubCatagory WHERE Catagory=@Catagory AND SubCatagory=@SubCatagory", Connection);            
            try
            {
                DELETE.Parameters.AddWithValue("@SubCatagory", SubCat.Text.ToString());
                DELETE.Parameters.AddWithValue("@Catagory", Cat.SelectedItem.ToString());
                Connection.Open();
                int a = DELETE.ExecuteNonQuery();
                Connection.Close();
                if (a == 1)
                {
                    toolStripStatusLabel1.Text = "Successfully Deleted";
                    SubCat.Text = "";
                    Des.Text = "";
                    Sup1.Checked = true;
                    Sup2.Checked = true;
                    Sup3.Checked = true;
                    unit.SelectedIndex = 0;
                    
                }
                else
                    toolStripStatusLabel1.Text = "Error SubCatagory Not Deleted";
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubCat.Text = "";
            Des.Text = "";
            Sup1.Checked = true;
            Sup2.Checked = true;
            Sup3.Checked = true;
            unit.SelectedIndex = 0;            
            toolStripStatusLabel1.Text = "Cleared";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }
        private void SubCatagory_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            DataEntry jj = new DataEntry();
            jj.ShowDataEntry();
        }
    }
}