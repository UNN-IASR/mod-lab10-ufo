namespace lab10
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
            Timer = new System.Windows.Forms.Timer(components);
            RootWrapper = new SplitContainer();
            SimulationPanel = new Panel();
            AsidePanel = new TableLayoutPanel();
            ParametersGroupBox = new GroupBox();
            ParametersLayoutWrapper = new TableLayoutPanel();
            StartPointCoordinatesWrapper = new GroupBox();
            StartPointCoordinatesLayoutWrapper = new TableLayoutPanel();
            StartPointXInput = new NumericUpDown();
            StartPointYInput = new NumericUpDown();
            EndPointCoordinatesWrapper = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            EndPointXInput = new NumericUpDown();
            EndPointYInput = new NumericUpDown();
            OtherParamsWrapper = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            EpsilonInput = new NumericUpDown();
            PrecisionInput = new NumericUpDown();
            StepInput = new NumericUpDown();
            ControlsGroupBox = new GroupBox();
            ControlsWrapper = new TableLayoutPanel();
            StartSimulationButton = new Button();
            StartAnalysisButton = new Button();
            StopButton = new Button();
            ((System.ComponentModel.ISupportInitialize)RootWrapper).BeginInit();
            RootWrapper.Panel1.SuspendLayout();
            RootWrapper.Panel2.SuspendLayout();
            RootWrapper.SuspendLayout();
            AsidePanel.SuspendLayout();
            ParametersGroupBox.SuspendLayout();
            ParametersLayoutWrapper.SuspendLayout();
            StartPointCoordinatesWrapper.SuspendLayout();
            StartPointCoordinatesLayoutWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StartPointXInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartPointYInput).BeginInit();
            EndPointCoordinatesWrapper.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EndPointXInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndPointYInput).BeginInit();
            OtherParamsWrapper.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EpsilonInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PrecisionInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StepInput).BeginInit();
            ControlsGroupBox.SuspendLayout();
            ControlsWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // Timer
            // 
            Timer.Interval = 50;
            Timer.Tick += Timer_Tick;
            // 
            // RootWrapper
            // 
            RootWrapper.Dock = DockStyle.Fill;
            RootWrapper.FixedPanel = FixedPanel.Panel2;
            RootWrapper.IsSplitterFixed = true;
            RootWrapper.Location = new Point(0, 0);
            RootWrapper.Name = "RootWrapper";
            // 
            // RootWrapper.Panel1
            // 
            RootWrapper.Panel1.Controls.Add(SimulationPanel);
            // 
            // RootWrapper.Panel2
            // 
            RootWrapper.Panel2.Controls.Add(AsidePanel);
            RootWrapper.Size = new Size(984, 471);
            RootWrapper.SplitterDistance = 734;
            RootWrapper.TabIndex = 0;
            // 
            // SimulationPanel
            // 
            SimulationPanel.Dock = DockStyle.Fill;
            SimulationPanel.Location = new Point(0, 0);
            SimulationPanel.Name = "SimulationPanel";
            SimulationPanel.Size = new Size(734, 471);
            SimulationPanel.TabIndex = 0;
            SimulationPanel.Paint += SimulationPanel_Paint;
            // 
            // AsidePanel
            // 
            AsidePanel.ColumnCount = 1;
            AsidePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            AsidePanel.Controls.Add(ParametersGroupBox, 0, 0);
            AsidePanel.Controls.Add(ControlsGroupBox, 0, 1);
            AsidePanel.Dock = DockStyle.Fill;
            AsidePanel.Location = new Point(0, 0);
            AsidePanel.Name = "AsidePanel";
            AsidePanel.RowCount = 2;
            AsidePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            AsidePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            AsidePanel.Size = new Size(246, 471);
            AsidePanel.TabIndex = 0;
            // 
            // ParametersGroupBox
            // 
            ParametersGroupBox.Controls.Add(ParametersLayoutWrapper);
            ParametersGroupBox.Dock = DockStyle.Fill;
            ParametersGroupBox.Location = new Point(3, 3);
            ParametersGroupBox.Name = "ParametersGroupBox";
            ParametersGroupBox.Size = new Size(240, 276);
            ParametersGroupBox.TabIndex = 0;
            ParametersGroupBox.TabStop = false;
            ParametersGroupBox.Text = "Параметры";
            // 
            // ParametersLayoutWrapper
            // 
            ParametersLayoutWrapper.ColumnCount = 1;
            ParametersLayoutWrapper.ColumnStyles.Add(new ColumnStyle());
            ParametersLayoutWrapper.Controls.Add(StartPointCoordinatesWrapper, 0, 0);
            ParametersLayoutWrapper.Controls.Add(EndPointCoordinatesWrapper, 0, 1);
            ParametersLayoutWrapper.Controls.Add(OtherParamsWrapper, 0, 2);
            ParametersLayoutWrapper.Dock = DockStyle.Fill;
            ParametersLayoutWrapper.Location = new Point(3, 19);
            ParametersLayoutWrapper.Name = "ParametersLayoutWrapper";
            ParametersLayoutWrapper.RowCount = 3;
            ParametersLayoutWrapper.RowStyles.Add(new RowStyle());
            ParametersLayoutWrapper.RowStyles.Add(new RowStyle());
            ParametersLayoutWrapper.RowStyles.Add(new RowStyle());
            ParametersLayoutWrapper.Size = new Size(234, 254);
            ParametersLayoutWrapper.TabIndex = 0;
            // 
            // StartPointCoordinatesWrapper
            // 
            StartPointCoordinatesWrapper.Controls.Add(StartPointCoordinatesLayoutWrapper);
            StartPointCoordinatesWrapper.Dock = DockStyle.Top;
            StartPointCoordinatesWrapper.Location = new Point(3, 3);
            StartPointCoordinatesWrapper.Name = "StartPointCoordinatesWrapper";
            StartPointCoordinatesWrapper.Size = new Size(228, 57);
            StartPointCoordinatesWrapper.TabIndex = 0;
            StartPointCoordinatesWrapper.TabStop = false;
            StartPointCoordinatesWrapper.Text = "Начальная точка";
            // 
            // StartPointCoordinatesLayoutWrapper
            // 
            StartPointCoordinatesLayoutWrapper.ColumnCount = 2;
            StartPointCoordinatesLayoutWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            StartPointCoordinatesLayoutWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            StartPointCoordinatesLayoutWrapper.Controls.Add(StartPointXInput, 0, 0);
            StartPointCoordinatesLayoutWrapper.Controls.Add(StartPointYInput, 1, 0);
            StartPointCoordinatesLayoutWrapper.Dock = DockStyle.Fill;
            StartPointCoordinatesLayoutWrapper.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            StartPointCoordinatesLayoutWrapper.Location = new Point(3, 19);
            StartPointCoordinatesLayoutWrapper.Name = "StartPointCoordinatesLayoutWrapper";
            StartPointCoordinatesLayoutWrapper.RowCount = 1;
            StartPointCoordinatesLayoutWrapper.RowStyles.Add(new RowStyle());
            StartPointCoordinatesLayoutWrapper.Size = new Size(222, 35);
            StartPointCoordinatesLayoutWrapper.TabIndex = 0;
            // 
            // StartPointXInput
            // 
            StartPointXInput.Dock = DockStyle.Top;
            StartPointXInput.Location = new Point(3, 3);
            StartPointXInput.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            StartPointXInput.Name = "StartPointXInput";
            StartPointXInput.Size = new Size(105, 23);
            StartPointXInput.TabIndex = 0;
            StartPointXInput.ValueChanged += StartPointXInput_ValueChanged;
            // 
            // StartPointYInput
            // 
            StartPointYInput.Dock = DockStyle.Top;
            StartPointYInput.Location = new Point(114, 3);
            StartPointYInput.Maximum = new decimal(new int[] { 230, 0, 0, 0 });
            StartPointYInput.Name = "StartPointYInput";
            StartPointYInput.Size = new Size(105, 23);
            StartPointYInput.TabIndex = 1;
            StartPointYInput.ValueChanged += StartPointYInput_ValueChanged;
            // 
            // EndPointCoordinatesWrapper
            // 
            EndPointCoordinatesWrapper.Controls.Add(tableLayoutPanel3);
            EndPointCoordinatesWrapper.Dock = DockStyle.Top;
            EndPointCoordinatesWrapper.Location = new Point(3, 66);
            EndPointCoordinatesWrapper.Name = "EndPointCoordinatesWrapper";
            EndPointCoordinatesWrapper.Size = new Size(228, 55);
            EndPointCoordinatesWrapper.TabIndex = 1;
            EndPointCoordinatesWrapper.TabStop = false;
            EndPointCoordinatesWrapper.Text = "Конечная точка";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(EndPointXInput, 0, 0);
            tableLayoutPanel3.Controls.Add(EndPointYInput, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(222, 33);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // EndPointXInput
            // 
            EndPointXInput.Dock = DockStyle.Top;
            EndPointXInput.Location = new Point(3, 3);
            EndPointXInput.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            EndPointXInput.Name = "EndPointXInput";
            EndPointXInput.Size = new Size(105, 23);
            EndPointXInput.TabIndex = 0;
            EndPointXInput.ValueChanged += EndPointXInput_ValueChanged;
            // 
            // EndPointYInput
            // 
            EndPointYInput.Dock = DockStyle.Top;
            EndPointYInput.Location = new Point(114, 3);
            EndPointYInput.Maximum = new decimal(new int[] { 230, 0, 0, 0 });
            EndPointYInput.Name = "EndPointYInput";
            EndPointYInput.Size = new Size(105, 23);
            EndPointYInput.TabIndex = 1;
            EndPointYInput.ValueChanged += EndPointYInput_ValueChanged;
            // 
            // OtherParamsWrapper
            // 
            OtherParamsWrapper.Controls.Add(tableLayoutPanel4);
            OtherParamsWrapper.Dock = DockStyle.Fill;
            OtherParamsWrapper.Location = new Point(3, 127);
            OtherParamsWrapper.Name = "OtherParamsWrapper";
            OtherParamsWrapper.Size = new Size(228, 124);
            OtherParamsWrapper.TabIndex = 2;
            OtherParamsWrapper.TabStop = false;
            OtherParamsWrapper.Text = "Другое";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(EpsilonInput, 0, 0);
            tableLayoutPanel4.Controls.Add(PrecisionInput, 0, 1);
            tableLayoutPanel4.Controls.Add(StepInput, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 19);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(222, 102);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // EpsilonInput
            // 
            EpsilonInput.DecimalPlaces = 2;
            EpsilonInput.Dock = DockStyle.Top;
            EpsilonInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            EpsilonInput.Location = new Point(3, 3);
            EpsilonInput.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            EpsilonInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            EpsilonInput.Name = "EpsilonInput";
            EpsilonInput.Size = new Size(216, 23);
            EpsilonInput.TabIndex = 0;
            EpsilonInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            EpsilonInput.ValueChanged += EpsilonInput_ValueChanged;
            // 
            // PrecisionInput
            // 
            PrecisionInput.Dock = DockStyle.Top;
            PrecisionInput.Location = new Point(3, 32);
            PrecisionInput.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            PrecisionInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PrecisionInput.Name = "PrecisionInput";
            PrecisionInput.Size = new Size(216, 23);
            PrecisionInput.TabIndex = 1;
            PrecisionInput.Tag = "";
            PrecisionInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            PrecisionInput.ValueChanged += PrecisionInput_ValueChanged;
            // 
            // StepInput
            // 
            StepInput.DecimalPlaces = 2;
            StepInput.Dock = DockStyle.Top;
            StepInput.Location = new Point(3, 61);
            StepInput.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            StepInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            StepInput.Name = "StepInput";
            StepInput.Size = new Size(216, 23);
            StepInput.TabIndex = 2;
            StepInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            StepInput.ValueChanged += StepInput_ValueChanged;
            // 
            // ControlsGroupBox
            // 
            ControlsGroupBox.Controls.Add(ControlsWrapper);
            ControlsGroupBox.Dock = DockStyle.Fill;
            ControlsGroupBox.Location = new Point(3, 285);
            ControlsGroupBox.Name = "ControlsGroupBox";
            ControlsGroupBox.Size = new Size(240, 183);
            ControlsGroupBox.TabIndex = 1;
            ControlsGroupBox.TabStop = false;
            ControlsGroupBox.Text = "Управление";
            // 
            // ControlsWrapper
            // 
            ControlsWrapper.ColumnCount = 1;
            ControlsWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsWrapper.Controls.Add(StartSimulationButton, 0, 0);
            ControlsWrapper.Controls.Add(StartAnalysisButton, 0, 1);
            ControlsWrapper.Controls.Add(StopButton, 0, 2);
            ControlsWrapper.Dock = DockStyle.Fill;
            ControlsWrapper.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            ControlsWrapper.Location = new Point(3, 19);
            ControlsWrapper.Name = "ControlsWrapper";
            ControlsWrapper.RowCount = 3;
            ControlsWrapper.RowStyles.Add(new RowStyle());
            ControlsWrapper.RowStyles.Add(new RowStyle());
            ControlsWrapper.RowStyles.Add(new RowStyle());
            ControlsWrapper.Size = new Size(234, 161);
            ControlsWrapper.TabIndex = 0;
            // 
            // StartSimulationButton
            // 
            StartSimulationButton.Dock = DockStyle.Top;
            StartSimulationButton.Location = new Point(3, 3);
            StartSimulationButton.Name = "StartSimulationButton";
            StartSimulationButton.Size = new Size(228, 23);
            StartSimulationButton.TabIndex = 0;
            StartSimulationButton.Text = "Запустить симуляцию";
            StartSimulationButton.UseVisualStyleBackColor = true;
            StartSimulationButton.Click += StartSimulationButton_Click;
            // 
            // StartAnalysisButton
            // 
            StartAnalysisButton.Dock = DockStyle.Top;
            StartAnalysisButton.Location = new Point(3, 32);
            StartAnalysisButton.Name = "StartAnalysisButton";
            StartAnalysisButton.Size = new Size(228, 23);
            StartAnalysisButton.TabIndex = 1;
            StartAnalysisButton.Text = "Запустить анализ";
            StartAnalysisButton.UseVisualStyleBackColor = true;
            StartAnalysisButton.Click += StartAnalysisButton_Click;
            // 
            // StopButton
            // 
            StopButton.Dock = DockStyle.Top;
            StopButton.Location = new Point(3, 61);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(228, 23);
            StopButton.TabIndex = 2;
            StopButton.Text = "Остановить";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 471);
            Controls.Add(RootWrapper);
            MaximumSize = new Size(1000, 510);
            MinimumSize = new Size(1000, 510);
            Name = "MainForm";
            Text = "MainForm";
            RootWrapper.Panel1.ResumeLayout(false);
            RootWrapper.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RootWrapper).EndInit();
            RootWrapper.ResumeLayout(false);
            AsidePanel.ResumeLayout(false);
            ParametersGroupBox.ResumeLayout(false);
            ParametersLayoutWrapper.ResumeLayout(false);
            StartPointCoordinatesWrapper.ResumeLayout(false);
            StartPointCoordinatesLayoutWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StartPointXInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartPointYInput).EndInit();
            EndPointCoordinatesWrapper.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EndPointXInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndPointYInput).EndInit();
            OtherParamsWrapper.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EpsilonInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)PrecisionInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)StepInput).EndInit();
            ControlsGroupBox.ResumeLayout(false);
            ControlsWrapper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private SplitContainer RootWrapper;
        private TableLayoutPanel AsidePanel;
        private GroupBox ParametersGroupBox;
        private GroupBox ControlsGroupBox;
        private TableLayoutPanel ControlsWrapper;
        private Button StartSimulationButton;
        private Button StartAnalysisButton;
        private Button StopButton;
        private TableLayoutPanel ParametersLayoutWrapper;
        private GroupBox StartPointCoordinatesWrapper;
        private GroupBox EndPointCoordinatesWrapper;
        private TableLayoutPanel StartPointCoordinatesLayoutWrapper;
        private GroupBox OtherParamsWrapper;
        private NumericUpDown StartPointXInput;
        private NumericUpDown StartPointYInput;
        private TableLayoutPanel tableLayoutPanel3;
        private NumericUpDown EndPointXInput;
        private NumericUpDown EndPointYInput;
        private TableLayoutPanel tableLayoutPanel4;
        private NumericUpDown EpsilonInput;
        private NumericUpDown PrecisionInput;
        private NumericUpDown StepInput;
        private Panel SimulationPanel;
    }
}