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
            this.timerLog = new System.Windows.Forms.DataGridView();
            this.startColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.functionalityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remindRightClick = new System.Windows.Forms.ToolTip(this.components);
            this.simpleTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beepAtMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.every5MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.every10MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.every15MinutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.everyHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerLog)).BeginInit();
            this.contextMenu.SuspendLayout();
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
            this.timeDisplay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.timeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDisplay.Location = new System.Drawing.Point(12, 12);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.ReadOnly = true;
            this.timeDisplay.Size = new System.Drawing.Size(285, 41);
            this.timeDisplay.TabIndex = 0;
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
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionalityToolStripMenuItem,
            this.simpleTimerToolStripMenuItem,
            this.countdownToolStripMenuItem,
            this.toolStripSeparator2,
            this.preferencesToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.transparencyToolStripMenuItem,
            this.beepAtMeToolStripMenuItem,
            this.toolStripSeparator1,
            this.extraToolStripMenuItem,
            this.aboutTimerToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(201, 236);
            this.contextMenu.Text = "Timer Preferences";
            // 
            // functionalityToolStripMenuItem
            // 
            this.functionalityToolStripMenuItem.Enabled = false;
            this.functionalityToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.functionalityToolStripMenuItem.Name = "functionalityToolStripMenuItem";
            this.functionalityToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.functionalityToolStripMenuItem.Text = "Functions";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Enabled = false;
            this.preferencesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.Enabled = false;
            this.extraToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // remindRightClick
            // 
            this.remindRightClick.AutoPopDelay = 5000;
            this.remindRightClick.InitialDelay = 300;
            this.remindRightClick.IsBalloon = true;
            this.remindRightClick.ReshowDelay = 200;
            this.remindRightClick.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.remindRightClick.ToolTipTitle = "More Options for Timer";
            // 
            // simpleTimerToolStripMenuItem
            // 
            this.simpleTimerToolStripMenuItem.Image = global::Timer.Properties.Resources.clock_red;
            this.simpleTimerToolStripMenuItem.Name = "simpleTimerToolStripMenuItem";
            this.simpleTimerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.simpleTimerToolStripMenuItem.Text = "Stopwatch (default)";
            this.simpleTimerToolStripMenuItem.Click += new System.EventHandler(this.simpleTimerToolStripMenuItem_Click);
            // 
            // countdownToolStripMenuItem
            // 
            this.countdownToolStripMenuItem.Image = global::Timer.Properties.Resources.clock;
            this.countdownToolStripMenuItem.Name = "countdownToolStripMenuItem";
            this.countdownToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.countdownToolStripMenuItem.Text = "Countdown...";
            this.countdownToolStripMenuItem.Click += new System.EventHandler(this.countdownToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::Timer.Properties.Resources.text_replace;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.ShortcutKeyDisplayString = "Crtl+Alt+Sace";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.Image = global::Timer.Properties.Resources.contrast;
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.transparencyToolStripMenuItem.Text = "Transparency...";
            this.transparencyToolStripMenuItem.Click += new System.EventHandler(this.transparancyToolStripMenuItem_Click);
            // 
            // beepAtMeToolStripMenuItem
            // 
            this.beepAtMeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.every5MinutesToolStripMenuItem,
            this.every10MinutesToolStripMenuItem,
            this.every15MinutesToolStripMenuItem,
            this.everyHourToolStripMenuItem});
            this.beepAtMeToolStripMenuItem.Image = global::Timer.Properties.Resources.bell;
            this.beepAtMeToolStripMenuItem.Name = "beepAtMeToolStripMenuItem";
            this.beepAtMeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.beepAtMeToolStripMenuItem.Text = "Beep At Me";
            // 
            // every5MinutesToolStripMenuItem
            // 
            this.every5MinutesToolStripMenuItem.Name = "every5MinutesToolStripMenuItem";
            this.every5MinutesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.every5MinutesToolStripMenuItem.Tag = "5";
            this.every5MinutesToolStripMenuItem.Text = "Every 5 Minutes";
            this.every5MinutesToolStripMenuItem.Click += new System.EventHandler(this.beepMenuItem_Click);
            // 
            // every10MinutesToolStripMenuItem
            // 
            this.every10MinutesToolStripMenuItem.Name = "every10MinutesToolStripMenuItem";
            this.every10MinutesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.every10MinutesToolStripMenuItem.Tag = "10";
            this.every10MinutesToolStripMenuItem.Text = "Every 10 Minutes";
            this.every10MinutesToolStripMenuItem.Click += new System.EventHandler(this.beepMenuItem_Click);
            // 
            // every15MinutesToolStripMenuItem
            // 
            this.every15MinutesToolStripMenuItem.Name = "every15MinutesToolStripMenuItem";
            this.every15MinutesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.every15MinutesToolStripMenuItem.Tag = "30";
            this.every15MinutesToolStripMenuItem.Text = "Every 30 Minutes";
            this.every15MinutesToolStripMenuItem.Click += new System.EventHandler(this.beepMenuItem_Click);
            // 
            // everyHourToolStripMenuItem
            // 
            this.everyHourToolStripMenuItem.Name = "everyHourToolStripMenuItem";
            this.everyHourToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.everyHourToolStripMenuItem.Tag = "60";
            this.everyHourToolStripMenuItem.Text = "Every Hour";
            this.everyHourToolStripMenuItem.Click += new System.EventHandler(this.beepMenuItem_Click);
            // 
            // aboutTimerToolStripMenuItem
            // 
            this.aboutTimerToolStripMenuItem.Image = global::Timer.Properties.Resources.information;
            this.aboutTimerToolStripMenuItem.Name = "aboutTimerToolStripMenuItem";
            this.aboutTimerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.aboutTimerToolStripMenuItem.Text = "About Timer";
            this.aboutTimerToolStripMenuItem.Click += new System.EventHandler(this.aboutTimerToolStripMenuItem_Click);
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
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(309, 116);
            this.ContextMenuStrip = this.contextMenu;
            this.ControlBox = false;
            this.Controls.Add(this.showLog);
            this.Controls.Add(this.timerLog);
            this.Controls.Add(this.timeDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Timer";
            this.Opacity = 0.95;
            this.Text = "Timer";
            this.remindRightClick.SetToolTip(this, "To see more options for Timer right-click anywhere on this window.");
            ((System.ComponentModel.ISupportInitialize)(this.timerLog)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TextBox timeDisplay;
        private System.Windows.Forms.DataGridView timerLog;
        private System.Windows.Forms.Button showLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn startColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem beepAtMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem every5MinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem every10MinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem every15MinutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem everyHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutTimerToolStripMenuItem;
        private System.Windows.Forms.ToolTip remindRightClick;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem functionalityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleTimerToolStripMenuItem;
    }
}

