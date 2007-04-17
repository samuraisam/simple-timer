using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    /// <summary>
    /// Smaller version of the main timer window. Simply provides a readout,
    /// a drag handle (for movement) and the contextual menu.
    /// </summary>
    public partial class TimerSmall : TimerChild
    {
        private Point MousePoint;
        private bool MouseIsDown = false;

        /// <summary>
        /// Constructs a new TimerSmall and copies all the important stuff from parent
        /// </summary>
        /// <param name="timer">The timer this window is started from.</param>
        public TimerSmall(Timer timer)
            : base(timer)
        {
            this.ParentTimer.timeDisplay.TextChanged +=new EventHandler(this.timerMain_Tick);
            // copy all the important stuff from ParentTimer
            this.Text = this.ParentTimer.Text;
            this.Icon = this.ParentTimer.Icon;
            this.Location = this.ParentTimer.Location;

            this.MousePoint = new Point();
            InitializeComponent();
        }

        /// <summary>
        /// Simply update display
        /// </summary>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            this.timeDisplay.Text = ((TextBox)sender).Text;
        }

        /// <summary>
        /// Go back to the big window
        /// </summary>
        private void timeDisplay_DoubleClick(object sender, EventArgs e)
        {
            this.ParentTimer.GoBig();
        }
        
        /// <summary>
        /// Record the current mouse position and set MouseIsDown to true
        /// </summary>
        private void TimerSmall_MouseDown(object sender, MouseEventArgs e)
        {
            this.MousePoint.X = e.X;
            this.MousePoint.Y = e.Y;
            this.MouseIsDown = true;
        }

        /// <summary>
        /// Set MouseIsDown to false
        /// </summary>
        private void TimerSmall_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseIsDown = false;
        }

        /// <summary>
        /// If mouse is down move the small window.
        /// </summary>
        private void TimerSmall_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseIsDown)
            {
                Point currentPosition = Control.MousePosition;
                currentPosition.X = currentPosition.X - this.MousePoint.X;
                currentPosition.Y = currentPosition.Y - this.MousePoint.Y;
                this.Location = currentPosition;
            }
        }
    }
}