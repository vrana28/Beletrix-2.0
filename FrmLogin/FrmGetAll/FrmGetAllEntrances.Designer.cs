namespace FrmLogin.FrmGetAll
{
    partial class FrmGetAllEntrances
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
            this.btnDeleteArtikal = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnChooseArtikal = new System.Windows.Forms.Button();
            this.btnChooseClient = new System.Windows.Forms.Button();
            this.txtArtikal = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDatumOdDo = new System.Windows.Forms.RadioButton();
            this.lblOd = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvEntrances = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStanje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrances)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteArtikal
            // 
            this.btnDeleteArtikal.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteArtikal.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteArtikal.Location = new System.Drawing.Point(201, 180);
            this.btnDeleteArtikal.Name = "btnDeleteArtikal";
            this.btnDeleteArtikal.Size = new System.Drawing.Size(26, 24);
            this.btnDeleteArtikal.TabIndex = 31;
            this.btnDeleteArtikal.Text = "X";
            this.btnDeleteArtikal.UseVisualStyleBackColor = false;
            this.btnDeleteArtikal.Click += new System.EventHandler(this.btnDeleteArtikal_Click);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteClient.Location = new System.Drawing.Point(201, 138);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(26, 24);
            this.btnDeleteClient.TabIndex = 30;
            this.btnDeleteClient.Text = "X";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnChooseArtikal
            // 
            this.btnChooseArtikal.Location = new System.Drawing.Point(238, 183);
            this.btnChooseArtikal.Name = "btnChooseArtikal";
            this.btnChooseArtikal.Size = new System.Drawing.Size(116, 23);
            this.btnChooseArtikal.TabIndex = 29;
            this.btnChooseArtikal.Text = "Izaberi artikal";
            this.btnChooseArtikal.UseVisualStyleBackColor = true;
            this.btnChooseArtikal.Click += new System.EventHandler(this.btnChooseArtikal_Click);
            // 
            // btnChooseClient
            // 
            this.btnChooseClient.Location = new System.Drawing.Point(238, 138);
            this.btnChooseClient.Name = "btnChooseClient";
            this.btnChooseClient.Size = new System.Drawing.Size(116, 23);
            this.btnChooseClient.TabIndex = 28;
            this.btnChooseClient.Text = "Izaberi klijenta";
            this.btnChooseClient.UseVisualStyleBackColor = true;
            this.btnChooseClient.Click += new System.EventHandler(this.btnChooseClient_Click_1);
            // 
            // txtArtikal
            // 
            this.txtArtikal.Location = new System.Drawing.Point(95, 183);
            this.txtArtikal.Name = "txtArtikal";
            this.txtArtikal.ReadOnly = true;
            this.txtArtikal.Size = new System.Drawing.Size(100, 20);
            this.txtArtikal.TabIndex = 27;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(95, 142);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(100, 20);
            this.txtClient.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Artikal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Klijent:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Ulazi - Uskladištenja";
            // 
            // rbDatumOdDo
            // 
            this.rbDatumOdDo.AutoSize = true;
            this.rbDatumOdDo.Location = new System.Drawing.Point(49, 98);
            this.rbDatumOdDo.Name = "rbDatumOdDo";
            this.rbDatumOdDo.Size = new System.Drawing.Size(14, 13);
            this.rbDatumOdDo.TabIndex = 33;
            this.rbDatumOdDo.TabStop = true;
            this.rbDatumOdDo.UseVisualStyleBackColor = true;
            // 
            // lblOd
            // 
            this.lblOd.AutoSize = true;
            this.lblOd.Location = new System.Drawing.Point(76, 98);
            this.lblOd.Name = "lblOd";
            this.lblOd.Size = new System.Drawing.Size(27, 13);
            this.lblOd.TabIndex = 34;
            this.lblOd.Text = "Od: ";
            // 
            // dtpOd
            // 
            this.dtpOd.Location = new System.Drawing.Point(109, 92);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(200, 20);
            this.dtpOd.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Do: ";
            // 
            // dtpDo
            // 
            this.dtpDo.Location = new System.Drawing.Point(366, 91);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(200, 20);
            this.dtpDo.TabIndex = 37;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(817, 134);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 62);
            this.btnSearch.TabIndex = 39;
            this.btnSearch.Text = "Pretraži";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(817, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 36);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.Text = "Štampa";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvEntrances
            // 
            this.dgvEntrances.AllowUserToAddRows = false;
            this.dgvEntrances.AllowUserToDeleteRows = false;
            this.dgvEntrances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrances.Location = new System.Drawing.Point(49, 235);
            this.dgvEntrances.Name = "dgvEntrances";
            this.dgvEntrances.ReadOnly = true;
            this.dgvEntrances.Size = new System.Drawing.Size(896, 348);
            this.dgvEntrances.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Ukupno uskladišteno ( kg ):";
            // 
            // lblStanje
            // 
            this.lblStanje.AutoSize = true;
            this.lblStanje.Location = new System.Drawing.Point(416, 183);
            this.lblStanje.Name = "lblStanje";
            this.lblStanje.Size = new System.Drawing.Size(0, 13);
            this.lblStanje.TabIndex = 42;
            // 
            // FrmGetAllEntrances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 595);
            this.Controls.Add(this.lblStanje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvEntrances);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.lblOd);
            this.Controls.Add(this.rbDatumOdDo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteArtikal);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnChooseArtikal);
            this.Controls.Add(this.btnChooseClient);
            this.Controls.Add(this.txtArtikal);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "FrmGetAllEntrances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uskladištenja";
            this.Load += new System.EventHandler(this.FrmGetAllEntrances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteArtikal;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnChooseArtikal;
        private System.Windows.Forms.Button btnChooseClient;
        private System.Windows.Forms.TextBox txtArtikal;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDatumOdDo;
        private System.Windows.Forms.Label lblOd;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvEntrances;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStanje;
    }
}