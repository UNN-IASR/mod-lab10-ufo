namespace winUfo
{
    partial class MainForm
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
            fieldBox = new PictureBox();
            Timer = new System.Windows.Forms.Timer(components);
            formsPlot = new ScottPlot.WinForms.FormsPlot();
            labelStart = new Label();
            entryStart = new TextBox();
            labelEnd = new Label();
            entryEnd = new TextBox();
            runButton = new Button();
            ((System.ComponentModel.ISupportInitialize)fieldBox).BeginInit();
            SuspendLayout();
            // 
            // fieldBox
            // 
            fieldBox.Location = new Point(12, 12);
            fieldBox.Name = "fieldBox";
            fieldBox.Size = new Size(810, 597);
            fieldBox.TabIndex = 0;
            fieldBox.TabStop = false;
            fieldBox.Paint += fieldBox_Paint;
            // 
            // Timer
            // 
            Timer.Interval = 20;
            Timer.Tick += Timer_Tick;
            // 
            // formsPlot
            // 
            formsPlot.DisplayScale = 1F;
            formsPlot.Location = new Point(828, 12);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(431, 311);
            formsPlot.TabIndex = 1;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Location = new Point(864, 326);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(31, 15);
            labelStart.TabIndex = 2;
            labelStart.Text = "Start";
            // 
            // entryStart
            // 
            entryStart.Location = new Point(901, 323);
            entryStart.Name = "entryStart";
            entryStart.Size = new Size(100, 23);
            entryStart.TabIndex = 3;
            // 
            // labelEnd
            // 
            labelEnd.AutoSize = true;
            labelEnd.Location = new Point(864, 354);
            labelEnd.Name = "labelEnd";
            labelEnd.Size = new Size(27, 15);
            labelEnd.TabIndex = 4;
            labelEnd.Text = "End";
            // 
            // entryEnd
            // 
            entryEnd.Location = new Point(901, 352);
            entryEnd.Name = "entryEnd";
            entryEnd.Size = new Size(100, 23);
            entryEnd.TabIndex = 5;
            // 
            // runButton
            // 
            runButton.Location = new Point(901, 381);
            runButton.Name = "runButton";
            runButton.Size = new Size(75, 23);
            runButton.TabIndex = 6;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 621);
            Controls.Add(runButton);
            Controls.Add(entryEnd);
            Controls.Add(labelEnd);
            Controls.Add(entryStart);
            Controls.Add(labelStart);
            Controls.Add(formsPlot);
            Controls.Add(fieldBox);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "winUfo";
            ((System.ComponentModel.ISupportInitialize)fieldBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox fieldBox;
        private System.Windows.Forms.Timer Timer;
        private ScottPlot.WinForms.FormsPlot formsPlot;
        private Label labelStart;
        private TextBox entryStart;
        private Label labelEnd;
        private TextBox entryEnd;
        private Button runButton;
    }
}
