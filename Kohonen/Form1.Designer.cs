namespace Kohonen
{
    partial class MainForm
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
            this.button_Create = new System.Windows.Forms.Button();
            this.button_Training = new System.Windows.Forms.Button();
            this.button_SaveFile = new System.Windows.Forms.Button();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_Show = new System.Windows.Forms.Button();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.textBox_DataDim = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(14, 7);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(184, 38);
            this.button_Create.TabIndex = 1;
            this.button_Create.Text = "Создать сеть";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // button_Training
            // 
            this.button_Training.Location = new System.Drawing.Point(14, 51);
            this.button_Training.Name = "button_Training";
            this.button_Training.Size = new System.Drawing.Size(185, 38);
            this.button_Training.TabIndex = 2;
            this.button_Training.Text = "Обучить сеть";
            this.button_Training.UseVisualStyleBackColor = true;
            this.button_Training.Click += new System.EventHandler(this.button_Training_Click);
            // 
            // button_SaveFile
            // 
            this.button_SaveFile.Location = new System.Drawing.Point(15, 51);
            this.button_SaveFile.Name = "button_SaveFile";
            this.button_SaveFile.Size = new System.Drawing.Size(184, 38);
            this.button_SaveFile.TabIndex = 3;
            this.button_SaveFile.Text = "Сохранить в файл";
            this.button_SaveFile.UseVisualStyleBackColor = true;
            this.button_SaveFile.Click += new System.EventHandler(this.button_SaveFile_Click);
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(15, 7);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(184, 38);
            this.button_OpenFile.TabIndex = 4;
            this.button_OpenFile.Text = "Открыть из файла";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 95);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(185, 23);
            this.progressBar.TabIndex = 5;
            // 
            // button_Show
            // 
            this.button_Show.Location = new System.Drawing.Point(15, 25);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(184, 93);
            this.button_Show.TabIndex = 9;
            this.button_Show.Text = "Изобразить";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button_Show_Click);
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(14, 51);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(89, 20);
            this.textBox_Width.TabIndex = 11;
            this.textBox_Width.Text = "300";
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(109, 51);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(87, 20);
            this.textBox_Height.TabIndex = 12;
            this.textBox_Height.Text = "300";
            // 
            // textBox_DataDim
            // 
            this.textBox_DataDim.Location = new System.Drawing.Point(14, 25);
            this.textBox_DataDim.Name = "textBox_DataDim";
            this.textBox_DataDim.Size = new System.Drawing.Size(185, 20);
            this.textBox_DataDim.TabIndex = 13;
            this.textBox_DataDim.Text = "10";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Create);
            this.panel1.Controls.Add(this.textBox_Width);
            this.panel1.Controls.Add(this.textBox_Height);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 95);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button_Training);
            this.panel2.Controls.Add(this.textBox_DataDim);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Location = new System.Drawing.Point(12, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 134);
            this.panel2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Задайте количество цветов";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_SaveFile);
            this.panel3.Controls.Add(this.button_OpenFile);
            this.panel3.Location = new System.Drawing.Point(231, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 95);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 113);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(433, 65);
            this.panel4.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создайте сеть или загрузите из файла";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.button_Show);
            this.panel5.Location = new System.Drawing.Point(231, 184);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(214, 134);
            this.panel5.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 332);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "SOM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Button button_Training;
        private System.Windows.Forms.Button button_SaveFile;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_DataDim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
    }
}

