
namespace FrmLogin
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStorekeeperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStorekeeperToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.storekeepersdeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRobuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robedeleteupdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.addStorekeeperToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.robeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.mapToolStripMenuItem.Text = "Mapa";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // addStorekeeperToolStripMenuItem
            // 
            this.addStorekeeperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStorekeeperToolStripMenuItem1,
            this.storekeepersdeleteToolStripMenuItem});
            this.addStorekeeperToolStripMenuItem.Name = "addStorekeeperToolStripMenuItem";
            this.addStorekeeperToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.addStorekeeperToolStripMenuItem.Text = "Magacioner";
            // 
            // addStorekeeperToolStripMenuItem1
            // 
            this.addStorekeeperToolStripMenuItem1.Name = "addStorekeeperToolStripMenuItem1";
            this.addStorekeeperToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.addStorekeeperToolStripMenuItem1.Text = "Dodaj magacionera";
            this.addStorekeeperToolStripMenuItem1.Click += new System.EventHandler(this.addStorekeeperToolStripMenuItem1_Click);
            // 
            // storekeepersdeleteToolStripMenuItem
            // 
            this.storekeepersdeleteToolStripMenuItem.Name = "storekeepersdeleteToolStripMenuItem";
            this.storekeepersdeleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storekeepersdeleteToolStripMenuItem.Text = "Magacioneri";
            this.storekeepersdeleteToolStripMenuItem.Click += new System.EventHandler(this.storekeepersdeleteToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addClientToolStripMenuItem,
            this.clientsDeleteToolStripMenuItem});
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.clientsToolStripMenuItem.Text = "Klijent";
            // 
            // addClientToolStripMenuItem
            // 
            this.addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            this.addClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addClientToolStripMenuItem.Text = "Dodaj klijenta";
            this.addClientToolStripMenuItem.Click += new System.EventHandler(this.addClientToolStripMenuItem_Click);
            // 
            // clientsDeleteToolStripMenuItem
            // 
            this.clientsDeleteToolStripMenuItem.Name = "clientsDeleteToolStripMenuItem";
            this.clientsDeleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientsDeleteToolStripMenuItem.Text = "Klijenti";
            this.clientsDeleteToolStripMenuItem.Click += new System.EventHandler(this.clientsDeleteToolStripMenuItem_Click);
            // 
            // robeToolStripMenuItem
            // 
            this.robeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRobuToolStripMenuItem,
            this.robedeleteupdateToolStripMenuItem});
            this.robeToolStripMenuItem.Name = "robeToolStripMenuItem";
            this.robeToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.robeToolStripMenuItem.Text = "Artikal";
            // 
            // addRobuToolStripMenuItem
            // 
            this.addRobuToolStripMenuItem.Name = "addRobuToolStripMenuItem";
            this.addRobuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addRobuToolStripMenuItem.Text = "Dodaj artikal";
            this.addRobuToolStripMenuItem.Click += new System.EventHandler(this.addRobuToolStripMenuItem_Click);
            // 
            // robedeleteupdateToolStripMenuItem
            // 
            this.robedeleteupdateToolStripMenuItem.Name = "robedeleteupdateToolStripMenuItem";
            this.robedeleteupdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.robedeleteupdateToolStripMenuItem.Text = "Artikli";
            this.robedeleteupdateToolStripMenuItem.Click += new System.EventHandler(this.robedeleteupdateToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1484, 767);
            this.pnlMain.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(741, 8);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 13);
            this.lblUser.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 791);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beletrix 2.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ToolStripMenuItem addStorekeeperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStorekeeperToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storekeepersdeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRobuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robedeleteupdateToolStripMenuItem;
    }
}