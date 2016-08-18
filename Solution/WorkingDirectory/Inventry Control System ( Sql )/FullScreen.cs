using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventry_Control_System
{
    public partial class FullScreen : Form
    {
        public FullScreen()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void FullScreen_Load(object sender, EventArgs e)
        {
            
        }
        public void Show(ListView hh,string gg,int d)
        {
            if (d == 1)
            {
                Transac.Visible = false;
                for (int a = 0; a < hh.Items.Count; a++)
                {
                    string[] uu ={ hh.Items[a].SubItems[1].Text, hh.Items[a].SubItems[2].Text, hh.Items[a].SubItems[3].Text, hh.Items[a].SubItems[4].Text, hh.Items[a].SubItems[5].Text, hh.Items[a].SubItems[6].Text, hh.Items[a].SubItems[7].Text, hh.Items[a].SubItems[8].Text, hh.Items[a].SubItems[9].Text };
                    S_Rep.Items.Add(hh.Items[a].Text.ToString()).SubItems.AddRange(uu);

                }
            }
            else if(d==2)
            {
                S_Rep.Visible = false;

                for (int a = 0; a < hh.Items.Count; a++)
                {
                    string[] vv ={ hh.Items[a].SubItems[1].Text, hh.Items[a].SubItems[2].Text, hh.Items[a].SubItems[3].Text.Replace('/','-'), hh.Items[a].SubItems[4].Text, hh.Items[a].SubItems[5].Text, hh.Items[a].SubItems[6].Text };
                    Transac.Items.Add(hh.Items[a].Text).SubItems.AddRange(vv);
                }

            }
            label1.Text = gg;
            this.Show();
            Application.DoEvents();
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
    }
}