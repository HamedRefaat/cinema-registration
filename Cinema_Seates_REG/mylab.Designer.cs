namespace Cinema_Seates_REG
{
    partial class Seat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbname = new System.Windows.Forms.Label();
            this.lncoclr = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbname, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lncoclr, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(84, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbname
            // 
            this.lbname.BackColor = System.Drawing.Color.White;
            this.lbname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbname.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbname.Location = new System.Drawing.Point(3, 0);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(78, 25);
            this.lbname.TabIndex = 0;
            this.lbname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbname.Click += new System.EventHandler(this.lbname_Click);
            // 
            // lncoclr
            // 
            this.lncoclr.BackColor = System.Drawing.Color.White;
            this.lncoclr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lncoclr.Location = new System.Drawing.Point(3, 25);
            this.lncoclr.Name = "lncoclr";
            this.lncoclr.Size = new System.Drawing.Size(78, 25);
            this.lncoclr.TabIndex = 1;
            // 
            // Seat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Seat";
            this.Size = new System.Drawing.Size(84, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lbname;
        public System.Windows.Forms.Label lncoclr;
    }
}
