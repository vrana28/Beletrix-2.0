
namespace FrmLogin.FrmGetAll
{
    partial class FrmGetAllRoba
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
            this.dgvRoba = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoba)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoba
            // 
            this.dgvRoba.AllowUserToAddRows = false;
            this.dgvRoba.AllowUserToDeleteRows = false;
            this.dgvRoba.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvRoba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoba.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvRoba.Location = new System.Drawing.Point(30, 90);
            this.dgvRoba.Name = "dgvRoba";
            this.dgvRoba.ReadOnly = true;
            this.dgvRoba.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoba.Size = new System.Drawing.Size(384, 262);
            this.dgvRoba.TabIndex = 3;
            this.dgvRoba.DoubleClick += new System.EventHandler(this.dgvRoba_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Roba";
            // 
            // FrmGetAllRoba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 382);
            this.Controls.Add(this.dgvRoba);
            this.Controls.Add(this.label1);
            this.Name = "FrmGetAllRoba";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGetAllRoba";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoba;
        private System.Windows.Forms.Label label1;
    }
}