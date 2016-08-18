namespace Inventry_Control_System
{
    partial class FullScreen
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.S_Rep = new System.Windows.Forms.ListView();
            this.TransactionID = new System.Windows.Forms.ColumnHeader(1);
            this.ItemNo = new System.Windows.Forms.ColumnHeader(2);
            this.Description = new System.Windows.Forms.ColumnHeader(5);
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.Units = new System.Windows.Forms.ColumnHeader();
            this.Catagory = new System.Windows.Forms.ColumnHeader();
            this.SubCatagory = new System.Windows.Forms.ColumnHeader();
            this.ItemPrice = new System.Windows.Forms.ColumnHeader();
            this.Discount = new System.Windows.Forms.ColumnHeader();
            this.TotalAmt = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.Transac = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 2);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Maroon;
            this.linkLabel1.Location = new System.Drawing.Point(983, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(19, 30);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // S_Rep
            // 
            this.S_Rep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TransactionID,
            this.ItemNo,
            this.Description,
            this.Quantity,
            this.Units,
            this.Catagory,
            this.SubCatagory,
            this.ItemPrice,
            this.Discount,
            this.TotalAmt});
            this.S_Rep.Font = new System.Drawing.Font("Calibri", 9F);
            this.S_Rep.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.S_Rep.Location = new System.Drawing.Point(12, 67);
            this.S_Rep.Name = "S_Rep";
            this.S_Rep.Size = new System.Drawing.Size(992, 649);
            this.S_Rep.TabIndex = 1;
            this.S_Rep.UseCompatibleStateImageBehavior = false;
            this.S_Rep.View = System.Windows.Forms.View.Details;
            // 
            // TransactionID
            // 
            this.TransactionID.Text = "Transaction ID";
            this.TransactionID.Width = 100;
            // 
            // ItemNo
            // 
            this.ItemNo.Text = "Item No";
            this.ItemNo.Width = 90;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 175;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 50;
            // 
            // Units
            // 
            this.Units.Text = "Units";
            this.Units.Width = 80;
            // 
            // Catagory
            // 
            this.Catagory.Text = "Catagory";
            this.Catagory.Width = 105;
            // 
            // SubCatagory
            // 
            this.SubCatagory.Text = "Sub Catagory";
            this.SubCatagory.Width = 125;
            // 
            // ItemPrice
            // 
            this.ItemPrice.Text = "Item Price";
            this.ItemPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ItemPrice.Width = 80;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Discount.Width = 80;
            // 
            // TotalAmt
            // 
            this.TotalAmt.Text = "Total Amount";
            this.TotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalAmt.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Transac
            // 
            this.Transac.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.Transac.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transac.Location = new System.Drawing.Point(12, 67);
            this.Transac.Name = "Transac";
            this.Transac.Size = new System.Drawing.Size(990, 649);
            this.Transac.TabIndex = 3;
            this.Transac.UseCompatibleStateImageBehavior = false;
            this.Transac.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Transaction ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Total Amount";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Discount";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tran.. DateTime";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cashier";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "No Of Items Sold";
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Profit";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 140;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(718, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 18);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Show Grid";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 728);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Transac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.S_Rep);
            this.Controls.Add(this.linkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreen";
            this.Text = "FullScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FullScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListView S_Rep;
        private System.Windows.Forms.ColumnHeader TransactionID;
        private System.Windows.Forms.ColumnHeader ItemNo;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Units;
        private System.Windows.Forms.ColumnHeader Catagory;
        private System.Windows.Forms.ColumnHeader SubCatagory;
        private System.Windows.Forms.ColumnHeader ItemPrice;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader TotalAmt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView Transac;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}