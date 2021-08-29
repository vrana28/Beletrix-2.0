namespace FrmLogin.FrmGetAll
{
    partial class FrmGetAllLeavingEntrances
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
            this.lblStanje = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvLeavingEntrances = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.lblOd = new System.Windows.Forms.Label();
            this.rbDatumOdDo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteArtikal = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnChooseArtikal = new System.Windows.Forms.Button();
            this.btnChooseClient = new System.Windows.Forms.Button();
            this.txtArtikal = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeavingEntrances)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStanje
            // 
            this.lblStanje.AutoSize = true;
            this.lblStanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStanje.Location = new System.Drawing.Point(624, 186);
            this.lblStanje.Name = "lblStanje";
            this.lblStanje.Size = new System.Drawing.Size(0, 20);
            this.lblStanje.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(404, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 20);
            this.label5.TabIndex = 60;
            this.label5.Text = "Ukupno iskladišteno ( kg ):";
            // 
            // dgvLeavingEntrances
            // 
            this.dgvLeavingEntrances.AllowUserToAddRows = false;
            this.dgvLeavingEntrances.AllowUserToDeleteRows = false;
            this.dgvLeavingEntrances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeavingEntrances.Location = new System.Drawing.Point(24, 235);
            this.dgvLeavingEntrances.Name = "dgvLeavingEntrances";
            this.dgvLeavingEntrances.ReadOnly = true;
            this.dgvLeavingEntrances.Size = new System.Drawing.Size(919, 348);
            this.dgvLeavingEntrances.TabIndex = 59;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(815, 134);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 62);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.Text = "Pretraži";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(815, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 36);
            this.btnPrint.TabIndex = 57;
            this.btnPrint.Text = "Štampa";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // dtpDo
            // 
            this.dtpDo.Location = new System.Drawing.Point(364, 91);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(200, 20);
            this.dtpDo.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Do: ";
            // 
            // dtpOd
            // 
            this.dtpOd.Location = new System.Drawing.Point(107, 92);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(200, 20);
            this.dtpOd.TabIndex = 54;
            // 
            // lblOd
            // 
            this.lblOd.AutoSize = true;
            this.lblOd.Location = new System.Drawing.Point(74, 98);
            this.lblOd.Name = "lblOd";
            this.lblOd.Size = new System.Drawing.Size(27, 13);
            this.lblOd.TabIndex = 53;
            this.lblOd.Text = "Od: ";
            // 
            // rbDatumOdDo
            // 
            this.rbDatumOdDo.AutoSize = true;
            this.rbDatumOdDo.Location = new System.Drawing.Point(47, 98);
            this.rbDatumOdDo.Name = "rbDatumOdDo";
            this.rbDatumOdDo.Size = new System.Drawing.Size(14, 13);
            this.rbDatumOdDo.TabIndex = 52;
            this.rbDatumOdDo.TabStop = true;
            this.rbDatumOdDo.UseVisualStyleBackColor = true;
            this.rbDatumOdDo.CheckedChanged += new System.EventHandler(this.rbDatumOdDo_CheckedChanged);
            this.rbDatumOdDo.Click += new System.EventHandler(this.rbDatumOdDo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "Izlazi - Iskladištenja";
            // 
            // btnDeleteArtikal
            // 
            this.btnDeleteArtikal.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteArtikal.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteArtikal.Location = new System.Drawing.Point(199, 180);
            this.btnDeleteArtikal.Name = "btnDeleteArtikal";
            this.btnDeleteArtikal.Size = new System.Drawing.Size(26, 24);
            this.btnDeleteArtikal.TabIndex = 50;
            this.btnDeleteArtikal.Text = "X";
            this.btnDeleteArtikal.UseVisualStyleBackColor = false;
            this.btnDeleteArtikal.Click += new System.EventHandler(this.btnDeleteArtikal_Click_1);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteClient.Location = new System.Drawing.Point(199, 138);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(26, 24);
            this.btnDeleteClient.TabIndex = 49;
            this.btnDeleteClient.Text = "X";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click_1);
            // 
            // btnChooseArtikal
            // 
            this.btnChooseArtikal.Location = new System.Drawing.Point(236, 183);
            this.btnChooseArtikal.Name = "btnChooseArtikal";
            this.btnChooseArtikal.Size = new System.Drawing.Size(116, 23);
            this.btnChooseArtikal.TabIndex = 48;
            this.btnChooseArtikal.Text = "Izaberi artikal";
            this.btnChooseArtikal.UseVisualStyleBackColor = true;
            this.btnChooseArtikal.Click += new System.EventHandler(this.btnChooseArtikal_Click_1);
            // 
            // btnChooseClient
            // 
            this.btnChooseClient.Location = new System.Drawing.Point(236, 138);
            this.btnChooseClient.Name = "btnChooseClient";
            this.btnChooseClient.Size = new System.Drawing.Size(116, 23);
            this.btnChooseClient.TabIndex = 47;
            this.btnChooseClient.Text = "Izaberi klijenta";
            this.btnChooseClient.UseVisualStyleBackColor = true;
            this.btnChooseClient.Click += new System.EventHandler(this.btnChooseClient_Click);
            // 
            // txtArtikal
            // 
            this.txtArtikal.Location = new System.Drawing.Point(93, 183);
            this.txtArtikal.Name = "txtArtikal";
            this.txtArtikal.ReadOnly = true;
            this.txtArtikal.Size = new System.Drawing.Size(100, 20);
            this.txtArtikal.TabIndex = 46;
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(93, 142);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(100, 20);
            this.txtClient.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Artikal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Klijent:";
            // 
            // FrmGetAllLeavingEntrances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 611);
            this.Controls.Add(this.lblStanje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLeavingEntrances);
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
            this.Name = "FrmGetAllLeavingEntrances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iskladištenja";
            this.Load += new System.EventHandler(this.FrmGetAllLeavingEntrances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeavingEntrances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStanje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLeavingEntrances;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.Label lblOd;
        private System.Windows.Forms.RadioButton rbDatumOdDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteArtikal;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnChooseArtikal;
        private System.Windows.Forms.Button btnChooseClient;
        private System.Windows.Forms.TextBox txtArtikal;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}