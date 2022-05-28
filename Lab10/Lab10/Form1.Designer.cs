
namespace Lab10
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
            this.textBoxForX1 = new System.Windows.Forms.TextBox();
            this.textBoxForY1 = new System.Windows.Forms.TextBox();
            this.textBoxForX2 = new System.Windows.Forms.TextBox();
            this.textBoxForY2 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxForValue = new System.Windows.Forms.TextBox();
            this.textBoxForColSteps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxForX1
            // 
            this.textBoxForX1.Location = new System.Drawing.Point(68, 11);
            this.textBoxForX1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxForX1.Name = "textBoxForX1";
            this.textBoxForX1.Size = new System.Drawing.Size(68, 20);
            this.textBoxForX1.TabIndex = 0;
            this.textBoxForX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxForX1_KeyPress);
            // 
            // textBoxForY1
            // 
            this.textBoxForY1.Location = new System.Drawing.Point(68, 35);
            this.textBoxForY1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxForY1.Name = "textBoxForY1";
            this.textBoxForY1.Size = new System.Drawing.Size(68, 20);
            this.textBoxForY1.TabIndex = 1;
            this.textBoxForY1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxForX1_KeyPress);
            // 
            // textBoxForX2
            // 
            this.textBoxForX2.Location = new System.Drawing.Point(68, 63);
            this.textBoxForX2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxForX2.Name = "textBoxForX2";
            this.textBoxForX2.Size = new System.Drawing.Size(68, 20);
            this.textBoxForX2.TabIndex = 2;
            this.textBoxForX2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxForX1_KeyPress);
            // 
            // textBoxForY2
            // 
            this.textBoxForY2.Location = new System.Drawing.Point(68, 87);
            this.textBoxForY2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxForY2.Name = "textBoxForY2";
            this.textBoxForY2.Size = new System.Drawing.Size(68, 20);
            this.textBoxForY2.TabIndex = 3;
            this.textBoxForY2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxForX1_KeyPress);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(146, 87);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(183, 34);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Уравнение прямой",
            "Использование угла"});
            this.comboBox1.Location = new System.Drawing.Point(189, 7);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxForValue
            // 
            this.textBoxForValue.Location = new System.Drawing.Point(261, 35);
            this.textBoxForValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxForValue.Name = "textBoxForValue";
            this.textBoxForValue.Size = new System.Drawing.Size(68, 20);
            this.textBoxForValue.TabIndex = 6;
            this.textBoxForValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxForValue_KeyPress);
            // 
            // textBoxForColSteps
            // 
            this.textBoxForColSteps.Location = new System.Drawing.Point(261, 60);
            this.textBoxForColSteps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxForColSteps.Name = "textBoxForColSteps";
            this.textBoxForColSteps.Size = new System.Drawing.Size(68, 20);
            this.textBoxForColSteps.TabIndex = 7;
            this.textBoxForColSteps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxForX1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "X1 = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y1 = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "X2 = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Y2 = ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Accuracy = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Number of members = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 612);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxForColSteps);
            this.Controls.Add(this.textBoxForValue);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.textBoxForY2);
            this.Controls.Add(this.textBoxForX2);
            this.Controls.Add(this.textBoxForY1);
            this.Controls.Add(this.textBoxForX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxForX1;
        private System.Windows.Forms.TextBox textBoxForY1;
        private System.Windows.Forms.TextBox textBoxForX2;
        private System.Windows.Forms.TextBox textBoxForY2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxForValue;
        private System.Windows.Forms.TextBox textBoxForColSteps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

