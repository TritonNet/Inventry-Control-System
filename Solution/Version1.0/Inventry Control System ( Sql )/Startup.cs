using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventry_Control_System
{
    public partial class Startup : Form
    {
        int a=0;
        int b=0;
        public Startup()
        {
            InitializeComponent();
        }
        
        private void Startup_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label1.Text.Length > 20)
                label1.Text = "Loading";
            label1.Text += ".";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (a != 2)
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.01;
                }
                else
                {
                    a = 1;
                }
            }
            else
            {
                this.Opacity -= 0.05;
            }
            if(a==1)
            {
                System.Threading.Thread.Sleep(3000);
                a = 2;
            }

        }
    }
}