namespace selene
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.protocolosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nBNSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutPut = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(88, 40);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(121, 22);
            this.ipAddress.TabIndex = 0;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(215, 40);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(77, 22);
            this.Port.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protocolosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1224, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // protocolosToolStripMenuItem
            // 
            this.protocolosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nBNSToolStripMenuItem,
            this.sMBToolStripMenuItem});
            this.protocolosToolStripMenuItem.Name = "protocolosToolStripMenuItem";
            this.protocolosToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.protocolosToolStripMenuItem.Text = "Protocolos";
            // 
            // nBNSToolStripMenuItem
            // 
            this.nBNSToolStripMenuItem.Name = "nBNSToolStripMenuItem";
            this.nBNSToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.nBNSToolStripMenuItem.Text = "NBNS";
            this.nBNSToolStripMenuItem.Click += new System.EventHandler(this.nBNSToolStripMenuItem_Click);
            // 
            // sMBToolStripMenuItem
            // 
            this.sMBToolStripMenuItem.Name = "sMBToolStripMenuItem";
            this.sMBToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.sMBToolStripMenuItem.Text = "SMB";
            this.sMBToolStripMenuItem.Click += new System.EventHandler(this.sMBToolStripMenuItem_Click);
            // 
            // OutPut
            // 
            this.OutPut.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.OutPut.Location = new System.Drawing.Point(537, 31);
            this.OutPut.Name = "OutPut";
            this.OutPut.Size = new System.Drawing.Size(681, 224);
            this.OutPut.TabIndex = 4;
            this.OutPut.UseCompatibleStateImageBehavior = false;
            this.OutPut.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Info";
            this.columnHeader2.Width = 350;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(88, 68);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 31);
            this.stop.TabIndex = 6;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "lP/Puerto:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::selene.Properties.Resources.selenee;
            this.pictureBox1.Location = new System.Drawing.Point(0, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 150);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1224, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.OutPut);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "selene";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem protocolosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nBNSToolStripMenuItem;
        private System.Windows.Forms.ListView OutPut;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem sMBToolStripMenuItem;
    }
}

