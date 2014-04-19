namespace iMuseum
{
    partial class ExbDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeexp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autcat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audcat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryexp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.af = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.be = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название выставки";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(551, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Печать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.printExb);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(488, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Сроки выставки";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Категории выставки";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 413);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.addEE);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 413);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.typeexp,
            this.autcat,
            this.audcat,
            this.damae,
            this.categoryexp,
            this.a,
            this.b,
            this.c,
            this.d,
            this.e,
            this.f,
            this.aa,
            this.ab,
            this.ac,
            this.ad,
            this.ae,
            this.af,
            this.ba,
            this.bb,
            this.bc,
            this.bd,
            this.be,
            this.bf});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(640, 351);
            this.dataGridView1.TabIndex = 16;
            // 
            // title
            // 
            this.title.HeaderText = "Наименование";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // typeexp
            // 
            this.typeexp.HeaderText = "Тип экспоната";
            this.typeexp.Name = "typeexp";
            this.typeexp.ReadOnly = true;
            // 
            // autcat
            // 
            this.autcat.HeaderText = "Категория автора";
            this.autcat.MinimumWidth = 120;
            this.autcat.Name = "autcat";
            this.autcat.ReadOnly = true;
            this.autcat.Width = 120;
            // 
            // audcat
            // 
            this.audcat.HeaderText = "Целевая аудитория";
            this.audcat.Name = "audcat";
            this.audcat.ReadOnly = true;
            // 
            // damae
            // 
            this.damae.HeaderText = "Состояние";
            this.damae.Name = "damae";
            this.damae.ReadOnly = true;
            // 
            // categoryexp
            // 
            this.categoryexp.HeaderText = "Категория экспоната";
            this.categoryexp.Name = "categoryexp";
            this.categoryexp.ReadOnly = true;
            // 
            // a
            // 
            this.a.HeaderText = "Column1";
            this.a.Name = "a";
            this.a.ReadOnly = true;
            this.a.Visible = false;
            // 
            // b
            // 
            this.b.HeaderText = "Column1";
            this.b.Name = "b";
            this.b.ReadOnly = true;
            this.b.Visible = false;
            // 
            // c
            // 
            this.c.HeaderText = "Column1";
            this.c.Name = "c";
            this.c.ReadOnly = true;
            this.c.Visible = false;
            // 
            // d
            // 
            this.d.HeaderText = "Column1";
            this.d.Name = "d";
            this.d.ReadOnly = true;
            this.d.Visible = false;
            // 
            // e
            // 
            this.e.HeaderText = "Column1";
            this.e.Name = "e";
            this.e.ReadOnly = true;
            this.e.Visible = false;
            // 
            // f
            // 
            this.f.HeaderText = "Column1";
            this.f.Name = "f";
            this.f.ReadOnly = true;
            this.f.Visible = false;
            // 
            // aa
            // 
            this.aa.HeaderText = "Column1";
            this.aa.Name = "aa";
            this.aa.ReadOnly = true;
            this.aa.Visible = false;
            // 
            // ab
            // 
            this.ab.HeaderText = "Column1";
            this.ab.Name = "ab";
            this.ab.ReadOnly = true;
            this.ab.Visible = false;
            // 
            // ac
            // 
            this.ac.HeaderText = "Column1";
            this.ac.Name = "ac";
            this.ac.ReadOnly = true;
            this.ac.Visible = false;
            // 
            // ad
            // 
            this.ad.HeaderText = "Column1";
            this.ad.Name = "ad";
            this.ad.ReadOnly = true;
            this.ad.Visible = false;
            // 
            // ae
            // 
            this.ae.HeaderText = "Column1";
            this.ae.Name = "ae";
            this.ae.ReadOnly = true;
            this.ae.Visible = false;
            // 
            // af
            // 
            this.af.HeaderText = "Column1";
            this.af.Name = "af";
            this.af.ReadOnly = true;
            this.af.Visible = false;
            // 
            // ba
            // 
            this.ba.HeaderText = "Column1";
            this.ba.Name = "ba";
            this.ba.ReadOnly = true;
            this.ba.Visible = false;
            // 
            // bb
            // 
            this.bb.HeaderText = "Column1";
            this.bb.Name = "bb";
            this.bb.ReadOnly = true;
            this.bb.Visible = false;
            // 
            // bc
            // 
            this.bc.HeaderText = "Column1";
            this.bc.Name = "bc";
            this.bc.ReadOnly = true;
            this.bc.Visible = false;
            // 
            // bd
            // 
            this.bd.HeaderText = "Column1";
            this.bd.Name = "bd";
            this.bd.ReadOnly = true;
            this.bd.Visible = false;
            // 
            // be
            // 
            this.be.HeaderText = "Column1";
            this.be.Name = "be";
            this.be.ReadOnly = true;
            this.be.Visible = false;
            // 
            // bf
            // 
            this.bf.HeaderText = "Column1";
            this.bf.Name = "bf";
            this.bf.ReadOnly = true;
            this.bf.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // ExbDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(638, 445);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExbDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Название выставки";
            this.Load += new System.EventHandler(this.ExbDetails_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.closeByEsc);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeexp;
        private System.Windows.Forms.DataGridViewTextBoxColumn autcat;
        private System.Windows.Forms.DataGridViewTextBoxColumn audcat;
        private System.Windows.Forms.DataGridViewTextBoxColumn damae;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryexp;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewTextBoxColumn c;
        private System.Windows.Forms.DataGridViewTextBoxColumn d;
        private System.Windows.Forms.DataGridViewTextBoxColumn e;
        private System.Windows.Forms.DataGridViewTextBoxColumn f;
        private System.Windows.Forms.DataGridViewTextBoxColumn aa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ac;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ae;
        private System.Windows.Forms.DataGridViewTextBoxColumn af;
        private System.Windows.Forms.DataGridViewTextBoxColumn ba;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb;
        private System.Windows.Forms.DataGridViewTextBoxColumn bc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bd;
        private System.Windows.Forms.DataGridViewTextBoxColumn be;
        private System.Windows.Forms.DataGridViewTextBoxColumn bf;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}