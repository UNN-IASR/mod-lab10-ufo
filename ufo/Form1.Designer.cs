namespace ufo
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
            start_button = new Button();
            stop_button = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // start_button
            // 
            start_button.Location = new Point(570, 527);
            start_button.Name = "start_button";
            start_button.Size = new Size(75, 23);
            start_button.TabIndex = 0;
            start_button.Text = "start";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += start_button_Click;
            // 
            // stop_button
            // 
            stop_button.Location = new Point(651, 527);
            stop_button.Name = "stop_button";
            stop_button.Size = new Size(75, 23);
            stop_button.TabIndex = 2;
            stop_button.Text = "clear";
            stop_button.UseVisualStyleBackColor = true;
            stop_button.Click += stop_button_Click;
            // 
            // button1
            // 
            button1.Location = new Point(489, 527);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "plot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(button1);
            Controls.Add(stop_button);
            Controls.Add(start_button);
            Name = "Form1";
            Text = "Form1";
            MouseUp += Form1_MouseUp;
            ResumeLayout(false);
        }

        #endregion

        private Button start_button;
        private Button stop_button;
        private Button button1;
    }
}
