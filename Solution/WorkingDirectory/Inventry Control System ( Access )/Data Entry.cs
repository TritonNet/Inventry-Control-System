using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventry_Control_System
{
    public partial class DataEntry : Form
    {
        public DataEntry()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Form Sup = new Suppliers();
            this.Hide();
            Sup.ShowDialog();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ww = new SubCatagory();
            this.Hide();
            ww.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form ww = new Items();
            this.Hide();
            ww.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ww = new Catagory();
            this.Hide();
            ww.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About dd = new About();
            dd.Show();
        }
        void DataEntry_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Main dd = new Main();
            dd.ChangeA(1);
            dd.ShowMain();
        }
        public void ShowDataEntry()
        {
            this.Show();
        }
    }
}