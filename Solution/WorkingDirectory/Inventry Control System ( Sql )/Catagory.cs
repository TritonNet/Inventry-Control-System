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
    public partial class Catagory : Form
    {
        private SqlCon Con = new SqlCon();

        public Catagory()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            SqlCommand DEL = new SqlCommand("DELETE FROM Catagory WHERE CatName=@CatName", Connection);
            DEL.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
            try
            {
                Connection.Open();
                int a = DEL.ExecuteNonQuery();
                Connection.Close();
                if (a == 1)
                {
                    toolStripStatusLabel1.Text = "Successfully Deleted";
                    CatName.Text = "";
                    Des.Text = "";
                    Sup1.Text = "";
                    Sup2.Text = "";
                    Sup3.Text = "";
                    CatName.Focus();
                }
                else
                    toolStripStatusLabel1.Text = "Error Catagory Not Deleted";
            }
            catch
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            if(CatName.Text.ToString().Trim(' ')=="")
            {
                toolStripStatusLabel1.Text = "Please Enter Catagory Name";
                CatName.Text = "";
                CatName.Focus();
            }
            else if ((Sup1.SelectedIndex == -1) && (Sup2.SelectedIndex == -1) && (Sup3.SelectedIndex == -1))
            {
                toolStripStatusLabel1.Text = "Please Select atleast One Supplier for this Catagory";
                Sup1.Focus();                
            }
            else
            {
                
                try
                {
                    if (button1.Text.ToString() == "Save")
                    {
                        SqlCommand INSERT = new SqlCommand("INSERT INTO Catagory(CatName,Descriptions,Supplier1,Supplier2,Supplier3) VALUES(@CatName,@Descriptions,@Supplier1,@Supplier2,@Supplier3)", Connection);
                        INSERT.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
                        INSERT.Parameters.AddWithValue("@Descriptions", Des.Text.ToString());

                        if(Sup1.SelectedIndex!=-1) INSERT.Parameters.AddWithValue("@Supplier1", Sup1.SelectedItem.ToString());
                        else INSERT.Parameters.AddWithValue("@Supplier1", "");

                        if (Sup2.SelectedIndex != -1) INSERT.Parameters.AddWithValue("@Supplier2", Sup2.SelectedItem.ToString());
                        else INSERT.Parameters.AddWithValue("@Supplier2", "");

                        if (Sup3.SelectedIndex != -1) INSERT.Parameters.AddWithValue("@Supplier3", Sup3.SelectedItem.ToString());
                        else INSERT.Parameters.AddWithValue("@Supplier3", "");

                        Connection.Open();
                        int a = INSERT.ExecuteNonQuery();
                        Connection.Close();

                        if (a == 1)
                        {
                            toolStripStatusLabel1.Text = "Successfully Saved";
                            CatName.Text = "";
                            Des.Text = "";
                            Sup1.Text = "";
                            Sup2.Text = "";
                            Sup3.Text = "";
                            CatName.Focus();
                        }
                        else
                            toolStripStatusLabel1.Text = "Error Catagory not Saved";

                        
                    }
                    else
                    {
                        SqlCommand UPDES = new SqlCommand("UPDATE Catagory SET Descriptions=@Descriptions WHERE CatName=@CatName", Connection);
                        UPDES.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
                        UPDES.Parameters.AddWithValue("@Descriptions", Des.Text.ToString());

                        SqlCommand UPSUP1 = new SqlCommand("UPDATE Catagory SET Supplier1=@Supplier1 WHERE CatName=@CatName", Connection);
                        if (Sup1.SelectedIndex != -1) UPSUP1.Parameters.AddWithValue("@Supplier1", Sup1.SelectedItem.ToString());
                        else UPSUP1.Parameters.AddWithValue("@Supplier1", "");
                        UPSUP1.Parameters.AddWithValue("@CatName", CatName.Text.ToString());

                        SqlCommand UPSUP2 = new SqlCommand("UPDATE Catagory SET Supplier2=@Supplier2 WHERE CatName=@CatName", Connection);
                        if (Sup2.SelectedIndex != -1) UPSUP2.Parameters.AddWithValue("@Supplier2", Sup2.SelectedItem.ToString());
                        else UPSUP2.Parameters.AddWithValue("@Supplier2", "");
                        UPSUP2.Parameters.AddWithValue("@CatName", CatName.Text.ToString());

                        SqlCommand UPSUP3 = new SqlCommand("UPDATE Catagory SET Supplier3=@Supplier3 WHERE CatName=@CatName", Connection);
                        if (Sup3.SelectedIndex != -1) UPSUP3.Parameters.AddWithValue("@Supplier3", Sup3.SelectedItem.ToString());
                        else UPSUP3.Parameters.AddWithValue("@Supplier3", "");
                        UPSUP3.Parameters.AddWithValue("@CatName", CatName.Text.ToString());

                        int a, b, c, d;

                        Connection.Open();
                        a = UPDES.ExecuteNonQuery();
                        b = UPSUP1.ExecuteNonQuery();
                        c = UPSUP2.ExecuteNonQuery();
                        d = UPSUP3.ExecuteNonQuery();
                        Connection.Close();

                        if ((a == 1) && (b == 1) && (c == 1) && (d == 1))
                        {
                            toolStripStatusLabel1.Text = "Successfully Updated";
                            CatName.Text = "";
                            Des.Text = "";
                            Sup1.Text = "";
                            Sup2.Text = "";
                            Sup3.Text = "";
                            CatName.Focus();
                        }
                        else
                            toolStripStatusLabel1.Text = "Error Catagory Not Updated";

                        
                    }
                }
                catch
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CatName.Text = "";
            Des.Text = "";
            Sup1.SelectedIndex = -1;
            Sup2.SelectedIndex = -1;
            Sup3.SelectedIndex = -1;
            toolStripStatusLabel1.Text = "Cleared";
            CatName.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Catagory_Load(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            button3.Enabled = false;

            SqlCommand FIND = new SqlCommand("SELECT Company FROM Suppliers", Connection);
            Connection.Open();
            try
            {
                SqlDataReader dd = FIND.ExecuteReader();
                while (dd.Read())
                {
                    Sup1.Items.Add(dd["Company"]);
                    Sup2.Items.Add(dd["Company"]);
                    Sup3.Items.Add(dd["Company"]);
                }
            }
            catch (SqlException s)
            {
                MessageBox.Show(s.ToString(), "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Connection.Close();
        }

        private void CatName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection Connection = new SqlConnection(Con.ConnectionString());

            SqlCommand FINDCAT = new SqlCommand("SELECT COUNT(CatName) FROM Catagory WHERE CatName=@CatName", Connection);
            FINDCAT.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
            Connection.Open();
            if (FINDCAT.ExecuteScalar().ToString() == "1")
                {
                    button1.Text = "Update";
                    button3.Enabled = true;

                    SqlCommand FINDDES = new SqlCommand("SELECT Descriptions FROM Catagory WHERE CatName=@CatName", Connection);
                    FINDDES.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
                    Des.Text = FINDDES.ExecuteScalar().ToString();

                    SqlCommand FINDSUP1 = new SqlCommand("SELECT Supplier1 FROM Catagory WHERE CatName=@CatName", Connection);
                    FINDSUP1.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
                    Sup1.SelectedItem= FINDSUP1.ExecuteScalar().ToString();

                    SqlCommand FINDSUP2 = new SqlCommand("SELECT Supplier2 FROM Catagory WHERE CatName=@CatName",Connection);
                    FINDSUP2.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
                    Sup2.SelectedItem = FINDSUP2.ExecuteScalar().ToString();

                    SqlCommand FINDSUP3 = new SqlCommand("SELECT Supplier3 FROM Catagory WHERE CatName=@CatName", Connection);
                    FINDSUP3.Parameters.AddWithValue("@CatName", CatName.Text.ToString());
                    Sup3.SelectedItem = FINDSUP3.ExecuteScalar().ToString();
                }
                else
                {
                    button1.Text = "Save";
                    button3.Enabled = false;

                    Des.Text = "";
                    Sup1.SelectedIndex = -1;
                    Sup2.SelectedIndex = -1;
                    Sup3.SelectedIndex = -1;
                }
                Connection.Close();
        }

        private void Sup1_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }
        void Catagory_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            DataEntry jj = new DataEntry();
            jj.ShowDataEntry();
        }
    }
}