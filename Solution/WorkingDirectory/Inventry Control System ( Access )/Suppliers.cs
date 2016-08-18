using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Inventry_Control_System
{
    public partial class Suppliers : Form
    {
        private OledbCon Con = new OledbCon();

        public Suppliers()
        {
            InitializeComponent();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Names.Text = "";
            Comapny.Text = "";
            Official.Text = "";
            Residential.Text = "";
            TPOffice.Text = "";
            TPResidential.Text = "";
            TPMobile.Text = "";
            Fax.Text = "";
            Web.Text = "";
            Email.Text = "";
            toolStripStatusLabel1.Text = "Cleared";
            Comapny.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection Connection = new OleDbConnection(Con.ConnectionString());

            OleDbCommand DEL = new OleDbCommand("DELETE FROM Suppliers WHERE Company=@Company", Connection);
            DEL.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
            try
            {
                Connection.Open();
                int s=DEL.ExecuteNonQuery();
                Connection.Close();
                if (s == 1)
                {
                    toolStripStatusLabel1.Text = "Successfully Deleted";
                    Names.Text = "";
                    Comapny.Text = "";
                    Official.Text = "";
                    Residential.Text = "";
                    TPOffice.Text = "";
                    TPMobile.Text = "";
                    TPResidential.Text = "";
                    Fax.Text = "";
                    Email.Text = "";
                    Web.Text = "";
                    Comapny.Focus();
                }
            }
            catch 
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
               
                if (Comapny.Text.ToString().Trim(' ') == "")
                {
                    toolStripStatusLabel1.Text = "Please ENter Company Name";
                    Comapny.Text = "";
                    Comapny.Focus();
                }
                else if (Names.Text.ToString().Trim(' ') == "")
                {
                    toolStripStatusLabel1.Text = "Please Enter Name";
                    Names.Text = "";
                    Names.Focus();
                }
                else
                {
                    OleDbConnection Connection = new OleDbConnection(Con.ConnectionString());
                    try
                    {
                        if (button1.Text.ToString() == "Save")
                        {
                            OleDbCommand INSERT = new OleDbCommand("INSERT INTO Suppliers VALUES(@Names,@Company,@OfficeAddress,@ResidentialAddress,@TPOffice,@TPResidential,@TPMobile,@Fax,@Email,@Web)", Connection);
                            INSERT.Parameters.AddWithValue("@Names", Names.Text.ToString());
                            INSERT.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                            INSERT.Parameters.AddWithValue("@OfficeAddress", Residential.Text.ToString());
                            INSERT.Parameters.AddWithValue("@ResidentialAddress", Residential.Text.ToString());
                            INSERT.Parameters.AddWithValue("@TPOffice", TPOffice.Text.ToString());
                            INSERT.Parameters.AddWithValue("@TPResidential", TPResidential.Text.ToString());
                            INSERT.Parameters.AddWithValue("@TPMobile", TPMobile.Text.ToString());
                            INSERT.Parameters.AddWithValue("@Fax", Fax.Text.ToString());
                            INSERT.Parameters.AddWithValue("@Email", Email.Text.ToString());
                            INSERT.Parameters.AddWithValue("@Web", Web.Text.ToString());
                            Connection.Open();
                            int a = INSERT.ExecuteNonQuery();
                            Connection.Close();
                            if (a == 1)
                            {
                                toolStripStatusLabel1.Text = "Successfully Saved";
                                Names.Text = "";
                                Comapny.Text = "";
                                Official.Text = "";
                                Residential.Text = "";
                                TPOffice.Text = "";
                                TPMobile.Text = "";
                                TPResidential.Text = "";
                                Fax.Text = "";
                                Email.Text = "";
                                Web.Text = "";
                            }
                            else
                            {
                                toolStripStatusLabel1.Text = "Error Data Not Saved";
                            }

                        }
                        else
                        {
                            OleDbCommand UPDATENAME = new OleDbCommand("UPDATE Suppliers SET Names=@Names WHERE Company=@Company", Connection);
                            UPDATENAME.Parameters.AddWithValue("@Names", Names.Text.ToString());
                            UPDATENAME.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand ADD1 = new OleDbCommand("UPDATE Suppliers SET OfficeAddress=@OfficeAddress WHERE Company=@Company", Connection);
                            ADD1.Parameters.AddWithValue("@OfficeAddress", Official.Text.ToString());
                            ADD1.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand Add2 = new OleDbCommand("UPDATE Suppliers SET ResidentialAddress=@ResidentialAddress WHERE Company=@Company", Connection);
                            Add2.Parameters.AddWithValue("@ResidentialAddress", Residential.Text.ToString());
                            Add2.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand UPDATETPOFF = new OleDbCommand("UPDATE Suppliers SET TPOffice=@TPOffice WHERE Company=@Company", Connection);
                            UPDATETPOFF.Parameters.AddWithValue("@TPOffice", TPOffice.Text.ToString());
                            UPDATETPOFF.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand UPTPRES = new OleDbCommand("UPDATE Suppliers SET TPResidential=@TPResidential WHERE Company=@Company", Connection);
                            UPTPRES.Parameters.AddWithValue("@TPResidential", TPResidential.Text.ToString());
                            UPTPRES.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand UPTPMOB = new OleDbCommand("UPDATE Suppliers SET TPMobile=@TPMobile WHERE Company=@Company", Connection);
                            UPTPMOB.Parameters.AddWithValue("@TPMobile", TPMobile.Text.ToString());
                            UPTPMOB.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand UPFAX = new OleDbCommand("UPDATE Suppliers Set Fax=@Fax WHERE Company=@Company", Connection);
                            UPFAX.Parameters.AddWithValue("@Fax", Fax.Text.ToString());
                            UPFAX.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand UPEMAIL = new OleDbCommand("UPDATE Suppliers SET Email=@Email WHERE Company=@Company", Connection);
                            UPEMAIL.Parameters.AddWithValue("@Email", Email.Text.ToString());
                            UPEMAIL.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            OleDbCommand UPWEB = new OleDbCommand("UPDATE Suppliers SET Web=@Web WHERE Company=@Company", Connection);
                            UPWEB.Parameters.AddWithValue("@Web", Web.Text.ToString());
                            UPWEB.Parameters.AddWithValue("@Company", Comapny.Text.ToString());

                            Connection.Open();

                            int a, b, c, d, x, f, g, h, i;
                            a = UPDATENAME.ExecuteNonQuery();
                            b = ADD1.ExecuteNonQuery();
                            c = Add2.ExecuteNonQuery();
                            d = UPDATETPOFF.ExecuteNonQuery();
                            x = UPTPRES.ExecuteNonQuery();
                            f = UPTPMOB.ExecuteNonQuery();
                            g = UPFAX.ExecuteNonQuery();
                            h = UPEMAIL.ExecuteNonQuery();
                            i = UPWEB.ExecuteNonQuery();
                            if ((a == 1) && (b == 1) && (c == 1) && (d == 1) && (x == 1) && (f == 1) && (g == 1) && (h == 1) && (i == 1))
                            {
                                toolStripStatusLabel1.Text = "Update Successfully";
                                Names.Text = "";
                                Comapny.Text = "";
                                Official.Text = "";
                                Residential.Text = "";
                                TPOffice.Text = "";
                                TPMobile.Text = "";
                                TPResidential.Text = "";
                                Fax.Text = "";
                                Email.Text = "";
                                Web.Text = "";
                            }

                            Connection.Close();

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Data Fields or unhandled Error Occered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Comapny.Focus();
                }
        }

        private void Comapny_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection Connection = new OleDbConnection(Con.ConnectionString());

            OleDbCommand SELECTd = new OleDbCommand("select count(Company) FROM Suppliers WHERE Company=@Company", Connection);
            SELECTd.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
            Connection.Open();
            if (SELECTd.ExecuteScalar().ToString() == "1")
            {
                OleDbCommand FINDNAME = new OleDbCommand("SELECT Names FROM Suppliers WHERE Company=@Company", Connection);
                FINDNAME.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                Names.Text = FINDNAME.ExecuteScalar().ToString();

                OleDbCommand FINDADD1 = new OleDbCommand("SELECT OfficeAddress FROM Suppliers WHERE Company=@Company", Connection);
                FINDADD1.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                Official.Text = FINDADD1.ExecuteScalar().ToString();

                OleDbCommand FINDADD2 = new OleDbCommand("SELECT ResidentialAddress FROM Suppliers WHERE Company=@Company", Connection);
                FINDADD2.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                Residential.Text = FINDADD2.ExecuteScalar().ToString();

                OleDbCommand FINDTPOFF = new OleDbCommand("SELECT TPOffice FROM Suppliers WHERE Company=@Company", Connection);
                FINDTPOFF.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                TPOffice.Text = FINDTPOFF.ExecuteScalar().ToString();

                OleDbCommand FINDTPMOB = new OleDbCommand("SELECT TPMobile FROM Suppliers WHERE Company=@Company", Connection);
                FINDTPMOB.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                TPMobile.Text = FINDTPMOB.ExecuteScalar().ToString();

                OleDbCommand FINDTPRES = new OleDbCommand("SELECT TPResidential FROM Suppliers WHERE Company=@Company", Connection);
                FINDTPRES.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                TPResidential.Text = FINDTPRES.ExecuteScalar().ToString();

                OleDbCommand FINDFAX = new OleDbCommand("SELECT Fax FROM Suppliers WHERE Company=@Company", Connection);
                FINDFAX.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                Fax.Text = FINDFAX.ExecuteScalar().ToString();

                OleDbCommand FINDEMAIL = new OleDbCommand("SELECT Email FROM Suppliers WHERE Company=@Company", Connection);
                FINDEMAIL.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                Email.Text = FINDEMAIL.ExecuteScalar().ToString();

                OleDbCommand FINDWEB = new OleDbCommand("SELECT Web FROM Suppliers WHERE Company=@Company", Connection);
                FINDWEB.Parameters.AddWithValue("@Company", Comapny.Text.ToString());
                Web.Text = FINDWEB.ExecuteScalar().ToString();

                button1.Text = "Update";
                button3.Enabled = true;
            }
            else
            {
                button1.Text = "Save";
                button3.Enabled = false;
                Names.Text = "";
                Official.Text = "";
                Residential.Text = "";
                TPMobile.Text = "";
                TPOffice.Text="";
                TPResidential.Text="";
                Fax.Text="";
                Email.Text="";
                Web.Text="";
            }
            Connection.Close();
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
        void Suppliers_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            DataEntry kk = new DataEntry();
            kk.ShowDataEntry();
        }     
           
        
    }
}