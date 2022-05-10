
namespace PointMovement
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.y2 = new System.Windows.Forms.TextBox();
      this.x2 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.lineCalculationRB = new System.Windows.Forms.RadioButton();
      this.AngleRB = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.Precision = new System.Windows.Forms.TextBox();
      this.Value = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // y2
      // 
      this.y2.Location = new System.Drawing.Point(99, 50);
      this.y2.Name = "y2";
      this.y2.Size = new System.Drawing.Size(100, 22);
      this.y2.TabIndex = 1;
      this.y2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.y2_KeyPress);
      // 
      // x2
      // 
      this.x2.Location = new System.Drawing.Point(99, 14);
      this.x2.Name = "x2";
      this.x2.Size = new System.Drawing.Size(100, 22);
      this.x2.TabIndex = 2;
      this.x2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.x2_KeyPress);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Location = new System.Drawing.Point(27, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "X2 =";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Location = new System.Drawing.Point(27, 53);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(41, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Y2 = ";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(205, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(114, 55);
      this.button1.TabIndex = 8;
      this.button1.Text = "Start!";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // lineCalculationRB
      // 
      this.lineCalculationRB.AutoSize = true;
      this.lineCalculationRB.BackColor = System.Drawing.Color.Transparent;
      this.lineCalculationRB.Checked = true;
      this.lineCalculationRB.Location = new System.Drawing.Point(325, 15);
      this.lineCalculationRB.Name = "lineCalculationRB";
      this.lineCalculationRB.Size = new System.Drawing.Size(115, 21);
      this.lineCalculationRB.TabIndex = 9;
      this.lineCalculationRB.TabStop = true;
      this.lineCalculationRB.Text = "Line equation";
      this.lineCalculationRB.UseVisualStyleBackColor = false;
      // 
      // AngleRB
      // 
      this.AngleRB.AutoSize = true;
      this.AngleRB.BackColor = System.Drawing.Color.Transparent;
      this.AngleRB.Location = new System.Drawing.Point(325, 49);
      this.AngleRB.Name = "AngleRB";
      this.AngleRB.Size = new System.Drawing.Size(97, 21);
      this.AngleRB.TabIndex = 10;
      this.AngleRB.Text = "With Angle";
      this.AngleRB.UseVisualStyleBackColor = false;
      this.AngleRB.CheckedChanged += new System.EventHandler(this.AngleRB_CheckedChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Location = new System.Drawing.Point(27, 95);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 17);
      this.label1.TabIndex = 11;
      this.label1.Text = "N =";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Location = new System.Drawing.Point(27, 131);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 17);
      this.label2.TabIndex = 12;
      this.label2.Text = "Precision";
      // 
      // Precision
      // 
      this.Precision.Location = new System.Drawing.Point(99, 92);
      this.Precision.Name = "Precision";
      this.Precision.Size = new System.Drawing.Size(100, 22);
      this.Precision.TabIndex = 13;
      this.Precision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Precision_KeyPress);
      // 
      // Value
      // 
      this.Value.Location = new System.Drawing.Point(99, 128);
      this.Value.Name = "Value";
      this.Value.Size = new System.Drawing.Size(100, 22);
      this.Value.TabIndex = 14;
      this.Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Value_KeyPress);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.Value);
      this.Controls.Add(this.Precision);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.AngleRB);
      this.Controls.Add(this.lineCalculationRB);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.x2);
      this.Controls.Add(this.y2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "MainForm";
      this.Text = "Point Movement";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox y2;
    private System.Windows.Forms.TextBox x2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.RadioButton lineCalculationRB;
    private System.Windows.Forms.RadioButton AngleRB;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox Precision;
    private System.Windows.Forms.TextBox Value;
  }
}

