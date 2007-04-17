namespace Timer
{
    partial class TimerSmall
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
            this.timeDisplay = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timeDisplay
            // 
            this.timeDisplay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.timeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDisplay.Location = new System.Drawing.Point(17, 3);
            this.timeDisplay.Multiline = true;
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.ReadOnly = true;
            this.timeDisplay.ShortcutsEnabled = false;
            this.timeDisplay.Size = new System.Drawing.Size(174, 20);
            this.timeDisplay.TabIndex = 0;
            this.timeDisplay.TabStop = false;
            this.timeDisplay.WordWrap = false;
            this.timeDisplay.DoubleClick += new System.EventHandler(this.timeDisplay_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Timer.Properties.Resources.grips;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 26);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.timeDisplay_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimerSmall_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimerSmall_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimerSmall_MouseUp);
            // 
            // TimerSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(194, 26);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.timeDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimerSmall";
            this.Text = "TimerSmall";
            this.TopMost = true;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TimerSmall_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimerSmall_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimerSmall_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox timeDisplay;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}