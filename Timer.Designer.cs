namespace Timer
{
    partial class Timer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timer));
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.timeDisplay = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.timerLog = new System.Windows.Forms.DataGridView();
            this.showLog = new System.Windows.Forms.Button();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.timerLog)).BeginInit();
            this.SuspendLayout();
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 50;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // timeDisplay
            // 
            this.timeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDisplay.Location = new System.Drawing.Point(12, 12);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.ReadOnly = true;
            this.timeDisplay.Size = new System.Drawing.Size(285, 41);
            this.timeDisplay.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(12, 59);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(91, 38);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.resetButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.resetButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(109, 59);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(55, 38);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(250, 59);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(47, 38);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.renameButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.renameButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.renameButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.renameButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.renameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renameButton.Location = new System.Drawing.Point(170, 59);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(74, 38);
            this.renameButton.TabIndex = 4;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = false;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // timerLog
            // 
            this.timerLog.AllowUserToAddRows = false;
            this.timerLog.AllowUserToDeleteRows = false;
            this.timerLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.timerLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timerLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startColumn,
            this.stopColumn,
            this.timeColumn});
            this.timerLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.timerLog.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.timerLog.Location = new System.Drawing.Point(13, 126);
            this.timerLog.Name = "timerLog";
            this.timerLog.ReadOnly = true;
            this.timerLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.timerLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.timerLog.ShowEditingIcon = false;
            this.timerLog.ShowRowErrors = false;
            this.timerLog.Size = new System.Drawing.Size(284, 138);
            this.timerLog.TabIndex = 5;
            // 
            // showLog
            // 
            this.showLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.showLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showLog.FlatAppearance.BorderSize = 0;
            this.showLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showLog.Image = global::Timer.Properties.Resources.showLogDown;
            this.showLog.Location = new System.Drawing.Point(0, 102);
            this.showLog.Name = "showLog";
            this.showLog.Size = new System.Drawing.Size(309, 15);
            this.showLog.TabIndex = 6;
            this.showLog.UseVisualStyleBackColor = false;
            this.showLog.Click += new System.EventHandler(this.showLog_Click);
            // 
            // startColumn
            // 
            this.startColumn.HeaderText = "Start";
            this.startColumn.Name = "startColumn";
            this.startColumn.ReadOnly = true;
            this.startColumn.Width = 80;
            // 
            // stopColumn
            // 
            this.stopColumn.HeaderText = "Stop";
            this.stopColumn.Name = "stopColumn";
            this.stopColumn.ReadOnly = true;
            this.stopColumn.Width = 80;
            // 
            // timeColumn
            // 
            this.timeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeColumn.HeaderText = "Time";
            this.timeColumn.Name = "timeColumn";
            this.timeColumn.ReadOnly = true;
            // 
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(309, 116);
            this.ControlBox = false;
            this.Controls.Add(this.showLog);
            this.Controls.Add(this.timerLog);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.timeDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Timer";
            this.Opacity = 0.95;
            this.Text = "Timer";
            ((System.ComponentModel.ISupportInitialize)(this.timerLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TextBox timeDisplay;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.DataGridView timerLog;
        private System.Windows.Forms.Button showLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColumn;
    }
}

