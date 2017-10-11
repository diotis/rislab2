namespace sharplab2cl
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.year = new System.Windows.Forms.TextBox();
            this.model = new System.Windows.Forms.TextBox();
            this.marka = new System.Windows.Forms.TextBox();
            this.radio_find = new System.Windows.Forms.RadioButton();
            this.radio_create = new System.Windows.Forms.RadioButton();
            this.radio_del = new System.Windows.Forms.RadioButton();
            this.radio_add = new System.Windows.Forms.RadioButton();
            this.radio_view = new System.Windows.Forms.RadioButton();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(190, 279);
            this.richTextBox1.TabIndex = 30;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Год :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Модель :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Марка :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 36);
            this.button1.TabIndex = 26;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.operation_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 297);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Показывать статус";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(468, 110);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(159, 20);
            this.year.TabIndex = 24;
            // 
            // model
            // 
            this.model.Location = new System.Drawing.Point(468, 70);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(159, 20);
            this.model.TabIndex = 23;
            // 
            // marka
            // 
            this.marka.Location = new System.Drawing.Point(468, 30);
            this.marka.Name = "marka";
            this.marka.Size = new System.Drawing.Size(159, 20);
            this.marka.TabIndex = 22;
            // 
            // radio_find
            // 
            this.radio_find.AutoSize = true;
            this.radio_find.Location = new System.Drawing.Point(234, 145);
            this.radio_find.Name = "radio_find";
            this.radio_find.Size = new System.Drawing.Size(56, 17);
            this.radio_find.TabIndex = 21;
            this.radio_find.TabStop = true;
            this.radio_find.Text = "Найти";
            this.radio_find.UseVisualStyleBackColor = true;
            this.radio_find.CheckedChanged += new System.EventHandler(this.radio_find_CheckedChanged);
            // 
            // radio_create
            // 
            this.radio_create.AutoSize = true;
            this.radio_create.Location = new System.Drawing.Point(234, 115);
            this.radio_create.Name = "radio_create";
            this.radio_create.Size = new System.Drawing.Size(102, 17);
            this.radio_create.TabIndex = 20;
            this.radio_create.TabStop = true;
            this.radio_create.Text = "Редактировать";
            this.radio_create.UseVisualStyleBackColor = true;
            this.radio_create.CheckedChanged += new System.EventHandler(this.radio_create_CheckedChanged);
            // 
            // radio_del
            // 
            this.radio_del.AutoSize = true;
            this.radio_del.Location = new System.Drawing.Point(234, 85);
            this.radio_del.Name = "radio_del";
            this.radio_del.Size = new System.Drawing.Size(68, 17);
            this.radio_del.TabIndex = 19;
            this.radio_del.TabStop = true;
            this.radio_del.Text = "Удалить";
            this.radio_del.UseVisualStyleBackColor = true;
            this.radio_del.CheckedChanged += new System.EventHandler(this.radio_del_CheckedChanged);
            // 
            // radio_add
            // 
            this.radio_add.AutoSize = true;
            this.radio_add.Location = new System.Drawing.Point(234, 55);
            this.radio_add.Name = "radio_add";
            this.radio_add.Size = new System.Drawing.Size(75, 17);
            this.radio_add.TabIndex = 18;
            this.radio_add.TabStop = true;
            this.radio_add.Text = "Добавить";
            this.radio_add.UseVisualStyleBackColor = true;
            this.radio_add.CheckedChanged += new System.EventHandler(this.radio_add_CheckedChanged);
            // 
            // radio_view
            // 
            this.radio_view.AutoSize = true;
            this.radio_view.Location = new System.Drawing.Point(234, 25);
            this.radio_view.Name = "radio_view";
            this.radio_view.Size = new System.Drawing.Size(87, 17);
            this.radio_view.TabIndex = 17;
            this.radio_view.TabStop = true;
            this.radio_view.Text = "Посмотреть";
            this.radio_view.UseVisualStyleBackColor = true;
            this.radio_view.CheckedChanged += new System.EventHandler(this.radio_view_CheckedChanged);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(384, 145);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(243, 160);
            this.listBox.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 326);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.year);
            this.Controls.Add(this.model);
            this.Controls.Add(this.marka);
            this.Controls.Add(this.radio_find);
            this.Controls.Add(this.radio_create);
            this.Controls.Add(this.radio_del);
            this.Controls.Add(this.radio_add);
            this.Controls.Add(this.radio_view);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.TextBox model;
        private System.Windows.Forms.TextBox marka;
        private System.Windows.Forms.RadioButton radio_find;
        private System.Windows.Forms.RadioButton radio_create;
        private System.Windows.Forms.RadioButton radio_del;
        private System.Windows.Forms.RadioButton radio_add;
        private System.Windows.Forms.RadioButton radio_view;
        private System.Windows.Forms.ListBox listBox;
    }
}

