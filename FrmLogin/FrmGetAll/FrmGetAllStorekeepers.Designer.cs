
namespace FrmLogin.FrmGetAll
{
    partial class FrmGetAllStorekeepers
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStorekeepers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorekeepers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Magacioneri";
            // 
            // dgvStorekeepers
            // 
            this.dgvStorekeepers.AllowUserToAddRows = false;
            this.dgvStorekeepers.AllowUserToDeleteRows = false;
            this.dgvStorekeepers.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvStorekeepers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStorekeepers.Location = new System.Drawing.Point(25, 111);
            this.dgvStorekeepers.Name = "dgvStorekeepers";
            this.dgvStorekeepers.ReadOnly = true;
            this.dgvStorekeepers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStorekeepers.Size = new System.Drawing.Size(516, 275);
            this.dgvStorekeepers.TabIndex = 1;
            this.dgvStorekeepers.DoubleClick += new System.EventHandler(this.dgvStorekeepers_DoubleClick);
            // 
            // FrmGetAllStorekeepers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 450);
            this.Controls.Add(this.dgvStorekeepers);
            this.Controls.Add(this.label1);
            this.Name = "FrmGetAllStorekeepers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magacioner";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorekeepers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStorekeepers;
    }
}