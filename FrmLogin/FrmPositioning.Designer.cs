namespace FrmLogin
{
    partial class FrmPositioning
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
            this.dgvEntrances = new System.Windows.Forms.DataGridView();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntranceId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKolona = new System.Windows.Forms.TextBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.txtPaletnoMesto = new System.Windows.Forms.TextBox();
            this.txtVertikala = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPositionId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnResi = new System.Windows.Forms.Button();
            this.btnEntranceDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEntrances
            // 
            this.dgvEntrances.AllowUserToAddRows = false;
            this.dgvEntrances.AllowUserToDeleteRows = false;
            this.dgvEntrances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrances.Location = new System.Drawing.Point(16, 70);
            this.dgvEntrances.Name = "dgvEntrances";
            this.dgvEntrances.ReadOnly = true;
            this.dgvEntrances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntrances.Size = new System.Drawing.Size(470, 250);
            this.dgvEntrances.TabIndex = 0;
            this.dgvEntrances.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEntrances_MouseDoubleClick);
            // 
            // dgvPositions
            // 
            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AllowUserToDeleteRows = false;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Location = new System.Drawing.Point(500, 70);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.ReadOnly = true;
            this.dgvPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPositions.Size = new System.Drawing.Size(262, 475);
            this.dgvPositions.TabIndex = 1;
            this.dgvPositions.DoubleClick += new System.EventHandler(this.dgvPositions_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(190, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ulazne palete";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(590, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pozicije";
            // 
            // txtEntranceId
            // 
            this.txtEntranceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtEntranceId.Location = new System.Drawing.Point(128, 371);
            this.txtEntranceId.Name = "txtEntranceId";
            this.txtEntranceId.ReadOnly = true;
            this.txtEntranceId.Size = new System.Drawing.Size(100, 29);
            this.txtEntranceId.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Šifra ulaza:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(822, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kolona:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(835, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Red:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(791, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Paletno mesto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(814, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Vertikala:";
            // 
            // txtKolona
            // 
            this.txtKolona.Location = new System.Drawing.Point(879, 70);
            this.txtKolona.Name = "txtKolona";
            this.txtKolona.Size = new System.Drawing.Size(42, 20);
            this.txtKolona.TabIndex = 10;
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(879, 107);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(42, 20);
            this.txtRed.TabIndex = 11;
            // 
            // txtPaletnoMesto
            // 
            this.txtPaletnoMesto.Location = new System.Drawing.Point(879, 155);
            this.txtPaletnoMesto.Name = "txtPaletnoMesto";
            this.txtPaletnoMesto.Size = new System.Drawing.Size(42, 20);
            this.txtPaletnoMesto.TabIndex = 12;
            // 
            // txtVertikala
            // 
            this.txtVertikala.Location = new System.Drawing.Point(879, 201);
            this.txtVertikala.Name = "txtVertikala";
            this.txtVertikala.Size = new System.Drawing.Size(42, 20);
            this.txtVertikala.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(846, 269);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 53);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Pretraži";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(33, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "Pozicija:";
            // 
            // txtPositionId
            // 
            this.txtPositionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPositionId.Location = new System.Drawing.Point(128, 425);
            this.txtPositionId.Name = "txtPositionId";
            this.txtPositionId.ReadOnly = true;
            this.txtPositionId.Size = new System.Drawing.Size(100, 29);
            this.txtPositionId.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(846, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 53);
            this.button1.TabIndex = 17;
            this.button1.Text = "Osveži";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConnect.Location = new System.Drawing.Point(294, 373);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(145, 81);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.SystemColors.Control;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRestart.Location = new System.Drawing.Point(294, 464);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(145, 41);
            this.btnRestart.TabIndex = 19;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnResi
            // 
            this.btnResi.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnResi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnResi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnResi.Location = new System.Drawing.Point(846, 450);
            this.btnResi.Name = "btnResi";
            this.btnResi.Size = new System.Drawing.Size(75, 55);
            this.btnResi.TabIndex = 20;
            this.btnResi.Text = "Resi";
            this.btnResi.UseVisualStyleBackColor = false;
            this.btnResi.Visible = false;
            this.btnResi.Click += new System.EventHandler(this.btnResi_Click);
            // 
            // btnEntranceDelete
            // 
            this.btnEntranceDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEntranceDelete.Location = new System.Drawing.Point(37, 506);
            this.btnEntranceDelete.Name = "btnEntranceDelete";
            this.btnEntranceDelete.Size = new System.Drawing.Size(172, 57);
            this.btnEntranceDelete.TabIndex = 21;
            this.btnEntranceDelete.Text = "Obriši učitani ulaz";
            this.btnEntranceDelete.UseVisualStyleBackColor = true;
            this.btnEntranceDelete.Click += new System.EventHandler(this.btnEntranceDelete_Click);
            // 
            // FrmPositioning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 575);
            this.Controls.Add(this.btnEntranceDelete);
            this.Controls.Add(this.btnResi);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPositionId);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtVertikala);
            this.Controls.Add(this.txtPaletnoMesto);
            this.Controls.Add(this.txtRed);
            this.Controls.Add(this.txtKolona);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEntranceId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPositions);
            this.Controls.Add(this.dgvEntrances);
            this.Name = "FrmPositioning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pozicionisanje";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEntrances;
        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntranceId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKolona;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.TextBox txtPaletnoMesto;
        private System.Windows.Forms.TextBox txtVertikala;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPositionId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnResi;
        private System.Windows.Forms.Button btnEntranceDelete;
    }
}