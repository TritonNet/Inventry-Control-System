namespace Inventry_Control_System
{
    partial class SubCatagory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubCatagory));
            this.Cat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Des = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SubCat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.unit = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Sup1 = new System.Windows.Forms.CheckBox();
            this.Sup2 = new System.Windows.Forms.CheckBox();
            this.Sup3 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cat
            // 
            this.Cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cat.Font = new System.Drawing.Font("Calibri", 10F);
            this.Cat.FormattingEnabled = true;
            this.Cat.Location = new System.Drawing.Point(323, 221);
            this.Cat.Name = "Cat";
            this.Cat.Size = new System.Drawing.Size(454, 23);
            this.Cat.TabIndex = 0;
            this.Cat.SelectedIndexChanged += new System.EventHandler(this.Cat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(207, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catagory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(207, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sub Catagory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(207, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // Des
            // 
            this.Des.Font = new System.Drawing.Font("Calibri", 10F);
            this.Des.Location = new System.Drawing.Point(323, 353);
            this.Des.Multiline = true;
            this.Des.Name = "Des";
            this.Des.Size = new System.Drawing.Size(454, 61);
            this.Des.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10F);
            this.button2.Location = new System.Drawing.Point(591, 634);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10F);
            this.button3.Location = new System.Drawing.Point(702, 634);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 8;
            this.button3.TabStop = false;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SubCat
            // 
            this.SubCat.Font = new System.Drawing.Font("Calibri", 10F);
            this.SubCat.Location = new System.Drawing.Point(323, 288);
            this.SubCat.Name = "SubCat";
            this.SubCat.Size = new System.Drawing.Size(454, 24);
            this.SubCat.TabIndex = 1;
            this.SubCat.TextChanged += new System.EventHandler(this.SubCat_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(207, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(207, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Suppliers";
            // 
            // unit
            // 
            this.unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unit.Font = new System.Drawing.Font("Calibri", 10F);
            this.unit.FormattingEnabled = true;
            this.unit.Items.AddRange(new object[] {
            "pieces",
            "mg",
            "g",
            "Kg",
            "ml",
            "L",
            "KL",
            "mm",
            "m",
            "cm",
            "Yard",
            "bottle"});
            this.unit.Location = new System.Drawing.Point(323, 563);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(197, 23);
            this.unit.TabIndex = 6;
            this.unit.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Calibri", 10F);
            this.button4.Location = new System.Drawing.Point(815, 634);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 18;
            this.button4.TabStop = false;
            this.button4.Text = "Main";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Sup1
            // 
            this.Sup1.AutoSize = true;
            this.Sup1.Checked = true;
            this.Sup1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Sup1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.Sup1.Location = new System.Drawing.Point(323, 451);
            this.Sup1.Name = "Sup1";
            this.Sup1.Size = new System.Drawing.Size(15, 14);
            this.Sup1.TabIndex = 3;
            this.Sup1.UseVisualStyleBackColor = true;
            // 
            // Sup2
            // 
            this.Sup2.AutoSize = true;
            this.Sup2.Checked = true;
            this.Sup2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Sup2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.Sup2.Location = new System.Drawing.Point(323, 481);
            this.Sup2.Name = "Sup2";
            this.Sup2.Size = new System.Drawing.Size(15, 14);
            this.Sup2.TabIndex = 4;
            this.Sup2.UseVisualStyleBackColor = true;
            // 
            // Sup3
            // 
            this.Sup3.AutoSize = true;
            this.Sup3.Checked = true;
            this.Sup3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Sup3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.Sup3.Location = new System.Drawing.Point(323, 511);
            this.Sup3.Name = "Sup3";
            this.Sup3.Size = new System.Drawing.Size(15, 14);
            this.Sup3.TabIndex = 5;
            this.Sup3.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1063, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10F);
            this.button1.Location = new System.Drawing.Point(477, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Black;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.linkLabel1.Location = new System.Drawing.Point(977, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(27, 25);
            this.linkLabel1.TabIndex = 37;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "©";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // SubCatagory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 728);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Sup3);
            this.Controls.Add(this.Sup2);
            this.Controls.Add(this.Sup1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.unit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SubCat);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Des);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SubCatagory";
            this.Text = "SubCatagory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SubCatagory_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SubCatagory_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Des;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox SubCat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox unit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox Sup1;
        private System.Windows.Forms.CheckBox Sup2;
        private System.Windows.Forms.CheckBox Sup3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}