using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    /// <summary>
    /// Child windows of timer should have most of the same properties.
    /// This class merely expedites that process by setting up several properties
    /// and hooking the opacity changing of ParentTimer to automatically change
    /// child classes' opacity.
    /// </summary>
    public abstract class TimerChild : Form
    {
        /// <summary>
        /// The Timer this child should be hooked to.
        /// </summary>
        protected Timer ParentTimer;

        /// <summary>
        /// Constructs a new TimerChild object.
        /// </summary>
        /// <param name="timer">The Timer this child should be hooked to.</param>
        public TimerChild(Timer timer)
        {
            this.ParentTimer = timer;
            this.Opacity = timer.Opacity;
            this.TopMost = timer.TopMost;
            this.ContextMenuStrip = timer.contextMenu;
            this.Icon = timer.Icon;
            timer.OpacityChanged += new OpacityChangeHandler(this.timerMain_OpacityChanged);
        }

        /// <summary>
        /// Set opacity to that of ParentTimer
        /// </summary>
        protected void timerMain_OpacityChanged(object sender, EventArgs e)
        {
            try
            {   // wtf??
                this.Opacity = this.ParentTimer.Opacity;
            }
            catch (Exception) { }
        }
    }
}
