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
    public partial class Select_Cashier : Form
    {
        private OledbCon Con = new OledbCon();
        
        public Select_Cashier()
        {
            InitializeComponent();
        }

        private void Select_Cashier_Load(object sender, EventArgs e)
        {
            OleDbConnection Connection = new OleDbConnection(Con.ConnectionString());

            Connection.Open();
            OleDbCommand SELCashier = new OleDbCommand("SELECT CashierID FROM Cashier", Connection);
            OleDbDataReader hh = SELCashier.ExecuteReader();
            while (hh.Read())
            {
                comboBox1.Items.Add(hh["CashierID"].ToString());
            }
            hh.Close();
            Connection.Close();
            if (comboBox1.Items.Count == 1)
            {
                comboBox1.SelectedIndex = 0;
                Inventry_Control_System ip = new Inventry_Control_System();
                ip.EnterCashier(comboBox1.SelectedItem.ToString());
                ip.ShowDialog();
                ip.Activate();
                this.Close();
                
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection Connection = new OleDbConnection(Con.ConnectionString());

            try
            {
                Connection.Open();
                OleDbCommand SELCashierName = new OleDbCommand("SELECT CashierName FROM Cashier WHERE CashierID=@CashierID", Connection);
                SELCashierName.Parameters.AddWithValue("@CashierID", comboBox1.SelectedItem.ToString());
                label2.Text = SELCashierName.ExecuteScalar().ToString();
                Connection.Close();
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventry_Control_System gh = new Inventry_Control_System();
            gh.EnterCashier(comboBox1.SelectedItem.ToString());
            gh.ShowDialog();
            gh.Activate();
            this.Close();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }
    }
}