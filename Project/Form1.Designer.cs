namespace Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            Start_Button = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            StartSettings_GroupBox = new GroupBox();
            CountSteps_NumericUpDown = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            Accuracy_NumericUpDown = new NumericUpDown();
            groupBox1 = new GroupBox();
            EndPointY_NumericUpDown = new NumericUpDown();
            label8 = new Label();
            EndPointX_NumericUpDown = new NumericUpDown();
            label9 = new Label();
            StartPointY_NumericUpDown = new NumericUpDown();
            label7 = new Label();
            StartPointX_NumericUpDown = new NumericUpDown();
            label6 = new Label();
            CountStepsForAnalize_NumericUpDown = new NumericUpDown();
            label5 = new Label();
            EndAccuracyForAnalize_NumericUpDown = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            StartAccuracyForAnalize_NumericUpDown = new NumericUpDown();
            StartAnalize_Button = new Button();
            Paint_Panel = new Panel();
            flowLayoutPanel1.SuspendLayout();
            StartSettings_GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CountSteps_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Accuracy_NumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EndPointY_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndPointX_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartPointY_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartPointX_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CountStepsForAnalize_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndAccuracyForAnalize_NumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartAccuracyForAnalize_NumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Start_Button
            // 
            Start_Button.Location = new Point(9, 104);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new Size(94, 29);
            Start_Button.TabIndex = 0;
            Start_Button.Text = "Start";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += Start_Button_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(StartSettings_GroupBox);
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(225, 450);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // StartSettings_GroupBox
            // 
            StartSettings_GroupBox.Controls.Add(CountSteps_NumericUpDown);
            StartSettings_GroupBox.Controls.Add(label2);
            StartSettings_GroupBox.Controls.Add(label1);
            StartSettings_GroupBox.Controls.Add(Accuracy_NumericUpDown);
            StartSettings_GroupBox.Controls.Add(Start_Button);
            StartSettings_GroupBox.Dock = DockStyle.Top;
            StartSettings_GroupBox.Location = new Point(3, 3);
            StartSettings_GroupBox.Name = "StartSettings_GroupBox";
            StartSettings_GroupBox.Size = new Size(215, 155);
            StartSettings_GroupBox.TabIndex = 5;
            StartSettings_GroupBox.TabStop = false;
            StartSettings_GroupBox.Text = "Start Settings";
            // 
            // CountSteps_NumericUpDown
            // 
            CountSteps_NumericUpDown.Location = new Point(112, 64);
            CountSteps_NumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CountSteps_NumericUpDown.Name = "CountSteps_NumericUpDown";
            CountSteps_NumericUpDown.Size = new Size(85, 27);
            CountSteps_NumericUpDown.TabIndex = 4;
            CountSteps_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 64);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 3;
            label2.Text = "Count steps";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 28);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 2;
            label1.Text = "Accuracy";
            // 
            // Accuracy_NumericUpDown
            // 
            Accuracy_NumericUpDown.Location = new Point(112, 28);
            Accuracy_NumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Accuracy_NumericUpDown.Name = "Accuracy_NumericUpDown";
            Accuracy_NumericUpDown.Size = new Size(85, 27);
            Accuracy_NumericUpDown.TabIndex = 1;
            Accuracy_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(EndPointY_NumericUpDown);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(EndPointX_NumericUpDown);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(StartPointY_NumericUpDown);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(StartPointX_NumericUpDown);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(CountStepsForAnalize_NumericUpDown);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(EndAccuracyForAnalize_NumericUpDown);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(StartAccuracyForAnalize_NumericUpDown);
            groupBox1.Controls.Add(StartAnalize_Button);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 164);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(215, 286);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Analize Settings";
            // 
            // EndPointY_NumericUpDown
            // 
            EndPointY_NumericUpDown.Location = new Point(112, 229);
            EndPointY_NumericUpDown.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            EndPointY_NumericUpDown.Minimum = new decimal(new int[] { 2000000000, 0, 0, int.MinValue });
            EndPointY_NumericUpDown.Name = "EndPointY_NumericUpDown";
            EndPointY_NumericUpDown.Size = new Size(85, 27);
            EndPointY_NumericUpDown.TabIndex = 14;
            EndPointY_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 229);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 13;
            label8.Text = "End Point Y";
            // 
            // EndPointX_NumericUpDown
            // 
            EndPointX_NumericUpDown.Location = new Point(112, 196);
            EndPointX_NumericUpDown.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            EndPointX_NumericUpDown.Minimum = new decimal(new int[] { 2000000000, 0, 0, int.MinValue });
            EndPointX_NumericUpDown.Name = "EndPointX_NumericUpDown";
            EndPointX_NumericUpDown.Size = new Size(85, 27);
            EndPointX_NumericUpDown.TabIndex = 12;
            EndPointX_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 196);
            label9.Name = "label9";
            label9.Size = new Size(84, 20);
            label9.TabIndex = 11;
            label9.Text = "End Point X";
            // 
            // StartPointY_NumericUpDown
            // 
            StartPointY_NumericUpDown.Location = new Point(112, 163);
            StartPointY_NumericUpDown.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            StartPointY_NumericUpDown.Minimum = new decimal(new int[] { 2000000000, 0, 0, int.MinValue });
            StartPointY_NumericUpDown.Name = "StartPointY_NumericUpDown";
            StartPointY_NumericUpDown.Size = new Size(85, 27);
            StartPointY_NumericUpDown.TabIndex = 10;
            StartPointY_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 163);
            label7.Name = "label7";
            label7.Size = new Size(89, 20);
            label7.TabIndex = 9;
            label7.Text = "Start Point Y";
            // 
            // StartPointX_NumericUpDown
            // 
            StartPointX_NumericUpDown.Location = new Point(112, 130);
            StartPointX_NumericUpDown.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            StartPointX_NumericUpDown.Minimum = new decimal(new int[] { 2000000000, 0, 0, int.MinValue });
            StartPointX_NumericUpDown.Name = "StartPointX_NumericUpDown";
            StartPointX_NumericUpDown.Size = new Size(85, 27);
            StartPointX_NumericUpDown.TabIndex = 8;
            StartPointX_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 130);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 7;
            label6.Text = "Start Point X";
            // 
            // CountStepsForAnalize_NumericUpDown
            // 
            CountStepsForAnalize_NumericUpDown.Location = new Point(112, 97);
            CountStepsForAnalize_NumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CountStepsForAnalize_NumericUpDown.Name = "CountStepsForAnalize_NumericUpDown";
            CountStepsForAnalize_NumericUpDown.Size = new Size(85, 27);
            CountStepsForAnalize_NumericUpDown.TabIndex = 6;
            CountStepsForAnalize_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 97);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 5;
            label5.Text = "Count steps";
            // 
            // EndAccuracyForAnalize_NumericUpDown
            // 
            EndAccuracyForAnalize_NumericUpDown.Location = new Point(112, 64);
            EndAccuracyForAnalize_NumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            EndAccuracyForAnalize_NumericUpDown.Name = "EndAccuracyForAnalize_NumericUpDown";
            EndAccuracyForAnalize_NumericUpDown.Size = new Size(85, 27);
            EndAccuracyForAnalize_NumericUpDown.TabIndex = 4;
            EndAccuracyForAnalize_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 66);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 3;
            label3.Text = "End accuracy";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 31);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 2;
            label4.Text = "Start accuracy";
            // 
            // StartAccuracyForAnalize_NumericUpDown
            // 
            StartAccuracyForAnalize_NumericUpDown.Location = new Point(112, 31);
            StartAccuracyForAnalize_NumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            StartAccuracyForAnalize_NumericUpDown.Name = "StartAccuracyForAnalize_NumericUpDown";
            StartAccuracyForAnalize_NumericUpDown.Size = new Size(85, 27);
            StartAccuracyForAnalize_NumericUpDown.TabIndex = 1;
            StartAccuracyForAnalize_NumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // StartAnalize_Button
            // 
            StartAnalize_Button.Location = new Point(6, 257);
            StartAnalize_Button.Name = "StartAnalize_Button";
            StartAnalize_Button.Size = new Size(94, 29);
            StartAnalize_Button.TabIndex = 0;
            StartAnalize_Button.Text = "Start";
            StartAnalize_Button.UseVisualStyleBackColor = true;
            StartAnalize_Button.Click += StartAnalize_Button_Click;
            // 
            // Paint_Panel
            // 
            Paint_Panel.Dock = DockStyle.Fill;
            Paint_Panel.Location = new Point(225, 0);
            Paint_Panel.Name = "Paint_Panel";
            Paint_Panel.Size = new Size(575, 450);
            Paint_Panel.TabIndex = 5;
            Paint_Panel.Paint += Paint_Panel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Paint_Panel);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            StartSettings_GroupBox.ResumeLayout(false);
            StartSettings_GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CountSteps_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Accuracy_NumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EndPointY_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndPointX_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartPointY_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartPointX_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CountStepsForAnalize_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndAccuracyForAnalize_NumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartAccuracyForAnalize_NumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button Start_Button;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button Analize_Button;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox StartSettings_GroupBox;
        private NumericUpDown CountSteps_NumericUpDown;
        private Label label2;
        private Label label1;
        private NumericUpDown Accuracy_NumericUpDown;
        private GroupBox groupBox1;
        private NumericUpDown EndAccuracyForAnalize_NumericUpDown;
        private Label label3;
        private Label label4;
        private NumericUpDown StartAccuracyForAnalize_NumericUpDown;
        private Button StartAnalize_Button;
        private NumericUpDown CountStepsForAnalize_NumericUpDown;
        private Label label5;
        private Panel Paint_Panel;
        private NumericUpDown StartPointY_NumericUpDown;
        private Label label7;
        private NumericUpDown StartPointX_NumericUpDown;
        private Label label6;
        private NumericUpDown EndPointY_NumericUpDown;
        private Label label8;
        private NumericUpDown EndPointX_NumericUpDown;
        private Label label9;
    }
}