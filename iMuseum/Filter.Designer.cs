namespace iMuseum
{
    partial class Filter
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties3 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties4 = new PresentationControls.CheckBoxProperties();
            this.label1 = new System.Windows.Forms.Label();
            this.objectTypeCB = new PresentationControls.CheckBoxComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxComboBox1 = new PresentationControls.CheckBoxComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxComboBox2 = new PresentationControls.CheckBoxComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxComboBox3 = new PresentationControls.CheckBoxComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Тип экспоната:";
            // 
            // objectTypeCB
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.objectTypeCB.CheckBoxProperties = checkBoxProperties1;
            this.objectTypeCB.DisplayMemberSingleItem = "";
            this.objectTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectTypeCB.FormattingEnabled = true;
            this.objectTypeCB.Location = new System.Drawing.Point(137, 12);
            this.objectTypeCB.Name = "objectTypeCB";
            this.objectTypeCB.Size = new System.Drawing.Size(272, 21);
            this.objectTypeCB.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Категория экспоната:";
            // 
            // checkBoxComboBox1
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox1.CheckBoxProperties = checkBoxProperties2;
            this.checkBoxComboBox1.DisplayMemberSingleItem = "";
            this.checkBoxComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkBoxComboBox1.FormattingEnabled = true;
            this.checkBoxComboBox1.Location = new System.Drawing.Point(137, 39);
            this.checkBoxComboBox1.Name = "checkBoxComboBox1";
            this.checkBoxComboBox1.Size = new System.Drawing.Size(272, 21);
            this.checkBoxComboBox1.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Категория автора:";
            // 
            // checkBoxComboBox2
            // 
            checkBoxProperties3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox2.CheckBoxProperties = checkBoxProperties3;
            this.checkBoxComboBox2.DisplayMemberSingleItem = "";
            this.checkBoxComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkBoxComboBox2.FormattingEnabled = true;
            this.checkBoxComboBox2.Location = new System.Drawing.Point(137, 66);
            this.checkBoxComboBox2.Name = "checkBoxComboBox2";
            this.checkBoxComboBox2.Size = new System.Drawing.Size(272, 21);
            this.checkBoxComboBox2.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Целевая аудитория:";
            // 
            // checkBoxComboBox3
            // 
            checkBoxProperties4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox3.CheckBoxProperties = checkBoxProperties4;
            this.checkBoxComboBox3.DisplayMemberSingleItem = "";
            this.checkBoxComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkBoxComboBox3.FormattingEnabled = true;
            this.checkBoxComboBox3.Location = new System.Drawing.Point(137, 93);
            this.checkBoxComboBox3.Name = "checkBoxComboBox3";
            this.checkBoxComboBox3.Size = new System.Drawing.Size(272, 21);
            this.checkBoxComboBox3.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Сброс";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(253, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Применить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(421, 167);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxComboBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxComboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxComboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.objectTypeCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтр";
            this.Load += new System.EventHandler(this.Filter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private PresentationControls.CheckBoxComboBox objectTypeCB;
        private System.Windows.Forms.Label label2;
        private PresentationControls.CheckBoxComboBox checkBoxComboBox1;
        private System.Windows.Forms.Label label3;
        private PresentationControls.CheckBoxComboBox checkBoxComboBox2;
        private System.Windows.Forms.Label label4;
        private PresentationControls.CheckBoxComboBox checkBoxComboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}