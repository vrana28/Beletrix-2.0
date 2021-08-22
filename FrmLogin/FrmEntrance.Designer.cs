
namespace FrmLogin
{
    partial class FrmEntrance
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.rtbVrstaPalete = new System.Windows.Forms.RichTextBox();
            this.txtDateOfEntrance = new System.Windows.Forms.TextBox();
            this.btnChooseClient = new System.Windows.Forms.Button();
            this.lbEntranceItems = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDeadlineDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChooseArtikal = new System.Windows.Forms.Button();
            this.txtDateOfMan = new System.Windows.Forms.TextBox();
            this.txtArtikal = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddToItems = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMagacioner = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalWeight = new System.Windows.Forms.Label();
            this.btnSaveComplete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ulaz paleta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Klijent:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum ulaza: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vrsta palete:";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(141, 57);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(207, 20);
            this.txtClient.TabIndex = 4;
            // 
            // rtbVrstaPalete
            // 
            this.rtbVrstaPalete.Location = new System.Drawing.Point(141, 109);
            this.rtbVrstaPalete.Name = "rtbVrstaPalete";
            this.rtbVrstaPalete.Size = new System.Drawing.Size(207, 96);
            this.rtbVrstaPalete.TabIndex = 5;
            this.rtbVrstaPalete.Text = "";
            // 
            // txtDateOfEntrance
            // 
            this.txtDateOfEntrance.Location = new System.Drawing.Point(141, 83);
            this.txtDateOfEntrance.Name = "txtDateOfEntrance";
            this.txtDateOfEntrance.ReadOnly = true;
            this.txtDateOfEntrance.Size = new System.Drawing.Size(207, 20);
            this.txtDateOfEntrance.TabIndex = 6;
            // 
            // btnChooseClient
            // 
            this.btnChooseClient.Location = new System.Drawing.Point(389, 47);
            this.btnChooseClient.Name = "btnChooseClient";
            this.btnChooseClient.Size = new System.Drawing.Size(102, 23);
            this.btnChooseClient.TabIndex = 7;
            this.btnChooseClient.Text = "Izaberi klijenta";
            this.btnChooseClient.UseVisualStyleBackColor = true;
            this.btnChooseClient.Click += new System.EventHandler(this.btnChooseClient_Click);
            // 
            // lbEntranceItems
            // 
            this.lbEntranceItems.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbEntranceItems.FormattingEnabled = true;
            this.lbEntranceItems.Location = new System.Drawing.Point(141, 219);
            this.lbEntranceItems.Name = "lbEntranceItems";
            this.lbEntranceItems.Size = new System.Drawing.Size(555, 199);
            this.lbEntranceItems.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Obriši stavku";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(154, 241);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(519, 159);
            this.dgvItems.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.txtDeadlineDate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnChooseArtikal);
            this.panel1.Controls.Add(this.txtDateOfMan);
            this.panel1.Controls.Add(this.txtArtikal);
            this.panel1.Controls.Add(this.txtNum);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnAddToItems);
            this.panel1.Location = new System.Drawing.Point(702, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 410);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtDeadlineDate
            // 
            this.txtDeadlineDate.Location = new System.Drawing.Point(137, 283);
            this.txtDeadlineDate.Name = "txtDeadlineDate";
            this.txtDeadlineDate.ReadOnly = true;
            this.txtDeadlineDate.Size = new System.Drawing.Size(100, 20);
            this.txtDeadlineDate.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Datum isteka:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(137, 316);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Količina:";
            // 
            // btnChooseArtikal
            // 
            this.btnChooseArtikal.Location = new System.Drawing.Point(135, 201);
            this.btnChooseArtikal.Name = "btnChooseArtikal";
            this.btnChooseArtikal.Size = new System.Drawing.Size(102, 23);
            this.btnChooseArtikal.TabIndex = 13;
            this.btnChooseArtikal.Text = "Izaberi artikal";
            this.btnChooseArtikal.UseVisualStyleBackColor = true;
            this.btnChooseArtikal.Click += new System.EventHandler(this.btnChooseArtikal_Click);
            // 
            // txtDateOfMan
            // 
            this.txtDateOfMan.Location = new System.Drawing.Point(137, 241);
            this.txtDateOfMan.Name = "txtDateOfMan";
            this.txtDateOfMan.Size = new System.Drawing.Size(100, 20);
            this.txtDateOfMan.TabIndex = 20;
            // 
            // txtArtikal
            // 
            this.txtArtikal.Location = new System.Drawing.Point(135, 164);
            this.txtArtikal.Name = "txtArtikal";
            this.txtArtikal.ReadOnly = true;
            this.txtArtikal.Size = new System.Drawing.Size(100, 20);
            this.txtArtikal.TabIndex = 19;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(135, 123);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(92, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Vrsta artikla:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Datum proizvodnje:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Artikal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Rbr:";
            // 
            // btnAddToItems
            // 
            this.btnAddToItems.Location = new System.Drawing.Point(10, 369);
            this.btnAddToItems.Name = "btnAddToItems";
            this.btnAddToItems.Size = new System.Drawing.Size(102, 23);
            this.btnAddToItems.TabIndex = 13;
            this.btnAddToItems.Text = "Dodaj stavku";
            this.btnAddToItems.UseVisualStyleBackColor = true;
            this.btnAddToItems.Click += new System.EventHandler(this.btnAddToItems_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(386, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Magacioner: ";
            // 
            // lblMagacioner
            // 
            this.lblMagacioner.AutoSize = true;
            this.lblMagacioner.Location = new System.Drawing.Point(462, 191);
            this.lblMagacioner.Name = "lblMagacioner";
            this.lblMagacioner.Size = new System.Drawing.Size(0, 13);
            this.lblMagacioner.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(5, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Ukupna težina:";
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotalWeight.Location = new System.Drawing.Point(42, 258);
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(0, 20);
            this.lblTotalWeight.TabIndex = 16;
            // 
            // btnSaveComplete
            // 
            this.btnSaveComplete.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveComplete.Location = new System.Drawing.Point(15, 358);
            this.btnSaveComplete.Name = "btnSaveComplete";
            this.btnSaveComplete.Size = new System.Drawing.Size(102, 60);
            this.btnSaveComplete.TabIndex = 17;
            this.btnSaveComplete.Text = "Sačuvaj paletu";
            this.btnSaveComplete.UseVisualStyleBackColor = false;
            this.btnSaveComplete.Click += new System.EventHandler(this.btnSaveComplete_Click);
            // 
            // FrmEntrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 425);
            this.Controls.Add(this.btnSaveComplete);
            this.Controls.Add(this.lblTotalWeight);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblMagacioner);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbEntranceItems);
            this.Controls.Add(this.btnChooseClient);
            this.Controls.Add(this.txtDateOfEntrance);
            this.Controls.Add(this.rtbVrstaPalete);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmEntrance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ulaz palete";
            this.Load += new System.EventHandler(this.FrmEntrance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.RichTextBox rtbVrstaPalete;
        private System.Windows.Forms.TextBox txtDateOfEntrance;
        private System.Windows.Forms.Button btnChooseClient;
        private System.Windows.Forms.ListBox lbEntranceItems;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDateOfMan;
        private System.Windows.Forms.TextBox txtArtikal;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddToItems;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnChooseArtikal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMagacioner;
        private System.Windows.Forms.TextBox txtDeadlineDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalWeight;
        private System.Windows.Forms.Button btnSaveComplete;
    }
}