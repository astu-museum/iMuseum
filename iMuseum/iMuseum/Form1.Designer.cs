namespace iMuseum
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вЫСТАВКИToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нАСТРОЙКИПОИСКАToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.иСТОЧНИКИToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пОИСКToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typesob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.вЫСТАВКИToolStripMenuItem,
            this.нАСТРОЙКИПОИСКАToolStripMenuItem,
            this.иСТОЧНИКИToolStripMenuItem,
            this.пОИСКToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.файлToolStripMenuItem.Text = "МЕНЮ";
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.печатьToolStripMenuItem.Text = "Печать...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // вЫСТАВКИToolStripMenuItem
            // 
            this.вЫСТАВКИToolStripMenuItem.Name = "вЫСТАВКИToolStripMenuItem";
            this.вЫСТАВКИToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.вЫСТАВКИToolStripMenuItem.Text = "ВЫСТАВКИ";
            this.вЫСТАВКИToolStripMenuItem.Click += new System.EventHandler(this.showExib);
            // 
            // нАСТРОЙКИПОИСКАToolStripMenuItem
            // 
            this.нАСТРОЙКИПОИСКАToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.нАСТРОЙКИПОИСКАToolStripMenuItem.Name = "нАСТРОЙКИПОИСКАToolStripMenuItem";
            this.нАСТРОЙКИПОИСКАToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.нАСТРОЙКИПОИСКАToolStripMenuItem.Text = "ФИЛЬТР";
            this.нАСТРОЙКИПОИСКАToolStripMenuItem.Click += new System.EventHandler(this.setFilter);
            // 
            // иСТОЧНИКИToolStripMenuItem
            // 
            this.иСТОЧНИКИToolStripMenuItem.Name = "иСТОЧНИКИToolStripMenuItem";
            this.иСТОЧНИКИToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.иСТОЧНИКИToolStripMenuItem.Text = "ИСТОЧНИКИ";
            this.иСТОЧНИКИToolStripMenuItem.Click += new System.EventHandler(this.showSources);
            // 
            // пОИСКToolStripMenuItem
            // 
            this.пОИСКToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.пОИСКToolStripMenuItem.Name = "пОИСКToolStripMenuItem";
            this.пОИСКToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.пОИСКToolStripMenuItem.Text = "ПОИСК";
            this.пОИСКToolStripMenuItem.Click += new System.EventHandler(this.searchSett);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 593);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewExp);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(93, 593);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Spisati";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.title,
            this.source,
            this.date,
            this.typesob,
            this.mesto,
            this.damage,
            this.price});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1010, 558);
            this.dataGridView1.TabIndex = 10;
            // 
            // number
            // 
            this.number.Frozen = true;
            this.number.HeaderText = "Инв. номер";
            this.number.Name = "number";
            // 
            // title
            // 
            this.title.Frozen = true;
            this.title.HeaderText = "Наименование";
            this.title.Name = "title";
            this.title.Width = 150;
            // 
            // source
            // 
            this.source.Frozen = true;
            this.source.HeaderText = "Источник получения";
            this.source.Name = "source";
            this.source.Width = 150;
            // 
            // date
            // 
            this.date.Frozen = true;
            this.date.HeaderText = "Дата получения";
            this.date.MinimumWidth = 125;
            this.date.Name = "date";
            this.date.Width = 125;
            // 
            // typesob
            // 
            this.typesob.Frozen = true;
            this.typesob.HeaderText = "Тип собственности";
            this.typesob.MinimumWidth = 125;
            this.typesob.Name = "typesob";
            this.typesob.Width = 125;
            // 
            // mesto
            // 
            this.mesto.Frozen = true;
            this.mesto.HeaderText = "Место хранения";
            this.mesto.MinimumWidth = 150;
            this.mesto.Name = "mesto";
            this.mesto.Width = 150;
            // 
            // damage
            // 
            this.damage.Frozen = true;
            this.damage.HeaderText = "Состояние";
            this.damage.Name = "damage";
            // 
            // price
            // 
            this.price.Frozen = true;
            this.price.HeaderText = "Стоимость";
            this.price.Name = "price";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(921, 593);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Gjlhj,ytt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.infoExp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1008, 624);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 80);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iMuseum";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn source;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn typesob;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.ToolStripMenuItem вЫСТАВКИToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem нАСТРОЙКИПОИСКАToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem иСТОЧНИКИToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пОИСКToolStripMenuItem;
    }
}

