namespace Inventry_Control_System
{
    partial class Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Items));
            this.label1 = new System.Windows.Forms.Label();
            this.ItemNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SalesPrice = new System.Windows.Forms.TextBox();
            this.Cat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SubCat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Discount = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UnitsInStock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ROL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.Des = new System.Windows.Forms.TextBox();
            this.CatDes = new System.Windows.Forms.TextBox();
            this.SubCatDes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Suppliers = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.StockPrice = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Units = new System.Windows.Forms.TextBox();
            this.Un = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Profit = new System.Windows.Forms.TextBox();
            this.ItemNo2 = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(147, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item No";
            // 
            // ItemNo
            // 
            this.ItemNo.Font = new System.Drawing.Font("Calibri", 10F);
            this.ItemNo.Location = new System.Drawing.Point(239, 420);
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.Size = new System.Drawing.Size(137, 24);
            this.ItemNo.TabIndex = 3;
            this.ItemNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(147, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Catagory";
            // 
            // SalesPrice
            // 
            this.SalesPrice.Font = new System.Drawing.Font("Calibri", 10F);
            this.SalesPrice.Location = new System.Drawing.Point(654, 455);
            this.SalesPrice.Name = "SalesPrice";
            this.SalesPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SalesPrice.Size = new System.Drawing.Size(137, 24);
            this.SalesPrice.TabIndex = 7;
            this.SalesPrice.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Cat
            // 
            this.Cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cat.Font = new System.Drawing.Font("Calibri", 10F);
            this.Cat.FormattingEnabled = true;
            this.Cat.Location = new System.Drawing.Point(239, 180);
            this.Cat.Name = "Cat";
            this.Cat.Size = new System.Drawing.Size(280, 23);
            this.Cat.TabIndex = 1;
            this.Cat.SelectedIndexChanged += new System.EventHandler(this.Cat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(147, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sub Catagory";
            // 
            // SubCat
            // 
            this.SubCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubCat.Font = new System.Drawing.Font("Calibri", 10F);
            this.SubCat.FormattingEnabled = true;
            this.SubCat.Location = new System.Drawing.Point(239, 231);
            this.SubCat.Name = "SubCat";
            this.SubCat.Size = new System.Drawing.Size(280, 23);
            this.SubCat.TabIndex = 2;
            this.SubCat.SelectedIndexChanged += new System.EventHandler(this.SubCat_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(561, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sales Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(832, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Discount ";
            // 
            // Discount
            // 
            this.Discount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Discount.Font = new System.Drawing.Font("Calibri", 10F);
            this.Discount.FormattingEnabled = true;
            this.Discount.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.Discount.Location = new System.Drawing.Point(893, 452);
            this.Discount.Name = "Discount";
            this.Discount.Size = new System.Drawing.Size(45, 23);
            this.Discount.TabIndex = 8;
            this.Discount.SelectedIndexChanged += new System.EventHandler(this.Discount_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F);
            this.label6.Location = new System.Drawing.Point(939, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "%";
            // 
            // UnitsInStock
            // 
            this.UnitsInStock.Font = new System.Drawing.Font("Calibri", 10F);
            this.UnitsInStock.Location = new System.Drawing.Point(654, 515);
            this.UnitsInStock.Name = "UnitsInStock";
            this.UnitsInStock.Size = new System.Drawing.Size(137, 24);
            this.UnitsInStock.TabIndex = 9;
            this.UnitsInStock.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(561, 518);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Units in Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(561, 548);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "ReOrder Level";
            // 
            // ROL
            // 
            this.ROL.Font = new System.Drawing.Font("Calibri", 10F);
            this.ROL.Location = new System.Drawing.Point(654, 545);
            this.ROL.Name = "ROL";
            this.ROL.Size = new System.Drawing.Size(137, 24);
            this.ROL.TabIndex = 10;
            this.ROL.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10F);
            this.button1.Location = new System.Drawing.Point(728, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10F);
            this.button2.Location = new System.Drawing.Point(614, 598);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10F);
            this.button3.Location = new System.Drawing.Point(842, 598);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 14;
            this.button3.Text = "Main";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Calibri", 10F);
            this.button4.Location = new System.Drawing.Point(500, 598);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 11;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(147, 459);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Description";
            // 
            // Des
            // 
            this.Des.Font = new System.Drawing.Font("Calibri", 10F);
            this.Des.Location = new System.Drawing.Point(239, 457);
            this.Des.Multiline = true;
            this.Des.Name = "Des";
            this.Des.Size = new System.Drawing.Size(280, 57);
            this.Des.TabIndex = 4;
            // 
            // CatDes
            // 
            this.CatDes.BackColor = System.Drawing.Color.White;
            this.CatDes.Font = new System.Drawing.Font("Calibri", 10F);
            this.CatDes.Location = new System.Drawing.Point(654, 180);
            this.CatDes.Multiline = true;
            this.CatDes.Name = "CatDes";
            this.CatDes.ReadOnly = true;
            this.CatDes.Size = new System.Drawing.Size(303, 32);
            this.CatDes.TabIndex = 0;
            this.CatDes.TabStop = false;
            // 
            // SubCatDes
            // 
            this.SubCatDes.BackColor = System.Drawing.Color.White;
            this.SubCatDes.Font = new System.Drawing.Font("Calibri", 10F);
            this.SubCatDes.Location = new System.Drawing.Point(654, 231);
            this.SubCatDes.Multiline = true;
            this.SubCatDes.Name = "SubCatDes";
            this.SubCatDes.ReadOnly = true;
            this.SubCatDes.Size = new System.Drawing.Size(303, 32);
            this.SubCatDes.TabIndex = 0;
            this.SubCatDes.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(561, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "Description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(561, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Description";
            // 
            // Suppliers
            // 
            this.Suppliers.Font = new System.Drawing.Font("Calibri", 10F);
            this.Suppliers.FormattingEnabled = true;
            this.Suppliers.ItemHeight = 15;
            this.Suppliers.Location = new System.Drawing.Point(239, 272);
            this.Suppliers.Name = "Suppliers";
            this.Suppliers.Size = new System.Drawing.Size(280, 49);
            this.Suppliers.TabIndex = 28;
            this.Suppliers.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(147, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "Supplier(s)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(236, 414);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 31;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1052, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(561, 423);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "Stock Price";
            // 
            // StockPrice
            // 
            this.StockPrice.Font = new System.Drawing.Font("Calibri", 10F);
            this.StockPrice.Location = new System.Drawing.Point(654, 420);
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.Size = new System.Drawing.Size(137, 24);
            this.StockPrice.TabIndex = 6;
            this.StockPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StockPrice.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(147, 526);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 17);
            this.label19.TabIndex = 37;
            this.label19.Text = "Unit";
            // 
            // Units
            // 
            this.Units.Font = new System.Drawing.Font("Calibri", 10F);
            this.Units.Location = new System.Drawing.Point(239, 522);
            this.Units.Name = "Units";
            this.Units.Size = new System.Drawing.Size(100, 24);
            this.Units.TabIndex = 5;
            this.Units.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Units.TextChanged += new System.EventHandler(this.Units_TextChanged);
            // 
            // Un
            // 
            this.Un.AutoSize = true;
            this.Un.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.Un.Location = new System.Drawing.Point(345, 526);
            this.Un.Name = "Un";
            this.Un.Size = new System.Drawing.Size(0, 17);
            this.Un.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(832, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Profit      -";
            // 
            // Profit
            // 
            this.Profit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Profit.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profit.Location = new System.Drawing.Point(896, 493);
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            this.Profit.Size = new System.Drawing.Size(79, 17);
            this.Profit.TabIndex = 41;
            this.Profit.Text = "0.0";
            this.Profit.TextChanged += new System.EventHandler(this.Profit_TextChanged);
            // 
            // ItemNo2
            // 
            this.ItemNo2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNo2.FormattingEnabled = true;
            this.ItemNo2.ItemHeight = 14;
            this.ItemNo2.Location = new System.Drawing.Point(239, 339);
            this.ItemNo2.Name = "ItemNo2";
            this.ItemNo2.Size = new System.Drawing.Size(137, 60);
            this.ItemNo2.TabIndex = 43;
            this.ItemNo2.SelectedIndexChanged += new System.EventHandler(this.ItemNo2_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(147, 339);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 17);
            this.label14.TabIndex = 44;
            this.label14.Text = "Item(s)";
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
            this.linkLabel1.TabIndex = 45;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "©";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 728);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ItemNo2);
            this.Controls.Add(this.Profit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Un);
            this.Controls.Add(this.Units);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.StockPrice);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Suppliers);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SubCatDes);
            this.Controls.Add(this.CatDes);
            this.Controls.Add(this.Des);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ROL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.UnitsInStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Discount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SubCat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cat);
            this.Controls.Add(this.SalesPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Items";
            this.Text = "Items";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Items_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Items_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ItemNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SalesPrice;
        private System.Windows.Forms.ComboBox Cat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SubCat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Discount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UnitsInStock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ROL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Des;
        private System.Windows.Forms.TextBox CatDes;
        private System.Windows.Forms.TextBox SubCatDes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox Suppliers;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox StockPrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox Units;
        private System.Windows.Forms.Label Un;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Profit;
        private System.Windows.Forms.ListBox ItemNo2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}