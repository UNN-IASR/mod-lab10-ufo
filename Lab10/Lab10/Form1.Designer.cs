
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
            this.tbX1 = new System.Windows.Forms.TextBox();
            this.tbY1 = new System.Windows.Forms.TextBox();
            this.tbX2 = new System.Windows.Forms.TextBox();
            this.tbY2 = new System.Windows.Forms.TextBox();
            this.PleaseStart = new System.Windows.Forms.Button();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.tbPrecision = new System.Windows.Forms.TextBox();
            this.tbReqTerms = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbX1
            // 
            this.tbX1.Location = new System.Drawing.Point(22, 557);
            this.tbX1.Margin = new System.Windows.Forms.Padding(2);
            this.tbX1.Name = "tbX1";
            this.tbX1.Size = new System.Drawing.Size(68, 20);
            this.tbX1.TabIndex = 0;
            this.tbX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXY_CheckChar);
            // 
            // tbY1
            // 
            this.tbY1.Location = new System.Drawing.Point(22, 581);
            this.tbY1.Margin = new System.Windows.Forms.Padding(2);
            this.tbY1.Name = "tbY1";
            this.tbY1.Size = new System.Drawing.Size(68, 20);
            this.tbY1.TabIndex = 1;
            this.tbY1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXY_CheckChar);
            // 
            // tbX2
            // 
            this.tbX2.Location = new System.Drawing.Point(94, 557);
            this.tbX2.Margin = new System.Windows.Forms.Padding(2);
            this.tbX2.Name = "tbX2";
            this.tbX2.Size = new System.Drawing.Size(68, 20);
            this.tbX2.TabIndex = 2;
            this.tbX2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXY_CheckChar);
            // 
            // tbY2
            // 
            this.tbY2.Location = new System.Drawing.Point(94, 581);
            this.tbY2.Margin = new System.Windows.Forms.Padding(2);
            this.tbY2.Name = "tbY2";
            this.tbY2.Size = new System.Drawing.Size(68, 20);
            this.tbY2.TabIndex = 3;
            this.tbY2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXY_CheckChar);
            // 
            // PleaseStart
            // 
            this.PleaseStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PleaseStart.Location = new System.Drawing.Point(676, 557);
            this.PleaseStart.Margin = new System.Windows.Forms.Padding(2);
            this.PleaseStart.Name = "PleaseStart";
            this.PleaseStart.Size = new System.Drawing.Size(276, 45);
            this.PleaseStart.TabIndex = 4;
            this.PleaseStart.Text = "Крути катушку!";
            this.PleaseStart.UseVisualStyleBackColor = true;
            this.PleaseStart.Click += new System.EventHandler(this.PleaseStart_Click);
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "Уравнение прямой",
            "Использование угла"});
            this.MethodComboBox.Location = new System.Drawing.Point(166, 581);
            this.MethodComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(140, 21);
            this.MethodComboBox.TabIndex = 5;
            this.MethodComboBox.SelectedIndexChanged += new System.EventHandler(this.MethodComboBox_SelectedIndexChanged);
            // 
            // tbPrecision
            // 
            this.tbPrecision.Location = new System.Drawing.Point(407, 581);
            this.tbPrecision.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrecision.Name = "tbPrecision";
            this.tbPrecision.Size = new System.Drawing.Size(44, 20);
            this.tbPrecision.TabIndex = 6;
            this.tbPrecision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrecision_CheckChar);
            // 
            // tbReqTerms
            // 
            this.tbReqTerms.Location = new System.Drawing.Point(604, 582);
            this.tbReqTerms.Margin = new System.Windows.Forms.Padding(2);
            this.tbReqTerms.Name = "tbReqTerms";
            this.tbReqTerms.Size = new System.Drawing.Size(68, 20);
            this.tbReqTerms.TabIndex = 7;
            this.tbReqTerms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbXY_CheckChar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Точка 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 540);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Точка 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 584);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 560);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Выбор метода:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 584);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Точность (пкс)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 584);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Членов в ряде Тейлора";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 612);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReqTerms);
            this.Controls.Add(this.tbPrecision);
            this.Controls.Add(this.MethodComboBox);
            this.Controls.Add(this.PleaseStart);
            this.Controls.Add(this.tbY2);
            this.Controls.Add(this.tbX2);
            this.Controls.Add(this.tbY1);
            this.Controls.Add(this.tbX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Рисование прямых";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbX1;
        private System.Windows.Forms.TextBox tbY1;
        private System.Windows.Forms.TextBox tbX2;
        private System.Windows.Forms.TextBox tbY2;
        private System.Windows.Forms.Button PleaseStart;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.TextBox tbPrecision;
        private System.Windows.Forms.TextBox tbReqTerms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

