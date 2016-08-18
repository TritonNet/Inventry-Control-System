using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventry_Control_System
{
    public partial class Main : Form
    {        
        public Main()
        {
            InitializeComponent();
        }
        int a = 0;
        public void ChangeA(int y)
        {
            a = y;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //System.Threading.Thread.)
            if(a==0)
            {
                Startup pp = new Startup();
                pp.ShowDialog();
            }
            this.Opacity = 0;
            timer1.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((UserName.Text.ToString() == "Admin") && (Password.Text.ToString() == "123"))
            {
                label3.Text = "";
                UserName.Text = "";
                Password.Text = "";
                Form ss = new Administrator();
                this.Hide();
                notifyIcon1.Visible = true;
                ss.Activate();
                ss.Show();
                
            }
            else if ((UserName.Text.ToString() == "Data") && (Password.Text.ToString() == "123"))
            {
                label3.Text = "";
                UserName.Text = "";
                Password.Text = "";
                Form ss = new DataEntry();
                this.Hide();
                notifyIcon1.Visible = true;                
                ss.Show();
                
            }
            else if ((UserName.Text.ToString() == "counter") && (Password.Text == "123"))
            {
                label3.Text = "";
                UserName.Text = "";
                Password.Text = "";
                Form ss = new Select_Cashier();
                this.Hide();
                notifyIcon1.Visible = true;
                ss.Show();
            }
            else
            {
                label3.Text = "Invalid User Name or Password";
                UserName.Text = "";
                Password.Text = "";
                UserName.Focus();
            }
        }
        public void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form df = new About();
            df.ShowDialog();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form df = new About();
            df.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
                timer1.Stop();
            this.Opacity += 0.01;
        }
        public void ShowMain()
        {
            this.Show();
            this.Activate();
        }
        private void Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}